
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class RouteListKeepingView
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::QSOrmProject.RepresentationTreeView treeRouteLists;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button buttonOpen;

		private global::Gtk.Button buttonRefresh;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.RouteListKeepingView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.RouteListKeepingView";
			// Container child Vodovoz.RouteListKeepingView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeRouteLists = new global::QSOrmProject.RepresentationTreeView();
			this.treeRouteLists.CanFocus = true;
			this.treeRouteLists.Name = "treeRouteLists";
			this.GtkScrolledWindow.Add(this.treeRouteLists);
			this.vbox2.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonOpen = new global::Gtk.Button();
			this.buttonOpen.CanFocus = true;
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.UseUnderline = true;
			this.buttonOpen.Label = global::Mono.Unix.Catalog.GetString("Открыть");
			global::Gtk.Image w3 = new global::Gtk.Image();
			this.buttonOpen.Image = w3;
			this.hbox1.Add(this.buttonOpen);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonOpen]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonRefresh = new global::Gtk.Button();
			this.buttonRefresh.CanFocus = true;
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.UseUnderline = true;
			this.buttonRefresh.Label = global::Mono.Unix.Catalog.GetString("Обновить");
			global::Gtk.Image w5 = new global::Gtk.Image();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-refresh", global::Gtk.IconSize.Menu);
			this.buttonRefresh.Image = w5;
			this.hbox1.Add(this.buttonRefresh);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonRefresh]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.Add(this.vbox2);
			if((this.Child != null)) {
				this.Child.ShowAll();
			}
			this.Hide();
			this.treeRouteLists.RowActivated += new global::Gtk.RowActivatedHandler(this.OnRouteListActivated);
			this.buttonOpen.Clicked += new global::System.EventHandler(this.OnButtonOpenClicked);
			this.buttonRefresh.Clicked += new global::System.EventHandler(this.OnButtonRefreshClicked);
		}
	}
}
