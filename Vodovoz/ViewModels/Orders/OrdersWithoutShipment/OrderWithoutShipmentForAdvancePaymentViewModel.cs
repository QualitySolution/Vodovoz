﻿using System;
using System.Linq;
using Gamma.Utilities;
using QS.Commands;
using QS.Dialog;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QS.Navigation;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Project.Services;
using QS.Services;
using QS.Tdi;
using QS.ViewModels;
using QSOrmProject;
using QSReport;
using Vodovoz.Dialogs.Email;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Orders.OrdersWithoutShipment;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.FilterViewModels.Goods;
using Vodovoz.Infrastructure.Services;
using Vodovoz.JournalViewModels;

namespace Vodovoz.ViewModels.Orders.OrdersWithoutShipment
{
	public class OrderWithoutShipmentForAdvancePaymentViewModel : EntityTabViewModelBase<OrderWithoutShipmentForAdvancePayment>, ITdiTabAddedNotifier
	{
		private readonly IEmployeeService employeeService;
		private readonly IEntityAutocompleteSelectorFactory nomenclatureSelectorFactory;
		private readonly IEntityAutocompleteSelectorFactory counterpartySelectorFactory;
		private readonly INomenclatureRepository nomenclatureRepository;
		private readonly IUserRepository userRepository;
		
		private object selectedItem;
		public object SelectedItem {
			get => selectedItem;
			set => SetField(ref selectedItem, value);
		}
		
		public SendDocumentByEmailViewModel SendDocViewModel { get; set; }
		
		public bool IsDocumentSent => Entity.IsBillWithoutShipmentSent;
		
		public Action<string> OpenCounterpartyJournal;
		public IEntityUoWBuilder EntityUoWBuilder { get; }

		public OrderWithoutShipmentForAdvancePaymentViewModel(
			IEntityUoWBuilder uowBuilder,
			IUnitOfWorkFactory uowFactory,
			ICommonServices commonServices,
			IEmployeeService employeeService,
			IEntityAutocompleteSelectorFactory nomenclatureSelectorFactory,
			IEntityAutocompleteSelectorFactory counterpartySelectorFactory,
			INomenclatureRepository nomenclatureRepository,
			IUserRepository userRepository) : base(uowBuilder, uowFactory, commonServices)
		{
			this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
			this.nomenclatureRepository = nomenclatureRepository ?? throw new ArgumentNullException(nameof(nomenclatureRepository));
			this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
			this.nomenclatureSelectorFactory = nomenclatureSelectorFactory ?? throw new ArgumentNullException(nameof(nomenclatureSelectorFactory));
			this.counterpartySelectorFactory = counterpartySelectorFactory ?? throw new ArgumentNullException(nameof(counterpartySelectorFactory));
			
			bool canCreateBillsWithoutShipment = CommonServices.PermissionService.ValidateUserPresetPermission("can_create_bills_without_shipment", CurrentUser.Id);
			
			if (uowBuilder.IsNewEntity)
			{
				if (canCreateBillsWithoutShipment)
				{
					if (!AskQuestion("Вы действительно хотите создать счет без отгрузки на предоплату?"))
					{
						AbortOpening();
					}
					else
					{
						Entity.Author = EmployeeSingletonRepository.GetInstance().GetEmployeeForCurrentUser(UoW);
					}
				}
				else
				{
					AbortOpening("У Вас нет прав на выставление счетов без отгрузки.");
				}
			}
			
			TabName = "Счет без отгрузки на предоплату";
			EntityUoWBuilder = uowBuilder;
			
			SendDocViewModel = new SendDocumentByEmailViewModel(new EmailRepository(), EmployeeSingletonRepository.GetInstance(), commonServices.InteractiveService, UoW);
		}

		#region Commands

		private DelegateCommand addForSaleCommand;
		public DelegateCommand AddForSaleCommand => addForSaleCommand ?? (addForSaleCommand = new DelegateCommand(
			() => {

				if(!CanAddNomenclaturesToOrder())
					return;

				var defaultCategory = NomenclatureCategory.water;
				if(CurrentUserSettings.Settings.DefaultSaleCategory.HasValue)
					defaultCategory = CurrentUserSettings.Settings.DefaultSaleCategory.Value;

				var nomenclatureFilter = new NomenclatureFilterViewModel();
				nomenclatureFilter.SetAndRefilterAtOnce(
					x => x.AvailableCategories = Nomenclature.GetCategoriesForSaleToOrder(),
					x => x.SelectCategory = defaultCategory,
					x => x.SelectSaleCategory = SaleCategory.forSale,
					x => x.RestrictArchive = false
				);
				var journalActions = new EntitiesJournalActionsViewModel(ServicesConfig.InteractiveService);

				NomenclaturesJournalViewModel journalViewModel = new NomenclaturesJournalViewModel(
					journalActions,
					nomenclatureFilter,
					UnitOfWorkFactory,
					ServicesConfig.CommonServices,
					employeeService,
					nomenclatureSelectorFactory,
					counterpartySelectorFactory,
					nomenclatureRepository,
					userRepository
				) {
					SelectionMode = JournalSelectionMode.Single,
				};
				journalViewModel.AdditionalJournalRestriction = new NomenclaturesForOrderJournalRestriction(ServicesConfig.CommonServices);
				journalViewModel.TabName = "Номенклатура на продажу";
				journalViewModel.OnEntitySelectedResult += (s, ea) => {
					var selectedNode = ea.SelectedNodes.FirstOrDefault();
					if(selectedNode == null)
						return;
					TryAddNomenclature(UoWGeneric.Session.Get<Nomenclature>(selectedNode.Id));
				};
				TabParent.AddSlaveTab(this, journalViewModel);
			},
			() => true
		));

		private DelegateCommand cancelCommand;
		public DelegateCommand CancelCommand => cancelCommand ?? (cancelCommand = new DelegateCommand(
			() =>Close(true, CloseSource.Cancel),
			() => true
		));

		private DelegateCommand deleteItemCommand;
		public DelegateCommand DeleteItemCommand => deleteItemCommand ?? (deleteItemCommand = new DelegateCommand(
			() => {
				var item = SelectedItem as OrderWithoutShipmentForAdvancePaymentItem;
				Entity.RemoveItem(item);
			},
			() => SelectedItem != null
		));

		private DelegateCommand openBillCommand;
		public DelegateCommand OpenBillCommand => openBillCommand ?? (openBillCommand = new DelegateCommand(
			() =>
			{
				string whatToPrint = "документа \"" + Entity.Type.GetEnumTitle() + "\"";
				
				if (UoWGeneric.HasChanges &&
				    CommonDialogs.SaveBeforePrint(typeof(OrderWithoutShipmentForAdvancePayment), whatToPrint))
				{
					if (Save(false))
						TabParent.AddTab(DocumentPrinter.GetPreviewTab(Entity), this, false);
				}

				if(!UoWGeneric.HasChanges && Entity.Id > 0)
					TabParent.AddTab(DocumentPrinter.GetPreviewTab(Entity), this, false);
			},
			() => true
		));
		
		#endregion Commands

		public void OnTabAdded()
		{
			if(EntityUoWBuilder.IsNewEntity)
				OpenCounterpartyJournal?.Invoke(string.Empty);
		}

		bool CanAddNomenclaturesToOrder()
		{
			if(Entity.Client == null) {
				CommonServices.InteractiveService.ShowMessage(ImportanceLevel.Warning,"Для добавления товара на продажу должен быть выбран клиент.");
				return false;
			}

			return true;
		}

		void TryAddNomenclature(Nomenclature nomenclature, int count = 0, decimal discount = 0, DiscountReason discountReason = null)
		{
			if(nomenclature.OnlineStore != null && !ServicesConfig.CommonServices.CurrentPermissionService
				.ValidatePresetPermission("can_add_online_store_nomenclatures_to_order")) {
				MessageDialogHelper.RunWarningDialog("У вас недостаточно прав для добавления на продажу номенклатуры интернет магазина");
				return;
			}

			Entity.AddNomenclature(nomenclature, count, discount, false, discountReason);
		}
		
		public void OnEntityViewModelEntryChanged(object sender, EventArgs e)
		{
			var email = Entity.GetEmailAddressForBill();

			if (email != null)
				SendDocViewModel.Update(Entity, email.Address);
			else
				SendDocViewModel.Update(Entity, string.Empty);
		}
	}
}
