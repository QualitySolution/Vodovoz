
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class RouteListMileageCheckView
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::QSOrmProject.RepresentationTreeView treeRouteLists;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button buttonOpen;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.RouteListMileageCheckView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.RouteListMileageCheckView";
			// Container child Vodovoz.RouteListMileageCheckView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeRouteLists = null;
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
			this.buttonOpen.Sensitive = false;
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
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonOpen.Clicked += new global::System.EventHandler(this.OnButtonOpenClicked);
		}
	}
}
