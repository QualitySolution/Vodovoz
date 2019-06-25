
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class CashDocumentsFilter
	{
		private global::Gtk.Table table1;

		private global::Vodovoz.Core.Permissions.AccessFilteredSubdivisionSelectorWidget accessfilteredsubdivisionselectorwidget;

		private global::QSWidgetLib.DatePeriodPicker dateperiodDocs;

		private global::QS.Widgets.GtkUI.RepresentationEntry entryEmployee;

		private global::Gamma.Widgets.yEnumComboBox enumcomboDocumentType;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gamma.Widgets.yEntryReference yentryExpense;

		private global::Gamma.Widgets.yEntryReference yentryIncome;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.CashDocumentsFilter
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.CashDocumentsFilter";
			// Container child Vodovoz.CashDocumentsFilter.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(4)), ((uint)(4)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.accessfilteredsubdivisionselectorwidget = new global::Vodovoz.Core.Permissions.AccessFilteredSubdivisionSelectorWidget();
			this.accessfilteredsubdivisionselectorwidget.Events = ((global::Gdk.EventMask)(256));
			this.accessfilteredsubdivisionselectorwidget.Name = "accessfilteredsubdivisionselectorwidget";
			this.accessfilteredsubdivisionselectorwidget.NeedChooseSubdivision = false;
			this.table1.Add(this.accessfilteredsubdivisionselectorwidget);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.accessfilteredsubdivisionselectorwidget]));
			w1.TopAttach = ((uint)(3));
			w1.BottomAttach = ((uint)(4));
			w1.RightAttach = ((uint)(4));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.dateperiodDocs = new global::QSWidgetLib.DatePeriodPicker();
			this.dateperiodDocs.Events = ((global::Gdk.EventMask)(256));
			this.dateperiodDocs.Name = "dateperiodDocs";
			this.dateperiodDocs.StartDate = new global::System.DateTime(0);
			this.dateperiodDocs.EndDate = new global::System.DateTime(0);
			this.table1.Add(this.dateperiodDocs);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.dateperiodDocs]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryEmployee = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.entryEmployee.Events = ((global::Gdk.EventMask)(256));
			this.entryEmployee.Name = "entryEmployee";
			this.table1.Add(this.entryEmployee);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.entryEmployee]));
			w3.TopAttach = ((uint)(2));
			w3.BottomAttach = ((uint)(3));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.enumcomboDocumentType = new global::Gamma.Widgets.yEnumComboBox();
			this.enumcomboDocumentType.Name = "enumcomboDocumentType";
			this.enumcomboDocumentType.ShowSpecialStateAll = true;
			this.enumcomboDocumentType.ShowSpecialStateNot = false;
			this.enumcomboDocumentType.UseShortTitle = false;
			this.enumcomboDocumentType.DefaultFirst = false;
			this.table1.Add(this.enumcomboDocumentType);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.enumcomboDocumentType]));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Вид документа:");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Статья дохода:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w6.LeftAttach = ((uint)(2));
			w6.RightAttach = ((uint)(3));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Статья расхода:");
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.LeftAttach = ((uint)(2));
			w7.RightAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("За период:");
			this.table1.Add(this.label4);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.label4]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Сотрудник:");
			this.table1.Add(this.label5);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.label5]));
			w9.TopAttach = ((uint)(2));
			w9.BottomAttach = ((uint)(3));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryExpense = new global::Gamma.Widgets.yEntryReference();
			this.yentryExpense.Events = ((global::Gdk.EventMask)(256));
			this.yentryExpense.Name = "yentryExpense";
			this.table1.Add(this.yentryExpense);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryExpense]));
			w10.TopAttach = ((uint)(1));
			w10.BottomAttach = ((uint)(2));
			w10.LeftAttach = ((uint)(3));
			w10.RightAttach = ((uint)(4));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryIncome = new global::Gamma.Widgets.yEntryReference();
			this.yentryIncome.Events = ((global::Gdk.EventMask)(256));
			this.yentryIncome.Name = "yentryIncome";
			this.table1.Add(this.yentryIncome);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryIncome]));
			w11.LeftAttach = ((uint)(3));
			w11.RightAttach = ((uint)(4));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.yentryIncome.Changed += new global::System.EventHandler(this.OnYentryIncomeChanged);
			this.yentryExpense.Changed += new global::System.EventHandler(this.OnYentryExpenseChanged);
			this.enumcomboDocumentType.EnumItemSelected += new global::System.EventHandler<Gamma.Widgets.ItemSelectedEventArgs>(this.OnEnumcomboDocumentTypeEnumItemSelected);
			this.entryEmployee.Changed += new global::System.EventHandler(this.OnEntryEmployeeChanged);
			this.dateperiodDocs.PeriodChanged += new global::System.EventHandler(this.OnDateperiodDocsPeriodChanged);
		}
	}
}
