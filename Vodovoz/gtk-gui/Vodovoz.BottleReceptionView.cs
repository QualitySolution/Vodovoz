
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class BottleReceptionView
	{
		private global::Gtk.Frame frameBottles;

		private global::Gtk.Alignment GtkAlignment2;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::QSOrmProject.RepresentationTreeView ytreeBottles;

		private global::Gtk.Label GtkLabel3;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.BottleReceptionView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.BottleReceptionView";
			// Container child Vodovoz.BottleReceptionView.Gtk.Container+ContainerChild
			this.frameBottles = new global::Gtk.Frame();
			this.frameBottles.Name = "frameBottles";
			this.frameBottles.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frameBottles.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment2.Name = "GtkAlignment2";
			this.GtkAlignment2.LeftPadding = ((uint)(12));
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeBottles = null;
			this.GtkScrolledWindow.Add(this.ytreeBottles);
			this.GtkAlignment2.Add(this.GtkScrolledWindow);
			this.frameBottles.Add(this.GtkAlignment2);
			this.GtkLabel3 = new global::Gtk.Label();
			this.GtkLabel3.Name = "GtkLabel3";
			this.GtkLabel3.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Тара на возврат</b>");
			this.GtkLabel3.UseMarkup = true;
			this.frameBottles.LabelWidget = this.GtkLabel3;
			this.Add(this.frameBottles);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
