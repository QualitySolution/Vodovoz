
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ViewWidgets
{
	public partial class DeliveryPriceView
	{
		private global::Gtk.Table table1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewPrices;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label8;

		private global::Gtk.Label label9;

		private global::Gtk.Label labelMinBottles;

		private global::Gtk.Label labelPrice;

		private global::Gtk.Label labelSchedule;

		private global::Gamma.GtkWidgets.yLabel ylabelDistance;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ViewWidgets.DeliveryPriceView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ViewWidgets.DeliveryPriceView";
			// Container child Vodovoz.ViewWidgets.DeliveryPriceView.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(5)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewPrices = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewPrices.CanFocus = true;
			this.ytreeviewPrices.Name = "ytreeviewPrices";
			this.GtkScrolledWindow.Add(this.ytreeviewPrices);
			this.hbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.GtkScrolledWindow]));
			w2.Position = 0;
			this.table1.Add(this.hbox1);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox1]));
			w3.TopAttach = ((uint)(4));
			w3.BottomAttach = ((uint)(5));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Цена на бутыль:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w4.TopAttach = ((uint)(2));
			w4.BottomAttach = ((uint)(3));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Расстояние от склада\n(в одну сторону):");
			this.label3.Justify = ((global::Gtk.Justification)(1));
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label();
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString("Минимальное\nколичество:");
			this.table1.Add(this.label8);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.label8]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("График доставки:");
			this.table1.Add(this.label9);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.label9]));
			w7.TopAttach = ((uint)(3));
			w7.BottomAttach = ((uint)(4));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelMinBottles = new global::Gtk.Label();
			this.labelMinBottles.Name = "labelMinBottles";
			this.table1.Add(this.labelMinBottles);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.labelMinBottles]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelPrice = new global::Gtk.Label();
			this.labelPrice.Name = "labelPrice";
			this.labelPrice.Selectable = true;
			this.table1.Add(this.labelPrice);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.labelPrice]));
			w9.TopAttach = ((uint)(2));
			w9.BottomAttach = ((uint)(3));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelSchedule = new global::Gtk.Label();
			this.labelSchedule.Name = "labelSchedule";
			this.table1.Add(this.labelSchedule);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.labelSchedule]));
			w10.TopAttach = ((uint)(3));
			w10.BottomAttach = ((uint)(4));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabelDistance = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelDistance.Name = "ylabelDistance";
			this.ylabelDistance.LabelProp = global::Mono.Unix.Catalog.GetString("Нет");
			this.table1.Add(this.ylabelDistance);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabelDistance]));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.hbox1.Hide();
			this.Hide();
		}
	}
}
