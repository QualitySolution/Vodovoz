
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class CounterpartyFilter
	{
		private global::Gtk.Table table1;

		private global::Gtk.CheckButton checkIncludeArhive;

		private global::Gtk.HBox hbox1;

		private global::Gtk.CheckButton checkCustomer;

		private global::Gtk.CheckButton checkSupplier;

		private global::Gtk.CheckButton checkPartner;

		private global::Gtk.Label label1;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.CounterpartyFilter
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.CounterpartyFilter";
			// Container child Vodovoz.CounterpartyFilter.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(1)), ((uint)(3)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.checkIncludeArhive = new global::Gtk.CheckButton();
			this.checkIncludeArhive.CanFocus = true;
			this.checkIncludeArhive.Name = "checkIncludeArhive";
			this.checkIncludeArhive.Label = global::Mono.Unix.Catalog.GetString("Включая архивных");
			this.checkIncludeArhive.DrawIndicator = true;
			this.checkIncludeArhive.UseUnderline = true;
			this.table1.Add(this.checkIncludeArhive);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.checkIncludeArhive]));
			w1.LeftAttach = ((uint)(2));
			w1.RightAttach = ((uint)(3));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.checkCustomer = new global::Gtk.CheckButton();
			this.checkCustomer.CanFocus = true;
			this.checkCustomer.Name = "checkCustomer";
			this.checkCustomer.Label = global::Mono.Unix.Catalog.GetString("Покупатель");
			this.checkCustomer.Active = true;
			this.checkCustomer.DrawIndicator = true;
			this.checkCustomer.UseUnderline = true;
			this.hbox1.Add(this.checkCustomer);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.checkCustomer]));
			w2.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.checkSupplier = new global::Gtk.CheckButton();
			this.checkSupplier.CanFocus = true;
			this.checkSupplier.Name = "checkSupplier";
			this.checkSupplier.Label = global::Mono.Unix.Catalog.GetString("Поставщик");
			this.checkSupplier.Active = true;
			this.checkSupplier.DrawIndicator = true;
			this.checkSupplier.UseUnderline = true;
			this.hbox1.Add(this.checkSupplier);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.checkSupplier]));
			w3.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.checkPartner = new global::Gtk.CheckButton();
			this.checkPartner.CanFocus = true;
			this.checkPartner.Name = "checkPartner";
			this.checkPartner.Label = global::Mono.Unix.Catalog.GetString("Партнер");
			this.checkPartner.Active = true;
			this.checkPartner.DrawIndicator = true;
			this.checkPartner.UseUnderline = true;
			this.hbox1.Add(this.checkPartner);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.checkPartner]));
			w4.Position = 2;
			this.table1.Add(this.hbox1);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox1]));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Показывать только:");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.checkCustomer.Toggled += new global::System.EventHandler(this.OnCheckCustomerToggled);
			this.checkSupplier.Toggled += new global::System.EventHandler(this.OnCheckSupplierToggled);
			this.checkPartner.Toggled += new global::System.EventHandler(this.OnCheckPartnerToggled);
			this.checkIncludeArhive.Toggled += new global::System.EventHandler(this.OnCheckIncludeArhiveToggled);
		}
	}
}
