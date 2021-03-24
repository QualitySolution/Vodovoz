
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ReportsParameters.Retail
{
	public partial class CounterpartyReport
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label labelCreate;

		private global::Gamma.Widgets.yDatePeriodPicker ydateperiodpickerCreate;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label labelSalesChannel;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry yEntitySalesChannel;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Label labelDistrict;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry yEntityDistrict;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Label label3;

		private global::Gamma.Widgets.yEnumComboBox yenumPaymentType;

		private global::Gtk.Button buttonCreateReport;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ReportsParameters.Retail.CounterpartyReport
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ReportsParameters.Retail.CounterpartyReport";
			// Container child Vodovoz.ReportsParameters.Retail.CounterpartyReport.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelCreate = new global::Gtk.Label();
			this.labelCreate.Name = "labelCreate";
			this.labelCreate.Xalign = 0F;
			this.labelCreate.LabelProp = global::Mono.Unix.Catalog.GetString("Период создания:");
			this.hbox1.Add(this.labelCreate);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelCreate]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.ydateperiodpickerCreate = new global::Gamma.Widgets.yDatePeriodPicker();
			this.ydateperiodpickerCreate.Events = ((global::Gdk.EventMask)(256));
			this.ydateperiodpickerCreate.Name = "ydateperiodpickerCreate";
			this.ydateperiodpickerCreate.StartDate = new global::System.DateTime(0);
			this.ydateperiodpickerCreate.EndDate = new global::System.DateTime(0);
			this.hbox1.Add(this.ydateperiodpickerCreate);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.ydateperiodpickerCreate]));
			w2.Position = 1;
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.labelSalesChannel = new global::Gtk.Label();
			this.labelSalesChannel.Name = "labelSalesChannel";
			this.labelSalesChannel.Xalign = 0F;
			this.labelSalesChannel.LabelProp = global::Mono.Unix.Catalog.GetString("Канал сбыта:");
			this.hbox3.Add(this.labelSalesChannel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.labelSalesChannel]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.yEntitySalesChannel = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.yEntitySalesChannel.Events = ((global::Gdk.EventMask)(256));
			this.yEntitySalesChannel.Name = "yEntitySalesChannel";
			this.yEntitySalesChannel.CanEditReference = false;
			this.hbox3.Add(this.yEntitySalesChannel);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.yEntitySalesChannel]));
			w5.Position = 1;
			this.vbox2.Add(this.hbox3);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox3]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.labelDistrict = new global::Gtk.Label();
			this.labelDistrict.Name = "labelDistrict";
			this.labelDistrict.LabelProp = global::Mono.Unix.Catalog.GetString("Район:");
			this.hbox5.Add(this.labelDistrict);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.labelDistrict]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.yEntityDistrict = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.yEntityDistrict.Events = ((global::Gdk.EventMask)(256));
			this.yEntityDistrict.Name = "yEntityDistrict";
			this.yEntityDistrict.CanEditReference = false;
			this.hbox5.Add(this.yEntityDistrict);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.yEntityDistrict]));
			w8.Position = 1;
			this.vbox2.Add(this.hbox5);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox5]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Форма оплаты:");
			this.hbox7.Add(this.label3);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.label3]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.yenumPaymentType = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumPaymentType.Name = "yenumPaymentType";
			this.yenumPaymentType.ShowSpecialStateAll = false;
			this.yenumPaymentType.ShowSpecialStateNot = false;
			this.yenumPaymentType.UseShortTitle = false;
			this.yenumPaymentType.DefaultFirst = false;
			this.hbox7.Add(this.yenumPaymentType);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.yenumPaymentType]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			this.vbox2.Add(this.hbox7);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox7]));
			w12.Position = 3;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonCreateReport = new global::Gtk.Button();
			this.buttonCreateReport.CanFocus = true;
			this.buttonCreateReport.Name = "buttonCreateReport";
			this.buttonCreateReport.UseUnderline = true;
			this.buttonCreateReport.Label = global::Mono.Unix.Catalog.GetString("Сформировать отчет");
			this.vbox2.Add(this.buttonCreateReport);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonCreateReport]));
			w13.Position = 5;
			w13.Expand = false;
			w13.Fill = false;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
