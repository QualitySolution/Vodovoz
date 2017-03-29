
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class EmployeeDlg
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.VSeparator vseparator1;

		private global::Gtk.RadioButton radioTabInfo;

		private global::Gtk.RadioButton radioTabAccounting;

		private global::Gtk.RadioButton radioTabFiles;

		private global::Gtk.Notebook notebookMain;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.Table datatableMain;

		private global::Gamma.GtkWidgets.yCheckButton checkIsFired;

		private global::Gamma.Widgets.yEnumComboBox comboCategory;

		private global::Gamma.GtkWidgets.yEntry dataentryDrivingNumber;

		private global::Gamma.GtkWidgets.yEntry dataentryLastName;

		private global::Gamma.GtkWidgets.yEntry dataentryName;

		private global::Gamma.GtkWidgets.yEntry dataentryPatronymic;

		private global::Gtk.HBox datahbox2;

		private global::Gtk.Label label4;

		private global::Gamma.GtkWidgets.yEntry dataentryPassportSeria;

		private global::Gtk.Label label13;

		private global::Gamma.GtkWidgets.yEntry dataentryPassportNumber;

		private global::Gamma.GtkWidgets.yEntry entryAddressCurrent;

		private global::Gamma.GtkWidgets.yEntry entryAddressRegistration;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Label labelAndroidLogin;

		private global::Gamma.GtkWidgets.yEntry dataentryAndroidLogin;

		private global::Gtk.Label labelAndroidPassword;

		private global::Gamma.GtkWidgets.yEntry dataentryAndroidPassword;

		private global::Gtk.Label label10;

		private global::Gtk.Label label11;

		private global::Gtk.Label label14;

		private global::Gtk.Label label15;

		private global::Gtk.Label label16;

		private global::Gtk.Label label18;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label5;

		private global::Gtk.Label label6;

		private global::Gtk.Label label7;

		private global::Gtk.Label label8;

		private global::Gtk.Label label9;

		private global::Gtk.Label labelAndroid;

		private global::QSContacts.PhonesView phonesView;

		private global::QSOrmProject.PhotoView photoviewEmployee;

		private global::Gamma.Widgets.yEntryReference referenceNationality;

		private global::Gamma.Widgets.yEntryReference referenceUser;

		private global::Gamma.Widgets.yEntryReference yentrySubdivision;

		private global::Gtk.Label label1;

		private global::Gtk.VBox vbox5;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Label label19;

		private global::Gamma.GtkWidgets.yEntry entryInn;

		private global::QSBanks.AccountsView accountsView;

		private global::Gtk.Label label12;

		private global::QSAttachment.Attachment attachmentFiles;

		private global::Gtk.Label label17;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.EmployeeDlg
			Stetic.BinContainer w1 = global::Stetic.BinContainer.Attach(this);
			this.UIManager = new global::Gtk.UIManager();
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup("Default");
			this.UIManager.InsertActionGroup(w2, 0);
			this.Name = "Vodovoz.EmployeeDlg";
			// Container child Vodovoz.EmployeeDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(6));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w3;
			this.hbox1.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonSave]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w5 = new global::Gtk.Image();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w5;
			this.hbox1.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonCancel]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator();
			this.vseparator1.Name = "vseparator1";
			this.hbox1.Add(this.vseparator1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vseparator1]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.radioTabInfo = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Основное"));
			this.radioTabInfo.CanFocus = true;
			this.radioTabInfo.Name = "radioTabInfo";
			this.radioTabInfo.DrawIndicator = false;
			this.radioTabInfo.UseUnderline = true;
			this.radioTabInfo.Group = new global::GLib.SList(global::System.IntPtr.Zero);
			this.hbox1.Add(this.radioTabInfo);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.radioTabInfo]));
			w8.Position = 3;
			// Container child hbox1.Gtk.Box+BoxChild
			this.radioTabAccounting = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Реквизиты"));
			this.radioTabAccounting.CanFocus = true;
			this.radioTabAccounting.Name = "radioTabAccounting";
			this.radioTabAccounting.DrawIndicator = false;
			this.radioTabAccounting.UseUnderline = true;
			this.radioTabAccounting.Group = this.radioTabInfo.Group;
			this.hbox1.Add(this.radioTabAccounting);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.radioTabAccounting]));
			w9.Position = 4;
			// Container child hbox1.Gtk.Box+BoxChild
			this.radioTabFiles = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Файлы"));
			this.radioTabFiles.CanFocus = true;
			this.radioTabFiles.Name = "radioTabFiles";
			this.radioTabFiles.DrawIndicator = false;
			this.radioTabFiles.UseUnderline = true;
			this.radioTabFiles.Group = this.radioTabInfo.Group;
			this.hbox1.Add(this.radioTabFiles);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.radioTabFiles]));
			w10.Position = 5;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.notebookMain = new global::Gtk.Notebook();
			this.notebookMain.CanFocus = true;
			this.notebookMain.Name = "notebookMain";
			this.notebookMain.CurrentPage = 0;
			// Container child notebookMain.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			global::Gtk.Viewport w12 = new global::Gtk.Viewport();
			w12.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.datatableMain = new global::Gtk.Table(((uint)(14)), ((uint)(3)), false);
			this.datatableMain.Name = "datatableMain";
			this.datatableMain.RowSpacing = ((uint)(6));
			this.datatableMain.ColumnSpacing = ((uint)(6));
			this.datatableMain.BorderWidth = ((uint)(6));
			// Container child datatableMain.Gtk.Table+TableChild
			this.checkIsFired = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkIsFired.CanFocus = true;
			this.checkIsFired.Name = "checkIsFired";
			this.checkIsFired.Label = "";
			this.checkIsFired.DrawIndicator = true;
			this.checkIsFired.UseUnderline = true;
			this.datatableMain.Add(this.checkIsFired);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.checkIsFired]));
			w13.TopAttach = ((uint)(13));
			w13.BottomAttach = ((uint)(14));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(3));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.comboCategory = new global::Gamma.Widgets.yEnumComboBox();
			this.comboCategory.Name = "comboCategory";
			this.comboCategory.ShowSpecialStateAll = false;
			this.comboCategory.ShowSpecialStateNot = false;
			this.comboCategory.UseShortTitle = false;
			this.comboCategory.DefaultFirst = true;
			this.datatableMain.Add(this.comboCategory);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.comboCategory]));
			w14.TopAttach = ((uint)(3));
			w14.BottomAttach = ((uint)(4));
			w14.LeftAttach = ((uint)(1));
			w14.RightAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryDrivingNumber = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryDrivingNumber.TooltipMarkup = "Десять символов серии и номера без пробелов.";
			this.dataentryDrivingNumber.CanFocus = true;
			this.dataentryDrivingNumber.Name = "dataentryDrivingNumber";
			this.dataentryDrivingNumber.IsEditable = true;
			this.dataentryDrivingNumber.MaxLength = 45;
			this.dataentryDrivingNumber.InvisibleChar = '●';
			this.datatableMain.Add(this.dataentryDrivingNumber);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.dataentryDrivingNumber]));
			w15.TopAttach = ((uint)(9));
			w15.BottomAttach = ((uint)(10));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(3));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryLastName = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryLastName.CanFocus = true;
			this.dataentryLastName.Name = "dataentryLastName";
			this.dataentryLastName.IsEditable = true;
			this.dataentryLastName.InvisibleChar = '●';
			this.datatableMain.Add(this.dataentryLastName);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.dataentryLastName]));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryName = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryName.CanFocus = true;
			this.dataentryName.Name = "dataentryName";
			this.dataentryName.IsEditable = true;
			this.dataentryName.MaxLength = 100;
			this.dataentryName.InvisibleChar = '●';
			this.datatableMain.Add(this.dataentryName);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.dataentryName]));
			w17.TopAttach = ((uint)(1));
			w17.BottomAttach = ((uint)(2));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryPatronymic = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryPatronymic.CanFocus = true;
			this.dataentryPatronymic.Name = "dataentryPatronymic";
			this.dataentryPatronymic.IsEditable = true;
			this.dataentryPatronymic.InvisibleChar = '●';
			this.datatableMain.Add(this.dataentryPatronymic);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.dataentryPatronymic]));
			w18.TopAttach = ((uint)(2));
			w18.BottomAttach = ((uint)(3));
			w18.LeftAttach = ((uint)(1));
			w18.RightAttach = ((uint)(2));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.datahbox2 = new global::Gtk.HBox();
			this.datahbox2.Name = "datahbox2";
			this.datahbox2.Spacing = 6;
			// Container child datahbox2.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("серия");
			this.datahbox2.Add(this.label4);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.datahbox2[this.label4]));
			w19.Position = 0;
			w19.Expand = false;
			w19.Fill = false;
			// Container child datahbox2.Gtk.Box+BoxChild
			this.dataentryPassportSeria = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryPassportSeria.CanFocus = true;
			this.dataentryPassportSeria.Name = "dataentryPassportSeria";
			this.dataentryPassportSeria.IsEditable = true;
			this.dataentryPassportSeria.InvisibleChar = '●';
			this.datahbox2.Add(this.dataentryPassportSeria);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.datahbox2[this.dataentryPassportSeria]));
			w20.Position = 1;
			// Container child datahbox2.Gtk.Box+BoxChild
			this.label13 = new global::Gtk.Label();
			this.label13.Name = "label13";
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString("номер");
			this.datahbox2.Add(this.label13);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.datahbox2[this.label13]));
			w21.Position = 2;
			w21.Expand = false;
			w21.Fill = false;
			// Container child datahbox2.Gtk.Box+BoxChild
			this.dataentryPassportNumber = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryPassportNumber.CanFocus = true;
			this.dataentryPassportNumber.Name = "dataentryPassportNumber";
			this.dataentryPassportNumber.IsEditable = true;
			this.dataentryPassportNumber.InvisibleChar = '●';
			this.datahbox2.Add(this.dataentryPassportNumber);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.datahbox2[this.dataentryPassportNumber]));
			w22.Position = 3;
			this.datatableMain.Add(this.datahbox2);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.datahbox2]));
			w23.TopAttach = ((uint)(8));
			w23.BottomAttach = ((uint)(9));
			w23.LeftAttach = ((uint)(1));
			w23.RightAttach = ((uint)(3));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.entryAddressCurrent = new global::Gamma.GtkWidgets.yEntry();
			this.entryAddressCurrent.CanFocus = true;
			this.entryAddressCurrent.Name = "entryAddressCurrent";
			this.entryAddressCurrent.IsEditable = true;
			this.entryAddressCurrent.InvisibleChar = '●';
			this.datatableMain.Add(this.entryAddressCurrent);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.entryAddressCurrent]));
			w24.TopAttach = ((uint)(12));
			w24.BottomAttach = ((uint)(13));
			w24.LeftAttach = ((uint)(1));
			w24.RightAttach = ((uint)(3));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.entryAddressRegistration = new global::Gamma.GtkWidgets.yEntry();
			this.entryAddressRegistration.CanFocus = true;
			this.entryAddressRegistration.Name = "entryAddressRegistration";
			this.entryAddressRegistration.IsEditable = true;
			this.entryAddressRegistration.InvisibleChar = '●';
			this.datatableMain.Add(this.entryAddressRegistration);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.entryAddressRegistration]));
			w25.TopAttach = ((uint)(11));
			w25.BottomAttach = ((uint)(12));
			w25.LeftAttach = ((uint)(1));
			w25.RightAttach = ((uint)(3));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.labelAndroidLogin = new global::Gtk.Label();
			this.labelAndroidLogin.Name = "labelAndroidLogin";
			this.labelAndroidLogin.LabelProp = global::Mono.Unix.Catalog.GetString("логин");
			this.hbox7.Add(this.labelAndroidLogin);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.labelAndroidLogin]));
			w26.Position = 0;
			w26.Expand = false;
			w26.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.dataentryAndroidLogin = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryAndroidLogin.CanFocus = true;
			this.dataentryAndroidLogin.Name = "dataentryAndroidLogin";
			this.dataentryAndroidLogin.IsEditable = true;
			this.dataentryAndroidLogin.InvisibleChar = '●';
			this.hbox7.Add(this.dataentryAndroidLogin);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.dataentryAndroidLogin]));
			w27.Position = 1;
			// Container child hbox7.Gtk.Box+BoxChild
			this.labelAndroidPassword = new global::Gtk.Label();
			this.labelAndroidPassword.Name = "labelAndroidPassword";
			this.labelAndroidPassword.LabelProp = global::Mono.Unix.Catalog.GetString("пароль");
			this.hbox7.Add(this.labelAndroidPassword);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.labelAndroidPassword]));
			w28.Position = 2;
			w28.Expand = false;
			w28.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.dataentryAndroidPassword = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryAndroidPassword.CanFocus = true;
			this.dataentryAndroidPassword.Name = "dataentryAndroidPassword";
			this.dataentryAndroidPassword.IsEditable = true;
			this.dataentryAndroidPassword.InvisibleChar = '●';
			this.hbox7.Add(this.dataentryAndroidPassword);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.dataentryAndroidPassword]));
			w29.Position = 3;
			this.datatableMain.Add(this.hbox7);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.hbox7]));
			w30.TopAttach = ((uint)(7));
			w30.BottomAttach = ((uint)(8));
			w30.LeftAttach = ((uint)(1));
			w30.RightAttach = ((uint)(3));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.Xalign = 1F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("Телефон:");
			this.datatableMain.Add(this.label10);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label10]));
			w31.TopAttach = ((uint)(10));
			w31.BottomAttach = ((uint)(11));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label11 = new global::Gtk.Label();
			this.label11.Name = "label11";
			this.label11.Xalign = 1F;
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString("Водительское\nудостоверение:");
			this.datatableMain.Add(this.label11);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label11]));
			w32.TopAttach = ((uint)(9));
			w32.BottomAttach = ((uint)(10));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label14 = new global::Gtk.Label();
			this.label14.Name = "label14";
			this.label14.Xalign = 1F;
			this.label14.LabelProp = global::Mono.Unix.Catalog.GetString("Адрес регистрации:");
			this.datatableMain.Add(this.label14);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label14]));
			w33.TopAttach = ((uint)(11));
			w33.BottomAttach = ((uint)(12));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label15 = new global::Gtk.Label();
			this.label15.Name = "label15";
			this.label15.Xalign = 1F;
			this.label15.LabelProp = global::Mono.Unix.Catalog.GetString("Фактический адрес:");
			this.datatableMain.Add(this.label15);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label15]));
			w34.TopAttach = ((uint)(12));
			w34.BottomAttach = ((uint)(13));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label16 = new global::Gtk.Label();
			this.label16.Name = "label16";
			this.label16.Xalign = 1F;
			this.label16.LabelProp = global::Mono.Unix.Catalog.GetString("Сотрудник уволен:");
			this.datatableMain.Add(this.label16);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label16]));
			w35.TopAttach = ((uint)(13));
			w35.BottomAttach = ((uint)(14));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label18 = new global::Gtk.Label();
			this.label18.Name = "label18";
			this.label18.LabelProp = global::Mono.Unix.Catalog.GetString("Подразделение");
			this.datatableMain.Add(this.label18);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label18]));
			w36.TopAttach = ((uint)(5));
			w36.BottomAttach = ((uint)(6));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Фамилия:");
			this.label2.UseMarkup = true;
			this.datatableMain.Add(this.label2);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label2]));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Категория:");
			this.datatableMain.Add(this.label3);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label3]));
			w38.TopAttach = ((uint)(3));
			w38.BottomAttach = ((uint)(4));
			w38.XOptions = ((global::Gtk.AttachOptions)(4));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Имя:");
			this.datatableMain.Add(this.label5);
			global::Gtk.Table.TableChild w39 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label5]));
			w39.TopAttach = ((uint)(1));
			w39.BottomAttach = ((uint)(2));
			w39.XOptions = ((global::Gtk.AttachOptions)(4));
			w39.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Отчество:");
			this.datatableMain.Add(this.label6);
			global::Gtk.Table.TableChild w40 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label6]));
			w40.TopAttach = ((uint)(2));
			w40.BottomAttach = ((uint)(3));
			w40.XOptions = ((global::Gtk.AttachOptions)(4));
			w40.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Национальность:");
			this.datatableMain.Add(this.label7);
			global::Gtk.Table.TableChild w41 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label7]));
			w41.TopAttach = ((uint)(4));
			w41.BottomAttach = ((uint)(5));
			w41.XOptions = ((global::Gtk.AttachOptions)(4));
			w41.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label();
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString("Пользователь:");
			this.datatableMain.Add(this.label8);
			global::Gtk.Table.TableChild w42 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label8]));
			w42.TopAttach = ((uint)(6));
			w42.BottomAttach = ((uint)(7));
			w42.XOptions = ((global::Gtk.AttachOptions)(4));
			w42.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("Паспорт:");
			this.datatableMain.Add(this.label9);
			global::Gtk.Table.TableChild w43 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label9]));
			w43.TopAttach = ((uint)(8));
			w43.BottomAttach = ((uint)(9));
			w43.XOptions = ((global::Gtk.AttachOptions)(4));
			w43.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.labelAndroid = new global::Gtk.Label();
			this.labelAndroid.Name = "labelAndroid";
			this.labelAndroid.Xalign = 1F;
			this.labelAndroid.LabelProp = global::Mono.Unix.Catalog.GetString("Android:");
			this.datatableMain.Add(this.labelAndroid);
			global::Gtk.Table.TableChild w44 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.labelAndroid]));
			w44.TopAttach = ((uint)(7));
			w44.BottomAttach = ((uint)(8));
			w44.XOptions = ((global::Gtk.AttachOptions)(4));
			w44.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child datatableMain.Gtk.Table+TableChild
			this.phonesView = new global::QSContacts.PhonesView();
			this.phonesView.Events = ((global::Gdk.EventMask)(256));
			this.phonesView.Name = "phonesView";
			this.datatableMain.Add(this.phonesView);
			global::Gtk.Table.TableChild w45 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.phonesView]));
			w45.TopAttach = ((uint)(10));
			w45.BottomAttach = ((uint)(11));
			w45.LeftAttach = ((uint)(1));
			w45.RightAttach = ((uint)(3));
			w45.XOptions = ((global::Gtk.AttachOptions)(4));
			w45.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.photoviewEmployee = null;
			this.datatableMain.Add(this.photoviewEmployee);
			global::Gtk.Table.TableChild w46 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.photoviewEmployee]));
			w46.BottomAttach = ((uint)(7));
			w46.LeftAttach = ((uint)(2));
			w46.RightAttach = ((uint)(3));
			w46.XOptions = ((global::Gtk.AttachOptions)(4));
			w46.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.referenceNationality = null;
			this.datatableMain.Add(this.referenceNationality);
			global::Gtk.Table.TableChild w47 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.referenceNationality]));
			w47.TopAttach = ((uint)(4));
			w47.BottomAttach = ((uint)(5));
			w47.LeftAttach = ((uint)(1));
			w47.RightAttach = ((uint)(2));
			w47.XOptions = ((global::Gtk.AttachOptions)(4));
			w47.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.referenceUser = null;
			this.datatableMain.Add(this.referenceUser);
			global::Gtk.Table.TableChild w48 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.referenceUser]));
			w48.TopAttach = ((uint)(6));
			w48.BottomAttach = ((uint)(7));
			w48.LeftAttach = ((uint)(1));
			w48.RightAttach = ((uint)(2));
			w48.XOptions = ((global::Gtk.AttachOptions)(4));
			w48.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.yentrySubdivision = null;
			this.datatableMain.Add(this.yentrySubdivision);
			global::Gtk.Table.TableChild w49 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.yentrySubdivision]));
			w49.TopAttach = ((uint)(5));
			w49.BottomAttach = ((uint)(6));
			w49.LeftAttach = ((uint)(1));
			w49.RightAttach = ((uint)(2));
			w49.XOptions = ((global::Gtk.AttachOptions)(4));
			w49.YOptions = ((global::Gtk.AttachOptions)(4));
			w12.Add(this.datatableMain);
			this.GtkScrolledWindow.Add(w12);
			this.notebookMain.Add(this.GtkScrolledWindow);
			// Notebook tab
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Информация");
			this.notebookMain.SetTabLabel(this.GtkScrolledWindow, this.label1);
			this.label1.ShowAll();
			// Container child notebookMain.Gtk.Notebook+NotebookChild
			this.vbox5 = new global::Gtk.VBox();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			this.vbox5.BorderWidth = ((uint)(6));
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label19 = new global::Gtk.Label();
			this.label19.Name = "label19";
			this.label19.LabelProp = global::Mono.Unix.Catalog.GetString("ИНН:");
			this.hbox6.Add(this.label19);
			global::Gtk.Box.BoxChild w53 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.label19]));
			w53.Position = 0;
			w53.Expand = false;
			w53.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.entryInn = new global::Gamma.GtkWidgets.yEntry();
			this.entryInn.CanFocus = true;
			this.entryInn.Name = "entryInn";
			this.entryInn.IsEditable = true;
			this.entryInn.InvisibleChar = '●';
			this.hbox6.Add(this.entryInn);
			global::Gtk.Box.BoxChild w54 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.entryInn]));
			w54.Position = 1;
			this.vbox5.Add(this.hbox6);
			global::Gtk.Box.BoxChild w55 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox6]));
			w55.Position = 0;
			w55.Expand = false;
			w55.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.accountsView = new global::QSBanks.AccountsView();
			this.accountsView.Events = ((global::Gdk.EventMask)(256));
			this.accountsView.Name = "accountsView";
			this.vbox5.Add(this.accountsView);
			global::Gtk.Box.BoxChild w56 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.accountsView]));
			w56.Position = 1;
			this.notebookMain.Add(this.vbox5);
			global::Gtk.Notebook.NotebookChild w57 = ((global::Gtk.Notebook.NotebookChild)(this.notebookMain[this.vbox5]));
			w57.Position = 1;
			// Notebook tab
			this.label12 = new global::Gtk.Label();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString("Реквизиты");
			this.notebookMain.SetTabLabel(this.vbox5, this.label12);
			this.label12.ShowAll();
			// Container child notebookMain.Gtk.Notebook+NotebookChild
			this.attachmentFiles = new global::QSAttachment.Attachment();
			this.attachmentFiles.Events = ((global::Gdk.EventMask)(256));
			this.attachmentFiles.Name = "attachmentFiles";
			this.notebookMain.Add(this.attachmentFiles);
			global::Gtk.Notebook.NotebookChild w58 = ((global::Gtk.Notebook.NotebookChild)(this.notebookMain[this.attachmentFiles]));
			w58.Position = 2;
			// Notebook tab
			this.label17 = new global::Gtk.Label();
			this.label17.Name = "label17";
			this.label17.LabelProp = global::Mono.Unix.Catalog.GetString("Файлы");
			this.notebookMain.SetTabLabel(this.attachmentFiles, this.label17);
			this.label17.ShowAll();
			this.vbox1.Add(this.notebookMain);
			global::Gtk.Box.BoxChild w59 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.notebookMain]));
			w59.Position = 1;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			w1.SetUiManager(UIManager);
			this.Hide();
			this.buttonSave.Clicked += new global::System.EventHandler(this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler(this.OnButtonCancelClicked);
			this.radioTabInfo.Toggled += new global::System.EventHandler(this.OnRadioTabInfoToggled);
			this.radioTabAccounting.Toggled += new global::System.EventHandler(this.OnRadioTabAccountingToggled);
			this.radioTabFiles.Toggled += new global::System.EventHandler(this.OnRadioTabFilesToggled);
			this.comboCategory.EnumItemSelected += new global::System.EventHandler<Gamma.Widgets.ItemSelectedEventArgs>(this.OnComboCategoryEnumItemSelected);
		}
	}
}
