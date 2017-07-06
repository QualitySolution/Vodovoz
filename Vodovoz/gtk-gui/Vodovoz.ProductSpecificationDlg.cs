
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class ProductSpecificationDlg
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Table datatable5;

		private global::Gamma.GtkWidgets.yEntry entryName;

		private global::Gtk.Label label32;

		private global::Gtk.Label label35;

		private global::Vodovoz.ProductSpecificationMaterialsView productspecificationmaterialsview1;

		private global::Gamma.Widgets.yEntryReference referenceProduct;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ProductSpecificationDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ProductSpecificationDlg";
			// Container child Vodovoz.ProductSpecificationDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox4.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox4.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add(this.hbox4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox4]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.datatable5 = new global::Gtk.Table(((uint)(3)), ((uint)(2)), false);
			this.datatable5.Name = "datatable5";
			this.datatable5.RowSpacing = ((uint)(6));
			this.datatable5.ColumnSpacing = ((uint)(6));
			this.datatable5.BorderWidth = ((uint)(6));
			// Container child datatable5.Gtk.Table+TableChild
			this.entryName = new global::Gamma.GtkWidgets.yEntry();
			this.entryName.CanFocus = true;
			this.entryName.Name = "entryName";
			this.entryName.IsEditable = true;
			this.entryName.InvisibleChar = '●';
			this.datatable5.Add(this.entryName);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.datatable5[this.entryName]));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.label32 = new global::Gtk.Label();
			this.label32.Name = "label32";
			this.label32.Xalign = 1F;
			this.label32.LabelProp = global::Mono.Unix.Catalog.GetString("Название спецификации:");
			this.datatable5.Add(this.label32);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.datatable5[this.label32]));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.label35 = new global::Gtk.Label();
			this.label35.Name = "label35";
			this.label35.Xalign = 1F;
			this.label35.LabelProp = global::Mono.Unix.Catalog.GetString("Продукция:");
			this.datatable5.Add(this.label35);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.datatable5[this.label35]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.productspecificationmaterialsview1 = new global::Vodovoz.ProductSpecificationMaterialsView();
			this.productspecificationmaterialsview1.Events = ((global::Gdk.EventMask)(256));
			this.productspecificationmaterialsview1.Name = "productspecificationmaterialsview1";
			this.datatable5.Add(this.productspecificationmaterialsview1);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.datatable5[this.productspecificationmaterialsview1]));
			w9.TopAttach = ((uint)(2));
			w9.BottomAttach = ((uint)(3));
			w9.RightAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.referenceProduct = new global::Gamma.Widgets.yEntryReference();
			this.referenceProduct.Events = ((global::Gdk.EventMask)(256));
			this.referenceProduct.Name = "referenceProduct";
			this.datatable5.Add(this.referenceProduct);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.datatable5[this.referenceProduct]));
			w10.TopAttach = ((uint)(1));
			w10.BottomAttach = ((uint)(2));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add(this.datatable5);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.datatable5]));
			w11.Position = 1;
			this.Add(this.vbox1);
			if((this.Child != null)) {
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
