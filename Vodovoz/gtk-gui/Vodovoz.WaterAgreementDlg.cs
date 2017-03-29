
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class WaterAgreementDlg
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.DataBindings.DataTable datatable1;

		private global::QSOrmProject.DataDatePicker dateIssue;

		private global::QSOrmProject.DataDatePicker dateStart;

		private global::Gtk.HBox hbox6;

		private global::Gtk.DataBindings.DataCheckButton checkIsFixedPrice;

		private global::Gtk.Label label1;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gtk.Label label6;

		private global::Gtk.Label label7;

		private global::Gtk.DataBindings.DataEntryReferenceVM referenceDeliveryPoint;

		private global::QSDocTemplates.TemplateWidget templatewidget1;

		private global::Gamma.GtkWidgets.yLabel ylabelNumber;

		private global::Gtk.ScrolledWindow GtkScrolledWindowFixedPrice;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewFixedPrices;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Button buttonAdd;

		private global::Gtk.Button buttonDel;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.WaterAgreementDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.WaterAgreementDlg";
			// Container child Vodovoz.WaterAgreementDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox1.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отмена");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox1.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.datatable1 = new global::Gtk.DataBindings.DataTable(((uint)(5)), ((uint)(3)), false);
			this.datatable1.Name = "datatable1";
			this.datatable1.RowSpacing = ((uint)(6));
			this.datatable1.ColumnSpacing = ((uint)(6));
			this.datatable1.BorderWidth = ((uint)(6));
			this.datatable1.InheritedDataSource = false;
			this.datatable1.InheritedBoundaryDataSource = false;
			this.datatable1.InheritedDataSource = false;
			this.datatable1.InheritedBoundaryDataSource = false;
			// Container child datatable1.Gtk.Table+TableChild
			this.dateIssue = null;
			this.datatable1.Add(this.dateIssue);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.datatable1[this.dateIssue]));
			w6.TopAttach = ((uint)(2));
			w6.BottomAttach = ((uint)(3));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.dateStart = null;
			this.datatable1.Add(this.dateStart);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.datatable1[this.dateStart]));
			w7.TopAttach = ((uint)(3));
			w7.BottomAttach = ((uint)(4));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.checkIsFixedPrice = new global::Gtk.DataBindings.DataCheckButton();
			this.checkIsFixedPrice.CanFocus = true;
			this.checkIsFixedPrice.Name = "checkIsFixedPrice";
			this.checkIsFixedPrice.Label = "";
			this.checkIsFixedPrice.Active = true;
			this.checkIsFixedPrice.DrawIndicator = true;
			this.checkIsFixedPrice.UseUnderline = true;
			this.checkIsFixedPrice.InheritedDataSource = true;
			this.checkIsFixedPrice.Mappings = "IsFixedPrice";
			this.checkIsFixedPrice.InheritedBoundaryDataSource = false;
			this.checkIsFixedPrice.Editable = true;
			this.checkIsFixedPrice.AutomaticTitle = false;
			this.checkIsFixedPrice.InheritedBoundaryDataSource = false;
			this.checkIsFixedPrice.InheritedDataSource = true;
			this.checkIsFixedPrice.Mappings = "IsFixedPrice";
			this.hbox6.Add(this.checkIsFixedPrice);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.checkIsFixedPrice]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			this.datatable1.Add(this.hbox6);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.datatable1[this.hbox6]));
			w9.TopAttach = ((uint)(4));
			w9.BottomAttach = ((uint)(5));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Номер доп. соглашения:");
			this.datatable1.Add(this.label1);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label1]));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Дата начала действия:");
			this.datatable1.Add(this.label4);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label4]));
			w11.TopAttach = ((uint)(3));
			w11.BottomAttach = ((uint)(4));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Фиксированная стоимость:");
			this.datatable1.Add(this.label5);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label5]));
			w12.TopAttach = ((uint)(4));
			w12.BottomAttach = ((uint)(5));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Дата создания:");
			this.datatable1.Add(this.label6);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label6]));
			w13.TopAttach = ((uint)(2));
			w13.BottomAttach = ((uint)(3));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Точка доставки:");
			this.datatable1.Add(this.label7);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label7]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.referenceDeliveryPoint = null;
			this.datatable1.Add(this.referenceDeliveryPoint);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.datatable1[this.referenceDeliveryPoint]));
			w15.TopAttach = ((uint)(1));
			w15.BottomAttach = ((uint)(2));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.templatewidget1 = new global::QSDocTemplates.TemplateWidget();
			this.templatewidget1.Events = ((global::Gdk.EventMask)(256));
			this.templatewidget1.Name = "templatewidget1";
			this.datatable1.Add(this.templatewidget1);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.datatable1[this.templatewidget1]));
			w16.BottomAttach = ((uint)(5));
			w16.LeftAttach = ((uint)(2));
			w16.RightAttach = ((uint)(3));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.ylabelNumber = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelNumber.Name = "ylabelNumber";
			this.ylabelNumber.Xalign = 0F;
			this.ylabelNumber.LabelProp = global::Mono.Unix.Catalog.GetString("ylabel1");
			this.datatable1.Add(this.ylabelNumber);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.datatable1[this.ylabelNumber]));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add(this.datatable1);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.datatable1]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindowFixedPrice = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindowFixedPrice.Name = "GtkScrolledWindowFixedPrice";
			this.GtkScrolledWindowFixedPrice.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindowFixedPrice.Gtk.Container+ContainerChild
			this.ytreeviewFixedPrices = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewFixedPrices.CanFocus = true;
			this.ytreeviewFixedPrices.Name = "ytreeviewFixedPrices";
			this.GtkScrolledWindowFixedPrice.Add(this.ytreeviewFixedPrices);
			this.vbox1.Add(this.GtkScrolledWindowFixedPrice);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindowFixedPrice]));
			w20.Position = 2;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonAdd = new global::Gtk.Button();
			this.buttonAdd.CanFocus = true;
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.UseUnderline = true;
			this.buttonAdd.Label = global::Mono.Unix.Catalog.GetString("Добавить");
			this.hbox7.Add(this.buttonAdd);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.buttonAdd]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonDel = new global::Gtk.Button();
			this.buttonDel.CanFocus = true;
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.UseUnderline = true;
			this.buttonDel.Label = global::Mono.Unix.Catalog.GetString("Удалить");
			this.hbox7.Add(this.buttonDel);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.buttonDel]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			this.vbox1.Add(this.hbox7);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox7]));
			w23.Position = 3;
			w23.Expand = false;
			w23.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonSave.Clicked += new global::System.EventHandler(this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler(this.OnButtonCancelClicked);
			this.checkIsFixedPrice.Toggled += new global::System.EventHandler(this.OnCheckIsFixedPriceToggled);
			this.buttonAdd.Clicked += new global::System.EventHandler(this.OnButtonAddClicked);
			this.buttonDel.Clicked += new global::System.EventHandler(this.OnButtonDelClicked);
		}
	}
}
