﻿using System;
using System.Collections.Generic;
using System.Linq;
using QS.Commands;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.FilterViewModels.Goods;
using Vodovoz.Infrastructure.Services;
using Vodovoz.JournalNodes;
using Vodovoz.JournalViewModels;

namespace Vodovoz.ViewModels.Orders
{
	public class PromotionalSetViewModel : EntityTabViewModelBase<PromotionalSet>, IPermissionResult
	{
		private readonly IEmployeeService employeeService;
		private readonly INomenclatureRepository nomenclatureRepository;
		private readonly IUserRepository userRepository;
		private readonly IEntityAutocompleteSelectorFactory counterpartySelectorFactory;
		private readonly IEntityAutocompleteSelectorFactory nomenclatureSelectorFactory;
		
		public PromotionalSetViewModel(IEntityUoWBuilder uowBuilder, 
		                               IUnitOfWorkFactory unitOfWorkFactory, 
		                               ICommonServices commonServices,
		                               IEmployeeService employeeService,
		                               IEntityAutocompleteSelectorFactory counterpartySelectorFactory,
		                               IEntityAutocompleteSelectorFactory nomenclatureSelectorFactory,
		                               INomenclatureRepository nomenclatureRepository,
		                               IUserRepository userRepository) : base(uowBuilder, unitOfWorkFactory, commonServices)
		{
			this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
			this.nomenclatureRepository = nomenclatureRepository ?? throw new ArgumentNullException(nameof(nomenclatureRepository));
			this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
			this.counterpartySelectorFactory = counterpartySelectorFactory ?? throw new ArgumentNullException(nameof(counterpartySelectorFactory));
			this.nomenclatureSelectorFactory = nomenclatureSelectorFactory ?? throw new ArgumentNullException(nameof(nomenclatureSelectorFactory));
			
			if(!CanRead)
				AbortOpening("У вас недостаточно прав для просмотра");

			TabName = "Рекламные наборы";
			UoW = uowBuilder.CreateUoW<PromotionalSet>(unitOfWorkFactory);
			CreateCommands();
		}

		public string CreationDate => Entity.Id != 0 ? Entity.CreateDate.ToString("dd-MM-yyyy") : String.Empty;

		private IEnumerable<DiscountReason> discountReasonSource;
		public IEnumerable<DiscountReason> DiscountReasonSource {
			get => discountReasonSource ?? (discountReasonSource = UoW.GetAll<DiscountReason>());
		}

		private DiscountReason discountReason;
		public DiscountReason DiscountReason {
			get {
				discountReason = Entity.PromoSetDiscountReason;
				return discountReason;
			}
			set {
				if(SetField(ref discountReason, value)) {
					Entity.PromoSetDiscountReason = value;
					if(value != null)
						Entity.Name = value.Name;
				}
			}
		}

		private PromotionalSetItem selectedPromoItem;
		public PromotionalSetItem SelectedPromoItem {
			get => selectedPromoItem;
			set {
				SetField(ref selectedPromoItem, value);
				OnPropertyChanged(nameof(CanRemoveNomenclature));
			}
		}

		private PromotionalSetActionBase selectedAction;
		public PromotionalSetActionBase SelectedAction {
			get => selectedAction;
			set {
				SetField(ref selectedAction, value);
				OnPropertyChanged(nameof(CanRemoveAction));
			}
		}

		private WidgetViewModelBase selectedActionViewModel;
		public WidgetViewModelBase SelectedActionViewModel {
			get => selectedActionViewModel;
			set {
				SetField(ref selectedActionViewModel, value);
			}
		}

		#region Permissions

		public bool CanCreate => PermissionResult.CanCreate;
		public bool CanRead => PermissionResult.CanRead;
		public bool CanUpdate => PermissionResult.CanUpdate;
		public bool CanDelete => PermissionResult.CanDelete;

		public bool CanCreateOrUpdate => Entity.Id == 0 ? CanCreate : CanUpdate;
		public bool CanRemoveNomenclature => SelectedPromoItem != null && CanUpdate;
		public bool CanRemoveAction => selectedAction != null && CanDelete && Entity.Id == 0;

		#endregion

		#region Commands

		private void CreateCommands()
		{
			CreateAddNomenclatureCommand();
			CreateRemoveNomenclatureCommand();
			CreateAddActionCommand();
			CreateRemoveActionCommand();
		}

		public DelegateCommand AddNomenclatureCommand;

		private void CreateAddNomenclatureCommand()
		{
			AddNomenclatureCommand = new DelegateCommand(
			() => {
				var nomenFilter = new NomenclatureFilterViewModel();
				nomenFilter.SetAndRefilterAtOnce(
				x => x.AvailableCategories = Nomenclature.GetCategoriesForSaleToOrder(),
					x => x.SelectCategory = NomenclatureCategory.water,
					x => x.SelectSaleCategory = SaleCategory.forSale);
				var journalActons = new EntitiesJournalActionsViewModel(CommonServices.InteractiveService);

				var nomenJournalViewModel = new NomenclaturesJournalViewModel(journalActons, nomenFilter, UnitOfWorkFactory, 
					CommonServices, employeeService, nomenclatureSelectorFactory, counterpartySelectorFactory,
					nomenclatureRepository, userRepository) {
					SelectionMode = JournalSelectionMode.Single
				};

				nomenJournalViewModel.OnEntitySelectedResult += (sender, e) => {
					var selectedNode = e.SelectedNodes.Cast<NomenclatureJournalNode>().FirstOrDefault();
					if(selectedNode == null) {
						return;
					}
					var nomenclature = UoW.GetById<Nomenclature>(selectedNode.Id);
					if(Entity.ObservablePromotionalSetItems.Any(i => i.Nomenclature.Id == nomenclature.Id))
						return;
					Entity.ObservablePromotionalSetItems.Add(new PromotionalSetItem {
						Nomenclature = nomenclature,
						Count = 0,
						Discount = 0,
						PromoSet = Entity
					});
				};
				TabParent.AddSlaveTab(this, nomenJournalViewModel);
			},
		  () => true
		  );
		}

		public DelegateCommand RemoveNomenclatureCommand;

		private void CreateRemoveNomenclatureCommand()
		{
			RemoveNomenclatureCommand = new DelegateCommand(
			() => Entity.ObservablePromotionalSetItems.Remove(SelectedPromoItem),
			() => CanRemoveNomenclature
			);
			RemoveNomenclatureCommand.CanExecuteChangedWith(this, x => CanRemoveNomenclature);
		}

		public DelegateCommand<PromotionalSetActionType> AddActionCommand;

		private void CreateAddActionCommand()
		{
			AddActionCommand = new DelegateCommand<PromotionalSetActionType>(
			(actionType) => {
				PromotionalSetActionWidgetResolver resolver = new PromotionalSetActionWidgetResolver(UoW, 
					counterpartySelectorFactory, nomenclatureRepository, userRepository);
				SelectedActionViewModel = resolver.Resolve(Entity, actionType);

				if(SelectedActionViewModel is ICreationControl) {
					(SelectedActionViewModel as ICreationControl).CancelCreation += () => {
						SelectedActionViewModel = null;
					};
				}
			}
			);
		}

		public DelegateCommand RemoveActionCommand;

		private void CreateRemoveActionCommand()
		{
			RemoveActionCommand = new DelegateCommand(
			() => Entity.ObservablePromotionalSetActions.Remove(SelectedAction),
			() => CanRemoveAction
				);
		}

		#endregion
	}
}
