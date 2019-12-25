﻿
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ReportsParameters
{
	public partial class LastOrderByDeliveryPointReport
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label label2;

		private global::QS.Widgets.GtkUI.DatePicker ydatepicker;

		private global::Gtk.CheckButton buttonSanitary;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label label1;

		private global::QSWidgetLib.ValidatedEntry BottleDeptEntry;

		private global::Gtk.Button button36;

		private global::Gtk.Button buttonCreateRepot;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ReportsParameters.LastOrderByDeliveryPointReport
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ReportsParameters.LastOrderByDeliveryPointReport";
			// Container child Vodovoz.ReportsParameters.LastOrderByDeliveryPointReport.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Дата:");
			this.hbox3.Add(this.label2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label2]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.ydatepicker = new global::QS.Widgets.GtkUI.DatePicker();
			this.ydatepicker.Events = ((global::Gdk.EventMask)(256));
			this.ydatepicker.Name = "ydatepicker";
			this.ydatepicker.WithTime = false;
			this.ydatepicker.Date = new global::System.DateTime(0);
			this.ydatepicker.IsEditable = true;
			this.ydatepicker.AutoSeparation = false;
			this.hbox3.Add(this.ydatepicker);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.ydatepicker]));
			w2.Position = 1;
			this.vbox1.Add(this.hbox3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox3]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.buttonSanitary = new global::Gtk.CheckButton();
			this.buttonSanitary.CanFocus = true;
			this.buttonSanitary.Name = "buttonSanitary";
			this.buttonSanitary.Label = global::Mono.Unix.Catalog.GetString("Отчёт по санитарной обработке");
			this.buttonSanitary.DrawIndicator = true;
			this.buttonSanitary.UseUnderline = true;
			this.vbox1.Add(this.buttonSanitary);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.buttonSanitary]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Долг бутылей >=");
			this.hbox2.Add(this.label1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.label1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.BottleDeptEntry = new global::QSWidgetLib.ValidatedEntry();
			this.BottleDeptEntry.CanFocus = true;
			this.BottleDeptEntry.Name = "BottleDeptEntry";
			this.BottleDeptEntry.IsEditable = true;
			this.BottleDeptEntry.InvisibleChar = '•';
			this.hbox2.Add(this.BottleDeptEntry);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.BottleDeptEntry]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.button36 = new global::Gtk.Button();
			this.button36.Sensitive = false;
			this.button36.CanFocus = true;
			this.button36.Name = "button36";
			this.button36.UseUnderline = true;
			this.button36.Label = global::Mono.Unix.Catalog.GetString("Добавить в обзвон");
			global::Gtk.Image w8 = new global::Gtk.Image();
			w8.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "stock_cell-phone", global::Gtk.IconSize.Menu);
			this.button36.Image = w8;
			this.vbox1.Add(this.button36);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.button36]));
			w9.PackType = ((global::Gtk.PackType)(1));
			w9.Position = 4;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.buttonCreateRepot = new global::Gtk.Button();
			this.buttonCreateRepot.CanFocus = true;
			this.buttonCreateRepot.Name = "buttonCreateRepot";
			this.buttonCreateRepot.UseUnderline = true;
			this.buttonCreateRepot.Label = global::Mono.Unix.Catalog.GetString("Сформировать отчет");
			global::Gtk.Image w10 = new global::Gtk.Image();
			w10.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.buttonCreateRepot.Image = w10;
			this.vbox1.Add(this.buttonCreateRepot);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.buttonCreateRepot]));
			w11.PackType = ((global::Gtk.PackType)(1));
			w11.Position = 5;
			w11.Expand = false;
			w11.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonCreateRepot.Clicked += new global::System.EventHandler(this.OnButtonCreateRepotClicked);
		}
	}
}
