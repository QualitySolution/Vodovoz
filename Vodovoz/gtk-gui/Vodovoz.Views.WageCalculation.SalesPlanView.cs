
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.WageCalculation
{
	public partial class SalesPlanView
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hboxDialogButtons;

		private global::Gamma.GtkWidgets.yButton btnSave;

		private global::Gamma.GtkWidgets.yButton btnCancel;

		private global::Gtk.Table tableWidget;

		private global::Gamma.GtkWidgets.yCheckButton chkIsArchive;

		private global::Gamma.GtkWidgets.ySpinButton entryEmptyBottlesToTake;

		private global::Gamma.GtkWidgets.ySpinButton entryFullBottlesToSell;

		private global::Gamma.GtkWidgets.ySpinButton entryProceeds;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewEquipmentKindSalesPlan;

		private global::Gtk.ScrolledWindow GtkScrolledWindow5;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewNomenclatureSalesPlan;

		private global::Gtk.ScrolledWindow GtkScrolledWindow7;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewEquipmentTypeSalesPlan;

		private global::Gtk.HSeparator hseparator1;

		private global::Gtk.HSeparator hseparator2;

		private global::Gtk.HSeparator hseparator3;

		private global::Gtk.Label labelName;

		private global::Gamma.GtkWidgets.yButton ybuttonAddEquipmentKind;

		private global::Gamma.GtkWidgets.yButton ybuttonAddEquipmentType;

		private global::Gamma.GtkWidgets.yButton ybuttonAddNomenclature;

		private global::Gamma.GtkWidgets.yButton ybuttonCancelEquipmentType;

		private global::Gamma.GtkWidgets.yButton ybuttonDeleteEquipmentKind;

		private global::Gamma.GtkWidgets.yButton ybuttonDeleteEquipmentType;

		private global::Gamma.GtkWidgets.yButton ybuttonDeleteNomenclature;

		private global::Gamma.GtkWidgets.yButton ybuttonSaveEquipmentType;

		private global::Gamma.GtkWidgets.yEntry yentryName;

		private global::Gamma.GtkWidgets.yLabel ylabelEquipmentKindSalesPlan;

		private global::Gamma.GtkWidgets.yLabel ylabelEquipmentKindSalesPlan1;

		private global::Gamma.GtkWidgets.yLabel ylabelFullBottlesToSell;

		private global::Gamma.GtkWidgets.yLabel ylabelFullBottlesToTake;

		private global::Gamma.GtkWidgets.yLabel ylabelNomenclatureSalesPlan;

		private global::Gamma.GtkWidgets.yLabel ylabelProceeds;

		private global::Gamma.Widgets.ySpecComboBox yspeccomboboxEquipmentType;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.WageCalculation.SalesPlanView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.WageCalculation.SalesPlanView";
			// Container child Vodovoz.Views.WageCalculation.SalesPlanView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hboxDialogButtons = new global::Gtk.HBox();
			this.hboxDialogButtons.Name = "hboxDialogButtons";
			this.hboxDialogButtons.Spacing = 6;
			// Container child hboxDialogButtons.Gtk.Box+BoxChild
			this.btnSave = new global::Gamma.GtkWidgets.yButton();
			this.btnSave.CanFocus = true;
			this.btnSave.Name = "btnSave";
			this.btnSave.UseUnderline = true;
			this.btnSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.btnSave.Image = w1;
			this.hboxDialogButtons.Add(this.btnSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hboxDialogButtons[this.btnSave]));
			w2.Position = 0;
			w2.Expand = false;
			// Container child hboxDialogButtons.Gtk.Box+BoxChild
			this.btnCancel = new global::Gamma.GtkWidgets.yButton();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.btnCancel.Image = w3;
			this.hboxDialogButtons.Add(this.btnCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hboxDialogButtons[this.btnCancel]));
			w4.Position = 1;
			w4.Expand = false;
			this.vbox2.Add(this.hboxDialogButtons);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hboxDialogButtons]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.tableWidget = new global::Gtk.Table(((uint)(15)), ((uint)(5)), false);
			this.tableWidget.Name = "tableWidget";
			this.tableWidget.RowSpacing = ((uint)(6));
			this.tableWidget.ColumnSpacing = ((uint)(6));
			// Container child tableWidget.Gtk.Table+TableChild
			this.chkIsArchive = new global::Gamma.GtkWidgets.yCheckButton();
			this.chkIsArchive.CanFocus = true;
			this.chkIsArchive.Name = "chkIsArchive";
			this.chkIsArchive.Label = global::Mono.Unix.Catalog.GetString("Архивный");
			this.chkIsArchive.DrawIndicator = true;
			this.chkIsArchive.UseUnderline = true;
			this.tableWidget.Add(this.chkIsArchive);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.chkIsArchive]));
			w6.TopAttach = ((uint)(4));
			w6.BottomAttach = ((uint)(5));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(4));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.entryEmptyBottlesToTake = new global::Gamma.GtkWidgets.ySpinButton(0D, 99999999D, 1D);
			this.entryEmptyBottlesToTake.CanFocus = true;
			this.entryEmptyBottlesToTake.Name = "entryEmptyBottlesToTake";
			this.entryEmptyBottlesToTake.Adjustment.PageIncrement = 10D;
			this.entryEmptyBottlesToTake.ClimbRate = 1D;
			this.entryEmptyBottlesToTake.Numeric = true;
			this.entryEmptyBottlesToTake.ValueAsDecimal = 0m;
			this.entryEmptyBottlesToTake.ValueAsInt = 0;
			this.tableWidget.Add(this.entryEmptyBottlesToTake);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.entryEmptyBottlesToTake]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.entryFullBottlesToSell = new global::Gamma.GtkWidgets.ySpinButton(0D, 99999999D, 1D);
			this.entryFullBottlesToSell.CanFocus = true;
			this.entryFullBottlesToSell.Name = "entryFullBottlesToSell";
			this.entryFullBottlesToSell.Adjustment.PageIncrement = 10D;
			this.entryFullBottlesToSell.ClimbRate = 1D;
			this.entryFullBottlesToSell.Numeric = true;
			this.entryFullBottlesToSell.ValueAsDecimal = 0m;
			this.entryFullBottlesToSell.ValueAsInt = 0;
			this.tableWidget.Add(this.entryFullBottlesToSell);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.entryFullBottlesToSell]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(3));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.entryProceeds = new global::Gamma.GtkWidgets.ySpinButton(0D, 99999999D, 1D);
			this.entryProceeds.CanFocus = true;
			this.entryProceeds.Name = "entryProceeds";
			this.entryProceeds.Adjustment.PageIncrement = 10D;
			this.entryProceeds.ClimbRate = 1D;
			this.entryProceeds.Digits = ((uint)(2));
			this.entryProceeds.Numeric = true;
			this.entryProceeds.ValueAsDecimal = 0m;
			this.entryProceeds.ValueAsInt = 0;
			this.tableWidget.Add(this.entryProceeds);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.entryProceeds]));
			w9.TopAttach = ((uint)(3));
			w9.BottomAttach = ((uint)(4));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(3));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewEquipmentKindSalesPlan = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewEquipmentKindSalesPlan.CanFocus = true;
			this.ytreeviewEquipmentKindSalesPlan.Name = "ytreeviewEquipmentKindSalesPlan";
			this.ytreeviewEquipmentKindSalesPlan.EnableSearch = false;
			this.ytreeviewEquipmentKindSalesPlan.HeadersVisible = false;
			this.ytreeviewEquipmentKindSalesPlan.SearchColumn = 0;
			this.GtkScrolledWindow.Add(this.ytreeviewEquipmentKindSalesPlan);
			this.tableWidget.Add(this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.GtkScrolledWindow]));
			w11.TopAttach = ((uint)(9));
			w11.BottomAttach = ((uint)(10));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(3));
			// Container child tableWidget.Gtk.Table+TableChild
			this.GtkScrolledWindow5 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow5.Name = "GtkScrolledWindow5";
			this.GtkScrolledWindow5.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow5.Gtk.Container+ContainerChild
			this.ytreeviewNomenclatureSalesPlan = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewNomenclatureSalesPlan.CanFocus = true;
			this.ytreeviewNomenclatureSalesPlan.Name = "ytreeviewNomenclatureSalesPlan";
			this.GtkScrolledWindow5.Add(this.ytreeviewNomenclatureSalesPlan);
			this.tableWidget.Add(this.GtkScrolledWindow5);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.GtkScrolledWindow5]));
			w13.TopAttach = ((uint)(6));
			w13.BottomAttach = ((uint)(7));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(3));
			// Container child tableWidget.Gtk.Table+TableChild
			this.GtkScrolledWindow7 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow7.Name = "GtkScrolledWindow7";
			this.GtkScrolledWindow7.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow7.Gtk.Container+ContainerChild
			this.ytreeviewEquipmentTypeSalesPlan = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewEquipmentTypeSalesPlan.CanFocus = true;
			this.ytreeviewEquipmentTypeSalesPlan.Name = "ytreeviewEquipmentTypeSalesPlan";
			this.GtkScrolledWindow7.Add(this.ytreeviewEquipmentTypeSalesPlan);
			this.tableWidget.Add(this.GtkScrolledWindow7);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.GtkScrolledWindow7]));
			w15.TopAttach = ((uint)(12));
			w15.BottomAttach = ((uint)(13));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(3));
			// Container child tableWidget.Gtk.Table+TableChild
			this.hseparator1 = new global::Gtk.HSeparator();
			this.hseparator1.Name = "hseparator1";
			this.tableWidget.Add(this.hseparator1);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.hseparator1]));
			w16.TopAttach = ((uint)(5));
			w16.BottomAttach = ((uint)(6));
			w16.RightAttach = ((uint)(5));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.hseparator2 = new global::Gtk.HSeparator();
			this.hseparator2.Name = "hseparator2";
			this.tableWidget.Add(this.hseparator2);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.hseparator2]));
			w17.TopAttach = ((uint)(8));
			w17.BottomAttach = ((uint)(9));
			w17.RightAttach = ((uint)(5));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.hseparator3 = new global::Gtk.HSeparator();
			this.hseparator3.Name = "hseparator3";
			this.tableWidget.Add(this.hseparator3);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.hseparator3]));
			w18.TopAttach = ((uint)(11));
			w18.BottomAttach = ((uint)(12));
			w18.RightAttach = ((uint)(5));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.labelName = new global::Gtk.Label();
			this.labelName.Name = "labelName";
			this.labelName.Xalign = 1F;
			this.labelName.LabelProp = global::Mono.Unix.Catalog.GetString("Название:");
			this.tableWidget.Add(this.labelName);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.labelName]));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ybuttonAddEquipmentKind = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonAddEquipmentKind.CanFocus = true;
			this.ybuttonAddEquipmentKind.Name = "ybuttonAddEquipmentKind";
			this.ybuttonAddEquipmentKind.UseUnderline = true;
			this.ybuttonAddEquipmentKind.Label = global::Mono.Unix.Catalog.GetString("Добавить виды оборудования");
			this.tableWidget.Add(this.ybuttonAddEquipmentKind);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ybuttonAddEquipmentKind]));
			w20.TopAttach = ((uint)(10));
			w20.BottomAttach = ((uint)(11));
			w20.LeftAttach = ((uint)(1));
			w20.RightAttach = ((uint)(2));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ybuttonAddEquipmentType = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonAddEquipmentType.CanFocus = true;
			this.ybuttonAddEquipmentType.Name = "ybuttonAddEquipmentType";
			this.ybuttonAddEquipmentType.UseUnderline = true;
			this.ybuttonAddEquipmentType.Label = global::Mono.Unix.Catalog.GetString("Добавить типы оборудования");
			this.tableWidget.Add(this.ybuttonAddEquipmentType);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ybuttonAddEquipmentType]));
			w21.TopAttach = ((uint)(13));
			w21.BottomAttach = ((uint)(14));
			w21.LeftAttach = ((uint)(1));
			w21.RightAttach = ((uint)(2));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ybuttonAddNomenclature = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonAddNomenclature.CanFocus = true;
			this.ybuttonAddNomenclature.Name = "ybuttonAddNomenclature";
			this.ybuttonAddNomenclature.UseUnderline = true;
			this.ybuttonAddNomenclature.Label = global::Mono.Unix.Catalog.GetString("Добавить номенклатуры");
			this.tableWidget.Add(this.ybuttonAddNomenclature);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ybuttonAddNomenclature]));
			w22.TopAttach = ((uint)(7));
			w22.BottomAttach = ((uint)(8));
			w22.LeftAttach = ((uint)(1));
			w22.RightAttach = ((uint)(2));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ybuttonCancelEquipmentType = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonCancelEquipmentType.CanFocus = true;
			this.ybuttonCancelEquipmentType.Name = "ybuttonCancelEquipmentType";
			this.ybuttonCancelEquipmentType.UseUnderline = true;
			this.ybuttonCancelEquipmentType.Label = global::Mono.Unix.Catalog.GetString("Отмена");
			this.tableWidget.Add(this.ybuttonCancelEquipmentType);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ybuttonCancelEquipmentType]));
			w23.TopAttach = ((uint)(13));
			w23.BottomAttach = ((uint)(14));
			w23.LeftAttach = ((uint)(4));
			w23.RightAttach = ((uint)(5));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ybuttonDeleteEquipmentKind = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonDeleteEquipmentKind.CanFocus = true;
			this.ybuttonDeleteEquipmentKind.Name = "ybuttonDeleteEquipmentKind";
			this.ybuttonDeleteEquipmentKind.UseUnderline = true;
			this.ybuttonDeleteEquipmentKind.Label = global::Mono.Unix.Catalog.GetString("Удалить");
			this.tableWidget.Add(this.ybuttonDeleteEquipmentKind);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ybuttonDeleteEquipmentKind]));
			w24.TopAttach = ((uint)(10));
			w24.BottomAttach = ((uint)(11));
			w24.LeftAttach = ((uint)(2));
			w24.RightAttach = ((uint)(3));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ybuttonDeleteEquipmentType = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonDeleteEquipmentType.CanFocus = true;
			this.ybuttonDeleteEquipmentType.Name = "ybuttonDeleteEquipmentType";
			this.ybuttonDeleteEquipmentType.UseUnderline = true;
			this.ybuttonDeleteEquipmentType.Label = global::Mono.Unix.Catalog.GetString("Удалить");
			this.tableWidget.Add(this.ybuttonDeleteEquipmentType);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ybuttonDeleteEquipmentType]));
			w25.TopAttach = ((uint)(13));
			w25.BottomAttach = ((uint)(14));
			w25.LeftAttach = ((uint)(2));
			w25.RightAttach = ((uint)(3));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ybuttonDeleteNomenclature = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonDeleteNomenclature.CanFocus = true;
			this.ybuttonDeleteNomenclature.Name = "ybuttonDeleteNomenclature";
			this.ybuttonDeleteNomenclature.UseUnderline = true;
			this.ybuttonDeleteNomenclature.Label = global::Mono.Unix.Catalog.GetString("Удалить");
			this.tableWidget.Add(this.ybuttonDeleteNomenclature);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ybuttonDeleteNomenclature]));
			w26.TopAttach = ((uint)(7));
			w26.BottomAttach = ((uint)(8));
			w26.LeftAttach = ((uint)(2));
			w26.RightAttach = ((uint)(3));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ybuttonSaveEquipmentType = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonSaveEquipmentType.CanFocus = true;
			this.ybuttonSaveEquipmentType.Name = "ybuttonSaveEquipmentType";
			this.ybuttonSaveEquipmentType.UseUnderline = true;
			this.ybuttonSaveEquipmentType.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			this.tableWidget.Add(this.ybuttonSaveEquipmentType);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ybuttonSaveEquipmentType]));
			w27.TopAttach = ((uint)(13));
			w27.BottomAttach = ((uint)(14));
			w27.LeftAttach = ((uint)(3));
			w27.RightAttach = ((uint)(4));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.yentryName = new global::Gamma.GtkWidgets.yEntry();
			this.yentryName.CanFocus = true;
			this.yentryName.Name = "yentryName";
			this.yentryName.IsEditable = true;
			this.yentryName.InvisibleChar = '•';
			this.tableWidget.Add(this.yentryName);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.yentryName]));
			w28.LeftAttach = ((uint)(1));
			w28.RightAttach = ((uint)(3));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ylabelEquipmentKindSalesPlan = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelEquipmentKindSalesPlan.Name = "ylabelEquipmentKindSalesPlan";
			this.ylabelEquipmentKindSalesPlan.Xalign = 1F;
			this.ylabelEquipmentKindSalesPlan.LabelProp = global::Mono.Unix.Catalog.GetString("Типы оборудования:");
			this.ylabelEquipmentKindSalesPlan.Justify = ((global::Gtk.Justification)(1));
			this.ylabelEquipmentKindSalesPlan.Ellipsize = ((global::Pango.EllipsizeMode)(3));
			this.tableWidget.Add(this.ylabelEquipmentKindSalesPlan);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ylabelEquipmentKindSalesPlan]));
			w29.TopAttach = ((uint)(12));
			w29.BottomAttach = ((uint)(13));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ylabelEquipmentKindSalesPlan1 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelEquipmentKindSalesPlan1.Name = "ylabelEquipmentKindSalesPlan1";
			this.ylabelEquipmentKindSalesPlan1.Xalign = 1F;
			this.ylabelEquipmentKindSalesPlan1.LabelProp = global::Mono.Unix.Catalog.GetString("Виды оборудования:");
			this.ylabelEquipmentKindSalesPlan1.Justify = ((global::Gtk.Justification)(1));
			this.ylabelEquipmentKindSalesPlan1.Ellipsize = ((global::Pango.EllipsizeMode)(3));
			this.tableWidget.Add(this.ylabelEquipmentKindSalesPlan1);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ylabelEquipmentKindSalesPlan1]));
			w30.TopAttach = ((uint)(9));
			w30.BottomAttach = ((uint)(10));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ylabelFullBottlesToSell = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelFullBottlesToSell.Name = "ylabelFullBottlesToSell";
			this.ylabelFullBottlesToSell.Xalign = 1F;
			this.ylabelFullBottlesToSell.LabelProp = global::Mono.Unix.Catalog.GetString("Бутылей на продажу:");
			this.tableWidget.Add(this.ylabelFullBottlesToSell);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ylabelFullBottlesToSell]));
			w31.TopAttach = ((uint)(1));
			w31.BottomAttach = ((uint)(2));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ylabelFullBottlesToTake = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelFullBottlesToTake.Name = "ylabelFullBottlesToTake";
			this.ylabelFullBottlesToTake.Xalign = 1F;
			this.ylabelFullBottlesToTake.LabelProp = global::Mono.Unix.Catalog.GetString("Бутылей на забор:");
			this.tableWidget.Add(this.ylabelFullBottlesToTake);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ylabelFullBottlesToTake]));
			w32.TopAttach = ((uint)(2));
			w32.BottomAttach = ((uint)(3));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ylabelNomenclatureSalesPlan = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelNomenclatureSalesPlan.Name = "ylabelNomenclatureSalesPlan";
			this.ylabelNomenclatureSalesPlan.Xalign = 1F;
			this.ylabelNomenclatureSalesPlan.LabelProp = global::Mono.Unix.Catalog.GetString("Номенклатуры:");
			this.ylabelNomenclatureSalesPlan.Justify = ((global::Gtk.Justification)(1));
			this.ylabelNomenclatureSalesPlan.Ellipsize = ((global::Pango.EllipsizeMode)(3));
			this.tableWidget.Add(this.ylabelNomenclatureSalesPlan);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ylabelNomenclatureSalesPlan]));
			w33.TopAttach = ((uint)(6));
			w33.BottomAttach = ((uint)(7));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.ylabelProceeds = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelProceeds.Name = "ylabelProceeds";
			this.ylabelProceeds.Xalign = 1F;
			this.ylabelProceeds.LabelProp = global::Mono.Unix.Catalog.GetString("Выручка:");
			this.tableWidget.Add(this.ylabelProceeds);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.ylabelProceeds]));
			w34.TopAttach = ((uint)(3));
			w34.BottomAttach = ((uint)(4));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWidget.Gtk.Table+TableChild
			this.yspeccomboboxEquipmentType = new global::Gamma.Widgets.ySpecComboBox();
			this.yspeccomboboxEquipmentType.Name = "yspeccomboboxEquipmentType";
			this.yspeccomboboxEquipmentType.AddIfNotExist = false;
			this.yspeccomboboxEquipmentType.DefaultFirst = false;
			this.yspeccomboboxEquipmentType.ShowSpecialStateAll = false;
			this.yspeccomboboxEquipmentType.ShowSpecialStateNot = false;
			this.tableWidget.Add(this.yspeccomboboxEquipmentType);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.tableWidget[this.yspeccomboboxEquipmentType]));
			w35.TopAttach = ((uint)(12));
			w35.BottomAttach = ((uint)(13));
			w35.LeftAttach = ((uint)(3));
			w35.RightAttach = ((uint)(5));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(0));
			this.vbox2.Add(this.tableWidget);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.tableWidget]));
			w36.Position = 1;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.ybuttonCancelEquipmentType.Hide();
			this.ybuttonSaveEquipmentType.Hide();
			this.yspeccomboboxEquipmentType.Hide();
			this.Hide();
		}
	}
}
