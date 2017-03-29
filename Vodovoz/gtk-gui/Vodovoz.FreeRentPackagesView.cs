
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class FreeRentPackagesView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.Label label10;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView treeRentPackages;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button buttonAddByType;

		private global::Gtk.Button buttonAdd;

		private global::Gtk.Button buttonDelete;

		private global::Gtk.Label label5;

		private global::Gtk.Label labelTotalDeposit;

		private global::Gtk.Label label6;

		private global::Gtk.Label labelTotalWaterAmount;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.FreeRentPackagesView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.FreeRentPackagesView";
			// Container child Vodovoz.FreeRentPackagesView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.Xalign = 0F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("Список оборудования");
			this.vbox1.Add(this.label10);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.label10]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeRentPackages = new global::Gamma.GtkWidgets.yTreeView();
			this.treeRentPackages.CanFocus = true;
			this.treeRentPackages.Name = "treeRentPackages";
			this.GtkScrolledWindow.Add(this.treeRentPackages);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w3.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonAddByType = new global::Gtk.Button();
			this.buttonAddByType.CanFocus = true;
			this.buttonAddByType.Name = "buttonAddByType";
			this.buttonAddByType.UseUnderline = true;
			this.buttonAddByType.Label = global::Mono.Unix.Catalog.GetString("Подобрать по типу");
			global::Gtk.Image w4 = new global::Gtk.Image();
			w4.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.buttonAddByType.Image = w4;
			this.hbox1.Add(this.buttonAddByType);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonAddByType]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonAdd = new global::Gtk.Button();
			this.buttonAdd.CanFocus = true;
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.UseUnderline = true;
			this.buttonAdd.Label = global::Mono.Unix.Catalog.GetString("Добавить вручную");
			global::Gtk.Image w6 = new global::Gtk.Image();
			w6.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.buttonAdd.Image = w6;
			this.hbox1.Add(this.buttonAdd);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonAdd]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonDelete = new global::Gtk.Button();
			this.buttonDelete.CanFocus = true;
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.UseUnderline = true;
			this.buttonDelete.Label = global::Mono.Unix.Catalog.GetString("Удалить");
			global::Gtk.Image w8 = new global::Gtk.Image();
			w8.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.buttonDelete.Image = w8;
			this.hbox1.Add(this.buttonDelete);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonDelete]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Общий залог:");
			this.hbox1.Add(this.label5);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label5]));
			w10.Position = 3;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelTotalDeposit = new global::Gtk.Label();
			this.labelTotalDeposit.Name = "labelTotalDeposit";
			this.labelTotalDeposit.LabelProp = global::Mono.Unix.Catalog.GetString("#Deposit");
			this.hbox1.Add(this.labelTotalDeposit);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelTotalDeposit]));
			w11.Position = 4;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Минимальный заказ:");
			this.hbox1.Add(this.label6);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label6]));
			w12.Position = 5;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelTotalWaterAmount = new global::Gtk.Label();
			this.labelTotalWaterAmount.Name = "labelTotalWaterAmount";
			this.labelTotalWaterAmount.LabelProp = global::Mono.Unix.Catalog.GetString("#WaterAmount");
			this.hbox1.Add(this.labelTotalWaterAmount);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelTotalWaterAmount]));
			w13.Position = 6;
			w13.Expand = false;
			w13.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonAddByType.Clicked += new global::System.EventHandler(this.OnButtonAddByTypeClicked);
			this.buttonAdd.Clicked += new global::System.EventHandler(this.OnButtonAddClicked);
			this.buttonDelete.Clicked += new global::System.EventHandler(this.OnButtonDeleteClicked);
		}
	}
}
