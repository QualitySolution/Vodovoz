
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Warehouse
{
	public partial class WarehouseView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button btnSave;

		private global::Gtk.Button btnCancel;

		private global::Gtk.Notebook notebook1;

		private global::Gtk.Table table1;

		private global::Gamma.GtkWidgets.yCheckButton checkArchive;

		private global::Gamma.GtkWidgets.yCheckButton checkCanReceiveBottles;

		private global::Gamma.GtkWidgets.yCheckButton checkCanReceiveEquipment;

		private global::Gamma.GtkWidgets.yCheckButton checkOnlineStore;

		private global::Gamma.Widgets.yEnumComboBox comboEnumTypeOfUse;

		private global::QS.Widgets.GtkUI.SpecialListComboBox comboOwner;

		private global::Gamma.GtkWidgets.yEntry entryName;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gtk.Label label1;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Warehouse.WarehouseView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Warehouse.WarehouseView";
			// Container child Vodovoz.Views.Warehouse.WarehouseView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnSave = new global::Gtk.Button();
			this.btnSave.CanFocus = true;
			this.btnSave.Name = "btnSave";
			this.btnSave.UseUnderline = true;
			this.btnSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.btnSave.Image = w1;
			this.hbox1.Add(this.btnSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.btnSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnCancel = new global::Gtk.Button();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.btnCancel.Image = w3;
			this.hbox1.Add(this.btnCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.btnCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.notebook1 = new global::Gtk.Notebook();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 0;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.table1 = new global::Gtk.Table(((uint)(8)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.checkArchive = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkArchive.CanFocus = true;
			this.checkArchive.Name = "checkArchive";
			this.checkArchive.Label = global::Mono.Unix.Catalog.GetString("Архивный");
			this.checkArchive.DrawIndicator = true;
			this.checkArchive.UseUnderline = true;
			this.table1.Add(this.checkArchive);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.checkArchive]));
			w6.TopAttach = ((uint)(7));
			w6.BottomAttach = ((uint)(8));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.checkCanReceiveBottles = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkCanReceiveBottles.CanFocus = true;
			this.checkCanReceiveBottles.Name = "checkCanReceiveBottles";
			this.checkCanReceiveBottles.Label = global::Mono.Unix.Catalog.GetString("Приём тары");
			this.checkCanReceiveBottles.DrawIndicator = true;
			this.checkCanReceiveBottles.UseUnderline = true;
			this.table1.Add(this.checkCanReceiveBottles);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.checkCanReceiveBottles]));
			w7.TopAttach = ((uint)(5));
			w7.BottomAttach = ((uint)(6));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.checkCanReceiveEquipment = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkCanReceiveEquipment.CanFocus = true;
			this.checkCanReceiveEquipment.Name = "checkCanReceiveEquipment";
			this.checkCanReceiveEquipment.Label = global::Mono.Unix.Catalog.GetString("Приём оборудования");
			this.checkCanReceiveEquipment.DrawIndicator = true;
			this.checkCanReceiveEquipment.UseUnderline = true;
			this.table1.Add(this.checkCanReceiveEquipment);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.checkCanReceiveEquipment]));
			w8.TopAttach = ((uint)(6));
			w8.BottomAttach = ((uint)(7));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.checkOnlineStore = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkOnlineStore.CanFocus = true;
			this.checkOnlineStore.Name = "checkOnlineStore";
			this.checkOnlineStore.Label = global::Mono.Unix.Catalog.GetString("Интернет магазин");
			this.checkOnlineStore.DrawIndicator = true;
			this.checkOnlineStore.UseUnderline = true;
			this.table1.Add(this.checkOnlineStore);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.checkOnlineStore]));
			w9.TopAttach = ((uint)(4));
			w9.BottomAttach = ((uint)(5));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.comboEnumTypeOfUse = new global::Gamma.Widgets.yEnumComboBox();
			this.comboEnumTypeOfUse.Name = "comboEnumTypeOfUse";
			this.comboEnumTypeOfUse.ShowSpecialStateAll = false;
			this.comboEnumTypeOfUse.ShowSpecialStateNot = false;
			this.comboEnumTypeOfUse.UseShortTitle = false;
			this.comboEnumTypeOfUse.DefaultFirst = false;
			this.table1.Add(this.comboEnumTypeOfUse);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.comboEnumTypeOfUse]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.comboOwner = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.comboOwner.Name = "comboOwner";
			this.comboOwner.AddIfNotExist = false;
			this.comboOwner.DefaultFirst = false;
			this.comboOwner.ShowSpecialStateAll = false;
			this.comboOwner.ShowSpecialStateNot = true;
			this.table1.Add(this.comboOwner);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.comboOwner]));
			w11.TopAttach = ((uint)(3));
			w11.BottomAttach = ((uint)(4));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryName = new global::Gamma.GtkWidgets.yEntry();
			this.entryName.CanFocus = true;
			this.entryName.Name = "entryName";
			this.entryName.IsEditable = true;
			this.entryName.InvisibleChar = '•';
			this.table1.Add(this.entryName);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.entryName]));
			w12.TopAttach = ((uint)(1));
			w12.BottomAttach = ((uint)(2));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Название:");
			this.label2.Justify = ((global::Gtk.Justification)(1));
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w13.TopAttach = ((uint)(1));
			w13.BottomAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Тип использования:");
			this.label3.Justify = ((global::Gtk.Justification)(1));
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w14.TopAttach = ((uint)(2));
			w14.BottomAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Подразделение-владелец:");
			this.label4.Justify = ((global::Gtk.Justification)(1));
			this.table1.Add(this.label4);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1[this.label4]));
			w15.TopAttach = ((uint)(3));
			w15.BottomAttach = ((uint)(4));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Публиковать количество:");
			this.label5.Justify = ((global::Gtk.Justification)(1));
			this.table1.Add(this.label5);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1[this.label5]));
			w16.TopAttach = ((uint)(4));
			w16.BottomAttach = ((uint)(5));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			this.notebook1.Add(this.table1);
			// Notebook tab
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Информация");
			this.notebook1.SetTabLabel(this.table1, this.label1);
			this.label1.ShowAll();
			this.vbox1.Add(this.notebook1);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.notebook1]));
			w18.Position = 1;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}