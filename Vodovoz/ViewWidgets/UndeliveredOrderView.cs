﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gamma.GtkWidgets;
using QS.Dialog.Gtk;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QS.Project.Dialogs;
using QS.Project.Dialogs.GtkUI;
using QS.Project.Services;
using QS.Services;
using QSProjectsLib;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories.Logistic;
using Vodovoz.Repositories.HumanResources;
using Vodovoz.Repositories.Orders;
using Vodovoz.Repository;
using Vodovoz.ViewModel;

namespace Vodovoz.ViewWidgets
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class UndeliveredOrderView : WidgetOnDialogBase
	{
		Order newOrder = null;
		Order oldOrder = null;
		bool routeListDoesNotExist = false;
		string InitialProcDepartmentName = String.Empty;
		IList<GuiltyInUndelivery> initialGuiltyList = new List<GuiltyInUndelivery>();
		UndeliveredOrder undelivery;
		ICommonServices commonServices = ServicesConfig.CommonServices;
		bool CanChangeProblemSource = false;

		public Func<bool> isSaved;
		public IUnitOfWork UoW { get; set; }
		public UndeliveredOrderView() => this.Build();

		public void OnTabAdded()
		{
			//если новый недовоз без выбранного недовезённого заказа
			if(UoW.IsNew && undelivery.OldOrder == null)
				//открыть окно выбора недовезённого заказа
				yEForUndeliveredOrder.OpenSelectDialog("Выбор недовезённого заказа");
		}

		public void ConfigureDlg(IUnitOfWork uow, UndeliveredOrder undelivery)
		{
			this.Sensitive = false;
			yEForUndeliveredOrder.Changed += OnUndeliveredOrderChanged;

			CanChangeProblemSource = commonServices.PermissionService.ValidateUserPresetPermission("can_change_undelivery_problem_source", commonServices.UserService.CurrentUserId);
			this.undelivery = undelivery;
			UoW = uow;
			oldOrder = undelivery.OldOrder;
			newOrder = undelivery.NewOrder;
			if(undelivery.Id > 0 && undelivery.InProcessAtDepartment != null)
				InitialProcDepartmentName = undelivery.InProcessAtDepartment.Name;
			if(undelivery.Id > 0){
				foreach(GuiltyInUndelivery g in undelivery.ObservableGuilty) {
					initialGuiltyList.Add(
						new GuiltyInUndelivery {
							Id = g.Id,
							UndeliveredOrder = g.UndeliveredOrder,
							GuiltySide = g.GuiltySide,
							GuiltyDepartment = g.GuiltyDepartment
						}
					);
				}
			}
			var filterOrders = new OrdersFilter(UoW);
			List<OrderStatus> hiddenStatusesList = new List<OrderStatus>();
			var grantedStatusesArray = OrderRepository.GetStatusesForOrderCancelation();
			foreach(OrderStatus status in Enum.GetValues(typeof(OrderStatus))) {
				if(!grantedStatusesArray.Contains(status))
					hiddenStatusesList.Add(status);
			}
			filterOrders.SetAndRefilterAtOnce(x => x.HideStatuses = hiddenStatusesList.Cast<Enum>().ToArray());
			yEForUndeliveredOrder.Changed += (sender, e) => {
				oldOrder = undelivery.OldOrder;
				lblInfo.Markup = undelivery.GetOldOrderInfo();
				if(undelivery.Id <= 0)
					undelivery.OldOrderStatus = oldOrder.OrderStatus;
				routeListDoesNotExist = oldOrder != null && (undelivery.OldOrderStatus == OrderStatus.NewOrder
													   || undelivery.OldOrderStatus == OrderStatus.Accepted
													   || undelivery.OldOrderStatus == OrderStatus.WaitForPayment);

				guiltyInUndeliveryView.ConfigureWidget(UoW, undelivery, !routeListDoesNotExist);
				SetSensitivities();
				SetVisibilities();
				GetFines();
				RemoveItemsFromEnums();
			};
			yEForUndeliveredOrder.RepresentationModel = new OrdersVM(filterOrders);
			yEForUndeliveredOrder.Binding.AddBinding(undelivery, x => x.OldOrder, x => x.Subject).InitializeFromSource();
			yEForUndeliveredOrder.CanEditReference = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_delete");

			yDateDriverCallTime.Binding.AddBinding(undelivery, t => t.DriverCallTime, w => w.DateOrNull).InitializeFromSource();
			if(undelivery.Id <= 0)
				yDateDriverCallTime.DateOrNull = DateTime.Now;

			yEnumCMBDriverCallPlace.ItemsEnum = typeof(DriverCallType);
			yEnumCMBDriverCallPlace.Binding.AddBinding(undelivery, p => p.DriverCallType, w => w.SelectedItem).InitializeFromSource();

			yDateDispatcherCallTime.Binding.AddBinding(undelivery, t => t.DispatcherCallTime, w => w.DateOrNull).InitializeFromSource();
			if(undelivery.Id <= 0)
				yDateDispatcherCallTime.DateOrNull = DateTime.Now;

			referenceNewDeliverySchedule.ItemsQuery = DeliveryScheduleRepository.AllQuery();
			referenceNewDeliverySchedule.SetObjectDisplayFunc<DeliverySchedule>(e => e.Name);
			referenceNewDeliverySchedule.Binding.AddBinding(undelivery, s => s.NewDeliverySchedule, w => w.Subject).InitializeFromSource();
			referenceNewDeliverySchedule.Sensitive = false;

			SetLabelsAcordingToNewOrder();

			yEnumCMBStatus.ItemsEnum = typeof(UndeliveryStatus);
			yEnumCMBStatus.SelectedItem = undelivery.UndeliveryStatus;
			yEnumCMBStatus.EnumItemSelected += (s, e) => {
				SetSensitivities();
				undelivery.SetUndeliveryStatus((UndeliveryStatus)e.SelectedItem);
			};

			yentInProcessAtDepartment.SubjectType = typeof(Subdivision);
			yentInProcessAtDepartment.Binding.AddBinding(undelivery, d => d.InProcessAtDepartment, w => w.Subject).InitializeFromSource();
			yentInProcessAtDepartment.ChangedByUser += (s, e) => {
				undelivery.AddCommentToTheField(
					UoW, 
					CommentedFields.Reason, 
					String.Format(
						"сменил(а) \"в работе у отдела\" \nс \"{0}\" на \"{1}\"",
						InitialProcDepartmentName,
						undelivery.InProcessAtDepartment.Name
					)
				);
			};

			if(undelivery.Id <= 0)
				yentInProcessAtDepartment.Subject = SubdivisionsRepository.GetQCDepartment(UoW);

			refRegisteredBy.RepresentationModel = new EmployeesVM(UoW);
			refRegisteredBy.Binding.AddBinding(undelivery, s => s.EmployeeRegistrator, w => w.Subject).InitializeFromSource();

			yEnumCMBDriverCallPlace.EnumItemSelected += CMBSelectedItemChanged;

			txtReason.Binding.AddBinding(undelivery, u => u.Reason, w => w.Buffer.Text).InitializeFromSource();

			lblInfo.Markup = undelivery.GetOldOrderInfo();

			yenumcomboboxTransferType.ItemsEnum = typeof(TransferType);
			yenumcomboboxTransferType.Binding.AddBinding(undelivery, u => u.OrderTransferType, w => w.SelectedItemOrNull).InitializeFromSource();

			comboProblemSource.SetRenderTextFunc<UndeliveryProblemSource>(k => k.GetFullName);
			comboProblemSource.Binding.AddBinding(undelivery, u => u.ProblemSourceItems, w => w.ItemsList).InitializeFromSource();
			comboProblemSource.Binding.AddBinding(undelivery, u => u.ProblemSource, w => w.SelectedItem).InitializeFromSource();
			comboProblemSource.Sensitive = CanChangeProblemSource;

			yTreeFines.ColumnsConfig = ColumnsConfigFactory.Create<FineItem>()
				.AddColumn("Номер").AddTextRenderer(node => node.Fine.Id.ToString())
				.AddColumn("Сотудники").AddTextRenderer(node => node.Employee.ShortName)
				.AddColumn("Сумма штрафа").AddTextRenderer(node => CurrencyWorks.GetShortCurrencyString(node.Money))
				.Finish();

			yenumcomboboxTransferType.Visible = undelivery?.NewOrder != null;

			undelivery.PropertyChanged += (sender, e) => {
				if(e.PropertyName != "NewOrder")
					return;

				if(undelivery.NewOrder == null) {
					yenumcomboboxTransferType.Visible = false;
					undelivery.OrderTransferType = null;
					return;
				}

				yenumcomboboxTransferType.Visible = true;
			};

			GetFines();
			SetVisibilities();
			SetSensitivities();
		}

        private void OnUndeliveredOrderChanged(object sender, EventArgs e)
        {
			this.Sensitive = true;
		}

        void GetFines()
		{
			List<FineItem> fineItems = new List<FineItem>();
			foreach(Fine f in undelivery.Fines)
				foreach(FineItem i in f.Items)
					fineItems.Add(i);
			yTreeFines.ItemsDataSource = fineItems;
		}

		private void SetLabelsAcordingToNewOrder()
		{
			lblTransferDate.Text = undelivery.NewOrder == null ?
				"Заказ не\nсоздан" :
				undelivery.NewOrder.Title + " на сумму " + String.Format(CurrencyWorks.GetShortCurrencyString(undelivery.NewOrder.TotalSum));
			btnNewOrder.Label = undelivery.NewOrder == null ? "Создать новый заказ" : "Открыть заказ";

			SetVisibilities();
		}

		void RemoveItemsFromEnums()
		{
			//удаляем статус "закрыт" из списка, если недовоз не закрыт и нет прав на их закрытие
			if(!ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_close_undeliveries") && undelivery.UndeliveryStatus != UndeliveryStatus.Closed) {
				yEnumCMBStatus.AddEnumToHideList(new Enum[] { UndeliveryStatus.Closed });
				yEnumCMBStatus.SelectedItem = (UndeliveryStatus)undelivery.UndeliveryStatus;
			}
		}

		void SetVisibilities()
		{
			lblDriverCallPlace.Visible = yEnumCMBDriverCallPlace.Visible = !routeListDoesNotExist;
			lblDriverCallTime.Visible = yDateDriverCallTime.Visible = undelivery.DriverCallType != DriverCallType.NoCall;
			btnChooseOrder.Visible = undelivery.NewOrder == null;
			lblTransferDate.Visible = undelivery.NewOrder != null;
		}

		void SetSensitivities()
		{
			bool hasPermissionOrNew = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_edit_undeliveries") || undelivery.Id == 0;

			//основные поля доступны если есть разрешение или это новый недовоз,
			//выбран старый заказ и статус недовоза не "Закрыт"
			yEnumCMBDriverCallPlace.Sensitive =
				yDateDriverCallTime.Sensitive =
					yDateDispatcherCallTime.Sensitive =
						refRegisteredBy.Sensitive =
							vbxReasonAndFines.Sensitive = (
								undelivery.OldOrder != null
								&& hasPermissionOrNew
								&& undelivery.UndeliveryStatus != UndeliveryStatus.Closed
							);

			//выбор старого заказа доступен, если есть разрешение или это новый недовоз и не выбран старый заказ
			hbxUndelivery.Sensitive = undelivery.OldOrder == null && hasPermissionOrNew;

			//можем менять статус, если есть права или нет прав и статус не "закрыт"
			hbxStatus.Sensitive = (
				(
					ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_close_undeliveries")
					|| undelivery.UndeliveryStatus != UndeliveryStatus.Closed
				)
				&& undelivery.OldOrder != null
			);

			//кнопки для выбора/создания нового заказа и группа "В работе у отдела"
			//доступны всегда, если статус недовоза не "Закрыт"
			guiltyInUndeliveryView.Sensitive = 
				hbxInProcessAtDepartment.Sensitive =
					hbxForNewOrder.Sensitive = undelivery.UndeliveryStatus != UndeliveryStatus.Closed;
		}

		void AddAutocomment()
		{
			#region удаление дублей из спсика виновных
			IList<GuiltyInUndelivery> guiltyTempList = new List<GuiltyInUndelivery>();
			foreach(GuiltyInUndelivery g in undelivery.ObservableGuilty)
				guiltyTempList.Add(g);
			undelivery.ObservableGuilty.Clear();
			foreach(GuiltyInUndelivery g in guiltyTempList.Distinct())
				undelivery.ObservableGuilty.Add(g);
			#endregion

			#region формирование и добавление автокомментарния об изменении списка виновных
			if(undelivery.Id > 0) {
				IList<GuiltyInUndelivery> removedGuiltyList = new List<GuiltyInUndelivery>();
				IList<GuiltyInUndelivery> addedGuiltyList = new List<GuiltyInUndelivery>();
				IList<GuiltyInUndelivery> toRemoveFromBoth = new List<GuiltyInUndelivery>();
				foreach(GuiltyInUndelivery r in initialGuiltyList)
					removedGuiltyList.Add(r);
				foreach(GuiltyInUndelivery a in undelivery.ObservableGuilty)
					addedGuiltyList.Add(a);
				foreach(GuiltyInUndelivery gu in addedGuiltyList) {
					foreach(var g in removedGuiltyList)
						if(gu == g)
							toRemoveFromBoth.Add(g);
				}
				foreach(var r in toRemoveFromBoth) {
					addedGuiltyList.Remove(r);
					removedGuiltyList.Remove(r);
				}
				StringBuilder sb = new StringBuilder();
				if(addedGuiltyList.Any()) {
					sb.AppendLine("добавил(а) виновных:");
					foreach(var a in addedGuiltyList)
						sb.AppendLine(String.Format("\t- {0}", a));
				}
				if(removedGuiltyList.Any()) {
					sb.AppendLine("удалил(а) виновных:");
					foreach(var r in removedGuiltyList)
						sb.AppendLine(String.Format("\t- {0}", r));
				}
				string text = sb.ToString().Trim();
				if(sb.Length > 0)
					undelivery.AddCommentToTheField(UoW, CommentedFields.Reason, text);
			}
			#endregion
		}

		public void BeforeSaving()
		{
			AddAutocomment();
			undelivery.LastEditor = EmployeeRepository.GetEmployeeForCurrentUser(UoW);
			undelivery.LastEditedTime = DateTime.Now;
			if(undelivery.DriverCallType == DriverCallType.NoCall) {
				undelivery.DriverCallTime = null;
				undelivery.DriverCallNr = null;
			}
		}

		protected void CMBSelectedItemChanged(object sender, Gamma.Widgets.ItemSelectedEventArgs e)
		{
			SetVisibilities();
		}

		protected void OnBtnNewOrderClicked(object sender, EventArgs e)
		{
			if(undelivery.NewOrder == null) {
				CreateNewOrder(oldOrder);
			} else {
				OpenOrder(newOrder);
			}
		}

		protected void OnBtnChooseOrderClicked(object sender, EventArgs e)
		{
			var filter = new OrdersFilter(UnitOfWorkFactory.CreateWithoutRoot());
			filter.SetAndRefilterAtOnce(
				x => x.RestrictCounterparty = oldOrder.Client,
				x => x.HideStatuses = new Enum[] { OrderStatus.WaitForPayment }
			);
			Buttons buttons = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_delete") ? Buttons.All : (Buttons.Add | Buttons.Edit);
			PermissionControlledRepresentationJournal dlg = new PermissionControlledRepresentationJournal(new OrdersVM(filter), buttons) {
				Mode = JournalSelectMode.Single
			};

			MyTab.TabParent.AddTab(dlg, MyTab, false);

			dlg.ObjectSelected += (s, ea) => {
				var selectedId = ea.GetSelectedIds().FirstOrDefault();
				if(selectedId == 0) {
					return;
				}
				if(oldOrder.Id == selectedId) {
					MessageDialogHelper.RunErrorDialog("Перенесённый заказ не может совпадать с недовезённым!");
					OnBtnChooseOrderClicked(sender, ea);
					return;
				}
				newOrder = undelivery.NewOrder = UoW.GetById<Order>(selectedId);
				newOrder.Author = this.oldOrder.Author;
				SetLabelsAcordingToNewOrder();
				undelivery.NewDeliverySchedule = newOrder.DeliverySchedule;
				if ((oldOrder.PaymentType == Domain.Client.PaymentType.ByCard) && 
					(oldOrder.OrderTotalSum == newOrder.OrderTotalSum) &&
					MessageDialogHelper.RunQuestionDialog("Перенести на выбранный заказ Оплату по Карте?")){
					newOrder.PaymentType = oldOrder.PaymentType;
					newOrder.OnlineOrder = oldOrder.OnlineOrder;
					newOrder.PaymentByCardFrom = oldOrder.PaymentByCardFrom;
				}
			};
		}

		/// <summary>
		/// Создаёт новый заказ, копируя поля существующего.
		/// </summary>
		/// <param name="order">Заказ, из которого копируются свойства.</param>
		void CreateNewOrder(Order order)
		{
			var dlg = new OrderDlg(UoW);
			dlg.CopyOrderFrom(order.Id);
			MyTab.TabParent.AddSlaveTab(MyTab, dlg);

			dlg.TabClosed += (sender, e) => {
				if(sender is OrderDlg) {
					Order o = (sender as OrderDlg).Entity;
					if(o.Id > 0) {
						newOrder = undelivery.NewOrder = o;
						SetLabelsAcordingToNewOrder();
						undelivery.NewDeliverySchedule = newOrder.DeliverySchedule;
					}
				}
			};
		}

		/// <summary>
		/// Открытие существующего заказа
		/// </summary>
		/// <param name="order">Заказ, который требуется открыть</param>
		void OpenOrder(Order order)
		{
			if(MessageDialogHelper.RunQuestionDialog("Требуется сохранить недовоз. Сохранить?")) {
				UoW.Save(undelivery);
				var dlg = new OrderDlg(order);
				MyTab.TabParent.OpenTab(
					DialogHelper.GenerateDialogHashName<Order>(order.Id),
					() => dlg
				);
			}
		}

		protected void OnYEnumCMBDriverCallPlaceEnumItemSelected(object sender, Gamma.Widgets.ItemSelectedEventArgs e)
		{
			var listDriverCallType = UoW.Session.QueryOver<UndeliveredOrder>()
							.Where(x => x.Id == undelivery.Id)
							.Select(x => x.DriverCallType).List<DriverCallType>().FirstOrDefault();

			if(listDriverCallType != (DriverCallType)yEnumCMBDriverCallPlace.SelectedItem) {
				var max = UoW.Session.QueryOver<UndeliveredOrder>().Select(NHibernate.Criterion.Projections.Max<UndeliveredOrder>(x => x.DriverCallNr)).SingleOrDefault<int>();
				if(max != 0)
					undelivery.DriverCallNr = max + 1;
				else
					undelivery.DriverCallNr = 1;
			}
		}

		protected void OnButtonAddFineClicked(object sender, EventArgs e)
		{
			if(undelivery.Id == 0) {
				if(QSOrmProject.CommonDialogs.SaveBeforeCreateSlaveEntity(undelivery.GetType(), typeof(Fine))) {
					var saved = isSaved?.Invoke();
					if(!saved.HasValue || !saved.Value)
						return;
				} else
					return;
			}
			
			FineDlg fineDlg;
			using(IUnitOfWork uow = UnitOfWorkFactory.CreateWithoutRoot()) {
				fineDlg = new FineDlg(uow.GetById<UndeliveredOrder>(undelivery.Id));
			}
			
			MyTab.TabParent.OpenTab(
				DialogHelper.GenerateDialogHashName<Fine>(undelivery.Id),
				() => fineDlg
			);

			var address = new RouteListItemRepository().GetRouteListItemForOrder(UoW, undelivery.OldOrder);

			if (address != null)
				fineDlg.Entity.AddAddress(address);
			
			fineDlg.EntitySaved += (object sender2, QS.Tdi.EntitySavedEventArgs args) => { 
				undelivery.Fines.Add(args.Entity as Fine);

				GetFines(); 
			};
		}
	}
}