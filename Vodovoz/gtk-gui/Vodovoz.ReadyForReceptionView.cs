
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class ReadyForReceptionView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label label1;

		private global::Gamma.GtkWidgets.yCheckButton checkWithoutUnload;

		private global::Gtk.Button buttonRefresh;

		private global::QSWidgetLib.SearchEntity searchentity1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::QSOrmProject.RepresentationTreeView tableReadyForReception;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Button buttonOpen;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ReadyForReceptionView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ReadyForReceptionView";
			// Container child Vodovoz.ReadyForReceptionView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Склад:");
			this.hbox3.Add(this.label1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.checkWithoutUnload = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkWithoutUnload.CanFocus = true;
			this.checkWithoutUnload.Name = "checkWithoutUnload";
			this.checkWithoutUnload.Label = global::Mono.Unix.Catalog.GetString("Только без погрузки");
			this.checkWithoutUnload.DrawIndicator = true;
			this.checkWithoutUnload.UseUnderline = true;
			this.checkWithoutUnload.FocusOnClick = false;
			this.checkWithoutUnload.Xalign = 0F;
			this.checkWithoutUnload.Yalign = 0F;
			this.hbox3.Add(this.checkWithoutUnload);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.checkWithoutUnload]));
			w2.PackType = ((global::Gtk.PackType)(1));
			w2.Position = 2;
			w2.Expand = false;
			w2.Fill = false;
			this.hbox1.Add(this.hbox3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.hbox3]));
			w3.Position = 0;
			w3.Expand = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonRefresh = new global::Gtk.Button();
			this.buttonRefresh.CanFocus = true;
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.UseUnderline = true;
			this.buttonRefresh.Label = global::Mono.Unix.Catalog.GetString("Обновить");
			this.hbox1.Add(this.buttonRefresh);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonRefresh]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.searchentity1 = new global::QSWidgetLib.SearchEntity();
			this.searchentity1.Events = ((global::Gdk.EventMask)(256));
			this.searchentity1.Name = "searchentity1";
			this.vbox1.Add(this.searchentity1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.searchentity1]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tableReadyForReception = new global::QSOrmProject.RepresentationTreeView();
			this.tableReadyForReception.CanFocus = true;
			this.tableReadyForReception.Name = "tableReadyForReception";
			this.GtkScrolledWindow.Add(this.tableReadyForReception);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w8.Position = 2;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonOpen = new global::Gtk.Button();
			this.buttonOpen.Sensitive = false;
			this.buttonOpen.CanFocus = true;
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.UseUnderline = true;
			this.buttonOpen.Label = global::Mono.Unix.Catalog.GetString("Разгрузить машину");
			global::Gtk.Image w9 = new global::Gtk.Image();
			w9.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-ok", global::Gtk.IconSize.Menu);
			this.buttonOpen.Image = w9;
			this.hbox4.Add(this.buttonOpen);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonOpen]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			this.vbox1.Add(this.hbox4);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox4]));
			w11.Position = 3;
			w11.Expand = false;
			w11.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonRefresh.Clicked += new global::System.EventHandler(this.OnButtonRefreshClicked);
			this.searchentity1.TextChanged += new global::System.EventHandler(this.OnSearchentity1TextChanged);
			this.tableReadyForReception.RowActivated += new global::Gtk.RowActivatedHandler(this.OnTableReadyForReceptionRowActivated);
			this.buttonOpen.Clicked += new global::System.EventHandler(this.OnButtonOpenClicked);
		}
	}
}
