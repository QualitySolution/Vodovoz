
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class RouteListCreateItemsView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewItems;

		private global::Gtk.HBox hbox1;

		private global::QSOrmProject.EnumMenuButton enumbuttonAddOrder;

		private global::Gtk.Button buttonDelete;

		private global::Gtk.Button buttonOpenOrder;

		private global::Gtk.Label labelSum;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.RouteListCreateItemsView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.RouteListCreateItemsView";
			// Container child Vodovoz.RouteListCreateItemsView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewItems = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewItems.CanFocus = true;
			this.ytreeviewItems.Name = "ytreeviewItems";
			this.ytreeviewItems.Reorderable = true;
			this.GtkScrolledWindow.Add(this.ytreeviewItems);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.enumbuttonAddOrder = null;
			this.hbox1.Add(this.enumbuttonAddOrder);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.enumbuttonAddOrder]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonDelete = new global::Gtk.Button();
			this.buttonDelete.Sensitive = false;
			this.buttonDelete.CanFocus = true;
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.UseUnderline = true;
			this.buttonDelete.Label = global::Mono.Unix.Catalog.GetString("Удалить");
			global::Gtk.Image w4 = new global::Gtk.Image();
			w4.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.buttonDelete.Image = w4;
			this.hbox1.Add(this.buttonDelete);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonDelete]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonOpenOrder = new global::Gtk.Button();
			this.buttonOpenOrder.Sensitive = false;
			this.buttonOpenOrder.CanFocus = true;
			this.buttonOpenOrder.Name = "buttonOpenOrder";
			this.buttonOpenOrder.UseUnderline = true;
			this.buttonOpenOrder.Label = global::Mono.Unix.Catalog.GetString("Открыть заказ");
			this.hbox1.Add(this.buttonOpenOrder);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonOpenOrder]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelSum = new global::Gtk.Label();
			this.labelSum.Name = "labelSum";
			this.labelSum.Xalign = 1F;
			this.hbox1.Add(this.labelSum);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelSum]));
			w7.PackType = ((global::Gtk.PackType)(1));
			w7.Position = 3;
			w7.Expand = false;
			w7.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.ytreeviewItems.RowActivated += new global::Gtk.RowActivatedHandler(this.OnYtreeviewItemsRowActivated);
			this.buttonDelete.Clicked += new global::System.EventHandler(this.OnButtonDeleteClicked);
			this.buttonOpenOrder.Clicked += new global::System.EventHandler(this.OnButtonOpenOrderClicked);
		}
	}
}
