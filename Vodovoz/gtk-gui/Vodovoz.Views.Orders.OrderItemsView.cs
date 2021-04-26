
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Orders
{
	public partial class OrderItemsView
	{
		private global::Gtk.HBox hboxMain;

		private global::Gtk.VBox vboxMain;

		private global::Gamma.GtkWidgets.yLabel ylblGoods;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeViewOrderItems;

		private global::Gtk.HBox hboxBtns;

		private global::Gamma.GtkWidgets.yButton ybtnAddOrderItem;

		private global::QS.Widgets.EnumMenuButton enumAddRentButton;

		private global::QS.Widgets.GtkUI.SpecialListComboBox yCmbPromoSets;

		private global::Gamma.GtkWidgets.yButton ybtnRemoveOrderItem;

		private global::Gtk.HBox hboxDiscount;

		private global::Gtk.Label lblDiscont;

		private global::Gamma.Widgets.ySpecComboBox ycomboboxReason;

		private global::QSOrmProject.EnumListComboBox enumDiscountUnit;

		private global::Gamma.GtkWidgets.ySpinButton yspinBtnDiscount;

		private global::Gtk.HBox hbox5;

		private global::Gamma.GtkWidgets.yLabel ylblBottlesToReturn;

		private global::Gamma.Widgets.yValidatedEntry entryBottlesToReturn;

		private global::Gtk.HBox hboxReturnTareReason;

		private global::Gamma.GtkWidgets.yLabel ylblReturnTareReasonCategory;

		private global::QS.Widgets.GtkUI.SpecialListComboBox yCmbReturnTareReasonCategories;

		private global::Gtk.HBox hboxReasons;

		private global::Gamma.GtkWidgets.yLabel ylblReturnTareReason;

		private global::QS.Widgets.GtkUI.SpecialListComboBox yCmbReturnTareReasons;

		private global::Gtk.HBox hbox6;

		private global::Gamma.GtkWidgets.yCheckButton ychkMovementEquipments;

		private global::Gamma.GtkWidgets.yCheckButton ychkDeposits;

		private global::Gtk.VBox vboxMovementItems;

		private global::Gtk.VBox vboxDeposits;

		private global::Gamma.GtkWidgets.yLabel ylblDeposits;

		private global::Gtk.VSeparator vseparator1;

		private global::Gtk.HBox hboxJournals;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Orders.OrderItemsView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Orders.OrderItemsView";
			// Container child Vodovoz.Views.Orders.OrderItemsView.Gtk.Container+ContainerChild
			this.hboxMain = new global::Gtk.HBox();
			this.hboxMain.Name = "hboxMain";
			this.hboxMain.Spacing = 6;
			// Container child hboxMain.Gtk.Box+BoxChild
			this.vboxMain = new global::Gtk.VBox();
			this.vboxMain.Name = "vboxMain";
			this.vboxMain.Spacing = 6;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.ylblGoods = new global::Gamma.GtkWidgets.yLabel();
			this.ylblGoods.Name = "ylblGoods";
			this.ylblGoods.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Товары</b>");
			this.ylblGoods.UseMarkup = true;
			this.vboxMain.Add(this.ylblGoods);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.ylblGoods]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeViewOrderItems = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeViewOrderItems.CanFocus = true;
			this.ytreeViewOrderItems.Name = "ytreeViewOrderItems";
			this.GtkScrolledWindow.Add(this.ytreeViewOrderItems);
			this.vboxMain.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.GtkScrolledWindow]));
			w3.Position = 1;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.hboxBtns = new global::Gtk.HBox();
			this.hboxBtns.Name = "hboxBtns";
			this.hboxBtns.Spacing = 6;
			// Container child hboxBtns.Gtk.Box+BoxChild
			this.ybtnAddOrderItem = new global::Gamma.GtkWidgets.yButton();
			this.ybtnAddOrderItem.CanFocus = true;
			this.ybtnAddOrderItem.Name = "ybtnAddOrderItem";
			this.ybtnAddOrderItem.UseUnderline = true;
			this.ybtnAddOrderItem.Label = global::Mono.Unix.Catalog.GetString("На продажу");
			this.hboxBtns.Add(this.ybtnAddOrderItem);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hboxBtns[this.ybtnAddOrderItem]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hboxBtns.Gtk.Box+BoxChild
			this.enumAddRentButton = new global::QS.Widgets.EnumMenuButton();
			this.enumAddRentButton.CanFocus = true;
			this.enumAddRentButton.Name = "enumAddRentButton";
			this.enumAddRentButton.UseUnderline = true;
			this.enumAddRentButton.UseMarkup = false;
			this.enumAddRentButton.LabelXAlign = 0F;
			this.enumAddRentButton.Label = global::Mono.Unix.Catalog.GetString("В аренду");
			global::Gtk.Image w5 = new global::Gtk.Image();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.enumAddRentButton.Image = w5;
			this.hboxBtns.Add(this.enumAddRentButton);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hboxBtns[this.enumAddRentButton]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hboxBtns.Gtk.Box+BoxChild
			this.yCmbPromoSets = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.yCmbPromoSets.Name = "yCmbPromoSets";
			this.yCmbPromoSets.AddIfNotExist = false;
			this.yCmbPromoSets.DefaultFirst = false;
			this.yCmbPromoSets.ShowSpecialStateAll = false;
			this.yCmbPromoSets.ShowSpecialStateNot = true;
			this.yCmbPromoSets.NameForSpecialStateNot = "Нет";
			this.hboxBtns.Add(this.yCmbPromoSets);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hboxBtns[this.yCmbPromoSets]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hboxBtns.Gtk.Box+BoxChild
			this.ybtnRemoveOrderItem = new global::Gamma.GtkWidgets.yButton();
			this.ybtnRemoveOrderItem.CanFocus = true;
			this.ybtnRemoveOrderItem.Name = "ybtnRemoveOrderItem";
			this.ybtnRemoveOrderItem.UseUnderline = true;
			this.ybtnRemoveOrderItem.Label = global::Mono.Unix.Catalog.GetString("Удалить");
			this.hboxBtns.Add(this.ybtnRemoveOrderItem);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hboxBtns[this.ybtnRemoveOrderItem]));
			w8.Position = 3;
			w8.Expand = false;
			w8.Fill = false;
			this.vboxMain.Add(this.hboxBtns);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.hboxBtns]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.hboxDiscount = new global::Gtk.HBox();
			this.hboxDiscount.Name = "hboxDiscount";
			this.hboxDiscount.Spacing = 6;
			// Container child hboxDiscount.Gtk.Box+BoxChild
			this.lblDiscont = new global::Gtk.Label();
			this.lblDiscont.Name = "lblDiscont";
			this.lblDiscont.LabelProp = global::Mono.Unix.Catalog.GetString("Скидка на все:");
			this.hboxDiscount.Add(this.lblDiscont);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hboxDiscount[this.lblDiscont]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hboxDiscount.Gtk.Box+BoxChild
			this.ycomboboxReason = new global::Gamma.Widgets.ySpecComboBox();
			this.ycomboboxReason.Name = "ycomboboxReason";
			this.ycomboboxReason.AddIfNotExist = false;
			this.ycomboboxReason.DefaultFirst = false;
			this.ycomboboxReason.ShowSpecialStateAll = false;
			this.ycomboboxReason.ShowSpecialStateNot = false;
			this.hboxDiscount.Add(this.ycomboboxReason);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hboxDiscount[this.ycomboboxReason]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hboxDiscount.Gtk.Box+BoxChild
			this.enumDiscountUnit = new global::QSOrmProject.EnumListComboBox();
			this.enumDiscountUnit.CanDefault = true;
			this.enumDiscountUnit.Name = "enumDiscountUnit";
			this.hboxDiscount.Add(this.enumDiscountUnit);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hboxDiscount[this.enumDiscountUnit]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hboxDiscount.Gtk.Box+BoxChild
			this.yspinBtnDiscount = new global::Gamma.GtkWidgets.ySpinButton(0D, 100D, 1D);
			this.yspinBtnDiscount.CanFocus = true;
			this.yspinBtnDiscount.Name = "yspinBtnDiscount";
			this.yspinBtnDiscount.Adjustment.PageIncrement = 10D;
			this.yspinBtnDiscount.ClimbRate = 1D;
			this.yspinBtnDiscount.Numeric = true;
			this.yspinBtnDiscount.ValueAsDecimal = 0m;
			this.yspinBtnDiscount.ValueAsInt = 0;
			this.hboxDiscount.Add(this.yspinBtnDiscount);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hboxDiscount[this.yspinBtnDiscount]));
			w13.Position = 3;
			w13.Expand = false;
			w13.Fill = false;
			this.vboxMain.Add(this.hboxDiscount);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.hboxDiscount]));
			w14.Position = 3;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.ylblBottlesToReturn = new global::Gamma.GtkWidgets.yLabel();
			this.ylblBottlesToReturn.Name = "ylblBottlesToReturn";
			this.ylblBottlesToReturn.LabelProp = global::Mono.Unix.Catalog.GetString("Планируемая тара:");
			this.hbox5.Add(this.ylblBottlesToReturn);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.ylblBottlesToReturn]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.entryBottlesToReturn = new global::Gamma.Widgets.yValidatedEntry();
			this.entryBottlesToReturn.CanFocus = true;
			this.entryBottlesToReturn.Name = "entryBottlesToReturn";
			this.entryBottlesToReturn.IsEditable = true;
			this.entryBottlesToReturn.WidthChars = 4;
			this.entryBottlesToReturn.InvisibleChar = '●';
			this.hbox5.Add(this.entryBottlesToReturn);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.entryBottlesToReturn]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.hboxReturnTareReason = new global::Gtk.HBox();
			this.hboxReturnTareReason.Name = "hboxReturnTareReason";
			this.hboxReturnTareReason.Spacing = 6;
			// Container child hboxReturnTareReason.Gtk.Box+BoxChild
			this.ylblReturnTareReasonCategory = new global::Gamma.GtkWidgets.yLabel();
			this.ylblReturnTareReasonCategory.Name = "ylblReturnTareReasonCategory";
			this.ylblReturnTareReasonCategory.LabelProp = global::Mono.Unix.Catalog.GetString("Категория причины забора тары: ");
			this.hboxReturnTareReason.Add(this.ylblReturnTareReasonCategory);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hboxReturnTareReason[this.ylblReturnTareReasonCategory]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hboxReturnTareReason.Gtk.Box+BoxChild
			this.yCmbReturnTareReasonCategories = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.yCmbReturnTareReasonCategories.Name = "yCmbReturnTareReasonCategories";
			this.yCmbReturnTareReasonCategories.AddIfNotExist = false;
			this.yCmbReturnTareReasonCategories.DefaultFirst = false;
			this.yCmbReturnTareReasonCategories.ShowSpecialStateAll = false;
			this.yCmbReturnTareReasonCategories.ShowSpecialStateNot = true;
			this.yCmbReturnTareReasonCategories.NameForSpecialStateNot = "Нет";
			this.hboxReturnTareReason.Add(this.yCmbReturnTareReasonCategories);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hboxReturnTareReason[this.yCmbReturnTareReasonCategories]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			// Container child hboxReturnTareReason.Gtk.Box+BoxChild
			this.hboxReasons = new global::Gtk.HBox();
			this.hboxReasons.Name = "hboxReasons";
			this.hboxReasons.Spacing = 6;
			// Container child hboxReasons.Gtk.Box+BoxChild
			this.ylblReturnTareReason = new global::Gamma.GtkWidgets.yLabel();
			this.ylblReturnTareReason.Name = "ylblReturnTareReason";
			this.ylblReturnTareReason.LabelProp = global::Mono.Unix.Catalog.GetString("Причина забора тары: ");
			this.hboxReasons.Add(this.ylblReturnTareReason);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hboxReasons[this.ylblReturnTareReason]));
			w19.Position = 0;
			w19.Expand = false;
			w19.Fill = false;
			// Container child hboxReasons.Gtk.Box+BoxChild
			this.yCmbReturnTareReasons = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.yCmbReturnTareReasons.Name = "yCmbReturnTareReasons";
			this.yCmbReturnTareReasons.AddIfNotExist = false;
			this.yCmbReturnTareReasons.DefaultFirst = false;
			this.yCmbReturnTareReasons.ShowSpecialStateAll = false;
			this.yCmbReturnTareReasons.ShowSpecialStateNot = true;
			this.yCmbReturnTareReasons.NameForSpecialStateNot = "Нет";
			this.hboxReasons.Add(this.yCmbReturnTareReasons);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hboxReasons[this.yCmbReturnTareReasons]));
			w20.Position = 1;
			w20.Expand = false;
			w20.Fill = false;
			this.hboxReturnTareReason.Add(this.hboxReasons);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hboxReturnTareReason[this.hboxReasons]));
			w21.Position = 2;
			w21.Expand = false;
			w21.Fill = false;
			this.hbox5.Add(this.hboxReturnTareReason);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.hboxReturnTareReason]));
			w22.Position = 2;
			w22.Expand = false;
			w22.Fill = false;
			this.vboxMain.Add(this.hbox5);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.hbox5]));
			w23.Position = 4;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.ychkMovementEquipments = new global::Gamma.GtkWidgets.yCheckButton();
			this.ychkMovementEquipments.CanFocus = true;
			this.ychkMovementEquipments.Name = "ychkMovementEquipments";
			this.ychkMovementEquipments.Label = global::Mono.Unix.Catalog.GetString("+ Движение оборудования");
			this.ychkMovementEquipments.DrawIndicator = false;
			this.ychkMovementEquipments.UseUnderline = true;
			this.hbox6.Add(this.ychkMovementEquipments);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.ychkMovementEquipments]));
			w24.Position = 0;
			w24.Expand = false;
			w24.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.ychkDeposits = new global::Gamma.GtkWidgets.yCheckButton();
			this.ychkDeposits.CanFocus = true;
			this.ychkDeposits.Name = "ychkDeposits";
			this.ychkDeposits.Label = global::Mono.Unix.Catalog.GetString("+ Возврат залогов");
			this.ychkDeposits.DrawIndicator = false;
			this.ychkDeposits.UseUnderline = true;
			this.hbox6.Add(this.ychkDeposits);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.ychkDeposits]));
			w25.Position = 2;
			w25.Expand = false;
			w25.Fill = false;
			this.vboxMain.Add(this.hbox6);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.hbox6]));
			w26.Position = 5;
			w26.Expand = false;
			w26.Fill = false;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.vboxMovementItems = new global::Gtk.VBox();
			this.vboxMovementItems.Name = "vboxMovementItems";
			this.vboxMovementItems.Spacing = 6;
			this.vboxMain.Add(this.vboxMovementItems);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.vboxMovementItems]));
			w27.Position = 6;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.vboxDeposits = new global::Gtk.VBox();
			this.vboxDeposits.Name = "vboxDeposits";
			this.vboxDeposits.Spacing = 6;
			// Container child vboxDeposits.Gtk.Box+BoxChild
			this.ylblDeposits = new global::Gamma.GtkWidgets.yLabel();
			this.ylblDeposits.Name = "ylblDeposits";
			this.ylblDeposits.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Возврат залогов</b>");
			this.ylblDeposits.UseMarkup = true;
			this.vboxDeposits.Add(this.ylblDeposits);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vboxDeposits[this.ylblDeposits]));
			w28.Position = 0;
			w28.Expand = false;
			w28.Fill = false;
			this.vboxMain.Add(this.vboxDeposits);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.vboxDeposits]));
			w29.Position = 7;
			this.hboxMain.Add(this.vboxMain);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hboxMain[this.vboxMain]));
			w30.Position = 0;
			// Container child hboxMain.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator();
			this.vseparator1.Name = "vseparator1";
			this.hboxMain.Add(this.vseparator1);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hboxMain[this.vseparator1]));
			w31.Position = 1;
			w31.Expand = false;
			w31.Fill = false;
			// Container child hboxMain.Gtk.Box+BoxChild
			this.hboxJournals = new global::Gtk.HBox();
			this.hboxJournals.Name = "hboxJournals";
			this.hboxJournals.Spacing = 6;
			this.hboxMain.Add(this.hboxJournals);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.hboxMain[this.hboxJournals]));
			w32.Position = 2;
			this.Add(this.hboxMain);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.hboxReasons.Hide();
			this.hboxReturnTareReason.Hide();
			this.vboxMovementItems.Hide();
			this.vboxDeposits.Hide();
			this.hboxJournals.Hide();
			this.Hide();
		}
	}
}