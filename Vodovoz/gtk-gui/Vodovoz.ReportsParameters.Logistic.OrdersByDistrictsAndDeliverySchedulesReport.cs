﻿
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ReportsParameters.Logistic
{
	public partial class OrdersByDistrictsAndDeliverySchedulesReport
	{
		private global::Gtk.Table table1;

		private global::Gtk.Button buttonRun;

		private global::Gamma.GtkWidgets.yLabel lblDate;

		private global::QS.Widgets.GtkUI.DatePicker pkrDate;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ReportsParameters.Logistic.OrdersByDistrictsAndDeliverySchedulesReport
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ReportsParameters.Logistic.OrdersByDistrictsAndDeliverySchedulesReport";
			// Container child Vodovoz.ReportsParameters.Logistic.OrdersByDistrictsAndDeliverySchedulesReport.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(4)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			this.table1.BorderWidth = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.buttonRun = new global::Gtk.Button();
			this.buttonRun.CanFocus = true;
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.UseUnderline = true;
			this.buttonRun.Label = global::Mono.Unix.Catalog.GetString("Сформировать отчет");
			this.table1.Add(this.buttonRun);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.buttonRun]));
			w1.TopAttach = ((uint)(3));
			w1.BottomAttach = ((uint)(4));
			w1.RightAttach = ((uint)(2));
			w1.XOptions = ((global::Gtk.AttachOptions)(0));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblDate = new global::Gamma.GtkWidgets.yLabel();
			this.lblDate.Name = "lblDate";
			this.lblDate.LabelProp = global::Mono.Unix.Catalog.GetString("Дата:");
			this.table1.Add(this.lblDate);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.lblDate]));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.pkrDate = new global::QS.Widgets.GtkUI.DatePicker();
			this.pkrDate.Events = ((global::Gdk.EventMask)(256));
			this.pkrDate.Name = "pkrDate";
			this.pkrDate.WithTime = false;
			this.pkrDate.Date = new global::System.DateTime(0);
			this.pkrDate.IsEditable = true;
			this.pkrDate.AutoSeparation = false;
			this.table1.Add(this.pkrDate);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.pkrDate]));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.pkrDate.DateChangedByUser += new global::System.EventHandler(this.OnPkrDateDateChangedByUser);
			this.buttonRun.Clicked += new global::System.EventHandler(this.OnButtonRunClicked);
		}
	}
}
