
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Mango.Incoming
{
	public partial class IncomingView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Gamma.GtkWidgets.yLabel labelNumber;

		private global::Gamma.GtkWidgets.yLabel labelTime;

		private global::Gamma.GtkWidgets.yLabel labelName;

		private global::Gtk.HSeparator hseparator1;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Mango.Incoming.IncomingView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Mango.Incoming.IncomingView";
			// Container child Vodovoz.Views.Mango.Incoming.IncomingView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelNumber = new global::Gamma.GtkWidgets.yLabel();
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Xalign = 0F;
			this.labelNumber.LabelProp = global::Mono.Unix.Catalog.GetString("ylabel1");
			this.labelNumber.UseMarkup = true;
			this.hbox1.Add(this.labelNumber);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelNumber]));
			w1.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelTime = new global::Gamma.GtkWidgets.yLabel();
			this.labelTime.Name = "labelTime";
			this.labelTime.LabelProp = global::Mono.Unix.Catalog.GetString("ylabel2");
			this.hbox1.Add(this.labelTime);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelTime]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.labelName = new global::Gamma.GtkWidgets.yLabel();
			this.labelName.Name = "labelName";
			this.labelName.Xalign = 0F;
			this.labelName.LabelProp = global::Mono.Unix.Catalog.GetString("ylabel3");
			this.vbox1.Add(this.labelName);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.labelName]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator();
			this.hseparator1.Name = "hseparator1";
			this.vbox1.Add(this.hseparator1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hseparator1]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
