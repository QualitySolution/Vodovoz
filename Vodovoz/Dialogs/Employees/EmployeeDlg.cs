﻿using System;
using System.Collections.Generic;
using System.Data.Bindings.Collections.Generic;
using System.Linq;
using Gamma.ColumnConfig;
using Gamma.Utilities;
using Gamma.Widgets;
using InstantSmsService;
using NLog;
using QS.Banks.Domain;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QS.Project.DB;
using QS.Project.Dialogs.GtkUI.ServiceDlg;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Project.Repositories;
using QS.Project.Services;
using QS.Project.Services.GtkUI;
using QS.Validation;
using QS.Widgets.GtkUI;
using QSOrmProject;
using QSProjectsLib;
using Vodovoz.Additions;
using Vodovoz.Core.DataService;
using Vodovoz.Dialogs.Employees;
using Vodovoz.Domain.Contacts;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Organizations;
using Vodovoz.Domain.Permissions;
using Vodovoz.Domain.Sale;
using Vodovoz.Domain.Service.BaseParametersServices;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.Permissions;
using Vodovoz.EntityRepositories.WageCalculation;
using Vodovoz.Filters.ViewModels;
using Vodovoz.FilterViewModels.Organization;
using Vodovoz.Infrastructure;
using Vodovoz.Journals.FilterViewModels;
using Vodovoz.Journals.JournalViewModels;
using Vodovoz.Journals.JournalViewModels.Organization;
using Vodovoz.JournalViewModels;
using Vodovoz.Parameters;
using Vodovoz.Services;
using Vodovoz.Tools;
using Vodovoz.ViewModel;
using Vodovoz.ViewModels.WageCalculation;

namespace Vodovoz
{
	public partial class EmployeeDlg : QS.Dialog.Gtk.EntityDialogBase<Employee>
	{
		private ICashDistributionCommonOrganisationProvider commonOrganisationProvider =
			new CashDistributionCommonOrganisationProvider(
				new OrganizationParametersProvider(ParametersProvider.Instance));
		
		public EmployeeDlg()
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Employee>();
			mySQLUserRepository = new MySQLUserRepository(new MySQLProvider(new GtkRunOperationService(), new GtkQuestionDialogsInteractive()), new GtkInteractiveService());
			this.authorizationService = new AuthorizationService(
				new PasswordGenerator(),
				new MySQLUserRepository(
					new MySQLProvider(new GtkRunOperationService(), new GtkQuestionDialogsInteractive()),
					new GtkInteractiveService()));
			

			TabName = "Новый сотрудник";
			ConfigureDlg();
		}

		public EmployeeDlg(int id)
		{
			this.Build();
			logger.Info("Загрузка информации о сотруднике...");
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<Employee>(id);
			mySQLUserRepository = new MySQLUserRepository(new MySQLProvider(new GtkRunOperationService(), new GtkQuestionDialogsInteractive()), new GtkInteractiveService());
			
			this.authorizationService = new AuthorizationService(
				new PasswordGenerator(),
				new MySQLUserRepository(
					new MySQLProvider(new GtkRunOperationService(), new GtkQuestionDialogsInteractive()),
					new GtkInteractiveService()));

			ConfigureDlg();
		}

		public EmployeeDlg(Employee sub) : this(sub.Id) {}

		public EmployeeDlg(IUnitOfWorkGeneric<Employee> uow)
		{
			this.Build();
			UoWGeneric = uow;
			if(!ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_change_trainee_to_driver")) {
				hiddenCategory.Add(EmployeeCategory.driver);
				hiddenCategory.Add(EmployeeCategory.forwarder);
			}
			mySQLUserRepository = new MySQLUserRepository(new MySQLProvider(new GtkRunOperationService(), new GtkQuestionDialogsInteractive()), new GtkInteractiveService());
			this.authorizationService = new AuthorizationService(
				new PasswordGenerator(),
				new MySQLUserRepository(
					new MySQLProvider(new GtkRunOperationService(), new GtkQuestionDialogsInteractive()),
					new GtkInteractiveService()));
			
			ConfigureDlg();
		}
		
		private ISubdivisionService subdivisionService;
		private bool canManageDriversAndForwarders;
		private bool canManageOfficeWorkers;
		private bool canEditOrganisationForSalary;
		private GenericObservableList<DriverWorkScheduleNode> driverWorkDays;

		private static readonly Logger logger = LogManager.GetCurrentClassLogger();
		private readonly MySQLUserRepository mySQLUserRepository;
		private readonly List<EmployeeCategory> hiddenCategory = new List<EmployeeCategory>();
		private readonly EmployeeDocumentType[] hiddenForRussianDocument = { EmployeeDocumentType.RefugeeId, EmployeeDocumentType.RefugeeCertificate, EmployeeDocumentType.Residence, EmployeeDocumentType.ForeignCitizenPassport };
		private readonly EmployeeDocumentType[] hiddenForForeignCitizen = { EmployeeDocumentType.MilitaryID, EmployeeDocumentType.NavyPassport, EmployeeDocumentType.OfficerCertificate };
		private readonly IAuthorizationService authorizationService;
		
		private void ConfigureDlg()
		{
			if (Entity.Id == 0) {
				Entity.OrganisationForSalary = commonOrganisationProvider.GetCommonOrganisation(UoW);
			}
			
			canManageDriversAndForwarders = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_manage_drivers_and_forwarders");
			canManageOfficeWorkers = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_manage_office_workers");
			canEditOrganisationForSalary = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_edit_organisation_for_salary");

			ConfigureCategory();
			ConfigureSubdivision();
			OnRussianCitizenToggled(null, EventArgs.Empty);
			dataentryDrivingNumber.MaxLength = 20;
			dataentryDrivingNumber.Binding.AddBinding(Entity, e => e.DrivingLicense, w => w.Text).InitializeFromSource();
			UoWGeneric.Root.PropertyChanged += OnPropertyChanged;
			notebookMain.Page = 0;
			notebookMain.ShowTabs = false;
			GenderComboBox.ItemsEnum = typeof(Gender);
			GenderComboBox.Binding.AddBinding(Entity, e => e.Gender, w => w.SelectedItemOrNull).InitializeFromSource();

			subdivisionService = SubdivisionParametersProvider.Instance;

			yenumcomboStatus.ItemsEnum = typeof(EmployeeStatus);
			yenumcomboStatus.Binding.AddBinding(Entity, e => e.Status, w => w.SelectedItem).InitializeFromSource();

			chkDriverForOneDay.Binding.AddBinding(Entity, e => e.IsDriverForOneDay, w => w.Active).InitializeFromSource();
			cmbDriverOf.ItemsEnum = typeof(CarTypeOfUse);
			cmbDriverOf.Binding.AddBinding(Entity, e => e.DriverOf, w => w.SelectedItemOrNull).InitializeFromSource();

			dataentryLastName.Binding.AddBinding(Entity, e => e.LastName, w => w.Text).InitializeFromSource();
			dataentryName.Binding.AddBinding(Entity, e => e.Name, w => w.Text).InitializeFromSource();
			dataentryPatronymic.Binding.AddBinding(Entity, e => e.Patronymic, w => w.Text).InitializeFromSource();
			dataentryInnerPhone.Binding.AddBinding(Entity, e => e.InnerPhone, w => w.Text, new Gamma.Binding.Converters.NumbersToStringConverter()).InitializeFromSource();

			entryAddressCurrent.Binding.AddBinding(Entity, e => e.AddressCurrent, w => w.Text).InitializeFromSource();
			entryAddressRegistration.Binding.AddBinding(Entity, e => e.AddressRegistration, w => w.Text).InitializeFromSource();
			entryInn.Binding.AddBinding(Entity, e => e.INN, w => w.Text).InitializeFromSource();

			dataentryAndroidLogin.Binding.AddBinding(Entity, e => e.AndroidLogin, w => w.Text).InitializeFromSource();
			dataentryAndroidPassword.Binding.AddBinding(Entity, e => e.AndroidPassword, w => w.Text).InitializeFromSource();

			var filterDefaultForwarder = new EmployeeFilterViewModel();
			filterDefaultForwarder.SetAndRefilterAtOnce(
				x => x.Category = EmployeeCategory.forwarder,
				x => x.Status = EmployeeStatus.IsWorking
			);
			repEntDefaultForwarder.RepresentationModel = new EmployeesVM(filterDefaultForwarder);
			repEntDefaultForwarder.Binding.AddBinding(Entity, e => e.DefaultForwarder, w => w.Subject).InitializeFromSource();

			referenceNationality.SubjectType = typeof(Nationality);
			referenceNationality.Binding.AddBinding(Entity, e => e.Nationality, w => w.Subject).InitializeFromSource();
			referenceCitizenship.SubjectType = typeof(Citizenship);
			referenceCitizenship.Binding.AddBinding(Entity, e => e.Citizenship, w => w.Subject).InitializeFromSource();

			referenceUser.SubjectType = typeof(User);
			referenceUser.CanEditReference = false;
			referenceUser.Binding.AddBinding(Entity, e => e.User, w => w.Subject).InitializeFromSource();
			referenceUser.Sensitive = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_manage_users");

			yenumcombobox13.ItemsEnum = typeof(RegistrationType);
			yenumcombobox13.Binding.AddBinding(Entity, e => e.Registration, w => w.SelectedItemOrNull).InitializeFromSource();

			comboDriverType.ItemsEnum = typeof(DriverType);
			comboDriverType.Binding.AddBinding(Entity, e => e.DriverType, w => w.SelectedItemOrNull).InitializeFromSource();

			ydatepicker1.Binding.AddBinding(Entity, e => e.BirthdayDate, w => w.DateOrNull).InitializeFromSource();
			dateFired.Binding.AddBinding(Entity, e => e.DateFired, w => w.DateOrNull).InitializeFromSource();
			dateHired.Binding.AddBinding(Entity, e => e.DateHired, w => w.DateOrNull).InitializeFromSource();
			dateCalculated.Binding.AddBinding(Entity, e => e.DateCalculated, w => w.DateOrNull).InitializeFromSource();

			photoviewEmployee.Binding.AddBinding(Entity, e => e.Photo, w => w.ImageFile).InitializeFromSource();
			photoviewEmployee.GetSaveFileName = () => Entity.FullName;

			attachmentFiles.AttachToTable = OrmConfig.GetDBTableName(typeof(Employee));
			if(Entity.Id != 0) {
				attachmentFiles.ItemId = UoWGeneric.Root.Id;
				attachmentFiles.UpdateFileList();
			}
			phonesView.UoW = UoWGeneric;
			if(UoWGeneric.Root.Phones == null)
				UoWGeneric.Root.Phones = new List<Phone>();
			phonesView.Phones = UoWGeneric.Root.Phones;
			accountsView.ParentReference = new ParentReferenceGeneric<Employee, Account>(UoWGeneric, o => o.Accounts);
			accountsView.SetTitle("Банковские счета сотрудника");
			ydateFirstWorkDay.Binding.AddBinding(Entity, e => e.FirstWorkDay, w => w.DateOrNull).InitializeFromSource();
			yspinTripsPriority.Binding.AddBinding(Entity, e => e.TripPriority, w => w.ValueAsShort).InitializeFromSource();
			yspinDriverSpeed.Binding.AddBinding(Entity, e => e.DriverSpeed, w => w.Value, new MultiplierToPercentConverter()).InitializeFromSource();
			minAddressesSpin.Binding.AddBinding(Entity, e => e.MinRouteAddresses, w => w.ValueAsInt).InitializeFromSource();
			maxAddressesSpin.Binding.AddBinding(Entity, e => e.MaxRouteAddresses, w => w.ValueAsInt).InitializeFromSource();
			checkbuttonRussianCitizen.Binding.AddBinding(Entity, e => e.IsRussianCitizen, w => w.Active).InitializeFromSource();
			checkVisitingMaster.Binding.AddBinding(Entity, e => e.VisitingMaster, w => w.Active).InitializeFromSource();
			checkChainStoreDriver.Binding.AddBinding(Entity, e => e.IsChainStoreDriver, w => w.Active).InitializeFromSource();

			ylblUserLogin.TooltipText = "При сохранении сотрудника создаёт нового пользователя с введённым логином и отправляет сотруднику SMS с сгенерированным паролем";
			yentryUserLogin.Binding.AddBinding(Entity, e => e.LoginForNewUser, w => w.Text);
			yentryUserLogin.Sensitive = CanCreateNewUser;

			specialListCmbOrganisation.ItemsList = UoW.GetAll<Organization>();
			specialListCmbOrganisation.Binding.AddBinding(Entity, e => e.OrganisationForSalary, w => w.SelectedItem).InitializeFromSource();
			specialListCmbOrganisation.Sensitive = canEditOrganisationForSalary;
			
			Entity.CheckAndFixDriverPriorities();
			ytreeviewDistricts.ColumnsConfig = FluentColumnsConfig<DriverDistrictPriority>.Create()
				.AddColumn("Район").AddTextRenderer(x => x.District.DistrictName)
				.AddColumn("Приоритет").AddNumericRenderer(x => x.Priority + 1)
				.Finish();
			ytreeviewDistricts.Reorderable = true;
			ytreeviewDistricts.SetItemsSource(Entity.ObservableDistricts);

			FillDriverWorkSchedule(new BaseParametersProvider());

			driverWorkDays.PropertyOfElementChanged += DriverWorkDays_PropertyOfElementChanged;

			ytreeviewDriverSchedule.ColumnsConfig = FluentColumnsConfig<DriverWorkScheduleNode>.Create()
				.AddColumn("").AddToggleRenderer(x => x.AtWork)
				.AddColumn("День").AddTextRenderer(x => x.WeekDay.GetEnumTitle())
				.AddColumn("Ходки")
					.AddComboRenderer(x => x.DaySchedule)
					.SetDisplayFunc(x => x.Name)
					.FillItems(UoW.GetAll<DeliveryDaySchedule>().ToList())
					.Editing()
				.Finish();
			ytreeviewDriverSchedule.SetItemsSource(driverWorkDays);

			ytreeviewEmployeeDocument.ColumnsConfig = FluentColumnsConfig<EmployeeDocument>.Create()
				.AddColumn("Документ").AddTextRenderer(x => x.Document.GetEnumTitle())
				.AddColumn("Доп. название").AddTextRenderer(x => x.Name)
				.Finish();
			ytreeviewEmployeeDocument.SetItemsSource(Entity.ObservableDocuments);

			ytreeviewEmployeeContract.ColumnsConfig = FluentColumnsConfig<EmployeeContract>.Create()
				.AddColumn("Договор").AddTextRenderer(x => x.EmployeeContractTemplate.TemplateType.GetEnumTitle())
				.AddColumn("Название").AddTextRenderer(x => x.Name)
				.AddColumn("Дата начала").AddTextRenderer(x => x.FirstDay.ToString("dd/MM/yyyy"))
				.AddColumn("Дата конца").AddTextRenderer(x => x.LastDay.ToString("dd/MM/yyyy"))
				.Finish();
			ytreeviewEmployeeContract.SetItemsSource(Entity.ObservableContracts);

			wageParametersView.ViewModel = new EmployeeWageParametersViewModel
			(
				Entity, 
				this, 
				UoW, 
				new HierarchicalPresetPermissionValidator(EmployeeSingletonRepository.GetInstance(), new PermissionRepository()),
				UserSingletonRepository.GetInstance(),
				ServicesConfig.CommonServices,
				NavigationManagerProvider.NavigationManager
			);

			logger.Info("Ok");
		}

		private void ConfigureCategory() 
		{
			comboCategory.ItemsEnum = typeof(EmployeeCategory);
			comboCategory.Binding.AddBinding(Entity, e => e.Category, w => w.SelectedItem).InitializeFromSource();

			if(Entity?.Id != 0) {
				comboCategory.Sensitive = false;
				return; 
			}

			var allCategories = Enum.GetValues(typeof(EmployeeCategory)).Cast<EmployeeCategory>();

			if(!canManageDriversAndForwarders && !canManageOfficeWorkers) {
				comboCategory.Sensitive = false;
				return;
			} else if(canManageDriversAndForwarders && !canManageOfficeWorkers)
				hiddenCategory.AddRange(allCategories.Except(new EmployeeCategory[] { EmployeeCategory.driver, EmployeeCategory.forwarder }));
			else if(canManageOfficeWorkers && !canManageDriversAndForwarders)
				hiddenCategory.AddRange(allCategories.Except(new EmployeeCategory[] { EmployeeCategory.office }));

			if(hiddenCategory != null && hiddenCategory.Any()) {
				comboCategory.AddEnumToHideList(hiddenCategory.Distinct().Cast<object>().ToArray());
			}
			comboCategory.ChangedByUser += (sender, e) => {
				if(Entity.Category != EmployeeCategory.driver)
					cmbDriverOf.SelectedItemOrNull = null;
			};
		}

		private void ConfigureSubdivision()
		{
			if(canManageDriversAndForwarders && !canManageOfficeWorkers) {
				var entityentrySubdivision = new EntityViewModelEntry();
				entityentrySubdivision.SetEntityAutocompleteSelectorFactory(
					new EntityAutocompleteSelectorFactory<SubdivisionsJournalViewModel>(typeof(Subdivision), () => {
						var filter = new SubdivisionFilterViewModel();
						filter.SubdivisionType = SubdivisionType.Logistic;
						IEntityAutocompleteSelectorFactory employeeSelectorFactory =
							new DefaultEntityAutocompleteSelectorFactory
							<Employee, EmployeesJournalViewModel, EmployeeFilterViewModel>(ServicesConfig.CommonServices);
						return new SubdivisionsJournalViewModel(
							filter,
							UnitOfWorkFactory.GetDefaultFactory,
							ServicesConfig.CommonServices,
							employeeSelectorFactory
						);
					})
				);
				entityentrySubdivision.Binding.AddBinding(Entity, e => e.Subdivision, w => w.Subject).InitializeFromSource();
				hboxSubdivision.Add(entityentrySubdivision);
				hboxSubdivision.ShowAll();
				return;
			}

			var entrySubdivision = new yEntryReference();
			entrySubdivision.SubjectType = typeof(Subdivision);
			entrySubdivision.Binding.AddBinding(Entity, e => e.Subdivision, w => w.Subject).InitializeFromSource();
			hboxSubdivision.Add(entrySubdivision);
			hboxSubdivision.ShowAll();

			if(!canManageOfficeWorkers && !canManageDriversAndForwarders) {
				entrySubdivision.Sensitive = false;
			}
		}
		
		public override bool HasChanges {
			get {
				phonesView.RemoveEmpty();
				return UoWGeneric.HasChanges || attachmentFiles.HasChanges || !String.IsNullOrEmpty(yentryUserLogin.Text);
			}
			set => base.HasChanges = value;
		}

		bool CanCreateNewUser => Entity.User == null && ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_manage_users");

		private void FillDriverWorkSchedule(IDefaultDeliveryDaySchedule defaultDelDaySchedule)
		{
			driverWorkDays = new GenericObservableList<DriverWorkScheduleNode> {
				new DriverWorkScheduleNode {WeekDay = WeekDayName.Monday},
				new DriverWorkScheduleNode {WeekDay = WeekDayName.Tuesday},
				new DriverWorkScheduleNode {WeekDay = WeekDayName.Wednesday},
				new DriverWorkScheduleNode {WeekDay = WeekDayName.Thursday},
				new DriverWorkScheduleNode {WeekDay = WeekDayName.Friday},
				new DriverWorkScheduleNode {WeekDay = WeekDayName.Saturday},
				new DriverWorkScheduleNode {WeekDay = WeekDayName.Sunday}
			};

			var daySchedule = UoW.GetById<DeliveryDaySchedule>(defaultDelDaySchedule.GetDefaultDeliveryDayScheduleId());

			foreach(DriverWorkScheduleNode workDay in driverWorkDays) {
				workDay.DaySchedule = daySchedule;

				if(Entity.ObservableWorkDays.Count > 0) {
					var day = Entity.ObservableWorkDays.SingleOrDefault(d => d.WeekDay == workDay.WeekDay);
					if(day != null) {
						workDay.AtWork = day.AtWork;
						workDay.DaySchedule = day.DaySchedule;
						workDay.DrvWorkSchedule = day;
					}
				}
			}
		}

		void DriverWorkDays_PropertyOfElementChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			//Пребираем строки с графиком работы
			foreach(DriverWorkScheduleNode workDay in driverWorkDays) {
				//Если день отмечен как рабочий и нет записи в БД
				if(workDay.AtWork && workDay.DrvWorkSchedule == null) {
					//Создаем рабочий день
					var newWorkDay = new DriverWorkSchedule {
						AtWork = true,
						DaySchedule = workDay.DaySchedule,
						WeekDay = workDay.WeekDay,
						Employee = Entity
					};
					workDay.DrvWorkSchedule = newWorkDay;
					Entity.ObservableWorkDays.Add(newWorkDay);
				} else { //Иначе смотрим в базе нужный день
					var day = Entity.ObservableWorkDays.SingleOrDefault(d => d.WeekDay == workDay.WeekDay
																			 && d.DaySchedule != workDay.DaySchedule);
					//Если запись есть меняем в ней график
					if(day != null)
						day.DaySchedule = workDay.DaySchedule;
				}

				//Если сняли рабочий день и запись в базе присутствует
				if(!workDay.AtWork && workDay.DrvWorkSchedule != null) {
					//находим запись и удаляем
					var day = Entity.ObservableWorkDays.SingleOrDefault(d => d.WeekDay == workDay.WeekDay);
					Entity.ObservableWorkDays.Remove(day);
					workDay.DrvWorkSchedule = null;
				}
			}
		}

		void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			logger.Debug("Property {0} changed", e.PropertyName);
		}

		public override bool Save()
		{
			if(Entity.Id == 0 && !canManageOfficeWorkers && !canManageDriversAndForwarders) {
				MessageDialogHelper.RunInfoDialog("У вас недостаточно прав для создания сотрудника");
				return false;
			}
			//Проверяем, чтобы в БД не попала пустая строка
			if(string.IsNullOrWhiteSpace(Entity.AndroidLogin))
				Entity.AndroidLogin = null;

			var valid = new QSValidator<Employee>(UoWGeneric.Root, Entity.GetValidationContextItems(subdivisionService));
			if(valid.RunDlgIfNotValid((Gtk.Window)this.Toplevel))
				return false;

			if(Entity.User != null) {
				var associatedEmployees = EmployeeSingletonRepository.GetInstance().GetEmployeesForUser(UoW, Entity.User.Id);
				if(associatedEmployees.Any(e => e.Id != Entity.Id)) {
					string mes = String.Format("Пользователь {0} уже связан с сотрудником {1}, при привязке этого сотрудника к пользователю, старая связь будет удалена. Продолжить?",
									 Entity.User.Name,
									 String.Join(", ", associatedEmployees.Select(e => e.ShortName))
								 );
					if(MessageDialogHelper.RunQuestionDialog(mes)) {
						foreach(var ae in associatedEmployees.Where(e => e.Id != Entity.Id)) {
							ae.User = null;
							UoWGeneric.Save(ae);
						}
					} else
						return false;
				}
			}
			if(Entity.InnerPhone != null) {
				var associatedEmployees = UoW.Session.Query<Employee>().Where(e => e.InnerPhone == Entity.InnerPhone);
				if(associatedEmployees.Any(e => e.Id != Entity.Id && e.InnerPhone == Entity.InnerPhone)) {
					string mes = String.Format("Внутренний номер {0} уже связан с сотрудником {1}, при привязке этого телефона к данному сотруднику , старая связь будет удалена. Продолжить?",
						Entity.InnerPhone,
						String.Join(", ", associatedEmployees.Select(e => e.Name))
						);
					if(MessageDialogHelper.RunQuestionDialog(mes)) {
						foreach(var ae in associatedEmployees.Where(e => e.InnerPhone == Entity.InnerPhone)) {
							ae.InnerPhone = null;
							UoW.Save(ae);
						}
					} else {
						return false;
					}
				}
			}
			Entity.CreateDefaultWageParameter(WageSingletonRepository.GetInstance(), new BaseParametersProvider(), ServicesConfig.InteractiveService);

			phonesView.RemoveEmpty();
			UoWGeneric.Save(Entity);

			#region Попытка сохранить логин для нового юзера
			if(!String.IsNullOrEmpty(Entity.LoginForNewUser) && InstantSmsServiceSetting.SendingAllowed)
			{
				if (!authorizationService.TryToSaveUser(Entity, UoWGeneric))
				{
					return false;
				}
			}
			#endregion

			logger.Info("Сохраняем сотрудника...");
			try {
				UoWGeneric.Save();
				if(UoWGeneric.IsNew) {
					attachmentFiles.ItemId = UoWGeneric.Root.Id;
				}
				attachmentFiles.SaveChanges();
			} catch(Exception ex) {
				logger.Error(ex, "Не удалось записать сотрудника.");
				QSMain.ErrorMessage((Gtk.Window)this.Toplevel, ex);
				return false;
			}
			logger.Info("Ok");
			return true;
		}

		protected void OnRussianCitizenToggled(object sender, EventArgs e)
		{
			if(Entity.IsRussianCitizen == false) {
				labelCitizenship.Visible = true;
				referenceCitizenship.Visible = true;
			} else {
				labelCitizenship.Visible = false;
				referenceCitizenship.Visible = false;
				Entity.Citizenship = null;
			}
		}

		#region RadioTabToggled
		protected void OnRadioTabInfoToggled(object sender, EventArgs e)
		{
			if(radioTabInfo.Active)
				notebookMain.CurrentPage = 0;
		}

		protected void OnRadioTabFilesToggled(object sender, EventArgs e)
		{
			if(radioTabFiles.Active)
				notebookMain.CurrentPage = 3;
		}

		protected void OnRadioTabAccountingToggled(object sender, EventArgs e)
		{
			if(radioTabAccounting.Active)
				notebookMain.CurrentPage = 2;
		}

		protected void OnRadioTabLogisticToggled(object sender, EventArgs e)
		{
			if(radioTabLogistic.Active)
				notebookMain.CurrentPage = 1;
		}

		protected void OnRadioTabEmployeeDocumentToggled(object sender, EventArgs e)
		{
			if(radioTabEmployeeDocument.Active)
				notebookMain.CurrentPage = 5;
		}

		protected void OnRadioTabContractsToggled(object sender, EventArgs e)
		{
			if(radioTabContracts.Active)
				notebookMain.CurrentPage = 4;
		}
		#endregion

		#region Document
		protected void OnButtonAddDocumentClicked(object sender, EventArgs e)
		{
			EmployeeDocDlg dlg = new EmployeeDocDlg(UoW, Entity.IsRussianCitizen ? hiddenForRussianDocument : hiddenForForeignCitizen);
			dlg.Save += (object sender1, EventArgs e1) => Entity.ObservableDocuments.Add(dlg.Entity);
			TabParent.AddSlaveTab(this, dlg);
		}

		protected void OnButtonRemoveDocumentClicked(object sender, EventArgs e)
		{
			var toRemoveDocument = ytreeviewEmployeeDocument.GetSelectedObjects<EmployeeDocument>().ToList();
			toRemoveDocument.ForEach(x => Entity.ObservableDocuments.Remove(x));
		}

		protected void OnButtonEditDocumentClicked(object sender, EventArgs e)
		{
			if(ytreeviewEmployeeDocument.GetSelectedObject<EmployeeDocument>() != null) {
				EmployeeDocDlg dlg = new EmployeeDocDlg(((EmployeeDocument)ytreeviewEmployeeDocument.GetSelectedObjects()[0]).Id, UoW);
				TabParent.AddSlaveTab(this, dlg);
			}
		}

		protected void OnEmployeeDocumentRowActivated(object o, Gtk.RowActivatedArgs args)
		{
			buttonDocumentEdit.Click();
		}

		#endregion

		#region Contract
		protected void OnAddContractButtonCliked(object sender, EventArgs e)
		{
			List<EmployeeDocument> doc = Entity.GetMainDocuments();
			if(!doc.Any()) {
				MessageDialogHelper.RunInfoDialog("Отсутствует главный документ");
				return;
			} 
			if(Entity.Registration != RegistrationType.Contract) {
				MessageDialogHelper.RunInfoDialog("Должен быть указан тип регистрации: 'ГПК' ");//FIXME: Временно до задачи I-1556
				return;
			}
			EmployeeContractDlg dlg = new EmployeeContractDlg(doc[0], Entity, UoW);
			dlg.Save += (object sender1, EventArgs e1) => Entity.ObservableContracts.Add(dlg.Entity);
			TabParent.AddSlaveTab(this, dlg);
		}

		protected void OnButtonRemoveContractClicked(object sender, EventArgs e)
		{
			var toRemoveContract = ytreeviewEmployeeContract.GetSelectedObjects<EmployeeContract>().ToList();
			toRemoveContract.ForEach(x => Entity.ObservableContracts.Remove(x));
		}

		protected void OnButtonEditContractClicked(object sender, EventArgs e)
		{
			if(ytreeviewEmployeeContract.GetSelectedObject<EmployeeContract>() != null) {
				EmployeeContractDlg dlg = new EmployeeContractDlg(((EmployeeContract)ytreeviewEmployeeContract.GetSelectedObjects()[0]).Id, UoW);
				TabParent.AddSlaveTab(this, dlg);
			}

		}

		protected void OnEmployeeContractRowActivated(object o, Gtk.RowActivatedArgs args)
		{
			buttonContractEdit.Click();
		}

		#endregion

		#region Driver & forwarder
		protected void OnButtonAddDistrictClicked(object sender, EventArgs e)
		{
			var filter = new DistrictJournalFilterViewModel { Status = DistrictsSetStatus.Active, OnlyWithBorders = true };
			var journalViewModel = new DistrictJournalViewModel(filter, UnitOfWorkFactory.GetDefaultFactory, ServicesConfig.CommonServices) {
				EnableDeleteButton = false, EnableEditButton = false, EnableAddButton = false, SelectionMode = JournalSelectionMode.Multiple
			};
			journalViewModel.OnEntitySelectedResult += (o, args) => {
				var addDistricts = args.SelectedNodes;
				addDistricts.Where(x => Entity.Districts.All(d => d.District.Id != x.Id))
					.Select(x => new DriverDistrictPriority {
						Driver = Entity,
						District = UoW.GetById<District>(x.Id)
					})
					.ToList()
					.ForEach(x => Entity.ObservableDistricts.Add(x));
			};
			TabParent.AddSlaveTab(this, journalViewModel);
		}

		protected void OnButtonRemoveDistrictClicked(object sender, EventArgs e)
		{
			var toRemoveDistricts = ytreeviewDistricts.GetSelectedObjects<DriverDistrictPriority>().ToList();
			toRemoveDistricts.ForEach(x => Entity.ObservableDistricts.Remove(x));
		}

		protected void OnComboCategoryEnumItemSelected(object sender, Gamma.Widgets.ItemSelectedEventArgs e)
		{
			radioTabLogistic.Visible
				= lblDriverOf.Visible
				= hboxDriversParameters.Visible
				= ((EmployeeCategory)e.SelectedItem == EmployeeCategory.driver);

			wageParametersView.Sensitive = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_edit_wage");
		}

		protected void OnRadioWageParametersClicked(object sender, EventArgs e)
		{
			if(radioWageParameters.Active)
				notebookMain.CurrentPage = 6;
		}

		#endregion
	}
}