
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Permissions
{
	public partial class WarehousePermissionView
	{
		private global::Gtk.HBox hbox1;

		private global::Gtk.ScrolledWindow scrolledwindow1;

		private global::Gamma.GtkWidgets.yTable tablePermissionMatrix;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Permissions.WarehousePermissionView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Permissions.WarehousePermissionView";
			// Container child Vodovoz.Views.Permissions.WarehousePermissionView.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.scrolledwindow1 = new global::Gtk.ScrolledWindow();
			this.scrolledwindow1.CanFocus = true;
			this.scrolledwindow1.Name = "scrolledwindow1";
			this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow1.Gtk.Container+ContainerChild
			global::Gtk.Viewport w1 = new global::Gtk.Viewport();
			w1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.tablePermissionMatrix = new global::Gamma.GtkWidgets.yTable();
			this.tablePermissionMatrix.Name = "tablePermissionMatrix";
			this.tablePermissionMatrix.NRows = ((uint)(3));
			this.tablePermissionMatrix.NColumns = ((uint)(3));
			this.tablePermissionMatrix.RowSpacing = ((uint)(6));
			this.tablePermissionMatrix.ColumnSpacing = ((uint)(6));
			w1.Add(this.tablePermissionMatrix);
			this.scrolledwindow1.Add(w1);
			this.hbox1.Add(this.scrolledwindow1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.scrolledwindow1]));
			w4.Position = 0;
			this.Add(this.hbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}