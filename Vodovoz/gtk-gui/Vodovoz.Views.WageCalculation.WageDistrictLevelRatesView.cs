
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.WageCalculation
{
	public partial class WageDistrictLevelRatesView
	{
		private global::Gtk.VBox vbxMain;

		private global::Gtk.HBox hboxDialogButtons;

		private global::Gamma.GtkWidgets.yButton buttonSave;

		private global::Gamma.GtkWidgets.yButton buttonCancel;

		private global::Gtk.Table table1;

		private global::Gtk.Label labelName;

		private global::Gamma.GtkWidgets.yEntry yentryName;

		private global::Gamma.GtkWidgets.yCheckButton chkDefaultLevel;

		private global::Gamma.GtkWidgets.yCheckButton chkDefaultLevelOurCars;

		private global::Gtk.HBox hbxNotebooksWithDistricts;

		private global::Gamma.GtkWidgets.yCheckButton chkIsArchive;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.WageCalculation.WageDistrictLevelRatesView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.WageCalculation.WageDistrictLevelRatesView";
			// Container child Vodovoz.Views.WageCalculation.WageDistrictLevelRatesView.Gtk.Container+ContainerChild
			this.vbxMain = new global::Gtk.VBox();
			this.vbxMain.Name = "vbxMain";
			this.vbxMain.Spacing = 6;
			// Container child vbxMain.Gtk.Box+BoxChild
			this.hboxDialogButtons = new global::Gtk.HBox();
			this.hboxDialogButtons.Name = "hboxDialogButtons";
			this.hboxDialogButtons.Spacing = 6;
			// Container child hboxDialogButtons.Gtk.Box+BoxChild
			this.buttonSave = new global::Gamma.GtkWidgets.yButton();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hboxDialogButtons.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hboxDialogButtons[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hboxDialogButtons.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gamma.GtkWidgets.yButton();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hboxDialogButtons.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hboxDialogButtons[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbxMain.Add(this.hboxDialogButtons);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbxMain[this.hboxDialogButtons]));
			w5.Position = 0;
			w5.Expand = false;
			// Container child vbxMain.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(1)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.labelName = new global::Gtk.Label();
			this.labelName.Name = "labelName";
			this.labelName.Xalign = 1F;
			this.labelName.LabelProp = global::Mono.Unix.Catalog.GetString("Название:");
			this.table1.Add(this.labelName);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.labelName]));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryName = new global::Gamma.GtkWidgets.yEntry();
			this.yentryName.CanFocus = true;
			this.yentryName.Name = "yentryName";
			this.yentryName.IsEditable = true;
			this.yentryName.InvisibleChar = '•';
			this.table1.Add(this.yentryName);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryName]));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbxMain.Add(this.table1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbxMain[this.table1]));
			w8.Position = 1;
			w8.Expand = false;
			// Container child vbxMain.Gtk.Box+BoxChild
			this.chkDefaultLevel = new global::Gamma.GtkWidgets.yCheckButton();
			this.chkDefaultLevel.CanFocus = true;
			this.chkDefaultLevel.Name = "chkDefaultLevel";
			this.chkDefaultLevel.Label = global::Mono.Unix.Catalog.GetString("Уровень по умолчанию для новых сотрудников");
			this.chkDefaultLevel.DrawIndicator = true;
			this.chkDefaultLevel.UseUnderline = true;
			this.vbxMain.Add(this.chkDefaultLevel);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbxMain[this.chkDefaultLevel]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbxMain.Gtk.Box+BoxChild
			this.chkDefaultLevelOurCars = new global::Gamma.GtkWidgets.yCheckButton();
			this.chkDefaultLevelOurCars.CanFocus = true;
			this.chkDefaultLevelOurCars.Name = "chkDefaultLevelOurCars";
			this.chkDefaultLevelOurCars.Label = global::Mono.Unix.Catalog.GetString("Уровень по умолчанию для новых сотрудников (Наши авто)");
			this.chkDefaultLevelOurCars.DrawIndicator = true;
			this.chkDefaultLevelOurCars.UseUnderline = true;
			this.vbxMain.Add(this.chkDefaultLevelOurCars);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbxMain[this.chkDefaultLevelOurCars]));
			w10.Position = 3;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbxMain.Gtk.Box+BoxChild
			this.hbxNotebooksWithDistricts = new global::Gtk.HBox();
			this.hbxNotebooksWithDistricts.Name = "hbxNotebooksWithDistricts";
			this.hbxNotebooksWithDistricts.Spacing = 6;
			this.vbxMain.Add(this.hbxNotebooksWithDistricts);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbxMain[this.hbxNotebooksWithDistricts]));
			w11.Position = 4;
			// Container child vbxMain.Gtk.Box+BoxChild
			this.chkIsArchive = new global::Gamma.GtkWidgets.yCheckButton();
			this.chkIsArchive.CanFocus = true;
			this.chkIsArchive.Name = "chkIsArchive";
			this.chkIsArchive.Label = global::Mono.Unix.Catalog.GetString("Архивный");
			this.chkIsArchive.DrawIndicator = true;
			this.chkIsArchive.UseUnderline = true;
			this.vbxMain.Add(this.chkIsArchive);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbxMain[this.chkIsArchive]));
			w12.Position = 5;
			w12.Expand = false;
			w12.Fill = false;
			this.Add(this.vbxMain);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
