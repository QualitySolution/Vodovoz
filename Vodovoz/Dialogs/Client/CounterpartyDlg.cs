﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gamma.GtkWidgets;
using NLog;
using QS.Banks.Domain;
using Vodovoz.Domain.Contacts;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QS.Project.Dialogs;
using QS.Project.Dialogs.GtkUI;
using QS.Project.Domain;
using QS.Project.Journal.EntitySelector;
using QSOrmProject;
using QSProjectsLib;
using QS.Validation;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Employees;
using Vodovoz.Filters.ViewModels;
using Vodovoz.Repositories;
using Vodovoz.SidePanel;
using Vodovoz.SidePanel.InfoProviders;
using Vodovoz.ViewModel;
using Gtk;
using Vodovoz.Domain.Goods;
using QS.Project.Services;
using QS.Tdi;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.FilterViewModels.Goods;
using Vodovoz.Infrastructure.Services;
using Vodovoz.JournalSelector;
using Vodovoz.JournalViewModels;
using Vodovoz.Parameters;
using Vodovoz.ViewModels.ViewModels.Goods;
using Vodovoz.TempAdapters;
using Vodovoz.Models;
using Vodovoz.Domain;
using Vodovoz.Domain.EntityFactories;
using QS.DomainModel.Entity;
using Vodovoz.Domain.Retail;
using System.Data.Bindings.Collections.Generic;
using NHibernate.Transform;
using System.ComponentModel;
using QS.ViewModels;
using Vodovoz.Dialogs.OrderWidgets;
using Vodovoz.Domain.Service.BaseParametersServices;
using Vodovoz.EntityRepositories.Logistic;
using Vodovoz.EntityRepositories.Subdivisions;
using Vodovoz.FilterViewModels;
using Vodovoz.Journals.JournalActionsViewModels;
using Vodovoz.Journals.JournalViewModels;
using Vodovoz.JournalViewers;
using Vodovoz.ViewModels.ViewModels.Counterparty;
using Vodovoz.ViewWidgets;
using NomenclatureRepository = Vodovoz.EntityRepositories.Goods.NomenclatureRepository;

namespace Vodovoz
{
    public partial class CounterpartyDlg : QS.Dialog.Gtk.EntityDialogBase<Counterparty>, ICounterpartyInfoProvider, ITDICloseControlTab
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        private readonly IEmployeeService employeeService = VodovozGtkServicesConfig.EmployeeService;
        private readonly IUserRepository userRepository = UserSingletonRepository.GetInstance();

        private bool currentUserCanEditCounterpartyDetails = false;

        private  INomenclatureRepository nomenclatureRepository;

        private bool deliveryPointsConfigured = false;
        private bool documentsConfigured = false;
        
        private IUndeliveriesViewOpener undeliveriesViewOpener;

        public virtual IUndeliveriesViewOpener UndeliveriesViewOpener
        {
	        get
	        {
		        if (undeliveriesViewOpener is null)
		        {
			        undeliveriesViewOpener = new UndeliveriesViewOpener();
		        }

		        return undeliveriesViewOpener;
	        }
        }

        private IEntityAutocompleteSelectorFactory employeeSelectorFactory;

        public virtual IEntityAutocompleteSelectorFactory EmployeeSelectorFactory
        {
	        get
	        {
		        if (employeeSelectorFactory is null)
		        {
			        employeeSelectorFactory =
				        new EntityAutocompleteSelectorFactory<EmployeesJournalViewModel>(typeof(Employee),
					        () =>
					        {
						        var employeeFilter = new EmployeeFilterViewModel();
						
						        var employeesJournalActions = 
							        new EmployeesJournalActionsViewModel(ServicesConfig.InteractiveService, UnitOfWorkFactory.GetDefaultFactory);
						
						        return new EmployeesJournalViewModel(
							        employeesJournalActions,
							        employeeFilter,
							        UnitOfWorkFactory.GetDefaultFactory,
							        ServicesConfig.CommonServices);
					        });
		        }
		        return employeeSelectorFactory;
	        }
        }

        private ISubdivisionRepository subdivisionRepository;

        public virtual ISubdivisionRepository SubdivisionRepository
        {
	        get
	        {
		        if (subdivisionRepository is null)
		        {
			        subdivisionRepository = new SubdivisionRepository();
		        }
		        return subdivisionRepository;
	        }
        }

        private IRouteListItemRepository routeListItemRepository;
        
        public virtual IRouteListItemRepository RouteListItemRepository
        {
	        get
	        {
		        if (routeListItemRepository is null)
		        {
			        routeListItemRepository = new RouteListItemRepository();
		        }

		        return routeListItemRepository;
	        }
        }

        private IFilePickerService filePickerService = new GtkFilePicker();
        
        public virtual IFilePickerService FilePickerService
        {
	        get
	        {
		        if (filePickerService is null)
		        {
			        filePickerService = new GtkFilePicker();
		        }

		        return filePickerService;
	        }
        }
        
        public virtual INomenclatureRepository NomenclatureRepository {
            get {
                if(nomenclatureRepository == null) {
                    nomenclatureRepository = new EntityRepositories.Goods.NomenclatureRepository(new NomenclatureParametersProvider());
                };
                return nomenclatureRepository;
            }
        }

        #region Список каналов сбыта

        private GenericObservableList<SalesChannelSelectableNode> salesChannels = new GenericObservableList<SalesChannelSelectableNode>();
        public GenericObservableList<SalesChannelSelectableNode> SalesChannels {
            get => salesChannels; 
            private set {
                UnsubscribeOnCheckChanged();
                salesChannels = value;
                SubscribeOnCheckChanged();
            }
        }

        private void UnsubscribeOnCheckChanged()
        {
            foreach (SalesChannelSelectableNode selectableSalesChannel in SalesChannels)
            {
                selectableSalesChannel.PropertyChanged -= OnStatusCheckChanged;
            }
        }

        private void SubscribeOnCheckChanged()
        {
            foreach (SalesChannelSelectableNode selectableSalesChannel in SalesChannels)
            {
                selectableSalesChannel.PropertyChanged += OnStatusCheckChanged;
            }
        }

        private void OnStatusCheckChanged(object sender, PropertyChangedEventArgs e)
        {
            var salesChannelSelectableNode = sender as SalesChannelSelectableNode;

            if(salesChannelSelectableNode.Selected) {
                if (!Entity.SalesChannels.Any(x => x.Id == salesChannelSelectableNode.Id))
                {
                    Entity.SalesChannels.Add(UoW.Session.Get<SalesChannel>(salesChannelSelectableNode.Id));
                }
            } else {
                SalesChannel salesChannelToRemove = Entity.SalesChannels.Where(x => x.Id == salesChannelSelectableNode.Id).FirstOrDefault();
                if (salesChannelToRemove != null)
                {
                    Entity.SalesChannels.Remove(salesChannelToRemove);
                }
            }
        }

        #endregion

        private IEntityAutocompleteSelectorFactory counterpartySelectorFactory;
        public virtual IEntityAutocompleteSelectorFactory CounterpartySelectorFactory {
            get {
                if(counterpartySelectorFactory == null) {
                    counterpartySelectorFactory =
                        new DefaultEntityAutocompleteSelectorFactory<Counterparty, CounterpartyJournalViewModel,
                            CounterpartyJournalFilterViewModel>(ServicesConfig.CommonServices);
                };
                return counterpartySelectorFactory;
            }
        }

        private IEntityAutocompleteSelectorFactory nomenclatureSelectorFactory;
        public virtual IEntityAutocompleteSelectorFactory NomenclatureSelectorFactory {
            get {
                if(nomenclatureSelectorFactory == null) {
                    nomenclatureSelectorFactory =
                        new NomenclatureAutoCompleteSelectorFactory<Nomenclature, NomenclaturesJournalViewModel>(
                            ServicesConfig.CommonServices, new NomenclatureFilterViewModel(), 
                            new EntitiesJournalActionsViewModel(ServicesConfig.InteractiveService),CounterpartySelectorFactory,
                            NomenclatureRepository, userRepository);
                }
                return nomenclatureSelectorFactory;
            }
        }

        public event EventHandler<CurrentObjectChangedArgs> CurrentObjectChanged;

        public PanelViewType[] InfoWidgets => new[] { PanelViewType.CounterpartyView };

        public Counterparty Counterparty => UoWGeneric.Root;
        public override bool HasChanges {
            get {
                phonesView.RemoveEmpty();
                emailsView.RemoveEmpty();
                return base.HasChanges;
            }
            set => base.HasChanges = value;
        }

        public CounterpartyDlg()
        {
            this.Build();
            UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Counterparty>();
            ConfigureDlg();
        }

        public CounterpartyDlg(int id)
        {
            this.Build();
            UoWGeneric = UnitOfWorkFactory.CreateForRoot<Counterparty>(id);
            ConfigureDlg();
        }

        public CounterpartyDlg(Counterparty sub) : this(sub.Id) { }

        public CounterpartyDlg(IEntityUoWBuilder uowBuilder, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.Build();
            UoWGeneric = uowBuilder.CreateUoW<Counterparty>(unitOfWorkFactory);
            ConfigureDlg();
        }

        public CounterpartyDlg(Phone phone)
        {
            this.Build();
            UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Counterparty>();
            Entity.Phones.Add(phone);
            ConfigureDlg();
        }

        void ConfigureDlg()
        {
            notebook1.CurrentPage = 0;
            notebook1.ShowTabs = false;
            radioSpecialDocFields.Visible = Entity.UseSpecialDocFields;
            rbnPrices.Toggled += OnRbnPricesToggled;

            currentUserCanEditCounterpartyDetails =
                UoW.IsNew
                || ServicesConfig.CommonServices.PermissionService.ValidateUserPresetPermission(
                    "can_edit_counterparty_details",
                    ServicesConfig.CommonServices.UserService.CurrentUserId);


            if (UoWGeneric.Root.CounterpartyContracts == null)
            {
                UoWGeneric.Root.CounterpartyContracts = new List<CounterpartyContract>();
            }

            ConfigureTabInfo();
            ConfigureTabComments();
            ConfigureTabContacts();
            ConfigureTabProxies();
            ConfigureTabContracts();
            ConfigureTabRequisites();
            ConfigureTabTags();
            ConfigureTabSpecialFields();
            ConfigureTabPrices();
            ConfigureTabFixedPrices();
            
            //make actions menu
            var menu = new Gtk.Menu();
            
            var menuItem = new Gtk.MenuItem("Все заказы контрагента");
            menuItem.Activated += AllOrders_Activated;
            menu.Add(menuItem);
            
            var menuItemFixedPrices = new Gtk.MenuItem("Фикс. цены для самовывоза");
            menuItemFixedPrices.Activated += (s, e) => OpenFixedPrices();
            menu.Add(menuItemFixedPrices);
            
            var menuComplaint = new Gtk.MenuItem("Рекламации контрагента");
            menuComplaint.Activated += ComplaintViewOnActivated;
            menu.Add(menuComplaint);
            
            menuActions.Menu = menu;
            menu.ShowAll();

            menuActions.Sensitive = !UoWGeneric.IsNew;

            datatable4.Sensitive = currentUserCanEditCounterpartyDetails;

            UpdateCargoReceiver();
        }

        private void ConfigureTabInfo()
        {
            enumPersonType.Sensitive = currentUserCanEditCounterpartyDetails;
            enumPersonType.ItemsEnum = typeof(PersonType);
            enumPersonType.Binding.AddBinding(Entity, s => s.PersonType, w => w.SelectedItemOrNull).InitializeFromSource();

            yEnumCounterpartyType.ItemsEnum = typeof(CounterpartyType);
            yEnumCounterpartyType.Binding.AddBinding(Entity, c => c.CounterpartyType, w => w.SelectedItemOrNull).InitializeFromSource();
            yEnumCounterpartyType.Changed += YEnumCounterpartyType_Changed;
            yEnumCounterpartyType.ChangedByUser += YEnumCounterpartyType_ChangedByUser;
            YEnumCounterpartyType_Changed(this, new EventArgs());

            if (Entity.Id != 0 && !ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission(
                "can_change_delay_days_for_buyers_and_chain_store")) {
                checkIsChainStore.Sensitive = false;
                DelayDaysForBuyerValue.Sensitive = false;
            }

            checkIsChainStore.Toggled += CheckIsChainStoreOnToggled;
            checkIsChainStore.Binding.AddBinding(Entity, e => e.IsChainStore, w => w.Active).InitializeFromSource();

            ycheckIsArchived.Binding.AddBinding(Entity, e => e.IsArchive, w => w.Active).InitializeFromSource();
            ycheckIsArchived.Sensitive = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_arc_counterparty_and_deliverypoint");

            lblVodovozNumber.LabelProp = Entity.VodovozInternalId.ToString();

            hboxCameFrom.Visible = (Entity.Id != 0 && Entity.CameFrom != null) || Entity.Id == 0;

            ySpecCmbCameFrom.SetRenderTextFunc<ClientCameFrom>(f => f.Name);

            ySpecCmbCameFrom.Sensitive = Entity.Id == 0;
            ySpecCmbCameFrom.ItemsList = CounterpartyRepository.GetPlacesClientCameFrom(
                UoW,
                Entity.CameFrom == null || !Entity.CameFrom.IsArchive
            );

            ySpecCmbCameFrom.Binding.AddBinding(Entity, f => f.CameFrom, w => w.SelectedItem).InitializeFromSource();

            ycheckIsForRetail.Binding.AddBinding(Entity, e => e.IsForRetail, w => w.Active).InitializeFromSource();

            ycheckNoPhoneCall.Binding.AddBinding(Entity, e => e.NoPhoneCall, w => w.Active).InitializeFromSource();
            ycheckNoPhoneCall.Sensitive = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("user_can_activate_no_phone_call_in_counterparty");
            ycheckNoPhoneCall.Visible = Entity.IsForRetail;

            DelayDaysForBuyerValue.Binding.AddBinding(Entity, e => e.DelayDaysForBuyers, w => w.ValueAsInt).InitializeFromSource();
            lblDelayDaysForBuyer.Visible = DelayDaysForBuyerValue.Visible = Entity?.IsChainStore ?? false;

            yspinDelayDaysForTechProcessing.Binding.AddBinding(Entity, e => e.TechnicalProcessingDelay, w => w.ValueAsInt).InitializeFromSource();

            entryFIO.Binding.AddBinding(Entity, e => e.Name, w => w.Text).InitializeFromSource();

            datalegalname1.Sensitive = currentUserCanEditCounterpartyDetails;

            datalegalname1.Binding.AddSource(Entity)
                .AddBinding(s => s.Name, t => t.OwnName)
                .AddBinding(s => s.TypeOfOwnership, t => t.Ownership)
                .InitializeFromSource();

            entryFullName.Sensitive = currentUserCanEditCounterpartyDetails;
            entryFullName.Binding.AddBinding(Entity, e => e.FullName, w => w.Text).InitializeFromSource();

            entryMainCounterparty.SetEntityAutocompleteSelectorFactory(
                new DefaultEntityAutocompleteSelectorFactory<Counterparty, CounterpartyJournalViewModel, CounterpartyJournalFilterViewModel>(ServicesConfig.CommonServices));
            entryMainCounterparty.Binding.AddBinding(Entity, e => e.MainCounterparty, w => w.Subject).InitializeFromSource();

            entryPreviousCounterparty.SetEntityAutocompleteSelectorFactory(
                new DefaultEntityAutocompleteSelectorFactory<Counterparty, CounterpartyJournalViewModel, CounterpartyJournalFilterViewModel>(ServicesConfig.CommonServices));
            entryPreviousCounterparty.Binding.AddBinding(Entity, e => e.PreviousCounterparty, w => w.Subject).InitializeFromSource();

            enumPayment.ItemsEnum = typeof(PaymentType);
            enumPayment.Binding.AddBinding(Entity, s => s.PaymentMethod, w => w.SelectedItemOrNull).InitializeFromSource();

            enumDefaultDocumentType.ItemsEnum = typeof(DefaultDocumentType);
            enumDefaultDocumentType.Binding.AddBinding(Entity, s => s.DefaultDocumentType, w => w.SelectedItemOrNull).InitializeFromSource();

            lblTax.Binding.AddFuncBinding(Entity, e => e.PersonType == PersonType.legal, w => w.Visible).InitializeFromSource();

            enumTax.ItemsEnum = typeof(TaxType);

            if (Entity.CreateDate != null)
            {
                Enum[] hideEnums = { TaxType.None };
                enumTax.AddEnumToHideList(hideEnums);
            }

            enumTax.Binding.AddBinding(Entity, e => e.TaxType, w => w.SelectedItem).InitializeFromSource();
            enumTax.Binding.AddFuncBinding(Entity, e => e.PersonType == PersonType.legal, w => w.Visible).InitializeFromSource();

            spinMaxCredit.Binding.AddBinding(Entity, e => e.MaxCredit, w => w.ValueAsDecimal).InitializeFromSource();
            spinMaxCredit.Sensitive = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("max_loan_amount");

            dataComment.Binding.AddBinding(Entity, e => e.Comment, w => w.Buffer.Text).InitializeFromSource();

            // Прикрепляемые документы

            var filesViewModel = new CounterpartyFilesViewModel(Entity, UoW, new GtkFilePicker(), ServicesConfig.CommonServices);
            counterpartyfilesview1.ViewModel = filesViewModel;

            chkNeedNewBottles.Binding.AddBinding(Entity, e => e.NewBottlesNeeded, w => w.Active).InitializeFromSource();

            ycheckSpecialDocuments.Binding.AddBinding(Entity, e => e.UseSpecialDocFields, w => w.Active).InitializeFromSource();

            ycheckAlwaysSendReceitps.Binding.AddBinding(Entity, e => e.AlwaysSendReceitps, w => w.Active).InitializeFromSource();
            ycheckAlwaysSendReceitps.Visible =
                ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_manage_cash_receipts");

            ycheckExpirationDateControl.Binding.AddBinding(Entity, e => e.SpecialExpireDatePercentCheck, w => w.Active).InitializeFromSource();
            yspinExpirationDatePercent.Binding.AddBinding(Entity, e => e.SpecialExpireDatePercentCheck, w => w.Visible).InitializeFromSource();
            yspinExpirationDatePercent.Binding.AddBinding(Entity, e => e.SpecialExpireDatePercent, w => w.ValueAsDecimal).InitializeFromSource();

            // Настройка каналов сбыта

            if(Entity.IsForRetail) { 
                ytreeviewSalesChannels.ColumnsConfig = ColumnsConfigFactory.Create<SalesChannelSelectableNode>()
                    .AddColumn("Название").AddTextRenderer(node => node.Name)
                    .AddColumn("").AddToggleRenderer(x => x.Selected)
                    .Finish();

                SalesChannel salesChannelAlias = null;
                SalesChannelSelectableNode salesChannelSelectableNodeAlias = null;

                var list = UoW.Session.QueryOver(() => salesChannelAlias)
                    .SelectList(scList => scList
                    .SelectGroup(() => salesChannelAlias.Id).WithAlias(() => salesChannelSelectableNodeAlias.Id)
                        .Select(() => salesChannelAlias.Name).WithAlias(() => salesChannelSelectableNodeAlias.Name)
                    ).TransformUsing(Transformers.AliasToBean<SalesChannelSelectableNode>()).List<SalesChannelSelectableNode>();

                SalesChannels = new GenericObservableList<SalesChannelSelectableNode>(list);

                foreach (var selectableChannel in SalesChannels.Where(x => Entity.SalesChannels.Any(sc => sc.Id == x.Id)))
                {
                    selectableChannel.Selected = true;
                }

                ytreeviewSalesChannels.ItemsDataSource = SalesChannels;
            } else {
                yspinDelayDaysForTechProcessing.Visible = false;
                lblDelayDaysForTechProcessing.Visible = false;
                frame2.Visible = false;
                frame3.Visible = false;
                label46.Visible = false;
                label47.Visible = false;
                label48.Visible = false;
                label49.Visible = false;
            }

            SetVisibilityForCloseDeliveryComments();
        }

        private void ConfigureTabComments()
        {
            commentsview4.UoW = UoW;
        }

        private void ConfigureTabContacts()
        {
            phonesView.UoW = UoWGeneric;
            if (UoWGeneric.Root.Phones == null)
                UoWGeneric.Root.Phones = new List<Phone>();
            phonesView.Phones = UoWGeneric.Root.Phones;

            emailsView.UoW = UoWGeneric;
            if (UoWGeneric.Root.Emails == null)
                UoWGeneric.Root.Emails = new List<Email>();
            emailsView.Emails = UoWGeneric.Root.Emails;

            var filterSalesManager = new EmployeeFilterViewModel();
            filterSalesManager.SetAndRefilterAtOnce(
                x => x.RestrictCategory = EmployeeCategory.office,
                x => x.Status = EmployeeStatus.IsWorking
            );

            referenceSalesManager.RepresentationModel = new EmployeesVM(filterSalesManager);
            referenceSalesManager.Binding.AddBinding(Entity, e => e.SalesManager, w => w.Subject).InitializeFromSource();

            var filterAccountant = new EmployeeFilterViewModel();
            filterAccountant.SetAndRefilterAtOnce(
                x => x.RestrictCategory = EmployeeCategory.office,
                x => x.Status = EmployeeStatus.IsWorking
            );

            referenceAccountant.RepresentationModel = new EmployeesVM(filterAccountant);
            referenceAccountant.Binding.AddBinding(Entity, e => e.Accountant, w => w.Subject).InitializeFromSource();

            dataentryMainContact.RepresentationModel = new ContactsVM(UoW, Entity);
            dataentryMainContact.Binding.AddBinding(Entity, e => e.MainContact, w => w.Subject).InitializeFromSource();

            var filterBottleManager = new EmployeeFilterViewModel();
            filterBottleManager.SetAndRefilterAtOnce(
                x => x.RestrictCategory = EmployeeCategory.office,
                x => x.Status = EmployeeStatus.IsWorking
            );

            referenceBottleManager.RepresentationModel = new EmployeesVM(filterBottleManager);
            referenceBottleManager.Binding.AddBinding(Entity, e => e.BottlesManager, w => w.Subject).InitializeFromSource();

            dataentryFinancialContact.RepresentationModel = new ContactsVM(UoW, Entity);
            dataentryFinancialContact.Binding.AddBinding(Entity, e => e.FinancialContact, w => w.Subject).InitializeFromSource();

            txtRingUpPhones.Binding.AddBinding(Entity, e => e.RingUpPhone, w => w.Buffer.Text).InitializeFromSource();

            contactsview1.CounterpartyUoW = UoWGeneric;
            contactsview1.Visible = true;
        }

        private void ConfigureTabRequisites()
        {
            validatedINN.ValidationMode = validatedKPP.ValidationMode = QSWidgetLib.ValidationType.numeric;
            validatedINN.Binding.AddBinding(Entity, e => e.INN, w => w.Text).InitializeFromSource();

            yentrySignFIO.Binding.AddBinding(Entity, e => e.SignatoryFIO, w => w.Text).InitializeFromSource();
            validatedKPP.Binding.AddBinding(Entity, e => e.KPP, w => w.Text).InitializeFromSource();
            yentrySignPost.Binding.AddBinding(Entity, e => e.SignatoryPost, w => w.Text).InitializeFromSource();
            entryJurAddress.Binding.AddBinding(Entity, e => e.RawJurAddress, w => w.Text).InitializeFromSource();
            yentrySignBaseOf.Binding.AddBinding(Entity, e => e.SignatoryBaseOf, w => w.Text).InitializeFromSource();

            accountsView.CanEdit = currentUserCanEditCounterpartyDetails;

            accountsView.ParentReference = new ParentReferenceGeneric<Counterparty, Account>(UoWGeneric, c => c.Accounts);
        }

        private void ConfigureTabProxies()
        {
            proxiesview1.CounterpartyUoW = UoWGeneric;
        }

        private void ConfigureTabContracts()
        {
            counterpartyContractsView.CounterpartyUoW = UoWGeneric;
        }

        private void ConfigureTabTags()
        {
            ytreeviewTags.ColumnsConfig = ColumnsConfigFactory.Create<Tag>()
                .AddColumn("Название").AddTextRenderer(node => node.Name)
                .AddColumn("Цвет").AddTextRenderer()
                .AddSetter((cell, node) => { cell.Markup = String.Format("<span foreground=\" {0}\">♥</span>", node.ColorText); })
                .AddColumn("")
                .Finish();

            ytreeviewTags.ItemsDataSource = Entity.ObservableTags;
        }

        private void ConfigureTabSpecialFields()
        {
            enumcomboCargoReceiverSource.ItemsEnum = typeof(CargoReceiverSource);
            enumcomboCargoReceiverSource.Binding.AddBinding(Entity, e => e.CargoReceiverSource, w => w.SelectedItem).InitializeFromSource();

            yentryCargoReceiver.Binding.AddBinding(Entity, e => e.CargoReceiver, w => w.Text).InitializeFromSource();
            yentryCustomer.Binding.AddBinding(Entity, e => e.SpecialCustomer, w => w.Text).InitializeFromSource();
            yentrySpecialContract.Binding.AddBinding(Entity, e => e.SpecialContractNumber, w => w.Text).InitializeFromSource();
            yentrySpecialKPP.Binding.AddBinding(Entity, e => e.PayerSpecialKPP, w => w.Text).InitializeFromSource();
            yentryGovContract.Binding.AddBinding(Entity, e => e.GovContract, w => w.Text).InitializeFromSource();
            yentrySpecialDeliveryAddress.Binding.AddBinding(Entity, e => e.SpecialDeliveryAddress, w => w.Text).InitializeFromSource();

            buttonLoadFromDP.Clicked += ButtonLoadFromDP_Clicked;

            yentryOKPO.Binding.AddBinding(Entity, e => e.OKPO, w => w.Text).InitializeFromSource();
            yentryOKDP.Binding.AddBinding(Entity, e => e.OKDP, w => w.Text).InitializeFromSource();

            int?[] docCount = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            yspeccomboboxTTNCount.ItemsList = docCount;
            yspeccomboboxTorg2Count.ItemsList = docCount;
            yspeccomboboxUPDForNonCashlessCount.ItemsList = docCount;

            yspeccomboboxTorg2Count.Binding.AddBinding(Entity, e => e.Torg2Count, w => w.SelectedItem).InitializeFromSource();
            yspeccomboboxTTNCount.Binding.AddBinding(Entity, e => e.TTNCount, w => w.SelectedItem).InitializeFromSource();
            yspeccomboboxUPDForNonCashlessCount.Binding.AddBinding(Entity, e => e.UPDCount, w => w.SelectedItem).InitializeFromSource();

            if (Entity.IsForRetail)
            {
                yspeccomboboxUPDCount.ItemsList = docCount;
                yspeccomboboxTorg12Count.ItemsList = docCount;
                yspeccomboboxShetFacturaCount.ItemsList = docCount;
                yspeccomboboxCarProxyCount.ItemsList = docCount;

                yspeccomboboxUPDCount.Binding.AddBinding(Entity, e => e.AllUPDCount, w => w.SelectedItem).InitializeFromSource();
                yspeccomboboxTorg12Count.Binding.AddBinding(Entity, e => e.Torg12Count, w => w.SelectedItem).InitializeFromSource();
                yspeccomboboxShetFacturaCount.Binding.AddBinding(Entity, e => e.ShetFacturaCount, w => w.SelectedItem).InitializeFromSource();
                yspeccomboboxCarProxyCount.Binding.AddBinding(Entity, e => e.CarProxyCount, w => w.SelectedItem).InitializeFromSource();
            } else {
                yspeccomboboxUPDCount.Visible = false;
                yspeccomboboxTorg12Count.Visible = false;
                yspeccomboboxShetFacturaCount.Visible = false;
                yspeccomboboxCarProxyCount.Visible = false;
            }

            ytreeviewSpecialNomenclature.ColumnsConfig = ColumnsConfigFactory.Create<SpecialNomenclature>()
                .AddColumn("№").AddTextRenderer(node => node.Nomenclature != null ? node.Nomenclature.Id.ToString() : "0")
                .AddColumn("ТМЦ").AddTextRenderer(node => node.Nomenclature != null ? node.Nomenclature.Name : string.Empty)
                .AddColumn("Код").AddNumericRenderer(node => node.SpecialId).Adjustment(new Adjustment(0, 0, 100000, 1, 1, 1)).Editing()
                .Finish();
            ytreeviewSpecialNomenclature.ItemsDataSource = Entity.ObservableSpecialNomenclatures;
        }

        private void ConfigureTabDeliveryPoints()
        {
            deliveryPointView.DeliveryPointUoW = UoWGeneric;
        }

        private void ConfigureTabDocuments()
        {
            counterpartydocumentsview.Config(UoWGeneric, Entity);
        }

        private void ConfigureTabPrices()
        {
            supplierPricesWidget.ViewModel =
                new ViewModels.Client.SupplierPricesWidgetViewModel(
                    Entity,
                    UoW,
                    this,
                    ServicesConfig.CommonServices,
                    employeeService,
                    CounterpartySelectorFactory,
                    NomenclatureSelectorFactory,
                    NomenclatureRepository,
                    userRepository);

        }

        private void ConfigureTabFixedPrices()
        {
            var waterFixedPricesGenerator = new WaterFixedPricesGenerator(NomenclatureRepository);
            var nomenclatureFixedPriceFactory = new NomenclatureFixedPriceFactory();
            var fixedPriceController = new NomenclatureFixedPriceController(nomenclatureFixedPriceFactory, waterFixedPricesGenerator);
            var fixedPricesModel = new CounterpartyFixedPricesModel(UoW, Entity, fixedPriceController);
            var nomSelectorFactory = new NomenclatureSelectorFactory();
            FixedPricesViewModel fixedPricesViewModel = new FixedPricesViewModel(UoW, fixedPricesModel, nomSelectorFactory, this);
            fixedpricesview.ViewModel = fixedPricesViewModel;
        }


        private void CheckIsChainStoreOnToggled(object sender, EventArgs e)
        {
            if (Entity.IsChainStore) {
                lblDelayDaysForBuyer.Visible = DelayDaysForBuyerValue.Visible = true;
            }
            else {
                lblDelayDaysForBuyer.Visible = DelayDaysForBuyerValue.Visible = false;
                Entity.DelayDaysForBuyers = 0;
            }
        }

        void ButtonLoadFromDP_Clicked(object sender, EventArgs e)
        {
            var deliveryPointSelectDlg = new PermissionControlledRepresentationJournal(new ClientDeliveryPointsVM(UoW, Entity)) {
                Mode = JournalSelectMode.Single
            };
            deliveryPointSelectDlg.ObjectSelected += DeliveryPointRep_ObjectSelected;
            TabParent.AddSlaveTab(this, deliveryPointSelectDlg);
        }

        void DeliveryPointRep_ObjectSelected(object sender, JournalObjectSelectedEventArgs e)
        {
            if(e.GetNodes<ClientDeliveryPointVMNode>().FirstOrDefault() is ClientDeliveryPointVMNode node)
                yentrySpecialDeliveryAddress.Text = node.CompiledAddress;
        }


        public void ActivateContactsTab()
        {
            if(radioContacts.Sensitive)
                radioContacts.Active = true;
        }

        public void ActivateDetailsTab()
        {
            if(radioDetails.Sensitive)
                radioDetails.Active = true;
        }

        void AllOrders_Activated(object sender, EventArgs e)
        {
	        var orderJournalFilter = new OrderJournalFilterViewModel
	        {
		        RestrictCounterparty = Entity
	        };
	        var journalActions = new EntitiesJournalActionsViewModel(ServicesConfig.InteractiveService);
	        
	        var orderJournalViewModel = new OrderJournalViewModel(
		        journalActions,
		        orderJournalFilter,
		        UnitOfWorkFactory.GetDefaultFactory,
		        ServicesConfig.CommonServices,
		        new EmployeeService(),
		        nomenclatureSelectorFactory,
		        counterpartySelectorFactory,
		        nomenclatureRepository,
		        userRepository
	        );

	        TabParent.AddTab(orderJournalViewModel, this, false);
        }
        
        private void ComplaintViewOnActivated(object sender, EventArgs e)
        {
	        var filter = new ComplaintFilterViewModel(ServicesConfig.CommonServices, SubdivisionRepository, EmployeeSelectorFactory,
		        CounterpartySelectorFactory);
	        filter.SetAndRefilterAtOnce(x=> x.Counterparty = Entity);
	        var journalActions = new ComplaintsJournalActionsViewModel(ServicesConfig.InteractiveService, new GtkReportViewOpener());
	        
	        var complaintsJournalViewModel = new ComplaintsJournalViewModel(
		        journalActions,
		        UnitOfWorkFactory.GetDefaultFactory,
		        ServicesConfig.CommonServices,
		        UndeliveriesViewOpener,
		        employeeService,
		        EmployeeSelectorFactory,
		        CounterpartySelectorFactory,
		        NomenclatureSelectorFactory,
		        RouteListItemRepository,
		        SubdivisionParametersProvider.Instance,
		        filter,
		        FilePickerService,
		        SubdivisionRepository,
		        new GtkTabsOpener(),
		        NomenclatureRepository,
		        userRepository
	        );
	        
	        TabParent.AddTab(complaintsJournalViewModel, this, false);
        }

        private bool canClose = true;
        public bool CanClose()
        {
            if(!canClose)
                MessageDialogHelper.RunInfoDialog("Дождитесь завершения сохранения и повторите");
            return canClose;
        }

        private void SetSensetivity(bool isSensetive)
        {
            canClose = isSensetive;
            buttonSave.Sensitive = isSensetive;
            buttonCancel.Sensitive = isSensetive;
        }

        public override bool Save()
        {
            try {
                SetSensetivity(false);
                if(Entity.PayerSpecialKPP == String.Empty)
                    Entity.PayerSpecialKPP = null;
                Entity.UoW = UoW;
                var valid = new QSValidator<Counterparty>(UoWGeneric.Root);
                if(valid.RunDlgIfNotValid((Gtk.Window)this.Toplevel))
                    return false;
                logger.Info("Сохраняем контрагента...");
                phonesView.RemoveEmpty();
                emailsView.RemoveEmpty();
                UoWGeneric.Save();
                logger.Info("Ok.");
                return true;
            } finally{
                SetSensetivity(true);
            }
        }

        /// <summary>
        /// Поиск контрагентов с таким же ИНН
        /// </summary>
        /// <returns><c>true</c>, if duplicate was checked, <c>false</c> otherwise.</returns>
        private bool CheckDuplicate()
        {
            string INN = UoWGeneric.Root.INN;
            IList<Counterparty> counterarties = Repositories.CounterpartyRepository.GetCounterpartiesByINN(UoW, INN);
            return counterarties != null && counterarties.Any(x => x.Id != UoWGeneric.Root.Id);
        }

        protected void OnRadioInfoToggled(object sender, EventArgs e)
        {
            if(radioInfo.Active)
                notebook1.CurrentPage = 0;
        }

        protected void OnRadioCommentsToggled(object sender, EventArgs e)
        {
            if(radioComments.Active)
                notebook1.CurrentPage = 1;
        }

        protected void OnRadioContactsToggled(object sender, EventArgs e)
        {
            if(radioContacts.Active)
                notebook1.CurrentPage = 2;
        }

        protected void OnRadioDetailsToggled(object sender, EventArgs e)
        {
            if(radioDetails.Active)
                notebook1.CurrentPage = 3;
        }

        protected void OnRadiobuttonProxiesToggled(object sender, EventArgs e)
        {
            if(radiobuttonProxies.Active)
                notebook1.CurrentPage = 4;
        }

        protected void OnRadioContractsToggled(object sender, EventArgs e)
        {
            if(radioContracts.Active)
                notebook1.CurrentPage = 5;
        }

        protected void OnRadioDocumentsToggled(object sender, EventArgs e)
        {
            if (!documentsConfigured)
            {
                ConfigureTabDocuments();
                documentsConfigured = true;
            }
            if (radioDocuments.Active)
                notebook1.CurrentPage = 6;
        }

        protected void OnRadioDeliveryPointToggled(object sender, EventArgs e)
        {
            if (!deliveryPointsConfigured)
            {
                ConfigureTabDeliveryPoints();
                deliveryPointsConfigured = true;
            }
            if(radioDeliveryPoint.Active)
                notebook1.CurrentPage = 7;
        }

        protected void OnRadioTagsToggled(object sender, EventArgs e)
        {
            if(radioTags.Active)
                notebook1.CurrentPage = 8;
        }

        protected void OnRadioSpecialDocFieldsToggled(object sender, EventArgs e)
        {
            if(radioSpecialDocFields.Active)
                notebook1.CurrentPage = 9;
        }

        protected void OnRbnPricesToggled(object sender, EventArgs e)
        {
            if(rbnPrices.Active)
                notebook1.CurrentPage = 10;
        }

        public void OpenFixedPrices()
        {
            notebook1.CurrentPage = 11;
        }

        void YEnumCounterpartyType_Changed(object sender, EventArgs e)
        {
            rbnPrices.Visible = Entity.CounterpartyType == CounterpartyType.Supplier;
        }

        void YEnumCounterpartyType_ChangedByUser(object sender, EventArgs e)
        {
            if(Entity.ObservableSuplierPriceItems.Any() && Entity.CounterpartyType == CounterpartyType.Buyer) {
                var response = MessageDialogHelper.RunWarningDialog(
                    "Смена типа контрагента",
                    "При смене контрагента с поставщика на покупателя произойдёт очистка списка цен на поставляемые им номенклатуры. Продолжить?",
                    Gtk.ButtonsType.YesNo
                );
                if(response)
                    Entity.ObservableSuplierPriceItems.Clear();
                else
                    Entity.CounterpartyType = CounterpartyType.Supplier;
            }
        }

        protected void OnEnumPersonTypeChanged(object sender, EventArgs e)
        {
            labelFIO.Visible = entryFIO.Visible = Entity.PersonType == PersonType.natural;
            labelShort.Visible = datalegalname1.Visible =
                    labelFullName.Visible = entryFullName.Visible =
                    entryMainCounterparty.Visible = labelMainCounterparty.Visible =
                        radioDetails.Visible = radiobuttonProxies.Visible = lblPaymentType.Visible =
                            enumPayment.Visible = (Entity.PersonType == PersonType.legal);

            if (Entity.PersonType != PersonType.legal && Entity.TaxType != TaxType.None)
                Entity.TaxType = TaxType.None;
        }

        protected void OnEnumPaymentEnumItemSelected(object sender, Gamma.Widgets.ItemSelectedEventArgs e)
        {
            enumDefaultDocumentType.Visible = labelDefaultDocumentType.Visible = (PaymentType)e.SelectedItem == PaymentType.cashless;
        }

        protected void OnEnumPaymentChangedByUser(object sender, EventArgs e)
        {
            if(Entity.PaymentMethod == PaymentType.cashless)
                Entity.DefaultDocumentType = DefaultDocumentType.upd;
            else
                Entity.DefaultDocumentType = null;
        }

        protected void OnReferencePreviousCounterpartyChangedByUser(object sender, EventArgs e)
        {
            if(DomainHelper.EqualDomainObjects(Entity.PreviousCounterparty, Entity))
                Entity.PreviousCounterparty = null;
        }

        protected void OnReferenceMainCounterpartyChangedByUser(object sender, EventArgs e)
        {
            if(DomainHelper.EqualDomainObjects(Entity.MainCounterparty, Entity))
                Entity.MainCounterparty = null;
        }

        protected void OnYentrySignPostFocusInEvent(object o, Gtk.FocusInEventArgs args)
        {
            if(yentrySignPost.Completion == null) {
                yentrySignPost.Completion = new EntryCompletion();
                var list = CounterpartyRepository.GetUniqueSignatoryPosts(UoW);
                yentrySignPost.Completion.Model = ListStoreWorks.CreateFromEnumerable(list);
                yentrySignPost.Completion.TextColumn = 0;
                yentrySignPost.Completion.Complete();
            }
        }

        protected void OnYentrySignBaseOfFocusInEvent(object o, Gtk.FocusInEventArgs args)
        {
            if(yentrySignBaseOf.Completion == null) {
                yentrySignBaseOf.Completion = new EntryCompletion();
                var list = CounterpartyRepository.GetUniqueSignatoryBaseOf(UoW);
                yentrySignBaseOf.Completion.Model = ListStoreWorks.CreateFromEnumerable(list);
                yentrySignBaseOf.Completion.TextColumn = 0;
                yentrySignBaseOf.Completion.Complete();
            }
        }

        void RefWin_ObjectSelected(object sender, OrmReferenceObjectSectedEventArgs e)
        {
            if(e.Subject is Tag tag)
                Entity.ObservableTags.Add(tag);
        }

        protected void OnButtonAddTagClicked(object sender, EventArgs e)
        {
            var refWin = new OrmReference(typeof(Tag)) {
                Mode = OrmReferenceMode.Select
            };
            refWin.ObjectSelected += RefWin_ObjectSelected;
            TabParent.AddSlaveTab(this, refWin);
        }

        protected void OnButtonDeleteTagClicked(object sender, EventArgs e)
        {
            if(ytreeviewTags.GetSelectedObject() is Tag tag)
                Entity.ObservableTags.Remove(tag);
        }

        protected void OnDatalegalname1OwnershipChanged(object sender, EventArgs e)
        {
            validatedKPP.Sensitive = Entity.TypeOfOwnership != "ИП";
        }

        protected void OnChkNeedNewBottlesToggled(object sender, EventArgs e)
        {
            Entity.NewBottlesNeeded = chkNeedNewBottles.Active;
        }

        protected void OnYcheckSpecialDocumentsToggled(object sender, EventArgs e)
        {
            radioSpecialDocFields.Visible = ycheckSpecialDocuments.Active;
        }

        #region CloseDelivery //Переделать на PermissionCommentView

        private void SetVisibilityForCloseDeliveryComments()
        {

            labelCloseDelivery.Visible = Entity.IsDeliveriesClosed;
            GtkScrolledWindowCloseDelivery.Visible = Entity.IsDeliveriesClosed;
            buttonSaveCloseComment.Visible = Entity.IsDeliveriesClosed;
            buttonEditCloseDeliveryComment.Visible = Entity.IsDeliveriesClosed;
            buttonCloseDelivery.Label = Entity.IsDeliveriesClosed ? "Открыть поставки" : "Закрыть поставки";
            ytextviewCloseComment.Buffer.Text = Entity.IsDeliveriesClosed ? Entity.CloseDeliveryComment : String.Empty;

            if(!Entity.IsDeliveriesClosed)
                return;

            labelCloseDelivery.LabelProp = "Поставки закрыл : " + Entity.GetCloseDeliveryInfo() + Environment.NewLine + "<b>Комментарий по закрытию поставок:</b>";

            if(String.IsNullOrWhiteSpace(Entity.CloseDeliveryComment)) {
                buttonSaveCloseComment.Sensitive = true;
                buttonEditCloseDeliveryComment.Sensitive = false;
                ytextviewCloseComment.Sensitive = true;
            } else {
                buttonEditCloseDeliveryComment.Sensitive = true;
                buttonSaveCloseComment.Sensitive = false;
                ytextviewCloseComment.Sensitive = false;
            }
        }

        protected void OnButtonSaveCloseCommentClicked(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(ytextviewCloseComment.Buffer.Text))
                return;

            if(!ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_close_deliveries_for_counterparty")) {
                MessageDialogHelper.RunWarningDialog("У вас нет прав для изменения комментария по закрытию поставок");
                return;
            }

            Entity.AddCloseDeliveryComment(ytextviewCloseComment.Buffer.Text, UoW);
            SetVisibilityForCloseDeliveryComments();
        }

        protected void OnButtonEditCloseDeliveryCommentClicked(object sender, EventArgs e)
        {
            if(!ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_close_deliveries_for_counterparty")) {
                MessageDialogHelper.RunWarningDialog("У вас нет прав для изменения комментария по закрытию поставок");
                return;
            }

            if(MessageDialogHelper.RunQuestionDialog("Вы уверены что хотите изменить комментарий (преведущий комментарий будет удален)?")) {
                Entity.CloseDeliveryComment = ytextviewCloseComment.Buffer.Text = String.Empty;
                SetVisibilityForCloseDeliveryComments();
            }
        }

        protected void OnButtonCloseDeliveryClicked(object sender, EventArgs e)
        {
            if(!Entity.ToogleDeliveryOption(UoW)) {
                MessageDialogHelper.RunWarningDialog("У вас нет прав для закрытия/открытия поставок");
                return;
            }
            SetVisibilityForCloseDeliveryComments();
        }

        #endregion CloseDelivery

        protected void OnYbuttonAddNomClicked(object sender, EventArgs e)
        {
            var nomenclatureSelectDlg = new OrmReference(typeof(Nomenclature));
            nomenclatureSelectDlg.Mode = OrmReferenceMode.Select;
            nomenclatureSelectDlg.ObjectSelected += NomenclatureSelectDlg_ObjectSelected;
            TabParent.AddSlaveTab(this, nomenclatureSelectDlg);
        }

        private void NomenclatureSelectDlg_ObjectSelected(object sender, OrmReferenceObjectSectedEventArgs e)
        {
            var specNom = new SpecialNomenclature();
            specNom.Nomenclature = e.Subject as Nomenclature;
            specNom.Counterparty = Entity;

            if(Entity.ObservableSpecialNomenclatures.Any(x => x.Nomenclature.Id == specNom.Nomenclature.Id))
                return;

            Entity.ObservableSpecialNomenclatures.Add(specNom);
        }

        protected void OnYbuttonRemoveNomClicked(object sender, EventArgs e)
        {
            Entity.ObservableSpecialNomenclatures.Remove(ytreeviewSpecialNomenclature.GetSelectedObject<SpecialNomenclature>());
        }

        protected void OnEnumcomboCargoReceiverSourceChangedByUser(object sender, EventArgs e)
        {
            UpdateCargoReceiver();
        }

        private string cargoReceiverBackupBuffer;

        private void UpdateCargoReceiver()
        {
            if(Entity.CargoReceiverSource != CargoReceiverSource.Special) {
                if(Entity.CargoReceiver != cargoReceiverBackupBuffer && !string.IsNullOrWhiteSpace(Entity.CargoReceiver)) {
                    cargoReceiverBackupBuffer = Entity.CargoReceiver;
                }
                Entity.CargoReceiver = null;
            } else {
                Entity.CargoReceiver = cargoReceiverBackupBuffer;
            }
            yentryCargoReceiver.Visible = Entity.CargoReceiverSource == CargoReceiverSource.Special;
        }

    }
    public class SalesChannelSelectableNode : PropertyChangedBase
    {
        private int id;
        public virtual int Id
        {
            get => id;
            set => SetField(ref id, value);
        }

        private bool selected;
        public virtual bool Selected
        {
            get => selected;
            set => SetField(ref selected, value);
        }

        private string name;
        public virtual string Name
        {
            get => name;
            set => SetField(ref name, value);
        }

        public string Title => Name;

        public SalesChannelSelectableNode(){}

        public SalesChannelSelectableNode(SalesChannel salesChannel)
        {
            Id = salesChannel.Id;
            Name = salesChannel.Name;
        }
    }
}
