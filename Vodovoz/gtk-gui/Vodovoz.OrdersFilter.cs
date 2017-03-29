
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class OrdersFilter
	{
		private global::Gtk.Table table1;

		private global::Gtk.CheckButton checkOnlySelfDelivery;

		private global::Gtk.CheckButton checkWithoutCoordinates;

		private global::Gtk.CheckButton checkWithoutSelfDelivery;

		private global::QSWidgetLib.DatePeriodPicker dateperiodOrders;

		private global::QSOrmProject.EntryReferenceVM entryreferenceClient;

		private global::QSOrmProject.EntryReferenceVM entryreferencePoint;

		private global::Gamma.Widgets.yEnumComboBox enumcomboStatus;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.OrdersFilter
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.OrdersFilter";
			// Container child Vodovoz.OrdersFilter.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(3)), ((uint)(4)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.checkOnlySelfDelivery = new global::Gtk.CheckButton();
			this.checkOnlySelfDelivery.CanFocus = true;
			this.checkOnlySelfDelivery.Name = "checkOnlySelfDelivery";
			this.checkOnlySelfDelivery.Label = global::Mono.Unix.Catalog.GetString("Только самовывоз");
			this.checkOnlySelfDelivery.DrawIndicator = true;
			this.checkOnlySelfDelivery.UseUnderline = true;
			this.table1.Add(this.checkOnlySelfDelivery);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.checkOnlySelfDelivery]));
			w1.TopAttach = ((uint)(2));
			w1.BottomAttach = ((uint)(3));
			w1.LeftAttach = ((uint)(2));
			w1.RightAttach = ((uint)(3));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.checkWithoutCoordinates = new global::Gtk.CheckButton();
			this.checkWithoutCoordinates.CanFocus = true;
			this.checkWithoutCoordinates.Name = "checkWithoutCoordinates";
			this.checkWithoutCoordinates.Label = global::Mono.Unix.Catalog.GetString("Только без координат");
			this.checkWithoutCoordinates.DrawIndicator = true;
			this.checkWithoutCoordinates.UseUnderline = true;
			this.table1.Add(this.checkWithoutCoordinates);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.checkWithoutCoordinates]));
			w2.TopAttach = ((uint)(2));
			w2.BottomAttach = ((uint)(3));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.checkWithoutSelfDelivery = new global::Gtk.CheckButton();
			this.checkWithoutSelfDelivery.CanFocus = true;
			this.checkWithoutSelfDelivery.Name = "checkWithoutSelfDelivery";
			this.checkWithoutSelfDelivery.Label = global::Mono.Unix.Catalog.GetString("Без самовывоза");
			this.checkWithoutSelfDelivery.DrawIndicator = true;
			this.checkWithoutSelfDelivery.UseUnderline = true;
			this.table1.Add(this.checkWithoutSelfDelivery);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.checkWithoutSelfDelivery]));
			w3.TopAttach = ((uint)(2));
			w3.BottomAttach = ((uint)(3));
			w3.LeftAttach = ((uint)(3));
			w3.RightAttach = ((uint)(4));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.dateperiodOrders = new global::QSWidgetLib.DatePeriodPicker();
			this.dateperiodOrders.Events = ((global::Gdk.EventMask)(256));
			this.dateperiodOrders.Name = "dateperiodOrders";
			this.dateperiodOrders.StartDate = new global::System.DateTime(0);
			this.dateperiodOrders.EndDate = new global::System.DateTime(0);
			this.table1.Add(this.dateperiodOrders);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.dateperiodOrders]));
			w4.LeftAttach = ((uint)(3));
			w4.RightAttach = ((uint)(4));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryreferenceClient = null;
			this.table1.Add(this.entryreferenceClient);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.entryreferenceClient]));
			w5.TopAttach = ((uint)(1));
			w5.BottomAttach = ((uint)(2));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryreferencePoint = null;
			this.table1.Add(this.entryreferencePoint);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.entryreferencePoint]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.LeftAttach = ((uint)(3));
			w6.RightAttach = ((uint)(4));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.enumcomboStatus = new global::Gamma.Widgets.yEnumComboBox();
			this.enumcomboStatus.Name = "enumcomboStatus";
			this.enumcomboStatus.ShowSpecialStateAll = true;
			this.enumcomboStatus.ShowSpecialStateNot = false;
			this.enumcomboStatus.UseShortTitle = false;
			this.enumcomboStatus.DefaultFirst = false;
			this.table1.Add(this.enumcomboStatus);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.enumcomboStatus]));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Статус:");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Контрагент:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w9.TopAttach = ((uint)(1));
			w9.BottomAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Точка доставки:");
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w10.TopAttach = ((uint)(1));
			w10.BottomAttach = ((uint)(2));
			w10.LeftAttach = ((uint)(2));
			w10.RightAttach = ((uint)(3));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Период:");
			this.table1.Add(this.label4);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.label4]));
			w11.LeftAttach = ((uint)(2));
			w11.RightAttach = ((uint)(3));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.enumcomboStatus.Changed += new global::System.EventHandler(this.OnEnumcomboStatusChanged);
			this.dateperiodOrders.PeriodChanged += new global::System.EventHandler(this.OnDateperiodOrdersPeriodChanged);
			this.checkWithoutSelfDelivery.Toggled += new global::System.EventHandler(this.OnCheckWithoutSelfDeliveryToggled);
			this.checkWithoutCoordinates.Toggled += new global::System.EventHandler(this.OnCheckWithoutCoordinatesToggled);
			this.checkOnlySelfDelivery.Toggled += new global::System.EventHandler(this.OnCheckOnlySelfDeliveryToggled);
		}
	}
}
