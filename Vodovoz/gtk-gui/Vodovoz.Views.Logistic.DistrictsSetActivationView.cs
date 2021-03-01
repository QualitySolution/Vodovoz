
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Logistic
{
	public partial class DistrictsSetActivationView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.Table table1;

		private global::Gamma.GtkWidgets.yButton ybuttonActivate;

		private global::Gamma.GtkWidgets.yLabel ylabelActivationStatus;

		private global::Gamma.GtkWidgets.yLabel ylabelCurrentDistrictsSet;

		private global::Gamma.GtkWidgets.yLabel ylabelCurrentDistrictsSetStr;

		private global::Gamma.GtkWidgets.yLabel ylabelSelectedDistrictsSet;

		private global::Gamma.GtkWidgets.yLabel ylabelSelectedDistrictsSetStr;

		private global::Gamma.GtkWidgets.yLabel ylabelPriorities;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreePrioritiesToDelete;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Logistic.DistrictsSetActivationView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Logistic.DistrictsSetActivationView";
			// Container child Vodovoz.Views.Logistic.DistrictsSetActivationView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(2)), ((uint)(4)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(10));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.ybuttonActivate = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonActivate.CanFocus = true;
			this.ybuttonActivate.Name = "ybuttonActivate";
			this.ybuttonActivate.UseUnderline = true;
			this.ybuttonActivate.Label = global::Mono.Unix.Catalog.GetString("Активировать");
			this.table1.Add(this.ybuttonActivate);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.ybuttonActivate]));
			w1.TopAttach = ((uint)(1));
			w1.BottomAttach = ((uint)(2));
			w1.LeftAttach = ((uint)(2));
			w1.RightAttach = ((uint)(3));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabelActivationStatus = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelActivationStatus.Name = "ylabelActivationStatus";
			this.table1.Add(this.ylabelActivationStatus);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabelActivationStatus]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.LeftAttach = ((uint)(3));
			w2.RightAttach = ((uint)(4));
			w2.XPadding = ((uint)(10));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabelCurrentDistrictsSet = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelCurrentDistrictsSet.HeightRequest = 37;
			this.ylabelCurrentDistrictsSet.Name = "ylabelCurrentDistrictsSet";
			this.ylabelCurrentDistrictsSet.Xalign = 1F;
			this.ylabelCurrentDistrictsSet.LabelProp = global::Mono.Unix.Catalog.GetString("Активная версия районов:");
			this.table1.Add(this.ylabelCurrentDistrictsSet);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabelCurrentDistrictsSet]));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabelCurrentDistrictsSetStr = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelCurrentDistrictsSetStr.Name = "ylabelCurrentDistrictsSetStr";
			this.table1.Add(this.ylabelCurrentDistrictsSetStr);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabelCurrentDistrictsSetStr]));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabelSelectedDistrictsSet = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelSelectedDistrictsSet.HeightRequest = 37;
			this.ylabelSelectedDistrictsSet.Name = "ylabelSelectedDistrictsSet";
			this.ylabelSelectedDistrictsSet.Xalign = 1F;
			this.ylabelSelectedDistrictsSet.LabelProp = global::Mono.Unix.Catalog.GetString("Выбранная версия районов:");
			this.table1.Add(this.ylabelSelectedDistrictsSet);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabelSelectedDistrictsSet]));
			w5.TopAttach = ((uint)(1));
			w5.BottomAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabelSelectedDistrictsSetStr = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelSelectedDistrictsSetStr.Name = "ylabelSelectedDistrictsSetStr";
			this.table1.Add(this.ylabelSelectedDistrictsSetStr);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabelSelectedDistrictsSetStr]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add(this.table1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.table1]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.ylabelPriorities = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelPriorities.Name = "ylabelPriorities";
			this.ylabelPriorities.LabelProp = global::Mono.Unix.Catalog.GetString("На новую версию не были перенесены следующие приоритеты районов водителей:");
			this.vbox1.Add(this.ylabelPriorities);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.ylabelPriorities]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreePrioritiesToDelete = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreePrioritiesToDelete.CanFocus = true;
			this.ytreePrioritiesToDelete.Name = "ytreePrioritiesToDelete";
			this.GtkScrolledWindow.Add(this.ytreePrioritiesToDelete);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w10.Position = 2;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
