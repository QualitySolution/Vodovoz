using System;
using System.Collections.Generic;
using System.Linq;
using QS.Commands;
using QS.DomainModel.Entity.EntityPermissions.EntityExtendedPermission;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Report;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Domain.Documents;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Permissions.Warehouse;
using Vodovoz.Domain.Store;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.Store;
using Vodovoz.Infrastructure.Print;
using Vodovoz.Infrastructure.Services;
using Vodovoz.Journals.JournalNodes;
using Vodovoz.PermissionExtensions;
using Vodovoz.PrintableDocuments;
using Vodovoz.Repositories;
using Vodovoz.TempAdapters;

namespace Vodovoz.ViewModels.Warehouses
{
    public class IncomingInvoiceViewModel: EntityTabViewModelBase<IncomingInvoice>
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IEmployeeService employeeService;
        private readonly IEntityExtendedPermissionValidator entityExtendedPermissionValidator;
        private readonly INomenclatureSelectorFactory nomenclatureSelectorFactory;
        private readonly IOrderSelectorFactory orderSelectorFactory;
        private readonly IWarehouseRepository warehouseRepository;
        private readonly IRDLPreviewOpener rdlPreviewOpener;
        private readonly IWarehousePermissionValidator warehousePermissionValidator;
        
        #region Конструктор
        public IncomingInvoiceViewModel(
            IEntityUoWBuilder uowBuilder, 
            IUnitOfWorkFactory unitOfWorkFactory,
            IWarehousePermissionService warehousePermissionService,
            IEmployeeService employeeService,
            IEntityExtendedPermissionValidator entityExtendedPermissionValidator,
            INomenclatureSelectorFactory nomenclatureSelectorFactory,
            IOrderSelectorFactory orderSelectorFactory,
            IWarehouseRepository warehouseRepository,
            IRDLPreviewOpener rdlPreviewOpener,
            ICommonServices commonServices) 
            : base(uowBuilder, unitOfWorkFactory, commonServices)
        {
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.entityExtendedPermissionValidator = entityExtendedPermissionValidator ?? throw new ArgumentNullException(nameof(entityExtendedPermissionValidator));
            this.nomenclatureSelectorFactory = nomenclatureSelectorFactory ?? throw new ArgumentNullException(nameof(nomenclatureSelectorFactory));
            this.orderSelectorFactory = orderSelectorFactory ?? throw new ArgumentNullException(nameof(orderSelectorFactory));
            this.warehouseRepository = warehouseRepository ?? throw new ArgumentNullException(nameof(warehouseRepository));
            this.rdlPreviewOpener = rdlPreviewOpener ?? throw new ArgumentNullException(nameof(rdlPreviewOpener));
            warehousePermissionValidator = warehousePermissionService.GetValidator(UoW, CommonServices.UserService.CurrentUserId);

            canEditRectroactively = entityExtendedPermissionValidator.Validate(typeof(MovementDocument), CommonServices.UserService.CurrentUserId, nameof(RetroactivelyClosePermission));
            ConfigureEntityChangingRelations();
            
            ValidationContext.ServiceContainer.AddService(typeof(IWarehouseRepository), warehouseRepository);
        }
        #endregion

        
        #region Functions

        private void ConfigureEntityChangingRelations()
        {
            SetPropertyChangeRelation(e => e.CanAddItem, () => CanAddItem, () => CanFillFromOrders);
            SetPropertyChangeRelation(e => e.CanDeleteItems, () => CanDeleteItems);
            
            SetPropertyChangeRelation(e => e.Warehouse, () => CanAddItem, () => CanFillFromOrders);
            SetPropertyChangeRelation(e => e.Warehouse, () => CanCreate);
        }
        
        private void ReloadAllowedWarehousesFrom()
        {
            var allowedWarehouses = warehousePermissionValidator.GetAllowedWarehouses(isNew? WarehousePermissions.IncomingInvoiceCreate: WarehousePermissions.IncomingInvoiceEdit, CurrentEmployee.Subdivision);
            allowedWarehousesFrom = UoW.Session.QueryOver<Warehouse>()
                .Where(x => !x.IsArchive)
                .WhereRestrictionOn(x => x.Id).IsIn(allowedWarehouses.Select(x => x.Id).ToArray())
                .List();
            OnPropertyChanged(nameof(AllowedWarehousesFrom));
            OnPropertyChanged(nameof(Warehouses));
        }
        
        public override bool Save(bool close)
        {
            if(!CanEdit)
                return false;
            
            if(UoW.IsNew) {
                Entity.Author = CurrentEmployee;
                Entity.TimeStamp = DateTime.Now;
            }
            else
            {
                if(Entity.LastEditor == null) {
                    throw new InvalidOperationException("Ваш пользователь не привязан к действующему сотруднику, вы не можете изменять складские документы, так как некого указывать в качестве кладовщика.");
                }
            }
            
            Entity.LastEditor = CurrentEmployee;
            Entity.LastEditedTime = DateTime.Now;
            

            return base.Save(close);
        }

        #endregion
        
        
        #region Properties

        public bool isNew => Entity.Id == 0;

        private readonly bool canEditRectroactively;
        public bool CanEdit => 
            (UoW.IsNew && PermissionResult.CanCreate) 
            || (PermissionResult.CanUpdate)
            || canEditRectroactively;

        public bool CanAddItem => CanEdit && Entity.CanAddItem && Entity.Warehouse != null;
        public bool CanDeleteItems => CanEdit && Entity.CanDeleteItems;
        public bool CanFillFromOrders => CanEdit && Entity.CanAddItem && Entity.Warehouse != null;

        public string TotalSum
        {
            get
            {
                return $"Итого: {Entity.TotalSum:N2} ₽";
            }
        }
        
        private IEnumerable<Warehouse> allowedWarehousesFrom;
        public IEnumerable<Warehouse> AllowedWarehousesFrom {
            get {
                if(allowedWarehousesFrom == null) {
                    ReloadAllowedWarehousesFrom();
                }
                return allowedWarehousesFrom;
            }
        }
        
        public IEnumerable<Warehouse> Warehouses {
            get {
                var result = new List<Warehouse>(AllowedWarehousesFrom);
                if(Entity.Warehouse != null && !AllowedWarehousesFrom.Contains(Entity.Warehouse)) {
                    result.Add(Entity.Warehouse);
                }
                return result;
            }
        }
        
        private Employee currentEmployee;
        public Employee CurrentEmployee {
            get {
                if(currentEmployee == null) {
                    currentEmployee = employeeService.GetEmployeeForUser(UoW, CommonServices.UserService.CurrentUserId);
                }
                return currentEmployee;
            }
        }
        private bool DocumentHasChanges { get { return UoWGeneric.HasChanges; } }
        public bool CanCreate => PermissionResult.CanCreate;
        public bool CanUpdate => PermissionResult.CanUpdate;
        public bool CanCreateOrUpdate => Entity.Id == 0 ? CanCreate : CanUpdate;
        
        #endregion
        
        
        #region Commands

        private DelegateCommand<IncomingInvoiceItem> deleteItemCommand;
        public DelegateCommand<IncomingInvoiceItem> DeleteItemCommand {
            get {
                if(deleteItemCommand == null) {
                    deleteItemCommand = new DelegateCommand<IncomingInvoiceItem>(
                        (selectedItem) => {
                            Entity.DeleteItem(selectedItem);
                            OnPropertyChanged(nameof(TotalSum));
                        },
                        (selectedItem) =>  CanDeleteItems && selectedItem != null
                    );
                    deleteItemCommand.CanExecuteChangedWith(this, x => x.CanDeleteItems);
                }
                return deleteItemCommand;
            }
        }
        
        private DelegateCommand addItemCommand;
        public DelegateCommand AddItemCommand {
            get {
                if(addItemCommand == null) {
                    addItemCommand = new DelegateCommand(
                        () => {
                            
                            var alreadyAddedNomenclatures = Entity.Items
                                .Where(x => x.Nomenclature != null)
                                .Select(x => x.Nomenclature.Id);
                            
                            
                            var nomenclatureSelector = nomenclatureSelectorFactory
                                .CreateNomenclatureSelector(alreadyAddedNomenclatures);
                            
                            nomenclatureSelector.OnEntitySelectedResult += (sender, e) => {
                                var selectedNodes = e.SelectedNodes;
                                if(!selectedNodes.Any()) {
                                    return;
                                }
                                
                                var selectedNomenclatures = UoW.GetById<Nomenclature>(
                                    selectedNodes.Select(x => x.Id)
                                );
                                
                                foreach(var nomenclature in selectedNomenclatures) {
                                    Entity.AddItem(new IncomingInvoiceItem(){Nomenclature = nomenclature, Amount = 1});
                                    OnPropertyChanged(nameof(TotalSum));
                                }
                                
                            };
                            TabParent.AddSlaveTab(this, nomenclatureSelector);
                        },
                        () => CanAddItem
                    );
                    addItemCommand.CanExecuteChangedWith(this, x => x.CanAddItem);
                }
                return addItemCommand;
            }
        }
        
        private DelegateCommand fillFromOrdersCommand;
		public DelegateCommand FillFromOrdersCommand {
			get {
				if(fillFromOrdersCommand == null) {
					fillFromOrdersCommand = new DelegateCommand(
						() => {
							bool IsOnlineStoreOrders = true;
							IEnumerable<OrderStatus> orderStatuses = new OrderStatus[] { OrderStatus.Accepted, OrderStatus.InTravelList, OrderStatus.OnLoading };
							var orderSelector = orderSelectorFactory.CreateOrderSelectorForDocument(IsOnlineStoreOrders, orderStatuses);
							orderSelector.OnEntitySelectedResult += (sender, e) => {
								IEnumerable<OrderForMovDocJournalNode> selectedNodes = e.SelectedNodes.Cast<OrderForMovDocJournalNode>();
								if(!selectedNodes.Any()) {
									return;
								}
								var orders = UoW.GetById<Order>(selectedNodes.Select(x => x.Id));
								var orderItems = orders.SelectMany(x => x.OrderItems);
								var nomIds = orderItems.Where(x => x.Nomenclature != null).Select(x => x.Nomenclature.Id).ToList();

								var nomsAmount = new Dictionary<int, decimal>();
								if (nomIds != null && nomIds.Any()) 
                                {
									nomIds = nomIds.Distinct().ToList();
									nomsAmount = StockRepository.NomenclatureInStock(UoW, Entity.Warehouse.Id, nomIds.ToArray());
								}
                                //Если такие уже добавлены, то только увеличить их количество
								foreach (var item in orderItems) {
                                    var moveItem = Entity.Items.FirstOrDefault(x => x.Nomenclature.Id == item.Nomenclature.Id);
                                    if (moveItem == null)
                                    {
                                        var count = item.Count > nomsAmount[item.Nomenclature.Id]
                                            ? nomsAmount[item.Nomenclature.Id]
                                            : item.Count;
                                        if ((count == 0) && item.Nomenclature.OnlineStore == null)
                                            continue;
                                        
                                        if (item.Nomenclature.Category == NomenclatureCategory.service || item.Nomenclature.Category == NomenclatureCategory.master)
                                            continue;
									
                                        Entity.AddItem( new IncomingInvoiceItem(){Nomenclature = item.Nomenclature, Amount = item.Count, PrimeCost = item.Price} );
                                    } else {
                                        var count = (moveItem.Amount + item.Count) > nomsAmount[item.Nomenclature.Id] ?
                                            nomsAmount[item.Nomenclature.Id] :
                                            (moveItem.Amount + item.Count);
                                        if(count == 0)
                                            continue;
                                        moveItem.Amount = count;
                                    }
                                }
                                
                                OnPropertyChanged(nameof(TotalSum));
							};
							TabParent.AddSlaveTab(this, orderSelector);
						},
						() => CanFillFromOrders
					);
					fillFromOrdersCommand.CanExecuteChangedWith(this, x => x.CanFillFromOrders);
				}
				return fillFromOrdersCommand;
			}
		}
        
        
        private DelegateCommand printCommand;
        public DelegateCommand PrintCommand {
            get {
                if(printCommand == null) {
                    printCommand = new DelegateCommand(
                        () => {
                            int? currentEmployeeId = EmployeeSingletonRepository.GetInstance().GetEmployeeForCurrentUser(UoW)?.Id;
                            var doc = new IncomingInvoiceDocumentRDL(Entity, currentEmployeeId){Title = Entity.Title};
                            if(doc is IPrintableRDLDocument) {
                                rdlPreviewOpener.OpenRldDocument(typeof(IncomingInvoice), doc);
                            }
                        },
                        () => true
                    );
                    
                }
                return printCommand;
            }
        }
        

        #endregion
       
    }
}