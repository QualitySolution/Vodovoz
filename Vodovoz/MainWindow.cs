﻿using System;
using System.Linq;
using Gamma.Utilities;
using Gtk;
using NLog;
using QS.Banks.Domain;
using QS.BusinessCommon.Domain;
using QS.Contacts;
using QS.Dialog.Gtk;
using QS.Dialog.GtkUI;
using QS.DomainModel.Config;
using QS.DomainModel.UoW;
using QS.Project.Dialogs;
using QS.Project.Dialogs.GtkUI;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Project.Repositories;
using QS.Project.Services;
using QS.RepresentationModel.GtkUI;
using QS.Tdi.Gtk;
using QSBanks;
using QSOrmProject;
using QSProjectsLib;
using QSSupportLib;
using Vodovoz;
using Vodovoz.Core;
using Vodovoz.Core.DataService;
using Vodovoz.Dialogs.OnlineStore;
using Vodovoz.Dialogs.OrderWidgets;
using Vodovoz.Domain;
using Vodovoz.Domain.Cash;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Complaints;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Sale;
using Vodovoz.Domain.Store;
using Vodovoz.Domain.StoredResources;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.Logistic;
using Vodovoz.EntityRepositories.Subdivisions;
using Vodovoz.EntityRepositories.WageCalculation;
using Vodovoz.Filters.ViewModels;
using Vodovoz.FilterViewModels;
using Vodovoz.Infrastructure.Services;
using Vodovoz.JournalViewers;
using Vodovoz.JournalViewModels;
using Vodovoz.JournalViewModels.WageCalculation;
using Vodovoz.ReportsParameters;
using Vodovoz.ReportsParameters.Bookkeeping;
using Vodovoz.ReportsParameters.Bottles;
using Vodovoz.ReportsParameters.Logistic;
using Vodovoz.ReportsParameters.Orders;
using Vodovoz.ReportsParameters.Payments;
using Vodovoz.ReportsParameters.Store;
using Vodovoz.Representations;
using Vodovoz.ServiceDialogs;
using Vodovoz.ServiceDialogs.Database;
using Vodovoz.SidePanel.InfoProviders;
using Vodovoz.TempAdapters;
using Vodovoz.ViewModel;
using Vodovoz.ViewModels.Complaints;
using Vodovoz.ViewModels.WageCalculation;
using Vodovoz.ViewWidgets;
using ToolbarStyle = Vodovoz.Domain.Employees.ToolbarStyle;

public partial class MainWindow : Gtk.Window, IProgressBarDisplayable
{
	private static Logger logger = LogManager.GetCurrentClassLogger();
	uint LastUiId;

	public TdiNotebook TdiMain {
		get {
			return tdiMain;
		}
	}

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		PerformanceHelper.AddTimePoint("Закончена стандартная сборка окна.");
		this.BuildToolbarActions();
		this.KeyReleaseEvent += ClipboardWorkaround.HandleKeyReleaseEvent;
		TDIMain.MainNotebook = tdiMain;
		this.KeyReleaseEvent += TDIMain.TDIHandleKeyReleaseEvent;
		//Передаем лебл
		QSMain.StatusBarLabel = labelStatus;
		this.Title = MainSupport.GetTitle();
		QSMain.MakeNewStatusTargetForNlog();
		//Настраиваем модули
		MainClass.SetupAppFromBase();
		ActionUsers.Sensitive = QSMain.User.Admin;
		ActionAdministration.Sensitive = QSMain.User.Admin;
		labelUser.LabelProp = QSMain.User.Name;
		ActionCash.Sensitive = UserPermissionRepository.CurrentUserPresetPermissions["money_manage_cash"];
		ActionAccounting.Sensitive = UserPermissionRepository.CurrentUserPresetPermissions["money_manage_bookkeeping"];
		ActionRouteListsAtDay.Sensitive =
			ActionRouteListTracking.Sensitive =
			ActionRouteListMileageCheck.Sensitive =
			ActionRouteListAddressesTransferring.Sensitive = UserPermissionRepository.CurrentUserPresetPermissions["logistican"];
		ActionStock.Sensitive = CurrentPermissions.Warehouse.Allowed().Any();

		bool hasAccessToSalaries = UserPermissionRepository.CurrentUserPresetPermissions["access_to_salaries"];
		bool hasAccessToWagesAndBonuses = UserPermissionRepository.CurrentUserPresetPermissions["access_to_fines_bonuses"];
		ActionEmployeesBonuses.Sensitive = hasAccessToWagesAndBonuses;
		ActionEmployeeFines.Sensitive = hasAccessToWagesAndBonuses;
		ActionEmployeesBonuses.Sensitive = hasAccessToWagesAndBonuses;
		ActionDriverWages.Sensitive = hasAccessToSalaries;
		ActionWagesOperations.Sensitive = hasAccessToSalaries;
		ActionForwarderWageReport.Sensitive = hasAccessToSalaries;

		ActionWage.Sensitive = UserPermissionRepository.CurrentUserPresetPermissions["can_edit_wage"];

		ActionFinesJournal.Visible = ActionPremiumJournal.Visible = UserPermissionRepository.CurrentUserPresetPermissions["access_to_fines_bonuses"];
		ActionReports.Sensitive = false;
		//ActionServices.Visible = false;
		ActionDocTemplates.Visible = QSMain.User.Admin;
		ActionService.Sensitive = UserPermissionRepository.CurrentUserPresetPermissions["database_maintenance"];

		//Читаем настройки пользователя
		switch(CurrentUserSettings.Settings.ToolbarStyle) {
			case ToolbarStyle.Both:
				ActionToolBarBoth.Activate();
				break;
			case ToolbarStyle.Icons:
				ActionToolBarIcon.Activate();
				break;
			case ToolbarStyle.Text:
				ActionToolBarText.Activate();
				break;
		}

		switch(CurrentUserSettings.Settings.ToolBarIconsSize) {
			case IconsSize.ExtraSmall:
				ActionIconsExtraSmall.Activate();
				break;
			case IconsSize.Small:
				ActionIconsSmall.Activate();
				break;
			case IconsSize.Middle:
				ActionIconsMiddle.Activate();
				break;
			case IconsSize.Large:
				ActionIconsLarge.Activate();
				break;
		}

		BanksUpdater.CheckBanksUpdate(false);
	}

	#region IProgressBarDisplayable implementation

	public void ProgressStart(double maxValue, double minValue = 0, string text = null, double startValue = 0)
	{
		progressStatus.Adjustment = new Adjustment(startValue, minValue, maxValue, 1, 1, 1);
		progressStatus.Text = text;
		progressStatus.Visible = true;
		QSMain.WaitRedraw();
	}

	public void ProgressUpdate(double curValue)
	{
		if(progressStatus == null || progressStatus.Adjustment == null)
			return;
		progressStatus.Adjustment.Value = curValue;
		QSMain.WaitRedraw();
	}

	public void ProgressUpdate(string curText)
	{
		if(progressStatus == null || progressStatus.Adjustment == null)
			return;
		progressStatus.Text = curText;
		QSMain.WaitRedraw();
	}

	public void ProgressAdd(double addValue = 1, string text = null)
	{
		if(progressStatus == null)
			return;
		progressStatus.Adjustment.Value += addValue;
		if(text != null)
			progressStatus.Text = text;
		if(progressStatus.Adjustment.Value > progressStatus.Adjustment.Upper)
			logger.Warn("Значение ({0}) прогресс бара в статусной строке больше максимального ({1})",
						(int)progressStatus.Adjustment.Value,
						(int)progressStatus.Adjustment.Upper
					   );
		QSMain.WaitRedraw();
	}

	public void ProgressClose()
	{
		progressStatus.Text = null;
		progressStatus.Visible = false;
		QSMain.WaitRedraw();
	}

	#endregion

	public void OnTdiMainTabAdded(object sender, TabAddedEventArgs args)
	{
		if(args.Tab is IInfoProvider dialogTab)
			dialogTab.CurrentObjectChanged += infopanel.OnCurrentObjectChanged;
		else if(args.Tab is TdiSliderTab journalTab && journalTab.Journal is IInfoProvider journal)
			journal.CurrentObjectChanged += infopanel.OnCurrentObjectChanged;
	}

	public void OnTdiMainTabClosed(object sender, TabClosedEventArgs args)
	{
		if(args.Tab is IInfoProvider dialogTab)
			infopanel.OnInfoProviderDisposed(dialogTab);
		else if(args.Tab is TdiSliderTab journalTab && journalTab.Journal is IInfoProvider journal)
			infopanel.OnInfoProviderDisposed(journal);
		if(tdiMain.NPages == 0)
			infopanel.SetInfoProvider(DefaultInfoProvider.Instance);
	}

	public void OnTdiMainTabSwitched(object sender, TabSwitchedEventArgs args)
	{
		var currentTab = args.Tab;
		if(currentTab is IInfoProvider)
			infopanel.SetInfoProvider(currentTab as IInfoProvider);
		else if(currentTab is TdiSliderTab && (currentTab as TdiSliderTab).Journal is IInfoProvider)
			infopanel.SetInfoProvider((currentTab as TdiSliderTab).Journal as IInfoProvider);
		else
			infopanel.SetInfoProvider(DefaultInfoProvider.Instance);
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		if(tdiMain.CloseAllTabs()) {
			a.RetVal = false;
			MainClass.TrayIcon.Dispose();
			Application.Quit();
		} else {
			a.RetVal = true;
		}
	}

	protected void OnQuitActionActivated(object sender, EventArgs e)
	{
		if(tdiMain.CloseAllTabs()) {
			Application.Quit();
		}
	}

	protected void OnDialogAuthenticationActionActivated(object sender, EventArgs e)
	{
		QSMain.User.ChangeUserPassword(this);
	}

	protected void OnAboutActionActivated(object sender, EventArgs e)
	{
		QSMain.RunAboutDialog();
	}

	protected void OnActionOrdersToggled(object sender, EventArgs e)
	{
		if(ActionOrders.Active)
			SwitchToUI("Vodovoz.toolbars.orders.xml");
	}

	private void SwitchToUI(string uiResource)
	{
		if(LastUiId > 0) {
			this.UIManager.RemoveUi(LastUiId);
			LastUiId = 0;
		}
		LastUiId = this.UIManager.AddUiFromResource(uiResource);
		this.UIManager.EnsureUpdate();
	}

	protected void OnActionServicesToggled(object sender, EventArgs e)
	{
		if(ActionServices.Active)
			SwitchToUI("Vodovoz.toolbars.services.xml");
	}

	protected void OnActionLogisticsToggled(object sender, EventArgs e)
	{
		if(ActionLogistics.Active)
			SwitchToUI("logistics.xml");
	}

	protected void OnActionStockToggled(object sender, EventArgs e)
	{
		if(ActionStock.Active)
			SwitchToUI("warehouse.xml");
	}

	protected void OnActionCRMActivated(object sender, EventArgs e)
	{
		SwitchToUI("Vodovoz.toolbars.CRM.xml");
	}

	protected void OnActionOrganizationsActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(Organization));
		tdiMain.AddTab(refWin);
	}

	protected void OnSubdivisionsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<Subdivision>(),
			() => new OrmReference(typeof(Subdivision))
		);
	}

	protected void OnActionBanksRFActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(Bank));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionNationalityActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(Nationality));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionCitizenshipActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(Citizenship));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionEmployeeActivated(object sender, EventArgs e)
	{
		EmployeeFilterViewModel employeeFilter = new EmployeeFilterViewModel(ServicesConfig.CommonServices);
		tdiMain.OpenTab(
			PermissionControlledRepresentationJournal.GenerateHashName<EmployeesVM>(),
			() => new PermissionControlledRepresentationJournal(new EmployeesVM(employeeFilter))
		);
	}

	protected void OnActionCarsActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(Car));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionUnitsActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(MeasurementUnits));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionDiscountReasonsActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(DiscountReason));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionColorsActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(EquipmentColors));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionManufacturersActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(Manufacturer));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionEquipmentTypesActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(EquipmentType));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionNomenclatureActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(Nomenclature));
		refWin.ButtonMode = ReferenceButtonMode.CanEdit;
		refWin.ButtonMode |= UserPermissionRepository.CurrentUserPresetPermissions["can_create_and_arc_nomenclatures"] ? ReferenceButtonMode.CanAdd : ReferenceButtonMode.None;
		refWin.ButtonMode |= UserPermissionRepository.CurrentUserPresetPermissions["can_delete_nomenclatures"] ? ReferenceButtonMode.CanDelete : ReferenceButtonMode.None;
		tdiMain.AddTab(refWin);
	}

	protected void OnActionPhoneTypesActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(PhoneType));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionCounterpartyHandbookActivated(object sender, EventArgs e)
	{
		CounterpartyJournalFilterViewModel filter = new CounterpartyJournalFilterViewModel(ServicesConfig.CommonServices.InteractiveService);
		var counterpartyJournal = new CounterpartyJournalViewModel(filter, UnitOfWorkFactory.GetDefaultFactory, ServicesConfig.CommonServices);

		tdiMain.AddTab(counterpartyJournal);
	}

	protected void OnActionEMailTypesActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(EmailType));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionCounterpartyPostActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(Post));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionFreeRentPackageActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(FreeRentPackage));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionPaidRentPackageActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(PaidRentPackage));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionEquipmentActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(Equipment));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionDeliveryScheduleActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(DeliverySchedule));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionUpdateBanksFromCBRActivated(object sender, EventArgs e)
	{
		BanksUpdater.CheckBanksUpdate(true);
	}

	protected void OnActionWarehousesActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			TdiTabBase.GenerateHashName<WarehousesView>(),
			() => new WarehousesView()
		);
	}

	protected void OnActionProductSpecificationActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(ProductSpecification));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionCullingCategoryActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(CullingCategory));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionCommentTemplatesActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(CommentTemplate));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionLoad1cActivated(object sender, EventArgs e)
	{
		var win = new LoadFrom1cDlg();
		tdiMain.AddTab(win);
	}

	protected void OnActionRouteColumnsActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(RouteColumn));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionFuelTypeActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<FuelType>(),
			() => new OrmReference(typeof(FuelType))
		);
	}

	protected void OnActionDeliveryShiftActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(DeliveryShift));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionParametersActivated(object sender, EventArgs e)
	{
		var config = new ApplicationConfigDialog();
		config.ShowAll();
		config.Run();
		config.Destroy();
	}

	protected void OnAction14Activated(object sender, EventArgs e)
	{
		var vm = new EntityCommonRepresentationModelConstructor<IncomeCategory>()
			.AddColumn("Имя", x => x.Name).AddSearch(x => x.Name)
			.AddColumn("Тип", x => x.IncomeDocumentType.GetEnumTitle())
			.OrderBy(x => x.Name)
			.Finish();
		tdiMain.AddTab(new PermissionControlledRepresentationJournal(vm));
	}

	protected void OnAction15Activated(object sender, EventArgs e)
	{
		var vm = new EntityCommonRepresentationModelConstructor<ExpenseCategory>()
			.AddColumn("Имя", x => x.Name).AddSearch(x => x.Name)
			.AddColumn("Тип", x => x.ExpenseDocumentType.GetEnumTitle())
			.OrderBy(x => x.Name)
			.Finish();
		tdiMain.AddTab(new PermissionControlledRepresentationJournal(vm));
	}

	protected void OnActionCashToggled(object sender, EventArgs e)
	{
		if(ActionCash.Active)
			SwitchToUI("cash.xml");
	}

	protected void OnActionAccountingToggled(object sender, EventArgs e)
	{
		if(ActionAccounting.Active)
			SwitchToUI("accounting.xml");
	}

	protected void OnActionDocTemplatesActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<DocTemplate>(),
			() => new OrmReference(typeof(DocTemplate))
		);
	}

	protected void OnActionToolBarTextToggled(object sender, EventArgs e)
	{
		if(ActionToolBarText.Active)
			ToolBarMode(ToolbarStyle.Text);
	}

	private void ToolBarMode(ToolbarStyle style)
	{
		if(CurrentUserSettings.Settings.ToolbarStyle != style) {
			CurrentUserSettings.Settings.ToolbarStyle = style;
			CurrentUserSettings.SaveSettings();
		}
		toolbarMain.ToolbarStyle = (Gtk.ToolbarStyle)style;
		tlbComplaints.ToolbarStyle = (Gtk.ToolbarStyle)style;
		ActionIconsExtraSmall.Sensitive = ActionIconsSmall.Sensitive = ActionIconsMiddle.Sensitive = ActionIconsLarge.Sensitive =
			style != ToolbarStyle.Text;
	}

	private void ToolBarMode(IconsSize size)
	{
		if(CurrentUserSettings.Settings.ToolBarIconsSize != size) {
			CurrentUserSettings.Settings.ToolBarIconsSize = size;
			CurrentUserSettings.SaveSettings();
		}
		switch(size) {
			case IconsSize.ExtraSmall:
				toolbarMain.IconSize = IconSize.SmallToolbar;
				tlbComplaints.IconSize = IconSize.SmallToolbar;
				break;
			case IconsSize.Small:
				toolbarMain.IconSize = IconSize.LargeToolbar;
				tlbComplaints.IconSize = IconSize.LargeToolbar;
				break;
			case IconsSize.Middle:
				toolbarMain.IconSize = IconSize.Dnd;
				tlbComplaints.IconSize = IconSize.Dnd;
				break;
			case IconsSize.Large:
				toolbarMain.IconSize = IconSize.Dialog;
				tlbComplaints.IconSize = IconSize.Dialog;
				break;
		}
	}

	protected void OnActionToolBarIconToggled(object sender, EventArgs e)
	{
		if(ActionToolBarIcon.Active)
			ToolBarMode(ToolbarStyle.Icons);
	}

	protected void OnActionToolBarBothToggled(object sender, EventArgs e)
	{
		if(ActionToolBarBoth.Active)
			ToolBarMode(ToolbarStyle.Both);
	}

	protected void OnActionIconsExtraSmallToggled(object sender, EventArgs e)
	{
		if(ActionIconsExtraSmall.Active)
			ToolBarMode(IconsSize.ExtraSmall);
	}

	protected void OnActionIconsSmallToggled(object sender, EventArgs e)
	{
		if(ActionIconsSmall.Active)
			ToolBarMode(IconsSize.Small);
	}

	protected void OnActionIconsMiddleToggled(object sender, EventArgs e)
	{
		if(ActionIconsMiddle.Active)
			ToolBarMode(IconsSize.Middle);
	}

	protected void OnActionIconsLargeToggled(object sender, EventArgs e)
	{
		if(ActionIconsLarge.Active)
			ToolBarMode(IconsSize.Large);
	}

	protected void OnActionDeliveryPointsActivated(object sender, EventArgs e)
	{
		Buttons mode = Buttons.Edit;
		if(UserPermissionRepository.CurrentUserPresetPermissions["can_delete_counterparty_and_deliverypoint"])
			mode |= Buttons.Delete;

		tdiMain.OpenTab(
			PermissionControlledRepresentationJournal.GenerateHashName<DeliveryPointsVM>(),
			() => new PermissionControlledRepresentationJournal(new DeliveryPointsVM(), mode)
		);
	}

	protected void OnPropertiesActionActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			DialogHelper.GenerateDialogHashName<UserSettings>(CurrentUserSettings.Settings.Id),
			() => new UserSettingsDlg(CurrentUserSettings.Settings)
		);
	}

	protected void OnActionTransportationWagonActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<MovementWagon>(),
			() => new OrmReference(typeof(MovementWagon))
		);
	}

	protected void OnActionRegrandingOfGoodsTempalteActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<RegradingOfGoodsTemplate>(),
			() => new OrmReference(typeof(RegradingOfGoodsTemplate))
		);
	}

	protected void OnActionEmployeeFinesActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.EmployeesFines>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.EmployeesFines())
		);
	}

	protected void OnActionStockMovementsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.StockMovements>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.StockMovements())
		);
	}

	protected void OnActionArchiveToggled(object sender, EventArgs e)
	{
		if(ActionArchive.Active)
			SwitchToUI("archive.xml");
	}

	protected void OnActionStaffToggled(object sender, EventArgs e)
	{
		if(ActionStaff.Active)
			SwitchToUI("Vodovoz.toolbars.staff.xml");
	}

	protected void OnActionComplaintsActivated(object sender, EventArgs e)
	{
		IUndeliveriesViewOpener undeliveriesViewOpener = new UndeliveriesViewOpener();
		IEntitySelectorFactory employeeSelectorFactory = new EntityRepresentationAdapterFactory(typeof(Employee), () => new EmployeesVM());
		IEntityAutocompleteSelectorFactory counterpartySelectorFactory = new DefaultEntityAutocompleteSelectorFactory<Counterparty, CounterpartyJournalViewModel, CounterpartyJournalFilterViewModel>(ServicesConfig.CommonServices);
		ISubdivisionRepository subdivisionRepository = new SubdivisionRepository();
		IRouteListItemRepository routeListItemRepository = new RouteListItemRepository();
		IFilePickerService filePickerService = new GtkFilePicker();

		tdiMain.OpenTab(
			() => {
				return new ComplaintsJournalViewModel(
					UnitOfWorkFactory.GetDefaultFactory,
					ServicesConfig.CommonServices,
					undeliveriesViewOpener,
					VodovozGtkServicesConfig.EmployeeService,
					employeeSelectorFactory,
					counterpartySelectorFactory,
					routeListItemRepository,
					new BaseParametersProvider(),
					EmployeeSingletonRepository.GetInstance(),
					new ComplaintFilterViewModel(new GtkInteractiveService()),
					filePickerService,
					subdivisionRepository,
					new GtkReportViewOpener(),
					new GtkTabsOpener()
				);
			}
		);
	}

	protected void OnActionSalesReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.SalesReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.SalesReport())
		);
	}

	protected void OnActionDriverWagesActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.DriverWagesReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.DriverWagesReport())
		);
	}

	protected void OnActionFuelReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.FuelReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.FuelReport())
		);
	}

	protected void OnActionShortfallBattlesActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Bottles.ShortfallBattlesReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Bottles.ShortfallBattlesReport())
		);
	}

	protected void OnActionWagesOperationsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.WagesOperationsReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.WagesOperationsReport())
		);
	}

	protected void OnActionEquipmentReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.EquipmentReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.EquipmentReport())
		);
	}

	protected void OnActionForwarderWageReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.ForwarderWageReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.ForwarderWageReport())
		);
	}

	protected void OnActionCashierCommentsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.CashierCommentsReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.CashierCommentsReport())
		);
	}

	protected void OnActionCommentsForLogistsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<OnecCommentsReport>(),
			() => new QSReport.ReportViewDlg(new OnecCommentsReport())
		);
	}

	protected void OnActionDriversWageBalanceActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.DriversWageBalanceReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.DriversWageBalanceReport())
		);
	}

	protected void OnActionFineCommentTemplatesActivated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(FineTemplate));
		tdiMain.AddTab(refWin);
	}

	protected void OnActionDeliveriesLateActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.Logistic.DeliveriesLateReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.Logistic.DeliveriesLateReport())
		);
	}

	protected void OnActionRoutesListRegisterActivated(object sender, EventArgs e) => OpenRoutesListRegisterReport(false);
	protected void OnActionOrderedByIdRoutesListRegisterActivated(object sender, EventArgs e) => OpenRoutesListRegisterReport(true);

	protected void OpenRoutesListRegisterReport(bool orderById)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.Reports.Logistic.RoutesListRegisterReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.Reports.Logistic.RoutesListRegisterReport(orderById))
		);
	}

	protected void OnActionDeliveryTimeReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Logistic.DeliveryTimeReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Logistic.DeliveryTimeReport())
		);
	}

	protected void OnActionOrdersByDistrict(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<OrdersByDistrictReport>(),
			() => new QSReport.ReportViewDlg(new OrdersByDistrictReport())
		);
	}

	protected void OnActionCompanyTrucksActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<CompanyTrucksReport>(),
			() => new QSReport.ReportViewDlg(new CompanyTrucksReport())
		);
	}

	protected void OnActionLastOrderReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<LastOrderByDeliveryPointReport>(),
			() => new QSReport.ReportViewDlg(new LastOrderByDeliveryPointReport())
		);
	}


	protected void OnActionOrderIncorrectPricesReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<OrderIncorrectPrices>(),
			() => new QSReport.ReportViewDlg(new OrderIncorrectPrices())
		);
	}

	protected void OnActionAddressDuplicetesActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			TdiTabBase.GenerateHashName<MergeAddressesDlg>(),
			() => new MergeAddressesDlg()
		);
	}

	protected void OnActionOrdersWithMinPriceLessThanActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<OrdersWithMinPriceLessThan>(),
			() => new QSReport.ReportViewDlg(new OrdersWithMinPriceLessThan())
		);
	}

	protected void OnActionRouteListsOnClosingActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Logistic.RouteListsOnClosingReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Logistic.RouteListsOnClosingReport())
		);
	}

	protected void OnActionOnLoadTimeActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Logistic.OnLoadTimeAtDayReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Logistic.OnLoadTimeAtDayReport())
		);
	}

	protected void OnActionSelfDeliveryReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<SelfDeliveryReport>(),
			() => new QSReport.ReportViewDlg(new SelfDeliveryReport())
		);
	}

	protected void OnActionDeliveryDayScheduleActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<DeliveryDaySchedule>(),
			() => new OrmReference(typeof(DeliveryDaySchedule))
		);
	}

	protected void OnActionShipmentReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Logistic.ShipmentReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Logistic.ShipmentReport())
		);
	}

	protected void OnActionBottlesMovementReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Bottles.BottlesMovementReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Bottles.BottlesMovementReport())
		);
	}

	protected void OnActionMileageReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Logistic.MileageReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Logistic.MileageReport())
		);
	}

	protected void OnActionMastersReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<MastersReport>(),
			() => new QSReport.ReportViewDlg(new MastersReport())
		);
	}

	protected void OnActionSuburbWaterPriceActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Sales.SuburbWaterPriceReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Sales.SuburbWaterPriceReport())
		);
	}

	protected void OnActionDistanceFromCenterActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			TdiTabBase.GenerateHashName<CalculateDistanceToPointsDlg>(),
			() => new CalculateDistanceToPointsDlg()
		);
	}

	protected void OnActionOrdersWithoutBottlesOperationActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			TdiTabBase.GenerateHashName<OrdersWithoutBottlesOperationDlg>(),
			() => new OrdersWithoutBottlesOperationDlg()
		);
	}

	protected void OnActionHistoryLogActivated(object sender, EventArgs e)
	{
		tdiMain.AddTab(new QS.HistoryLog.Dialogs.HistoryView());
	}

	protected void OnAction45Activated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			TdiTabBase.GenerateHashName<ReplaceEntityLinksDlg>(),
			() => new ReplaceEntityLinksDlg()
		);
	}

	protected void OnActionBottlesMovementSummaryReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Bottles.BottlesMovementSummaryReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Bottles.BottlesMovementSummaryReport())
		);
	}

	protected void OnActionDriveingCallsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Logistic.DrivingCallReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Logistic.DrivingCallReport())
		);
	}

	protected void OnActionMastersVisitReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<MastersVisitReport>(),
			() => new QSReport.ReportViewDlg(new MastersVisitReport())
		);
	}

	protected void OnActionNotDeliveredOrdersActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<NotDeliveredOrdersReport>(),
			() => new QSReport.ReportViewDlg(new NotDeliveredOrdersReport())
		);
	}

	protected void OnActionCounterpartyTagsActivated(object sender, EventArgs e)
	{
		var refWin = new OrmReference(typeof(Tag));
		tdiMain.AddTab(refWin);
	}

	protected void OnAction47Activated(object sender, EventArgs e)
	{
		OrmReference refWin = new OrmReference(typeof(PremiumTemplate));
		tdiMain.AddTab(refWin);
	}

	protected void OnAction48Activated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<EmployeesPremiums>(),
			() => new QSReport.ReportViewDlg(new EmployeesPremiums())
		);
	}

	protected void OnAction49Activated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<OrderStatisticByWeekReport>(),
			() => new QSReport.ReportViewDlg(new OrderStatisticByWeekReport())
		);
	}

	protected void OnReportKungolovoActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<ReportForBigClient>(),
			() => new QSReport.ReportViewDlg(new ReportForBigClient())
		);
	}

	protected void OnActionLoad1cCounterpartyAndDeliveryPointsActivated(object sender, EventArgs e)
	{
		var widget = new LoadFrom1cClientsAndDeliveryPoints();
		tdiMain.AddTab(widget);
	}

	protected void OnActionFolders1cActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<Folder1c>(),
			() => new OrmReference(typeof(Folder1c))
		);
	}

	protected void OnActionOrderRegistryActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<OrderRegistryReport>(),
			() => new QSReport.ReportViewDlg(new OrderRegistryReport())
		);
	}

	protected void OnActionEquipmentBalanceActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Store.EquipmentBalance>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Store.EquipmentBalance())
		);
	}

	protected void OnActionCardPaymentsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<CardPaymentsOrdersReport>(),
			() => new QSReport.ReportViewDlg(new CardPaymentsOrdersReport())
		);
	}

	protected void OnActionCameFromActivated(object sender, EventArgs e)
	{
		ClientCameFromFilterViewModel filter = new ClientCameFromFilterViewModel(ServicesConfig.CommonServices.InteractiveService) {
			HidenByDefault = true
		};
		var journal = new ClientCameFromJournalViewModel(filter, UnitOfWorkFactory.GetDefaultFactory, ServicesConfig.CommonServices);
		tdiMain.AddTab(journal);
	}

	protected void OnActionProductGroupsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<ProductGroup>(),
			() => new OrmReference(typeof(ProductGroup))
		);
	}

	protected void OnActionToOnlineStoreActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			TdiTabBase.GenerateHashName<ExportToSiteDlg>(),
			() => new ExportToSiteDlg()
		);
	}

	protected void OnActionSendedBillsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<SendedEmailsReport>(),
			() => new QSReport.ReportViewDlg(new SendedEmailsReport())
		);
	}

	protected void OnActionDefectiveItemsReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<DefectiveItemsReport>(),
			() => new QSReport.ReportViewDlg(new DefectiveItemsReport())
		);
	}

	protected void OnActionTraineeActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			PermissionControlledRepresentationJournal.GenerateHashName<TraineeVM>(),
			() => new PermissionControlledRepresentationJournal(new TraineeVM())
		);
	}

	protected void OnActionDeliveryPriceRulesActivated(object sender, EventArgs e)
	{
		bool right = UserPermissionRepository.CurrentUserPresetPermissions["can_edit_delivery_price_rules"];
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<DeliveryPriceRule>(),
			() => {
				var dlg = new OrmReference(typeof(DeliveryPriceRule)) {
					ButtonMode = right ? ReferenceButtonMode.CanAll : ReferenceButtonMode.None
				};
				return dlg;
			}
		);
	}

	protected void OnOnLineActionActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<PaymentsFromTinkoffReport>(),
			() => new QSReport.ReportViewDlg(new PaymentsFromTinkoffReport())
		);
	}

	protected void OnActionOrdersByDistrictsAndDeliverySchedulesActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<OrdersByDistrictsAndDeliverySchedulesReport>(),
			() => new QSReport.ReportViewDlg(new OrdersByDistrictsAndDeliverySchedulesReport())
		);
	}

	protected void OnActionOrdersByCreationDate(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<OrdersByCreationDateReport>(),
			() => new QSReport.ReportViewDlg(new OrdersByCreationDateReport())
		);
	}

	protected void OnActionTypesOfEntitiesActivated(object sender, EventArgs e)
	{
		if(QSMain.User.Admin)
			tdiMain.OpenTab(
				OrmReference.GenerateHashName<TypeOfEntity>(),
				() => new OrmReference(typeof(TypeOfEntity))
			);
	}

	protected void OnActionUsersActivated(object sender, EventArgs e)
	{
		UsersDialog usersDlg = new UsersDialog();
		usersDlg.Show();
		usersDlg.Run();
		usersDlg.Destroy();
	}

	protected void OnActionGeographicGroupsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<GeographicGroup>(),
			() => new OrmReference(typeof(GeographicGroup))
		);
	}

	protected void OnActionSetDistrictsToDeliveryPointsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab<DistrictFinderForDeliveryPointsDlg>();
	}

	protected void OnChequesReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<ChequesReport>(),
			() => new QSReport.ReportViewDlg(new ChequesReport())
		);
	}

	protected void OnActionCertificatesActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<Certificate>(),
			() => new OrmReference(typeof(Certificate))
		);
	}

	protected void OnForShipmentReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<NomenclatureForShipment>(),
			() => new QSReport.ReportViewDlg(new NomenclatureForShipment())
		);
	}

	protected void OnImageListOpenActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<StoredImageResource>(),
			() => new OrmReference(typeof(StoredImageResource))
		);
	}

	protected void OnActionOrderCreationDateReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<Vodovoz.ReportsParameters.Sales.OrderCreationDateReport>(),
			() => new QSReport.ReportViewDlg(new Vodovoz.ReportsParameters.Sales.OrderCreationDateReport())
		);
	}

	protected void OnActionNotFullyLoadedRouteListsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<NotFullyLoadedRouteListsReport>(),
			() => new QSReport.ReportViewDlg(new NotFullyLoadedRouteListsReport())
		);
	}

	protected void OnActionFirstClientsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<FirstClientsReport>(),
			() => new QSReport.ReportViewDlg(new FirstClientsReport())
		);
	}

	protected void OnActionTariffZoneDebtsReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<TariffZoneDebts>(),
			() => new QSReport.ReportViewDlg(new TariffZoneDebts())
		);
	}

	protected void OnActionTariffZonesActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<TariffZone>(),
			() => new OrmReference(typeof(TariffZone))
		);
	}

	protected void OnActionStockMovementsAdvancedReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<StockMovementsAdvancedReport>(),
			() => new QSReport.ReportViewDlg(new StockMovementsAdvancedReport())
		);
	}

	protected void OnActionNonReturnReasonsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<NonReturnReason>(),
			() => new OrmReference(typeof(NonReturnReason))
		);
	}

	protected void OnActionPromotionalSetsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<PromotionalSet>(),
			() => new OrmReference(typeof(PromotionalSet))
		);
	}

	protected void OnActionDeliveryPointCategoryActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<DeliveryPointCategory>(),
			() => new OrmReference(typeof(DeliveryPointCategory))
		);
	}

	protected void OnActionCounterpartyActivityKindsActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<CounterpartyActivityKind>(),
			() => new OrmReference(typeof(CounterpartyActivityKind))
		);
	}

	protected void OnActionCounterpartyActivityKindActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<ClientsByDeliveryPointCategoryAndActivityKindsReport>(),
			() => new QSReport.ReportViewDlg(new ClientsByDeliveryPointCategoryAndActivityKindsReport())
		);
	}

	protected void OnActionExtraBottlesReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<ExtraBottleReport>(),
			() => new QSReport.ReportViewDlg(new ExtraBottleReport())
		);
	}

	protected void OnActionFirstSecondReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<FirstSecondClientReport>(),
			() => new QSReport.ReportViewDlg(new FirstSecondClientReport())
		);
	}

	protected void OnActionFuelConsumptionReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<FuelConsumptionReport>(),
			() => new QSReport.ReportViewDlg(new FuelConsumptionReport())
		);
	}

	protected void OnActionCloseDeliveryReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<CounterpartyCloseDeliveryReport>(),
			() => new QSReport.ReportViewDlg(new CounterpartyCloseDeliveryReport())
		);
	}

	protected void OnIncomeBalanceReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<IncomeBalanceReport>(),
			() => new QSReport.ReportViewDlg(new IncomeBalanceReport())
		);
	}

	protected void OnActionProfitabilityBottlesByStockActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<ProfitabilityBottlesByStockReport>(),
			() => new QSReport.ReportViewDlg(new ProfitabilityBottlesByStockReport())
		);
	}

	protected void OnActionPaymentsFromActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<PaymentFrom>(),
			() => new OrmReference(typeof(PaymentFrom))
		);
	}

	protected void OnAction62Activated(object sender, EventArgs e)
	{
		var widget = new ResendEmailsDialog();
		tdiMain.AddTab(widget);
	}

	protected void OnActionComplaintSourcesActivated(object sender, EventArgs e)
	{
		var complaintSourcesViewModel = new SimpleEntityJournalViewModel<ComplaintSource, ComplaintSourceViewModel>(
			x => x.Name,
			() => new ComplaintSourceViewModel(EntityUoWBuilder.ForCreate(), ServicesConfig.CommonServices),
			(node) => new ComplaintSourceViewModel(EntityUoWBuilder.ForOpen(node.Id), ServicesConfig.CommonServices),
			 UnitOfWorkFactory.GetDefaultFactory,
			ServicesConfig.CommonServices
		);
		tdiMain.AddTab(complaintSourcesViewModel);
	}

	protected void OnActionComplaintResultActivated(object sender, EventArgs e)
	{
		var complaintResultsViewModel = new SimpleEntityJournalViewModel<ComplaintResult, ComplaintResultViewModel>(
			x => x.Name,
			() => new ComplaintResultViewModel(EntityUoWBuilder.ForCreate(), ServicesConfig.CommonServices),
			(node) => new ComplaintResultViewModel(EntityUoWBuilder.ForOpen(node.Id), ServicesConfig.CommonServices),
			UnitOfWorkFactory.GetDefaultFactory,
			ServicesConfig.CommonServices
		);
		tdiMain.AddTab(complaintResultsViewModel);
	}

	protected void OnActionSuppliersActivated(object sender, EventArgs e)
	{
		SwitchToUI("Vodovoz.toolbars.suppliers.xml");
	}

	protected void OnActionPlanImplementationReportActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			QSReport.ReportViewDlg.GenerateHashName<PlanImplementationReport>(),
			() => new QSReport.ReportViewDlg(new PlanImplementationReport())
		);
	}

	protected void OnActionWageDistrictActivated(object sender, EventArgs e)
	{
		tdiMain.AddTab(
			new WageDistrictsJournalViewModel(
				 UnitOfWorkFactory.GetDefaultFactory,
				ServicesConfig.CommonServices
			)
		);
	}

	protected void OnActionRatesActivated(object sender, EventArgs e)
	{
		tdiMain.AddTab(
			new WageDistrictLevelRatesJournalViewModel(
				UnitOfWorkFactory.GetDefaultFactory,
				ServicesConfig.CommonServices
			)
		);
	}

	protected void OnActionWageParametersForMercenariesCarsActivated(object sender, EventArgs e)
	{
		tdiMain.AddTab(
			new CarsWageParametersViewModel(
				UnitOfWorkFactory.GetDefaultFactory,
				WageSingletonRepository.GetInstance(),
				ServicesConfig.CommonServices
			)
		);
	}

	protected void OnActionSalesPlansActivated(object sender, EventArgs e)
	{
		tdiMain.AddTab(
			new SalesPlanJournalViewModel(
				UnitOfWorkFactory.GetDefaultFactory,
				ServicesConfig.CommonServices
			)
		);
	}
}