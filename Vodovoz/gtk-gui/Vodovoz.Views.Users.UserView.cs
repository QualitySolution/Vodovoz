
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Users
{
	public partial class UserView
	{
		private global::Gtk.VBox vboxDialog;

		private global::Gtk.HBox hboxButtons;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.VSeparator vseparator1;

		private global::Gtk.HBox hboxTabButtons;

		private global::Gtk.Button buttonUserInfo;

		private global::Gamma.GtkWidgets.yLabel ylabelPrivilegesButtons;

		private global::Gamma.GtkWidgets.yButton ybuttonPresetPrivileges;

		private global::Gamma.GtkWidgets.yButton ybuttonWarehousePrivileges;

		private global::Gamma.GtkWidgets.yButton ybuttonDocumentPrivileges;

		private global::Gamma.GtkWidgets.yButton ybuttonSpecialDocumentPrivileges;

		private global::Gamma.GtkWidgets.yNotebook notebook;

		private global::Gtk.HBox hboxInfoTab;

		private global::Gtk.Table tableInfo;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTextView ytextviewComment;

		private global::Gamma.GtkWidgets.yLabel PasswordWarning;

		private global::Gamma.GtkWidgets.yButton ybuttonResetPassword;

		private global::Gamma.GtkWidgets.yButton ybuttonSetNewPassword;

		private global::Gamma.GtkWidgets.yCheckButton ycheckIsAdmin;

		private global::Gamma.GtkWidgets.yCheckButton ycheckRequirePasswordChange;

		private global::Gamma.GtkWidgets.yCheckButton ycheckUserDisabled;

		private global::Gamma.GtkWidgets.yEntry yentryDisplayName;

		private global::Gamma.GtkWidgets.yEntry yentryLogin;

		private global::Gamma.GtkWidgets.yLabel ylabelComment;

		private global::Gamma.GtkWidgets.yLabel ylabelDisplayName;

		private global::Gamma.GtkWidgets.yLabel ylabelId;

		private global::Gamma.GtkWidgets.yLabel ylabelIdValue;

		private global::Gamma.GtkWidgets.yLabel ylabelLogin;

		private global::Gtk.Table tableRoles;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gamma.GtkWidgets.yTextView ytextview2;

		private global::Gtk.VBox vboxRolesButtons;

		private global::Gtk.Button buttonAddRole;

		private global::Gtk.Button buttonRemoveRole;

		private global::Gamma.Widgets.ySpecComboBox ycomboboxDefaultRole;

		private global::Gamma.GtkWidgets.yLabel ylabelAddedRoles;

		private global::Gamma.GtkWidgets.yLabel ylabelAvailableRoles;

		private global::Gamma.GtkWidgets.yLabel ylabelDefaultRole;

		private global::Gamma.GtkWidgets.yLabel ylabelRoleDescription;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewAddedRoles;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewAvailableRoles;

		private global::Gtk.Label tabLabelUserInfo;

		private global::Gtk.VBox vboxPresetPrivileges;

		private global::Gtk.Label tabLabelPresetPrivileges;

		private global::Gtk.VBox vboxWarehousePrivileges;

		private global::Gtk.Label tabLabelWarehousePrivileges;

		private global::Gtk.VBox vboxDocumentPrivileges;

		private global::Gtk.Label tabLabelDocumentPrivileges;

		private global::Gtk.VBox vboxSpecialDocumentPrivileges;

		private global::Gtk.Label tabLabelSpecialDocumentPrivileges;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Users.UserView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Users.UserView";
			// Container child Vodovoz.Views.Users.UserView.Gtk.Container+ContainerChild
			this.vboxDialog = new global::Gtk.VBox();
			this.vboxDialog.Name = "vboxDialog";
			this.vboxDialog.Spacing = 6;
			// Container child vboxDialog.Gtk.Box+BoxChild
			this.hboxButtons = new global::Gtk.HBox();
			this.hboxButtons.Name = "hboxButtons";
			this.hboxButtons.Spacing = 6;
			// Container child hboxButtons.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hboxButtons.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hboxButtons[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hboxButtons.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hboxButtons.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hboxButtons[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hboxButtons.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator();
			this.vseparator1.Name = "vseparator1";
			this.hboxButtons.Add(this.vseparator1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hboxButtons[this.vseparator1]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hboxButtons.Gtk.Box+BoxChild
			this.hboxTabButtons = new global::Gtk.HBox();
			this.hboxTabButtons.Name = "hboxTabButtons";
			this.hboxTabButtons.Spacing = 6;
			// Container child hboxTabButtons.Gtk.Box+BoxChild
			this.buttonUserInfo = new global::Gtk.Button();
			this.buttonUserInfo.CanFocus = true;
			this.buttonUserInfo.Name = "buttonUserInfo";
			this.buttonUserInfo.UseUnderline = true;
			this.buttonUserInfo.Label = global::Mono.Unix.Catalog.GetString("Информация");
			this.hboxTabButtons.Add(this.buttonUserInfo);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hboxTabButtons[this.buttonUserInfo]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hboxTabButtons.Gtk.Box+BoxChild
			this.ylabelPrivilegesButtons = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelPrivilegesButtons.Name = "ylabelPrivilegesButtons";
			this.ylabelPrivilegesButtons.LabelProp = global::Mono.Unix.Catalog.GetString("Права:");
			this.hboxTabButtons.Add(this.ylabelPrivilegesButtons);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hboxTabButtons[this.ylabelPrivilegesButtons]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hboxTabButtons.Gtk.Box+BoxChild
			this.ybuttonPresetPrivileges = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonPresetPrivileges.CanFocus = true;
			this.ybuttonPresetPrivileges.Name = "ybuttonPresetPrivileges";
			this.ybuttonPresetPrivileges.UseUnderline = true;
			this.ybuttonPresetPrivileges.Label = global::Mono.Unix.Catalog.GetString("Предустановленные");
			this.hboxTabButtons.Add(this.ybuttonPresetPrivileges);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hboxTabButtons[this.ybuttonPresetPrivileges]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hboxTabButtons.Gtk.Box+BoxChild
			this.ybuttonWarehousePrivileges = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonWarehousePrivileges.CanFocus = true;
			this.ybuttonWarehousePrivileges.Name = "ybuttonWarehousePrivileges";
			this.ybuttonWarehousePrivileges.UseUnderline = true;
			this.ybuttonWarehousePrivileges.Label = global::Mono.Unix.Catalog.GetString("Склады");
			this.hboxTabButtons.Add(this.ybuttonWarehousePrivileges);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hboxTabButtons[this.ybuttonWarehousePrivileges]));
			w9.Position = 3;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hboxTabButtons.Gtk.Box+BoxChild
			this.ybuttonDocumentPrivileges = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonDocumentPrivileges.CanFocus = true;
			this.ybuttonDocumentPrivileges.Name = "ybuttonDocumentPrivileges";
			this.ybuttonDocumentPrivileges.UseUnderline = true;
			this.ybuttonDocumentPrivileges.Label = global::Mono.Unix.Catalog.GetString("Документы");
			this.hboxTabButtons.Add(this.ybuttonDocumentPrivileges);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hboxTabButtons[this.ybuttonDocumentPrivileges]));
			w10.Position = 4;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hboxTabButtons.Gtk.Box+BoxChild
			this.ybuttonSpecialDocumentPrivileges = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonSpecialDocumentPrivileges.CanFocus = true;
			this.ybuttonSpecialDocumentPrivileges.Name = "ybuttonSpecialDocumentPrivileges";
			this.ybuttonSpecialDocumentPrivileges.UseUnderline = true;
			this.ybuttonSpecialDocumentPrivileges.Label = global::Mono.Unix.Catalog.GetString("Документы другого отдела");
			this.hboxTabButtons.Add(this.ybuttonSpecialDocumentPrivileges);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hboxTabButtons[this.ybuttonSpecialDocumentPrivileges]));
			w11.Position = 5;
			w11.Expand = false;
			w11.Fill = false;
			this.hboxButtons.Add(this.hboxTabButtons);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hboxButtons[this.hboxTabButtons]));
			w12.Position = 3;
			w12.Expand = false;
			w12.Fill = false;
			this.vboxDialog.Add(this.hboxButtons);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vboxDialog[this.hboxButtons]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vboxDialog.Gtk.Box+BoxChild
			this.notebook = new global::Gamma.GtkWidgets.yNotebook();
			this.notebook.CanFocus = true;
			this.notebook.Name = "notebook";
			this.notebook.CurrentPage = 1;
			// Container child notebook.Gtk.Notebook+NotebookChild
			this.hboxInfoTab = new global::Gtk.HBox();
			this.hboxInfoTab.Name = "hboxInfoTab";
			this.hboxInfoTab.Spacing = 6;
			// Container child hboxInfoTab.Gtk.Box+BoxChild
			this.tableInfo = new global::Gtk.Table(((uint)(11)), ((uint)(2)), false);
			this.tableInfo.Name = "tableInfo";
			this.tableInfo.RowSpacing = ((uint)(6));
			this.tableInfo.ColumnSpacing = ((uint)(6));
			// Container child tableInfo.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytextviewComment = new global::Gamma.GtkWidgets.yTextView();
			this.ytextviewComment.CanFocus = true;
			this.ytextviewComment.Name = "ytextviewComment";
			this.GtkScrolledWindow.Add(this.ytextviewComment);
			this.tableInfo.Add(this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.GtkScrolledWindow]));
			w15.TopAttach = ((uint)(10));
			w15.BottomAttach = ((uint)(11));
			w15.RightAttach = ((uint)(2));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.PasswordWarning = new global::Gamma.GtkWidgets.yLabel();
			this.PasswordWarning.Name = "PasswordWarning";
			this.PasswordWarning.Xalign = 0F;
			this.PasswordWarning.LabelProp = global::Mono.Unix.Catalog.GetString("PasswordWarning");
			this.tableInfo.Add(this.PasswordWarning);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.PasswordWarning]));
			w16.TopAttach = ((uint)(5));
			w16.BottomAttach = ((uint)(6));
			w16.RightAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ybuttonResetPassword = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonResetPassword.CanFocus = true;
			this.ybuttonResetPassword.Name = "ybuttonResetPassword";
			this.ybuttonResetPassword.UseUnderline = true;
			this.ybuttonResetPassword.Label = global::Mono.Unix.Catalog.GetString("Сбросить пароль");
			this.tableInfo.Add(this.ybuttonResetPassword);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ybuttonResetPassword]));
			w17.TopAttach = ((uint)(4));
			w17.BottomAttach = ((uint)(5));
			w17.RightAttach = ((uint)(2));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ybuttonSetNewPassword = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonSetNewPassword.CanFocus = true;
			this.ybuttonSetNewPassword.Name = "ybuttonSetNewPassword";
			this.ybuttonSetNewPassword.UseUnderline = true;
			this.ybuttonSetNewPassword.Label = global::Mono.Unix.Catalog.GetString("Новый пароль");
			this.tableInfo.Add(this.ybuttonSetNewPassword);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ybuttonSetNewPassword]));
			w18.TopAttach = ((uint)(3));
			w18.BottomAttach = ((uint)(4));
			w18.RightAttach = ((uint)(2));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ycheckIsAdmin = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckIsAdmin.CanFocus = true;
			this.ycheckIsAdmin.Name = "ycheckIsAdmin";
			this.ycheckIsAdmin.Label = global::Mono.Unix.Catalog.GetString("Администратор");
			this.ycheckIsAdmin.DrawIndicator = true;
			this.ycheckIsAdmin.UseUnderline = true;
			this.tableInfo.Add(this.ycheckIsAdmin);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ycheckIsAdmin]));
			w19.TopAttach = ((uint)(8));
			w19.BottomAttach = ((uint)(9));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ycheckRequirePasswordChange = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckRequirePasswordChange.CanFocus = true;
			this.ycheckRequirePasswordChange.Name = "ycheckRequirePasswordChange";
			this.ycheckRequirePasswordChange.Label = global::Mono.Unix.Catalog.GetString("Запрос смены пароля при входе");
			this.ycheckRequirePasswordChange.DrawIndicator = true;
			this.ycheckRequirePasswordChange.UseUnderline = true;
			this.tableInfo.Add(this.ycheckRequirePasswordChange);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ycheckRequirePasswordChange]));
			w20.TopAttach = ((uint)(6));
			w20.BottomAttach = ((uint)(7));
			w20.RightAttach = ((uint)(2));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ycheckUserDisabled = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckUserDisabled.CanFocus = true;
			this.ycheckUserDisabled.Name = "ycheckUserDisabled";
			this.ycheckUserDisabled.Label = global::Mono.Unix.Catalog.GetString("Пользователь отключен");
			this.ycheckUserDisabled.DrawIndicator = true;
			this.ycheckUserDisabled.UseUnderline = true;
			this.tableInfo.Add(this.ycheckUserDisabled);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ycheckUserDisabled]));
			w21.TopAttach = ((uint)(7));
			w21.BottomAttach = ((uint)(8));
			w21.RightAttach = ((uint)(2));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.yentryDisplayName = new global::Gamma.GtkWidgets.yEntry();
			this.yentryDisplayName.CanFocus = true;
			this.yentryDisplayName.Name = "yentryDisplayName";
			this.yentryDisplayName.IsEditable = true;
			this.yentryDisplayName.InvisibleChar = '●';
			this.tableInfo.Add(this.yentryDisplayName);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.yentryDisplayName]));
			w22.TopAttach = ((uint)(1));
			w22.BottomAttach = ((uint)(2));
			w22.LeftAttach = ((uint)(1));
			w22.RightAttach = ((uint)(2));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.yentryLogin = new global::Gamma.GtkWidgets.yEntry();
			this.yentryLogin.CanFocus = true;
			this.yentryLogin.Name = "yentryLogin";
			this.yentryLogin.IsEditable = true;
			this.yentryLogin.InvisibleChar = '●';
			this.tableInfo.Add(this.yentryLogin);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.yentryLogin]));
			w23.TopAttach = ((uint)(2));
			w23.BottomAttach = ((uint)(3));
			w23.LeftAttach = ((uint)(1));
			w23.RightAttach = ((uint)(2));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylabelComment = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelComment.Name = "ylabelComment";
			this.ylabelComment.Xalign = 1F;
			this.ylabelComment.LabelProp = global::Mono.Unix.Catalog.GetString("Комментарий:");
			this.tableInfo.Add(this.ylabelComment);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylabelComment]));
			w24.TopAttach = ((uint)(9));
			w24.BottomAttach = ((uint)(10));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylabelDisplayName = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelDisplayName.Name = "ylabelDisplayName";
			this.ylabelDisplayName.Xalign = 1F;
			this.ylabelDisplayName.LabelProp = global::Mono.Unix.Catalog.GetString("Имя:");
			this.ylabelDisplayName.Justify = ((global::Gtk.Justification)(1));
			this.tableInfo.Add(this.ylabelDisplayName);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylabelDisplayName]));
			w25.TopAttach = ((uint)(1));
			w25.BottomAttach = ((uint)(2));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylabelId = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelId.Name = "ylabelId";
			this.ylabelId.Xalign = 1F;
			this.ylabelId.LabelProp = global::Mono.Unix.Catalog.GetString("Код:");
			this.ylabelId.Justify = ((global::Gtk.Justification)(1));
			this.tableInfo.Add(this.ylabelId);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylabelId]));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylabelIdValue = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelIdValue.Name = "ylabelIdValue";
			this.ylabelIdValue.Xalign = 0F;
			this.ylabelIdValue.LabelProp = global::Mono.Unix.Catalog.GetString("Id");
			this.tableInfo.Add(this.ylabelIdValue);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylabelIdValue]));
			w27.LeftAttach = ((uint)(1));
			w27.RightAttach = ((uint)(2));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylabelLogin = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelLogin.Name = "ylabelLogin";
			this.ylabelLogin.Xalign = 1F;
			this.ylabelLogin.LabelProp = global::Mono.Unix.Catalog.GetString("Логин:");
			this.ylabelLogin.Justify = ((global::Gtk.Justification)(1));
			this.tableInfo.Add(this.ylabelLogin);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylabelLogin]));
			w28.TopAttach = ((uint)(2));
			w28.BottomAttach = ((uint)(3));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hboxInfoTab.Add(this.tableInfo);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hboxInfoTab[this.tableInfo]));
			w29.Position = 0;
			w29.Expand = false;
			w29.Fill = false;
			// Container child hboxInfoTab.Gtk.Box+BoxChild
			this.tableRoles = new global::Gtk.Table(((uint)(5)), ((uint)(3)), false);
			this.tableRoles.Name = "tableRoles";
			this.tableRoles.RowSpacing = ((uint)(6));
			this.tableRoles.ColumnSpacing = ((uint)(6));
			// Container child tableRoles.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.ytextview2 = new global::Gamma.GtkWidgets.yTextView();
			this.ytextview2.CanFocus = true;
			this.ytextview2.Name = "ytextview2";
			this.ytextview2.Editable = false;
			this.GtkScrolledWindow1.Add(this.ytextview2);
			this.tableRoles.Add(this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.tableRoles[this.GtkScrolledWindow1]));
			w31.TopAttach = ((uint)(4));
			w31.BottomAttach = ((uint)(5));
			w31.RightAttach = ((uint)(3));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableRoles.Gtk.Table+TableChild
			this.vboxRolesButtons = new global::Gtk.VBox();
			this.vboxRolesButtons.Name = "vboxRolesButtons";
			this.vboxRolesButtons.Spacing = 6;
			// Container child vboxRolesButtons.Gtk.Box+BoxChild
			this.buttonAddRole = new global::Gtk.Button();
			this.buttonAddRole.CanFocus = true;
			this.buttonAddRole.Name = "buttonAddRole";
			this.buttonAddRole.UseUnderline = true;
			this.buttonAddRole.Label = global::Mono.Unix.Catalog.GetString(">");
			this.vboxRolesButtons.Add(this.buttonAddRole);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vboxRolesButtons[this.buttonAddRole]));
			w32.Position = 0;
			w32.Expand = false;
			w32.Fill = false;
			// Container child vboxRolesButtons.Gtk.Box+BoxChild
			this.buttonRemoveRole = new global::Gtk.Button();
			this.buttonRemoveRole.CanFocus = true;
			this.buttonRemoveRole.Name = "buttonRemoveRole";
			this.buttonRemoveRole.UseUnderline = true;
			this.buttonRemoveRole.Label = global::Mono.Unix.Catalog.GetString("<");
			this.vboxRolesButtons.Add(this.buttonRemoveRole);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vboxRolesButtons[this.buttonRemoveRole]));
			w33.Position = 1;
			w33.Expand = false;
			w33.Fill = false;
			this.tableRoles.Add(this.vboxRolesButtons);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.tableRoles[this.vboxRolesButtons]));
			w34.TopAttach = ((uint)(2));
			w34.BottomAttach = ((uint)(3));
			w34.LeftAttach = ((uint)(1));
			w34.RightAttach = ((uint)(2));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableRoles.Gtk.Table+TableChild
			this.ycomboboxDefaultRole = new global::Gamma.Widgets.ySpecComboBox();
			this.ycomboboxDefaultRole.Name = "ycomboboxDefaultRole";
			this.ycomboboxDefaultRole.AddIfNotExist = false;
			this.ycomboboxDefaultRole.DefaultFirst = false;
			this.ycomboboxDefaultRole.ShowSpecialStateAll = false;
			this.ycomboboxDefaultRole.ShowSpecialStateNot = false;
			this.tableRoles.Add(this.ycomboboxDefaultRole);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.tableRoles[this.ycomboboxDefaultRole]));
			w35.LeftAttach = ((uint)(1));
			w35.RightAttach = ((uint)(3));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableRoles.Gtk.Table+TableChild
			this.ylabelAddedRoles = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelAddedRoles.Name = "ylabelAddedRoles";
			this.ylabelAddedRoles.Xalign = 0F;
			this.ylabelAddedRoles.LabelProp = global::Mono.Unix.Catalog.GetString("Установленные роли:");
			this.tableRoles.Add(this.ylabelAddedRoles);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.tableRoles[this.ylabelAddedRoles]));
			w36.TopAttach = ((uint)(1));
			w36.BottomAttach = ((uint)(2));
			w36.LeftAttach = ((uint)(2));
			w36.RightAttach = ((uint)(3));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableRoles.Gtk.Table+TableChild
			this.ylabelAvailableRoles = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelAvailableRoles.Name = "ylabelAvailableRoles";
			this.ylabelAvailableRoles.Xalign = 0F;
			this.ylabelAvailableRoles.LabelProp = global::Mono.Unix.Catalog.GetString("Доступные роли:");
			this.tableRoles.Add(this.ylabelAvailableRoles);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.tableRoles[this.ylabelAvailableRoles]));
			w37.TopAttach = ((uint)(1));
			w37.BottomAttach = ((uint)(2));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableRoles.Gtk.Table+TableChild
			this.ylabelDefaultRole = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelDefaultRole.Name = "ylabelDefaultRole";
			this.ylabelDefaultRole.LabelProp = global::Mono.Unix.Catalog.GetString("Роль по умолчанию");
			this.tableRoles.Add(this.ylabelDefaultRole);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.tableRoles[this.ylabelDefaultRole]));
			w38.XOptions = ((global::Gtk.AttachOptions)(4));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableRoles.Gtk.Table+TableChild
			this.ylabelRoleDescription = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelRoleDescription.Name = "ylabelRoleDescription";
			this.ylabelRoleDescription.Xalign = 0F;
			this.ylabelRoleDescription.LabelProp = global::Mono.Unix.Catalog.GetString("Описание роли:");
			this.tableRoles.Add(this.ylabelRoleDescription);
			global::Gtk.Table.TableChild w39 = ((global::Gtk.Table.TableChild)(this.tableRoles[this.ylabelRoleDescription]));
			w39.TopAttach = ((uint)(3));
			w39.BottomAttach = ((uint)(4));
			w39.XOptions = ((global::Gtk.AttachOptions)(4));
			w39.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableRoles.Gtk.Table+TableChild
			this.ytreeviewAddedRoles = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewAddedRoles.CanFocus = true;
			this.ytreeviewAddedRoles.Name = "ytreeviewAddedRoles";
			this.ytreeviewAddedRoles.HeadersVisible = false;
			this.tableRoles.Add(this.ytreeviewAddedRoles);
			global::Gtk.Table.TableChild w40 = ((global::Gtk.Table.TableChild)(this.tableRoles[this.ytreeviewAddedRoles]));
			w40.TopAttach = ((uint)(2));
			w40.BottomAttach = ((uint)(3));
			w40.LeftAttach = ((uint)(2));
			w40.RightAttach = ((uint)(3));
			w40.XOptions = ((global::Gtk.AttachOptions)(4));
			w40.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableRoles.Gtk.Table+TableChild
			this.ytreeviewAvailableRoles = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewAvailableRoles.CanFocus = true;
			this.ytreeviewAvailableRoles.Name = "ytreeviewAvailableRoles";
			this.ytreeviewAvailableRoles.EnableSearch = false;
			this.ytreeviewAvailableRoles.HeadersVisible = false;
			this.tableRoles.Add(this.ytreeviewAvailableRoles);
			global::Gtk.Table.TableChild w41 = ((global::Gtk.Table.TableChild)(this.tableRoles[this.ytreeviewAvailableRoles]));
			w41.TopAttach = ((uint)(2));
			w41.BottomAttach = ((uint)(3));
			w41.XOptions = ((global::Gtk.AttachOptions)(4));
			w41.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hboxInfoTab.Add(this.tableRoles);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.hboxInfoTab[this.tableRoles]));
			w42.Position = 1;
			w42.Expand = false;
			this.notebook.Add(this.hboxInfoTab);
			// Notebook tab
			this.tabLabelUserInfo = new global::Gtk.Label();
			this.tabLabelUserInfo.Name = "tabLabelUserInfo";
			this.tabLabelUserInfo.LabelProp = global::Mono.Unix.Catalog.GetString("UserInfo");
			this.notebook.SetTabLabel(this.hboxInfoTab, this.tabLabelUserInfo);
			this.tabLabelUserInfo.ShowAll();
			// Container child notebook.Gtk.Notebook+NotebookChild
			this.vboxPresetPrivileges = new global::Gtk.VBox();
			this.vboxPresetPrivileges.Name = "vboxPresetPrivileges";
			this.vboxPresetPrivileges.Spacing = 6;
			this.notebook.Add(this.vboxPresetPrivileges);
			global::Gtk.Notebook.NotebookChild w44 = ((global::Gtk.Notebook.NotebookChild)(this.notebook[this.vboxPresetPrivileges]));
			w44.Position = 1;
			// Notebook tab
			this.tabLabelPresetPrivileges = new global::Gtk.Label();
			this.tabLabelPresetPrivileges.Name = "tabLabelPresetPrivileges";
			this.tabLabelPresetPrivileges.LabelProp = global::Mono.Unix.Catalog.GetString("PresetPrivileges");
			this.notebook.SetTabLabel(this.vboxPresetPrivileges, this.tabLabelPresetPrivileges);
			this.tabLabelPresetPrivileges.ShowAll();
			// Container child notebook.Gtk.Notebook+NotebookChild
			this.vboxWarehousePrivileges = new global::Gtk.VBox();
			this.vboxWarehousePrivileges.Name = "vboxWarehousePrivileges";
			this.vboxWarehousePrivileges.Spacing = 6;
			this.notebook.Add(this.vboxWarehousePrivileges);
			global::Gtk.Notebook.NotebookChild w45 = ((global::Gtk.Notebook.NotebookChild)(this.notebook[this.vboxWarehousePrivileges]));
			w45.Position = 2;
			// Notebook tab
			this.tabLabelWarehousePrivileges = new global::Gtk.Label();
			this.tabLabelWarehousePrivileges.Name = "tabLabelWarehousePrivileges";
			this.tabLabelWarehousePrivileges.LabelProp = global::Mono.Unix.Catalog.GetString("WarehousePrivileges");
			this.notebook.SetTabLabel(this.vboxWarehousePrivileges, this.tabLabelWarehousePrivileges);
			this.tabLabelWarehousePrivileges.ShowAll();
			// Container child notebook.Gtk.Notebook+NotebookChild
			this.vboxDocumentPrivileges = new global::Gtk.VBox();
			this.vboxDocumentPrivileges.Name = "vboxDocumentPrivileges";
			this.vboxDocumentPrivileges.Spacing = 6;
			this.notebook.Add(this.vboxDocumentPrivileges);
			global::Gtk.Notebook.NotebookChild w46 = ((global::Gtk.Notebook.NotebookChild)(this.notebook[this.vboxDocumentPrivileges]));
			w46.Position = 3;
			// Notebook tab
			this.tabLabelDocumentPrivileges = new global::Gtk.Label();
			this.tabLabelDocumentPrivileges.Name = "tabLabelDocumentPrivileges";
			this.tabLabelDocumentPrivileges.LabelProp = global::Mono.Unix.Catalog.GetString("DocumentPrivileges");
			this.notebook.SetTabLabel(this.vboxDocumentPrivileges, this.tabLabelDocumentPrivileges);
			this.tabLabelDocumentPrivileges.ShowAll();
			// Container child notebook.Gtk.Notebook+NotebookChild
			this.vboxSpecialDocumentPrivileges = new global::Gtk.VBox();
			this.vboxSpecialDocumentPrivileges.Name = "vboxSpecialDocumentPrivileges";
			this.vboxSpecialDocumentPrivileges.Spacing = 6;
			this.notebook.Add(this.vboxSpecialDocumentPrivileges);
			global::Gtk.Notebook.NotebookChild w47 = ((global::Gtk.Notebook.NotebookChild)(this.notebook[this.vboxSpecialDocumentPrivileges]));
			w47.Position = 4;
			// Notebook tab
			this.tabLabelSpecialDocumentPrivileges = new global::Gtk.Label();
			this.tabLabelSpecialDocumentPrivileges.Name = "tabLabelSpecialDocumentPrivileges";
			this.tabLabelSpecialDocumentPrivileges.LabelProp = global::Mono.Unix.Catalog.GetString("SpecialDocumentPrivileges");
			this.notebook.SetTabLabel(this.vboxSpecialDocumentPrivileges, this.tabLabelSpecialDocumentPrivileges);
			this.tabLabelSpecialDocumentPrivileges.ShowAll();
			this.vboxDialog.Add(this.notebook);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.vboxDialog[this.notebook]));
			w48.Position = 1;
			this.Add(this.vboxDialog);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.PasswordWarning.Hide();
			this.Hide();
		}
	}
}
