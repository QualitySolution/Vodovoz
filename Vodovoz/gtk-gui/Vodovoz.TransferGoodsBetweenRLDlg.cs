
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class TransferGoodsBetweenRLDlg
	{
		private global::Gtk.Table table1;

		private global::Gtk.Button buttonTransfer;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewFrom;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewTo;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Button buttonCreateNewReceptionTicket;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Label label1;

		private global::Gamma.Widgets.yEntryReferenceVM yentryreferenceRouteListFrom;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Label label2;

		private global::Gamma.Widgets.yEntryReferenceVM yentryreferenceRouteListTo;

		private global::Gamma.Widgets.yListComboBox ylistcomboReceptionTicketFrom;

		private global::Gamma.Widgets.yListComboBox ylistcomboReceptionTicketTo;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.TransferGoodsBetweenRLDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.TransferGoodsBetweenRLDlg";
			// Container child Vodovoz.TransferGoodsBetweenRLDlg.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(5)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.buttonTransfer = new global::Gtk.Button();
			this.buttonTransfer.CanFocus = true;
			this.buttonTransfer.Name = "buttonTransfer";
			this.buttonTransfer.UseUnderline = true;
			this.buttonTransfer.Label = global::Mono.Unix.Catalog.GetString("Перенести");
			this.table1.Add(this.buttonTransfer);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.buttonTransfer]));
			w1.TopAttach = ((uint)(4));
			w1.BottomAttach = ((uint)(5));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewFrom = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewFrom.CanFocus = true;
			this.ytreeviewFrom.Name = "ytreeviewFrom";
			this.GtkScrolledWindow.Add(this.ytreeviewFrom);
			this.table1.Add(this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.GtkScrolledWindow]));
			w3.TopAttach = ((uint)(3));
			w3.BottomAttach = ((uint)(4));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.ytreeviewTo = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewTo.CanFocus = true;
			this.ytreeviewTo.Name = "ytreeviewTo";
			this.GtkScrolledWindow1.Add(this.ytreeviewTo);
			this.table1.Add(this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.GtkScrolledWindow1]));
			w5.TopAttach = ((uint)(3));
			w5.BottomAttach = ((uint)(4));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			this.hbox3.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.buttonSave]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			this.hbox3.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.buttonCancel]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.table1.Add(this.hbox3);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox3]));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonCreateNewReceptionTicket = new global::Gtk.Button();
			this.buttonCreateNewReceptionTicket.CanFocus = true;
			this.buttonCreateNewReceptionTicket.Name = "buttonCreateNewReceptionTicket";
			this.buttonCreateNewReceptionTicket.UseUnderline = true;
			this.buttonCreateNewReceptionTicket.Label = global::Mono.Unix.Catalog.GetString("Создать талон разгрузки для принимающего МЛ");
			this.hbox4.Add(this.buttonCreateNewReceptionTicket);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonCreateNewReceptionTicket]));
			w9.PackType = ((global::Gtk.PackType)(1));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			this.table1.Add(this.hbox4);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox4]));
			w10.TopAttach = ((uint)(4));
			w10.BottomAttach = ((uint)(5));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Откуда:");
			this.hbox5.Add(this.label1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label1]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.yentryreferenceRouteListFrom = null;
			this.hbox5.Add(this.yentryreferenceRouteListFrom);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.yentryreferenceRouteListFrom]));
			w12.Position = 1;
			this.table1.Add(this.hbox5);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox5]));
			w13.TopAttach = ((uint)(1));
			w13.BottomAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Куда:");
			this.hbox6.Add(this.label2);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.label2]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.yentryreferenceRouteListTo = null;
			this.hbox6.Add(this.yentryreferenceRouteListTo);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.yentryreferenceRouteListTo]));
			w15.Position = 1;
			this.table1.Add(this.hbox6);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox6]));
			w16.TopAttach = ((uint)(1));
			w16.BottomAttach = ((uint)(2));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylistcomboReceptionTicketFrom = new global::Gamma.Widgets.yListComboBox();
			this.ylistcomboReceptionTicketFrom.Name = "ylistcomboReceptionTicketFrom";
			this.ylistcomboReceptionTicketFrom.AddIfNotExist = false;
			this.ylistcomboReceptionTicketFrom.DefaultFirst = false;
			this.table1.Add(this.ylistcomboReceptionTicketFrom);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table1[this.ylistcomboReceptionTicketFrom]));
			w17.TopAttach = ((uint)(2));
			w17.BottomAttach = ((uint)(3));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylistcomboReceptionTicketTo = new global::Gamma.Widgets.yListComboBox();
			this.ylistcomboReceptionTicketTo.Name = "ylistcomboReceptionTicketTo";
			this.ylistcomboReceptionTicketTo.AddIfNotExist = false;
			this.ylistcomboReceptionTicketTo.DefaultFirst = false;
			this.table1.Add(this.ylistcomboReceptionTicketTo);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table1[this.ylistcomboReceptionTicketTo]));
			w18.TopAttach = ((uint)(2));
			w18.BottomAttach = ((uint)(3));
			w18.LeftAttach = ((uint)(1));
			w18.RightAttach = ((uint)(2));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonCreateNewReceptionTicket.Clicked += new global::System.EventHandler(this.OnButtonCreateNewReceptionTicketClicked);
			this.buttonSave.Clicked += new global::System.EventHandler(this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler(this.OnButtonCancelClicked);
			this.buttonTransfer.Clicked += new global::System.EventHandler(this.OnButtonTransferClicked);
		}
	}
}
