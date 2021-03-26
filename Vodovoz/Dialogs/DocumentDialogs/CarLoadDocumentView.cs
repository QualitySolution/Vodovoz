﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gamma.GtkWidgets;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QSOrmProject;
using Vodovoz.Domain.Documents;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories.Logistic;
using Vodovoz.EntityRepositories.Subdivisions;
using Vodovoz.Infrastructure.Converters;

namespace Vodovoz
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class CarLoadDocumentView : QS.Dialog.Gtk.WidgetOnDialogBase
	{
		public CarLoadDocumentView()
		{
			this.Build();

			ytreeviewItems.ColumnsConfig = ColumnsConfigFactory.Create<CarLoadDocumentItem>()
				.AddColumn("Номенклатура").AddTextRenderer(x => (x.ExpireDatePercent != null) ? x.Nomenclature.Name + " >" + x.ExpireDatePercent + "% срока годности" : x.Nomenclature.Name)
				.AddColumn("Принадлежность").AddEnumRenderer(x => x.OwnType, true, new Enum[] { OwnTypes.None })
				.AddColumn("С/Н оборудования").AddTextRenderer(x => x.Equipment != null ? x.Equipment.Serial : String.Empty)
				.AddColumn("Кол-во на складе").AddTextRenderer(x => x.Nomenclature.Unit.MakeAmountShortStr(x.AmountInStock))
				.AddColumn("В маршрутнике").AddTextRenderer(x => x.Nomenclature.Unit.MakeAmountShortStr(x.AmountInRouteList))
				.AddColumn("В других отгрузках").AddTextRenderer(x => x.Nomenclature.Unit.MakeAmountShortStr(x.AmountLoaded))
				.AddColumn("Отгружаемое кол-во").AddNumericRenderer(x => x.Amount ).Editing()
				// .AddColumn("Отгружаемое кол-во").AddNumericRenderer(x => x.Nomenclature.OfficialName != "Терминал для оплаты"? x.Amount : x.Amount >= 1? 1 : 0).Editing()
				.Adjustment(new Gtk.Adjustment(0, 0, 10000000, 1, 10, 10))
				.AddSetter((w, x) => w.Digits = (uint)x.Nomenclature.Unit.Digits)
				.AddSetter((w, x) => w.Foreground = CalculateAmountAndColor(x))
				.AddColumn("")
				.Finish();

			ytreeviewItems.Selection.Changed += YtreeviewItems_Selection_Changed;

		}

		public void FillItemsByWarehouse()
		{
			if(buttonFillWarehouseItems.Sensitive)
				buttonFillWarehouseItems.Click();
		}

		public void SetButtonEditing(bool isEditing)
		{
			buttonFillAllItems.Sensitive = buttonFillWarehouseItems.Sensitive = isEditing;
		}

		void YtreeviewItems_Selection_Changed(object sender, EventArgs e)
		{
			var selected = ytreeviewItems.GetSelectedObject<CarLoadDocumentItem>();
			buttonDelete.Sensitive = (selected != null && buttonFillAllItems.Sensitive == true);
		}

		private IUnitOfWorkGeneric<CarLoadDocument> documentUoW;

		public IUnitOfWorkGeneric<CarLoadDocument> DocumentUoW {
			get { return documentUoW; }
			set {
				if(documentUoW == value)
					return;
				documentUoW = value;
				if(DocumentUoW.Root.Items == null)
					DocumentUoW.Root.Items = new List<CarLoadDocumentItem>();

				ytreeviewItems.ItemsDataSource = DocumentUoW.Root.ObservableItems;
				DocumentUoW.Root.PropertyChanged += DocumentUoW_Root_PropertyChanged;
				UpdateButtonState();
			}
		}

		void UpdateButtonState()
		{
			bool routeExist = DocumentUoW.Root.RouteList != null;
			bool warehouseExist = DocumentUoW.Root.Warehouse != null;
			buttonFillAllItems.Sensitive = routeExist;
			buttonFillWarehouseItems.Sensitive = routeExist && warehouseExist;
		}

		void DocumentUoW_Root_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			UpdateButtonState();
		}

		string CalculateAmountAndColor(CarLoadDocumentItem item)
		{
			if (item.Nomenclature.OfficialName == "Терминал для оплаты" && item.Amount > 1)
				item.Amount = Decimal.One;
			if(item.Amount > item.AmountInStock)
				return "red";
			if(item.Equipment == null) {
				if(item.AmountInRouteList < item.AmountLoaded + item.Amount)
					return "orange";
				if(item.AmountInRouteList == item.AmountLoaded + item.Amount)
					return "green";
				if(item.AmountInRouteList > item.AmountLoaded + item.Amount)
					return "blue";
			} else {
				if(1 < item.AmountLoaded + item.Amount)
					return "orange";
				if(1 == item.AmountLoaded + item.Amount)
					return "green";
				if(1 > item.AmountLoaded + item.Amount)
					return "blue";
			}
			return "black";
		}

		protected void OnButtonDeleteClicked(object sender, EventArgs e)
		{
			DocumentUoW.Root.ObservableItems.Remove(ytreeviewItems.GetSelectedObject<CarLoadDocumentItem>());
		}

		protected void OnButtonFillWarehouseItemsClicked(object sender, EventArgs e)
		{
			if(DocumentUoW.Root.Items.Any() && !MessageDialogHelper.RunQuestionDialog("Список будет очищен. Продолжить?"))
				return;

			DocumentUoW.Root.FillFromRouteList(DocumentUoW, new RouteListRepository(), new SubdivisionRepository(), true);
			DocumentUoW.Root.UpdateAlreadyLoaded(DocumentUoW, new RouteListRepository());
			if(DocumentUoW.Root.Warehouse != null) {
				DocumentUoW.Root.UpdateStockAmount(DocumentUoW);
				UpdateAmounts();
			}
		}

		protected void OnButtonFillAllItemsClicked(object sender, EventArgs e)
		{
			if(DocumentUoW.Root.Items.Any() && !MessageDialogHelper.RunQuestionDialog("Список будет очищен. Продолжить?"))
				return;
			DocumentUoW.Root.FillFromRouteList(DocumentUoW, new RouteListRepository(), null, false);

			var items = DocumentUoW.Root.Items;
			string errorNomenclatures = string.Empty;
			foreach(var item in items) {
				if(item.Nomenclature.Unit == null)
					errorNomenclatures += string.Format("{0} код {1}{2}",
						item.Nomenclature.Name, item.Nomenclature.Id, Environment.NewLine);
			}
			if(!string.IsNullOrEmpty(errorNomenclatures)) {
				errorNomenclatures = "Не указаны единицы измерения для следующих номенклатур:"
					+ Environment.NewLine + errorNomenclatures;
				MessageDialogHelper.RunErrorDialog(errorNomenclatures);
				DocumentUoW.Root.Items.Clear();
				return;
			}

			DocumentUoW.Root.UpdateAlreadyLoaded(DocumentUoW, new RouteListRepository());
			if(DocumentUoW.Root.Warehouse != null) {
				DocumentUoW.Root.UpdateStockAmount(DocumentUoW);
				UpdateAmounts();
			}
		}

		public void UpdateAmounts()
		{
			foreach(var item in DocumentUoW.Root.Items) {
				item.Amount = item.AmountInRouteList - item.AmountLoaded;
				if(item.Amount > item.AmountInStock)
					item.Amount = item.AmountInStock;
			}
		}
	}
}