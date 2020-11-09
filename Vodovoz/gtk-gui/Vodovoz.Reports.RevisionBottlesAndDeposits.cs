
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Reports
{
	public partial class RevisionBottlesAndDeposits
	{
		private global::Gtk.Table table1;

		private global::Gtk.Button buttonRun;

		private global::QS.Widgets.GtkUI.DateRangePicker dateperiodpicker1;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry entityViewModelEntryCounterparty;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::QS.Widgets.GtkUI.RepresentationEntry referenceDeliveryPoint;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Reports.RevisionBottlesAndDeposits
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Reports.RevisionBottlesAndDeposits";
			// Container child Vodovoz.Reports.RevisionBottlesAndDeposits.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(6)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			this.table1.BorderWidth = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.buttonRun = new global::Gtk.Button();
			this.buttonRun.Sensitive = false;
			this.buttonRun.CanFocus = true;
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.UseUnderline = true;
			this.buttonRun.Label = global::Mono.Unix.Catalog.GetString("Сформировать отчет");
			this.table1.Add(this.buttonRun);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.buttonRun]));
			w1.TopAttach = ((uint)(5));
			w1.BottomAttach = ((uint)(6));
			w1.RightAttach = ((uint)(2));
			w1.XOptions = ((global::Gtk.AttachOptions)(0));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.dateperiodpicker1 = new global::QS.Widgets.GtkUI.DateRangePicker();
			this.dateperiodpicker1.Events = ((global::Gdk.EventMask)(256));
			this.dateperiodpicker1.Name = "dateperiodpicker1";
			this.dateperiodpicker1.StartDate = new global::System.DateTime(0);
			this.dateperiodpicker1.EndDate = new global::System.DateTime(0);
			this.table1.Add(this.dateperiodpicker1);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.dateperiodpicker1]));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entityViewModelEntryCounterparty = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.entityViewModelEntryCounterparty.Events = ((global::Gdk.EventMask)(256));
			this.entityViewModelEntryCounterparty.Name = "entityViewModelEntryCounterparty";
			this.entityViewModelEntryCounterparty.CanEditReference = true;
			this.table1.Add(this.entityViewModelEntryCounterparty);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.entityViewModelEntryCounterparty]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Период:");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Контрагент:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w5.TopAttach = ((uint)(1));
			w5.BottomAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Точка доставки:");
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w6.TopAttach = ((uint)(2));
			w6.BottomAttach = ((uint)(3));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.referenceDeliveryPoint = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.referenceDeliveryPoint.Sensitive = false;
			this.referenceDeliveryPoint.Events = ((global::Gdk.EventMask)(256));
			this.referenceDeliveryPoint.Name = "referenceDeliveryPoint";
			this.table1.Add(this.referenceDeliveryPoint);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.referenceDeliveryPoint]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.dateperiodpicker1.Hide();
			this.label1.Hide();
			this.Hide();
			this.entityViewModelEntryCounterparty.Changed += new global::System.EventHandler(this.OnEntryCounterpartyChanged);
			this.dateperiodpicker1.PeriodChanged += new global::System.EventHandler(this.OnDateperiodpicker1PeriodChanged);
			this.buttonRun.Clicked += new global::System.EventHandler(this.OnButtonRunClicked);
		}
	}
}
