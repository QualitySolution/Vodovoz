
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Reports
{
	public partial class DeliveryAnalyticsReportView
	{
		private global::Gamma.GtkWidgets.yTable ytable1;

		private global::Gamma.GtkWidgets.yButton btnHelp;

		private global::QS.Widgets.GtkUI.DateRangePicker deliveryDate;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry districtEntry;

		private global::Gamma.GtkWidgets.yButton exportBtn;

		private global::Gtk.HBox hbox3;

		private global::Gamma.GtkWidgets.yTreeView treeviewWeekDay;

		private global::Gtk.VBox vbox1;

		private global::Gamma.GtkWidgets.yButton btnAllDay;

		private global::Gamma.GtkWidgets.yButton btnUnAllDay;

		private global::Gamma.GtkWidgets.yTreeView treeviewGeographic;

		private global::Gamma.GtkWidgets.yTreeView treeviewPartCity;

		private global::Gamma.GtkWidgets.yTreeView treeviewWave;

		private global::Gamma.GtkWidgets.yLabel ylabel1;

		private global::Gamma.GtkWidgets.yLabel ylabel2;

		private global::Gamma.GtkWidgets.yLabel ylabel3;

		private global::Gamma.GtkWidgets.yLabel ylabel4;

		private global::Gamma.GtkWidgets.yLabel ylabel5;

		private global::Gamma.GtkWidgets.yLabel ylabel6;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Reports.DeliveryAnalyticsReportView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Reports.DeliveryAnalyticsReportView";
			// Container child Vodovoz.Views.Reports.DeliveryAnalyticsReportView.Gtk.Container+ContainerChild
			this.ytable1 = new global::Gamma.GtkWidgets.yTable();
			this.ytable1.Name = "ytable1";
			this.ytable1.NRows = ((uint)(7));
			this.ytable1.NColumns = ((uint)(2));
			this.ytable1.RowSpacing = ((uint)(6));
			this.ytable1.ColumnSpacing = ((uint)(6));
			// Container child ytable1.Gtk.Table+TableChild
			this.btnHelp = new global::Gamma.GtkWidgets.yButton();
			this.btnHelp.TooltipMarkup = "Справка по работе с отчетом.";
			this.btnHelp.CanFocus = true;
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.UseUnderline = true;
			this.btnHelp.Relief = ((global::Gtk.ReliefStyle)(1));
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-help", global::Gtk.IconSize.Menu);
			this.btnHelp.Image = w1;
			this.ytable1.Add(this.btnHelp);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.ytable1[this.btnHelp]));
			w2.TopAttach = ((uint)(6));
			w2.BottomAttach = ((uint)(7));
			w2.XOptions = ((global::Gtk.AttachOptions)(0));
			w2.YOptions = ((global::Gtk.AttachOptions)(1));
			// Container child ytable1.Gtk.Table+TableChild
			this.deliveryDate = new global::QS.Widgets.GtkUI.DateRangePicker();
			this.deliveryDate.Events = ((global::Gdk.EventMask)(256));
			this.deliveryDate.Name = "deliveryDate";
			this.deliveryDate.StartDate = new global::System.DateTime(0);
			this.deliveryDate.EndDate = new global::System.DateTime(0);
			this.ytable1.Add(this.deliveryDate);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.ytable1[this.deliveryDate]));
			w3.TopAttach = ((uint)(3));
			w3.BottomAttach = ((uint)(4));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.districtEntry = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.districtEntry.Events = ((global::Gdk.EventMask)(256));
			this.districtEntry.Name = "districtEntry";
			this.districtEntry.CanEditReference = false;
			this.ytable1.Add(this.districtEntry);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.ytable1[this.districtEntry]));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.exportBtn = new global::Gamma.GtkWidgets.yButton();
			this.exportBtn.CanFocus = true;
			this.exportBtn.Name = "exportBtn";
			this.exportBtn.UseUnderline = true;
			this.exportBtn.Label = global::Mono.Unix.Catalog.GetString("Экспорт отчёта");
			this.ytable1.Add(this.exportBtn);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.ytable1[this.exportBtn]));
			w5.TopAttach = ((uint)(6));
			w5.BottomAttach = ((uint)(7));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.treeviewWeekDay = new global::Gamma.GtkWidgets.yTreeView();
			this.treeviewWeekDay.CanFocus = true;
			this.treeviewWeekDay.Name = "treeviewWeekDay";
			this.hbox3.Add(this.treeviewWeekDay);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.treeviewWeekDay]));
			w6.Position = 0;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.btnAllDay = new global::Gamma.GtkWidgets.yButton();
			this.btnAllDay.CanFocus = true;
			this.btnAllDay.Name = "btnAllDay";
			this.btnAllDay.UseUnderline = true;
			this.btnAllDay.Label = global::Mono.Unix.Catalog.GetString("Выбрать все");
			this.vbox1.Add(this.btnAllDay);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.btnAllDay]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.btnUnAllDay = new global::Gamma.GtkWidgets.yButton();
			this.btnUnAllDay.CanFocus = true;
			this.btnUnAllDay.Name = "btnUnAllDay";
			this.btnUnAllDay.UseUnderline = true;
			this.btnUnAllDay.Label = global::Mono.Unix.Catalog.GetString("Снять выбор");
			this.vbox1.Add(this.btnUnAllDay);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.btnUnAllDay]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.hbox3.Add(this.vbox1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vbox1]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.ytable1.Add(this.hbox3);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.ytable1[this.hbox3]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.treeviewGeographic = new global::Gamma.GtkWidgets.yTreeView();
			this.treeviewGeographic.CanFocus = true;
			this.treeviewGeographic.Name = "treeviewGeographic";
			this.ytable1.Add(this.treeviewGeographic);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.ytable1[this.treeviewGeographic]));
			w11.TopAttach = ((uint)(5));
			w11.BottomAttach = ((uint)(6));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.treeviewPartCity = new global::Gamma.GtkWidgets.yTreeView();
			this.treeviewPartCity.CanFocus = true;
			this.treeviewPartCity.Name = "treeviewPartCity";
			this.ytable1.Add(this.treeviewPartCity);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.ytable1[this.treeviewPartCity]));
			w12.TopAttach = ((uint)(1));
			w12.BottomAttach = ((uint)(2));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.treeviewWave = new global::Gamma.GtkWidgets.yTreeView();
			this.treeviewWave.CanFocus = true;
			this.treeviewWave.Name = "treeviewWave";
			this.ytable1.Add(this.treeviewWave);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.ytable1[this.treeviewWave]));
			w13.TopAttach = ((uint)(4));
			w13.BottomAttach = ((uint)(5));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ylabel1 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel1.Name = "ylabel1";
			this.ylabel1.Xalign = 1F;
			this.ylabel1.LabelProp = global::Mono.Unix.Catalog.GetString("Район:");
			this.ytable1.Add(this.ylabel1);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ylabel1]));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ylabel2 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel2.Name = "ylabel2";
			this.ylabel2.Xalign = 1F;
			this.ylabel2.LabelProp = global::Mono.Unix.Catalog.GetString("Часть:");
			this.ytable1.Add(this.ylabel2);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ylabel2]));
			w15.TopAttach = ((uint)(1));
			w15.BottomAttach = ((uint)(2));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ylabel3 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel3.Name = "ylabel3";
			this.ylabel3.Xalign = 1F;
			this.ylabel3.LabelProp = global::Mono.Unix.Catalog.GetString("День недели:");
			this.ytable1.Add(this.ylabel3);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ylabel3]));
			w16.TopAttach = ((uint)(2));
			w16.BottomAttach = ((uint)(3));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ylabel4 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel4.Name = "ylabel4";
			this.ylabel4.Xalign = 1F;
			this.ylabel4.LabelProp = global::Mono.Unix.Catalog.GetString("Дата доставки:");
			this.ytable1.Add(this.ylabel4);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ylabel4]));
			w17.TopAttach = ((uint)(3));
			w17.BottomAttach = ((uint)(4));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ylabel5 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel5.Name = "ylabel5";
			this.ylabel5.Xalign = 1F;
			this.ylabel5.LabelProp = global::Mono.Unix.Catalog.GetString("Волна:");
			this.ytable1.Add(this.ylabel5);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ylabel5]));
			w18.TopAttach = ((uint)(4));
			w18.BottomAttach = ((uint)(5));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child ytable1.Gtk.Table+TableChild
			this.ylabel6 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel6.Name = "ylabel6";
			this.ylabel6.Xalign = 1F;
			this.ylabel6.LabelProp = global::Mono.Unix.Catalog.GetString("Юг/Север:");
			this.ytable1.Add(this.ylabel6);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.ytable1[this.ylabel6]));
			w19.TopAttach = ((uint)(5));
			w19.BottomAttach = ((uint)(6));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.ytable1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.exportBtn.Clicked += new global::System.EventHandler(this.OnExportBtnClicked);
		}
	}
}
