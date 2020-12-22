
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Dialogs.Cash
{
	public partial class CashRequestView
	{
		private global::Gtk.VBox vboxDialog;

		private global::Gtk.HBox hboxDialogButtons;

		private global::Gamma.GtkWidgets.yButton buttonSave;

		private global::Gamma.GtkWidgets.yButton buttonCancel;

		private global::Gamma.GtkWidgets.yLabel ylabelyourRoleIs;

		private global::Gamma.GtkWidgets.yLabel ylabelRole;

		private global::Gamma.GtkWidgets.yLabel labelStatus;

		private global::Gamma.GtkWidgets.yLabel ylabelStatus;

		private global::Gtk.Table table1;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry AuthorEntityviewmodelentry;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry ExpenseCategoryEntityviewmodelentry;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewSums;

		private global::Gtk.HBox hbox4;

		private global::Gamma.GtkWidgets.yButton ybtnAccept;

		private global::Gamma.GtkWidgets.yButton ybtnApprove;

		private global::Gamma.GtkWidgets.yButton ybtnConveyForResults;

		private global::Gamma.GtkWidgets.yButton ybtnCancel;

		private global::Gamma.GtkWidgets.yButton ybtnReturnForRenegotiation;

		private global::Gtk.HBox hbox6;

		private global::Gtk.HBox hbox7;

		private global::Gamma.GtkWidgets.yButton ybtnAddSumm;

		private global::Gamma.GtkWidgets.yButton ybtnEditSum;

		private global::Gamma.GtkWidgets.yButton ybtnDeleteSumm;

		private global::Gamma.GtkWidgets.yButton ybtnGiveSumm;

		private global::Gtk.HSeparator hseparator1;

		private global::Gtk.HSeparator hseparator2;

		private global::Gtk.HSeparator hseparator3;

		private global::Gtk.Label labelBalansOrganizations;

		private global::Gtk.Label labelCancelReason;

		private global::Gtk.Label labelCategoryEntityviewmodelentry;

		private global::Gtk.Label labelcomboOrganization;

		private global::Gtk.Label labelExplanation;

		private global::Gtk.Label labelGround;

		private global::Gtk.Label labelHaveReceipt;

		private global::Gtk.Label labelReasonForSendToReapproval;

		private global::Gtk.Label labelType5;

		private global::Gtk.Label labelType6;

		private global::QS.Widgets.GtkUI.SpecialListComboBox speccomboOrganization;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry SubdivisionEntityviewmodelentry;

		private global::Gamma.GtkWidgets.yCheckButton ycheckHaveReceipt;

		private global::Gamma.GtkWidgets.yEntry yentryCancelReason;

		private global::Gamma.GtkWidgets.yEntry yentryExplanation;

		private global::Gamma.GtkWidgets.yEntry yentryGround;

		private global::Gamma.GtkWidgets.yEntry yentryReasonForSendToReapproval;

		private global::Gamma.GtkWidgets.yLabel ylabelBalansOrganizations;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Dialogs.Cash.CashRequestView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Dialogs.Cash.CashRequestView";
			// Container child Vodovoz.Dialogs.Cash.CashRequestView.Gtk.Container+ContainerChild
			this.vboxDialog = new global::Gtk.VBox();
			this.vboxDialog.Name = "vboxDialog";
			this.vboxDialog.Spacing = 6;
			// Container child vboxDialog.Gtk.Box+BoxChild
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
			// Container child hboxDialogButtons.Gtk.Box+BoxChild
			this.ylabelyourRoleIs = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelyourRoleIs.Name = "ylabelyourRoleIs";
			this.ylabelyourRoleIs.LabelProp = global::Mono.Unix.Catalog.GetString("Роль:");
			this.hboxDialogButtons.Add(this.ylabelyourRoleIs);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hboxDialogButtons[this.ylabelyourRoleIs]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hboxDialogButtons.Gtk.Box+BoxChild
			this.ylabelRole = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelRole.Name = "ylabelRole";
			this.ylabelRole.LabelProp = global::Mono.Unix.Catalog.GetString(".");
			this.hboxDialogButtons.Add(this.ylabelRole);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hboxDialogButtons[this.ylabelRole]));
			w6.Position = 3;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hboxDialogButtons.Gtk.Box+BoxChild
			this.labelStatus = new global::Gamma.GtkWidgets.yLabel();
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.LabelProp = global::Mono.Unix.Catalog.GetString("Статус заявки:");
			this.hboxDialogButtons.Add(this.labelStatus);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hboxDialogButtons[this.labelStatus]));
			w7.Position = 4;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hboxDialogButtons.Gtk.Box+BoxChild
			this.ylabelStatus = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelStatus.Name = "ylabelStatus";
			this.ylabelStatus.LabelProp = global::Mono.Unix.Catalog.GetString(".");
			this.hboxDialogButtons.Add(this.ylabelStatus);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hboxDialogButtons[this.ylabelStatus]));
			w8.Position = 5;
			w8.Expand = false;
			w8.Fill = false;
			this.vboxDialog.Add(this.hboxDialogButtons);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vboxDialog[this.hboxDialogButtons]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vboxDialog.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(18)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.AuthorEntityviewmodelentry = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.AuthorEntityviewmodelentry.Events = ((global::Gdk.EventMask)(256));
			this.AuthorEntityviewmodelentry.Name = "AuthorEntityviewmodelentry";
			this.AuthorEntityviewmodelentry.CanEditReference = false;
			this.table1.Add(this.AuthorEntityviewmodelentry);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.AuthorEntityviewmodelentry]));
			w10.TopAttach = ((uint)(1));
			w10.BottomAttach = ((uint)(2));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ExpenseCategoryEntityviewmodelentry = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.ExpenseCategoryEntityviewmodelentry.Events = ((global::Gdk.EventMask)(256));
			this.ExpenseCategoryEntityviewmodelentry.Name = "ExpenseCategoryEntityviewmodelentry";
			this.ExpenseCategoryEntityviewmodelentry.CanEditReference = false;
			this.table1.Add(this.ExpenseCategoryEntityviewmodelentry);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.ExpenseCategoryEntityviewmodelentry]));
			w11.TopAttach = ((uint)(12));
			w11.BottomAttach = ((uint)(13));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewSums = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewSums.CanFocus = true;
			this.ytreeviewSums.Name = "ytreeviewSums";
			this.GtkScrolledWindow.Add(this.ytreeviewSums);
			this.table1.Add(this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.GtkScrolledWindow]));
			w13.TopAttach = ((uint)(3));
			w13.BottomAttach = ((uint)(5));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.ybtnAccept = new global::Gamma.GtkWidgets.yButton();
			this.ybtnAccept.CanFocus = true;
			this.ybtnAccept.Name = "ybtnAccept";
			this.ybtnAccept.UseUnderline = true;
			this.ybtnAccept.Label = global::Mono.Unix.Catalog.GetString("Подтвердить");
			this.hbox4.Add(this.ybtnAccept);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ybtnAccept]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.ybtnApprove = new global::Gamma.GtkWidgets.yButton();
			this.ybtnApprove.CanFocus = true;
			this.ybtnApprove.Name = "ybtnApprove";
			this.ybtnApprove.UseUnderline = true;
			this.ybtnApprove.Label = global::Mono.Unix.Catalog.GetString("Согласовать");
			this.hbox4.Add(this.ybtnApprove);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ybtnApprove]));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.ybtnConveyForResults = new global::Gamma.GtkWidgets.yButton();
			this.ybtnConveyForResults.CanFocus = true;
			this.ybtnConveyForResults.Name = "ybtnConveyForResults";
			this.ybtnConveyForResults.UseUnderline = true;
			this.ybtnConveyForResults.Label = global::Mono.Unix.Catalog.GetString("Передать на выдачу");
			this.hbox4.Add(this.ybtnConveyForResults);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ybtnConveyForResults]));
			w16.Position = 2;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.ybtnCancel = new global::Gamma.GtkWidgets.yButton();
			this.ybtnCancel.CanFocus = true;
			this.ybtnCancel.Name = "ybtnCancel";
			this.ybtnCancel.UseUnderline = true;
			this.ybtnCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			this.hbox4.Add(this.ybtnCancel);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ybtnCancel]));
			w17.Position = 3;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.ybtnReturnForRenegotiation = new global::Gamma.GtkWidgets.yButton();
			this.ybtnReturnForRenegotiation.CanFocus = true;
			this.ybtnReturnForRenegotiation.Name = "ybtnReturnForRenegotiation";
			this.ybtnReturnForRenegotiation.UseUnderline = true;
			this.ybtnReturnForRenegotiation.Label = global::Mono.Unix.Catalog.GetString("Отправить на пересогласование");
			this.hbox4.Add(this.ybtnReturnForRenegotiation);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ybtnReturnForRenegotiation]));
			w18.Position = 4;
			w18.Expand = false;
			w18.Fill = false;
			this.table1.Add(this.hbox4);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox4]));
			w19.TopAttach = ((uint)(17));
			w19.BottomAttach = ((uint)(18));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(0));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			this.table1.Add(this.hbox6);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox6]));
			w20.TopAttach = ((uint)(3));
			w20.BottomAttach = ((uint)(4));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.ybtnAddSumm = new global::Gamma.GtkWidgets.yButton();
			this.ybtnAddSumm.CanFocus = true;
			this.ybtnAddSumm.Name = "ybtnAddSumm";
			this.ybtnAddSumm.UseUnderline = true;
			this.ybtnAddSumm.Label = global::Mono.Unix.Catalog.GetString("Добавить");
			this.hbox7.Add(this.ybtnAddSumm);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.ybtnAddSumm]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.ybtnEditSum = new global::Gamma.GtkWidgets.yButton();
			this.ybtnEditSum.CanFocus = true;
			this.ybtnEditSum.Name = "ybtnEditSum";
			this.ybtnEditSum.UseUnderline = true;
			this.ybtnEditSum.Label = global::Mono.Unix.Catalog.GetString("Редактировать");
			this.hbox7.Add(this.ybtnEditSum);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.ybtnEditSum]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.ybtnDeleteSumm = new global::Gamma.GtkWidgets.yButton();
			this.ybtnDeleteSumm.CanFocus = true;
			this.ybtnDeleteSumm.Name = "ybtnDeleteSumm";
			this.ybtnDeleteSumm.UseUnderline = true;
			this.ybtnDeleteSumm.Label = global::Mono.Unix.Catalog.GetString("Удалить");
			this.hbox7.Add(this.ybtnDeleteSumm);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.ybtnDeleteSumm]));
			w23.Position = 2;
			w23.Expand = false;
			w23.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.ybtnGiveSumm = new global::Gamma.GtkWidgets.yButton();
			this.ybtnGiveSumm.CanFocus = true;
			this.ybtnGiveSumm.Name = "ybtnGiveSumm";
			this.ybtnGiveSumm.UseUnderline = true;
			this.ybtnGiveSumm.Label = global::Mono.Unix.Catalog.GetString("Выдать");
			this.hbox7.Add(this.ybtnGiveSumm);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.ybtnGiveSumm]));
			w24.Position = 3;
			w24.Expand = false;
			w24.Fill = false;
			this.table1.Add(this.hbox7);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox7]));
			w25.TopAttach = ((uint)(5));
			w25.BottomAttach = ((uint)(6));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hseparator1 = new global::Gtk.HSeparator();
			this.hseparator1.Name = "hseparator1";
			this.table1.Add(this.hseparator1);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.table1[this.hseparator1]));
			w26.TopAttach = ((uint)(9));
			w26.BottomAttach = ((uint)(10));
			w26.RightAttach = ((uint)(2));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hseparator2 = new global::Gtk.HSeparator();
			this.hseparator2.Name = "hseparator2";
			this.table1.Add(this.hseparator2);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.table1[this.hseparator2]));
			w27.TopAttach = ((uint)(13));
			w27.BottomAttach = ((uint)(14));
			w27.RightAttach = ((uint)(2));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hseparator3 = new global::Gtk.HSeparator();
			this.hseparator3.Name = "hseparator3";
			this.table1.Add(this.hseparator3);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.table1[this.hseparator3]));
			w28.TopAttach = ((uint)(16));
			w28.BottomAttach = ((uint)(17));
			w28.RightAttach = ((uint)(2));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelBalansOrganizations = new global::Gtk.Label();
			this.labelBalansOrganizations.Name = "labelBalansOrganizations";
			this.labelBalansOrganizations.Xalign = 0F;
			this.labelBalansOrganizations.LabelProp = global::Mono.Unix.Catalog.GetString("Баланс по нашим организациям:");
			this.labelBalansOrganizations.Wrap = true;
			this.labelBalansOrganizations.WidthChars = 1;
			this.labelBalansOrganizations.MaxWidthChars = 0;
			this.table1.Add(this.labelBalansOrganizations);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.table1[this.labelBalansOrganizations]));
			w29.TopAttach = ((uint)(10));
			w29.BottomAttach = ((uint)(11));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelCancelReason = new global::Gtk.Label();
			this.labelCancelReason.Name = "labelCancelReason";
			this.labelCancelReason.Xalign = 0F;
			this.labelCancelReason.LabelProp = global::Mono.Unix.Catalog.GetString("Причина отмены:");
			this.table1.Add(this.labelCancelReason);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.table1[this.labelCancelReason]));
			w30.TopAttach = ((uint)(15));
			w30.BottomAttach = ((uint)(16));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelCategoryEntityviewmodelentry = new global::Gtk.Label();
			this.labelCategoryEntityviewmodelentry.Name = "labelCategoryEntityviewmodelentry";
			this.labelCategoryEntityviewmodelentry.Xalign = 0F;
			this.labelCategoryEntityviewmodelentry.LabelProp = global::Mono.Unix.Catalog.GetString("Статья расхода:");
			this.table1.Add(this.labelCategoryEntityviewmodelentry);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.table1[this.labelCategoryEntityviewmodelentry]));
			w31.TopAttach = ((uint)(12));
			w31.BottomAttach = ((uint)(13));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelcomboOrganization = new global::Gtk.Label();
			this.labelcomboOrganization.Name = "labelcomboOrganization";
			this.labelcomboOrganization.Xalign = 0F;
			this.labelcomboOrganization.LabelProp = global::Mono.Unix.Catalog.GetString("Наша организация:");
			this.table1.Add(this.labelcomboOrganization);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.table1[this.labelcomboOrganization]));
			w32.TopAttach = ((uint)(11));
			w32.BottomAttach = ((uint)(12));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelExplanation = new global::Gtk.Label();
			this.labelExplanation.Name = "labelExplanation";
			this.labelExplanation.Xalign = 0F;
			this.labelExplanation.LabelProp = global::Mono.Unix.Catalog.GetString("Пояснение:");
			this.table1.Add(this.labelExplanation);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.table1[this.labelExplanation]));
			w33.TopAttach = ((uint)(7));
			w33.BottomAttach = ((uint)(8));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelGround = new global::Gtk.Label();
			this.labelGround.Name = "labelGround";
			this.labelGround.Xalign = 0F;
			this.labelGround.LabelProp = global::Mono.Unix.Catalog.GetString("Основание:");
			this.table1.Add(this.labelGround);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.table1[this.labelGround]));
			w34.TopAttach = ((uint)(6));
			w34.BottomAttach = ((uint)(7));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelHaveReceipt = new global::Gtk.Label();
			this.labelHaveReceipt.Name = "labelHaveReceipt";
			this.labelHaveReceipt.Xalign = 0F;
			this.labelHaveReceipt.LabelProp = global::Mono.Unix.Catalog.GetString("Наличие чека:");
			this.table1.Add(this.labelHaveReceipt);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.table1[this.labelHaveReceipt]));
			w35.TopAttach = ((uint)(8));
			w35.BottomAttach = ((uint)(9));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelReasonForSendToReapproval = new global::Gtk.Label();
			this.labelReasonForSendToReapproval.Name = "labelReasonForSendToReapproval";
			this.labelReasonForSendToReapproval.Xalign = 0F;
			this.labelReasonForSendToReapproval.LabelProp = global::Mono.Unix.Catalog.GetString("Причина отправки на пересогласование:");
			this.labelReasonForSendToReapproval.Wrap = true;
			this.labelReasonForSendToReapproval.WidthChars = 0;
			this.labelReasonForSendToReapproval.MaxWidthChars = 20;
			this.table1.Add(this.labelReasonForSendToReapproval);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.table1[this.labelReasonForSendToReapproval]));
			w36.TopAttach = ((uint)(14));
			w36.BottomAttach = ((uint)(15));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelType5 = new global::Gtk.Label();
			this.labelType5.Name = "labelType5";
			this.labelType5.Xalign = 0F;
			this.labelType5.LabelProp = global::Mono.Unix.Catalog.GetString("Автор:");
			this.table1.Add(this.labelType5);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.table1[this.labelType5]));
			w37.TopAttach = ((uint)(1));
			w37.BottomAttach = ((uint)(2));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelType6 = new global::Gtk.Label();
			this.labelType6.Name = "labelType6";
			this.labelType6.Xalign = 0F;
			this.labelType6.LabelProp = global::Mono.Unix.Catalog.GetString("Подразделение:");
			this.table1.Add(this.labelType6);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.table1[this.labelType6]));
			w38.TopAttach = ((uint)(2));
			w38.BottomAttach = ((uint)(3));
			w38.XOptions = ((global::Gtk.AttachOptions)(4));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.speccomboOrganization = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.speccomboOrganization.Name = "speccomboOrganization";
			this.speccomboOrganization.AddIfNotExist = false;
			this.speccomboOrganization.DefaultFirst = false;
			this.speccomboOrganization.ShowSpecialStateAll = false;
			this.speccomboOrganization.ShowSpecialStateNot = false;
			this.table1.Add(this.speccomboOrganization);
			global::Gtk.Table.TableChild w39 = ((global::Gtk.Table.TableChild)(this.table1[this.speccomboOrganization]));
			w39.TopAttach = ((uint)(11));
			w39.BottomAttach = ((uint)(12));
			w39.LeftAttach = ((uint)(1));
			w39.RightAttach = ((uint)(2));
			w39.XOptions = ((global::Gtk.AttachOptions)(4));
			w39.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.SubdivisionEntityviewmodelentry = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.SubdivisionEntityviewmodelentry.Events = ((global::Gdk.EventMask)(256));
			this.SubdivisionEntityviewmodelentry.Name = "SubdivisionEntityviewmodelentry";
			this.SubdivisionEntityviewmodelentry.CanEditReference = false;
			this.table1.Add(this.SubdivisionEntityviewmodelentry);
			global::Gtk.Table.TableChild w40 = ((global::Gtk.Table.TableChild)(this.table1[this.SubdivisionEntityviewmodelentry]));
			w40.TopAttach = ((uint)(2));
			w40.BottomAttach = ((uint)(3));
			w40.LeftAttach = ((uint)(1));
			w40.RightAttach = ((uint)(2));
			w40.XOptions = ((global::Gtk.AttachOptions)(4));
			w40.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckHaveReceipt = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckHaveReceipt.CanFocus = true;
			this.ycheckHaveReceipt.Name = "ycheckHaveReceipt";
			this.ycheckHaveReceipt.Label = "";
			this.ycheckHaveReceipt.DrawIndicator = true;
			this.ycheckHaveReceipt.UseUnderline = true;
			this.table1.Add(this.ycheckHaveReceipt);
			global::Gtk.Table.TableChild w41 = ((global::Gtk.Table.TableChild)(this.table1[this.ycheckHaveReceipt]));
			w41.TopAttach = ((uint)(8));
			w41.BottomAttach = ((uint)(9));
			w41.LeftAttach = ((uint)(1));
			w41.RightAttach = ((uint)(2));
			w41.XOptions = ((global::Gtk.AttachOptions)(4));
			w41.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryCancelReason = new global::Gamma.GtkWidgets.yEntry();
			this.yentryCancelReason.CanFocus = true;
			this.yentryCancelReason.Name = "yentryCancelReason";
			this.yentryCancelReason.IsEditable = true;
			this.yentryCancelReason.InvisibleChar = '•';
			this.table1.Add(this.yentryCancelReason);
			global::Gtk.Table.TableChild w42 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryCancelReason]));
			w42.TopAttach = ((uint)(15));
			w42.BottomAttach = ((uint)(16));
			w42.LeftAttach = ((uint)(1));
			w42.RightAttach = ((uint)(2));
			w42.XOptions = ((global::Gtk.AttachOptions)(4));
			w42.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryExplanation = new global::Gamma.GtkWidgets.yEntry();
			this.yentryExplanation.CanFocus = true;
			this.yentryExplanation.Name = "yentryExplanation";
			this.yentryExplanation.IsEditable = true;
			this.yentryExplanation.InvisibleChar = '•';
			this.table1.Add(this.yentryExplanation);
			global::Gtk.Table.TableChild w43 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryExplanation]));
			w43.TopAttach = ((uint)(7));
			w43.BottomAttach = ((uint)(8));
			w43.LeftAttach = ((uint)(1));
			w43.RightAttach = ((uint)(2));
			w43.XOptions = ((global::Gtk.AttachOptions)(4));
			w43.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryGround = new global::Gamma.GtkWidgets.yEntry();
			this.yentryGround.CanFocus = true;
			this.yentryGround.Name = "yentryGround";
			this.yentryGround.IsEditable = true;
			this.yentryGround.InvisibleChar = '•';
			this.table1.Add(this.yentryGround);
			global::Gtk.Table.TableChild w44 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryGround]));
			w44.TopAttach = ((uint)(6));
			w44.BottomAttach = ((uint)(7));
			w44.LeftAttach = ((uint)(1));
			w44.RightAttach = ((uint)(2));
			w44.XOptions = ((global::Gtk.AttachOptions)(4));
			w44.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryReasonForSendToReapproval = new global::Gamma.GtkWidgets.yEntry();
			this.yentryReasonForSendToReapproval.CanFocus = true;
			this.yentryReasonForSendToReapproval.Name = "yentryReasonForSendToReapproval";
			this.yentryReasonForSendToReapproval.IsEditable = true;
			this.yentryReasonForSendToReapproval.InvisibleChar = '•';
			this.table1.Add(this.yentryReasonForSendToReapproval);
			global::Gtk.Table.TableChild w45 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryReasonForSendToReapproval]));
			w45.TopAttach = ((uint)(14));
			w45.BottomAttach = ((uint)(15));
			w45.LeftAttach = ((uint)(1));
			w45.RightAttach = ((uint)(2));
			w45.XOptions = ((global::Gtk.AttachOptions)(4));
			w45.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabelBalansOrganizations = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelBalansOrganizations.Name = "ylabelBalansOrganizations";
			this.ylabelBalansOrganizations.LabelProp = global::Mono.Unix.Catalog.GetString(".");
			this.table1.Add(this.ylabelBalansOrganizations);
			global::Gtk.Table.TableChild w46 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabelBalansOrganizations]));
			w46.TopAttach = ((uint)(10));
			w46.BottomAttach = ((uint)(11));
			w46.LeftAttach = ((uint)(1));
			w46.RightAttach = ((uint)(2));
			w46.XOptions = ((global::Gtk.AttachOptions)(4));
			w46.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vboxDialog.Add(this.table1);
			global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.vboxDialog[this.table1]));
			w47.Position = 1;
			this.Add(this.vboxDialog);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
