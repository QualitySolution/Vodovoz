
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class RouteListAddressesTransferringDlg
	{
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.HBox hbox7;
		
		private global::Gtk.Button buttonSave;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.VBox vbox4;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gamma.GtkWidgets.yLabel ylabel1;
		
		private global::Gamma.Widgets.yEntryReference yentryreferenceRLFrom;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gamma.GtkWidgets.yTreeView ytreeviewRLFrom;
		
		private global::Gtk.VBox vbox5;
		
		private global::Gtk.HBox hbox4;
		
		private global::Gamma.GtkWidgets.yLabel ylabel2;
		
		private global::Gamma.Widgets.yEntryReference yentryreferenceRLTo;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		
		private global::Gamma.GtkWidgets.yTreeView ytreeviewRLTo;
		
		private global::Gtk.HBox hbox8;
		
		private global::Gtk.Button buttonTransfer;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Vodovoz.RouteListAddressesTransferringDlg
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Vodovoz.RouteListAddressesTransferringDlg";
			// Container child Vodovoz.RouteListAddressesTransferringDlg.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button ();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString ("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image ();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox7.Add (this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox7.Add (this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox3.Add (this.hbox7);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox7]));
			w5.Position = 0;
			w5.Expand = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.ylabel1 = new global::Gamma.GtkWidgets.yLabel ();
			this.ylabel1.Name = "ylabel1";
			this.ylabel1.LabelProp = global::Mono.Unix.Catalog.GetString ("От кого:");
			this.hbox3.Add (this.ylabel1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.ylabel1]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.yentryreferenceRLFrom = new global::Gamma.Widgets.yEntryReference ();
			this.yentryreferenceRLFrom.Events = ((global::Gdk.EventMask)(256));
			this.yentryreferenceRLFrom.Name = "yentryreferenceRLFrom";
			this.hbox3.Add (this.yentryreferenceRLFrom);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.yentryreferenceRLFrom]));
			w7.Position = 1;
			this.vbox4.Add (this.hbox3);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbox3]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewRLFrom = new global::Gamma.GtkWidgets.yTreeView ();
			this.ytreeviewRLFrom.CanFocus = true;
			this.ytreeviewRLFrom.Name = "ytreeviewRLFrom";
			this.ytreeviewRLFrom.EnableSearch = false;
			this.GtkScrolledWindow.Add (this.ytreeviewRLFrom);
			this.vbox4.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.GtkScrolledWindow]));
			w10.Position = 1;
			this.hbox2.Add (this.vbox4);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.vbox4]));
			w11.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.ylabel2 = new global::Gamma.GtkWidgets.yLabel ();
			this.ylabel2.Name = "ylabel2";
			this.ylabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("Кому:");
			this.hbox4.Add (this.ylabel2);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.ylabel2]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.yentryreferenceRLTo = new global::Gamma.Widgets.yEntryReference ();
			this.yentryreferenceRLTo.Events = ((global::Gdk.EventMask)(256));
			this.yentryreferenceRLTo.Name = "yentryreferenceRLTo";
			this.hbox4.Add (this.yentryreferenceRLTo);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.yentryreferenceRLTo]));
			w13.Position = 1;
			this.vbox5.Add (this.hbox4);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbox4]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.ytreeviewRLTo = new global::Gamma.GtkWidgets.yTreeView ();
			this.ytreeviewRLTo.CanFocus = true;
			this.ytreeviewRLTo.Name = "ytreeviewRLTo";
			this.ytreeviewRLTo.EnableSearch = false;
			this.GtkScrolledWindow1.Add (this.ytreeviewRLTo);
			this.vbox5.Add (this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.GtkScrolledWindow1]));
			w16.Position = 1;
			this.hbox2.Add (this.vbox5);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.vbox5]));
			w17.Position = 1;
			this.vbox3.Add (this.hbox2);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox2]));
			w18.Position = 1;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.buttonTransfer = new global::Gtk.Button ();
			this.buttonTransfer.Sensitive = false;
			this.buttonTransfer.CanFocus = true;
			this.buttonTransfer.Name = "buttonTransfer";
			this.buttonTransfer.UseUnderline = true;
			this.buttonTransfer.Label = global::Mono.Unix.Catalog.GetString ("Перенести");
			this.hbox8.Add (this.buttonTransfer);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.buttonTransfer]));
			w19.Position = 0;
			w19.Expand = false;
			w19.Fill = false;
			this.vbox3.Add (this.hbox8);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox8]));
			w20.Position = 2;
			w20.Expand = false;
			w20.Fill = false;
			this.hbox1.Add (this.vbox3);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox3]));
			w21.Position = 0;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.buttonSave.Clicked += new global::System.EventHandler (this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
			this.buttonTransfer.Clicked += new global::System.EventHandler (this.OnButtonTransferClicked);
		}
	}
}
