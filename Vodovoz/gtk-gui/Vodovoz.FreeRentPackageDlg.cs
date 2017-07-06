
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class FreeRentPackageDlg
	{
		private global::Gtk.VBox vbox3;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Table datatable1;

		private global::Gamma.GtkWidgets.yEntry dataentryName;

		private global::Gtk.HBox hbox5;

		private global::Gamma.GtkWidgets.ySpinButton spinDeposit;

		private global::QSProjectsLib.CurrencyLabel currencylabel2;

		private global::Gtk.Label label10;

		private global::Gtk.Label label11;

		private global::Gtk.Label label7;

		private global::Gtk.Label label8;

		private global::Gtk.Label label9;

		private global::Gamma.Widgets.yEntryReference referenceDepositService;

		private global::Gamma.Widgets.yEntryReference referenceEquipmentType;

		private global::Gamma.GtkWidgets.ySpinButton spinMinWaterAmount;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.FreeRentPackageDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.FreeRentPackageDlg";
			// Container child Vodovoz.FreeRentPackageDlg.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox4.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox4.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox3.Add(this.hbox4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox4]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.datatable1 = new global::Gtk.Table(((uint)(5)), ((uint)(2)), false);
			this.datatable1.Name = "datatable1";
			this.datatable1.RowSpacing = ((uint)(6));
			this.datatable1.ColumnSpacing = ((uint)(6));
			this.datatable1.BorderWidth = ((uint)(6));
			// Container child datatable1.Gtk.Table+TableChild
			this.dataentryName = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryName.CanFocus = true;
			this.dataentryName.Name = "dataentryName";
			this.dataentryName.IsEditable = true;
			this.dataentryName.InvisibleChar = '●';
			this.datatable1.Add(this.dataentryName);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.datatable1[this.dataentryName]));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.spinDeposit = new global::Gamma.GtkWidgets.ySpinButton(0, 99999, 1);
			this.spinDeposit.CanFocus = true;
			this.spinDeposit.Name = "spinDeposit";
			this.spinDeposit.Adjustment.PageIncrement = 10;
			this.spinDeposit.ClimbRate = 1;
			this.spinDeposit.Numeric = true;
			this.spinDeposit.ValueAsDecimal = 0m;
			this.spinDeposit.ValueAsInt = 0;
			this.hbox5.Add(this.spinDeposit);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.spinDeposit]));
			w7.Position = 0;
			// Container child hbox5.Gtk.Box+BoxChild
			this.currencylabel2 = new global::QSProjectsLib.CurrencyLabel();
			this.currencylabel2.Name = "currencylabel2";
			this.currencylabel2.LabelProp = global::Mono.Unix.Catalog.GetString("currencylabel2");
			this.hbox5.Add(this.currencylabel2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.currencylabel2]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.datatable1.Add(this.hbox5);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.datatable1[this.hbox5]));
			w9.TopAttach = ((uint)(3));
			w9.BottomAttach = ((uint)(4));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.Xalign = 1F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("Минимальное\nкол-во бутылей:");
			this.label10.Justify = ((global::Gtk.Justification)(1));
			this.datatable1.Add(this.label10);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label10]));
			w10.TopAttach = ((uint)(1));
			w10.BottomAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label11 = new global::Gtk.Label();
			this.label11.Name = "label11";
			this.label11.Xalign = 1F;
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString("Название:");
			this.datatable1.Add(this.label11);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label11]));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Услуга залога:");
			this.datatable1.Add(this.label7);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label7]));
			w12.TopAttach = ((uint)(4));
			w12.BottomAttach = ((uint)(5));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label();
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString("Сумма залога:");
			this.datatable1.Add(this.label8);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label8]));
			w13.TopAttach = ((uint)(3));
			w13.BottomAttach = ((uint)(4));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("Тип оборудования:");
			this.datatable1.Add(this.label9);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label9]));
			w14.TopAttach = ((uint)(2));
			w14.BottomAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.referenceDepositService = new global::Gamma.Widgets.yEntryReference();
			this.referenceDepositService.Events = ((global::Gdk.EventMask)(256));
			this.referenceDepositService.Name = "referenceDepositService";
			this.referenceDepositService.DisplayFields = new string[] {
					"Name"};
			this.referenceDepositService.DisplayFormatString = "{0}";
			this.datatable1.Add(this.referenceDepositService);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.datatable1[this.referenceDepositService]));
			w15.TopAttach = ((uint)(4));
			w15.BottomAttach = ((uint)(5));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.referenceEquipmentType = new global::Gamma.Widgets.yEntryReference();
			this.referenceEquipmentType.Events = ((global::Gdk.EventMask)(256));
			this.referenceEquipmentType.Name = "referenceEquipmentType";
			this.referenceEquipmentType.DisplayFields = new string[] {
					"Name"};
			this.referenceEquipmentType.DisplayFormatString = "{0}";
			this.datatable1.Add(this.referenceEquipmentType);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.datatable1[this.referenceEquipmentType]));
			w16.TopAttach = ((uint)(2));
			w16.BottomAttach = ((uint)(3));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.spinMinWaterAmount = new global::Gamma.GtkWidgets.ySpinButton(0, 100, 1);
			this.spinMinWaterAmount.CanFocus = true;
			this.spinMinWaterAmount.Name = "spinMinWaterAmount";
			this.spinMinWaterAmount.Adjustment.PageIncrement = 10;
			this.spinMinWaterAmount.ClimbRate = 1;
			this.spinMinWaterAmount.Numeric = true;
			this.spinMinWaterAmount.ValueAsDecimal = 0m;
			this.spinMinWaterAmount.ValueAsInt = 0;
			this.datatable1.Add(this.spinMinWaterAmount);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.datatable1[this.spinMinWaterAmount]));
			w17.TopAttach = ((uint)(1));
			w17.BottomAttach = ((uint)(2));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox3.Add(this.datatable1);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.datatable1]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			this.Add(this.vbox3);
			if((this.Child != null)) {
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
