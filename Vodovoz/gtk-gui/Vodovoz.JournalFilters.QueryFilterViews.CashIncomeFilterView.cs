﻿
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.JournalFilters.QueryFilterViews
{
	public partial class CashIncomeFilterView
	{
		private global::Gtk.Table table1;

		private global::QS.Widgets.GtkUI.RepresentationEntry entryEmployee;

		private global::QS.Widgets.GtkUI.RepresentationEntry entryExpenseCategory;

		private global::QS.Widgets.GtkUI.RepresentationEntry entryIncomeCategory;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::QS.Widgets.GtkUI.DateRangePicker ydateperiodPicker;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.JournalFilters.QueryFilterViews.CashIncomeFilterView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.JournalFilters.QueryFilterViews.CashIncomeFilterView";
			// Container child Vodovoz.JournalFilters.QueryFilterViews.CashIncomeFilterView.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(2)), ((uint)(4)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.entryEmployee = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.entryEmployee.Events = ((global::Gdk.EventMask)(256));
			this.entryEmployee.Name = "entryEmployee";
			this.table1.Add(this.entryEmployee);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.entryEmployee]));
			w1.TopAttach = ((uint)(1));
			w1.BottomAttach = ((uint)(2));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryExpenseCategory = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.entryExpenseCategory.Events = ((global::Gdk.EventMask)(256));
			this.entryExpenseCategory.Name = "entryExpenseCategory";
			this.table1.Add(this.entryExpenseCategory);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.entryExpenseCategory]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.LeftAttach = ((uint)(3));
			w2.RightAttach = ((uint)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryIncomeCategory = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.entryIncomeCategory.Events = ((global::Gdk.EventMask)(256));
			this.entryIncomeCategory.Name = "entryIncomeCategory";
			this.table1.Add(this.entryIncomeCategory);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.entryIncomeCategory]));
			w3.LeftAttach = ((uint)(3));
			w3.RightAttach = ((uint)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Статья дохода:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w4.LeftAttach = ((uint)(2));
			w4.RightAttach = ((uint)(3));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Статья расхода:");
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w5.TopAttach = ((uint)(1));
			w5.BottomAttach = ((uint)(2));
			w5.LeftAttach = ((uint)(2));
			w5.RightAttach = ((uint)(3));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("За период:");
			this.table1.Add(this.label4);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.label4]));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Сотрудник:");
			this.table1.Add(this.label5);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.label5]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ydateperiodPicker = new global::QS.Widgets.GtkUI.DateRangePicker();
			this.ydateperiodPicker.Events = ((global::Gdk.EventMask)(256));
			this.ydateperiodPicker.Name = "ydateperiodPicker";
			this.ydateperiodPicker.StartDate = new global::System.DateTime(0);
			this.ydateperiodPicker.EndDate = new global::System.DateTime(0);
			this.table1.Add(this.ydateperiodPicker);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.ydateperiodPicker]));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
