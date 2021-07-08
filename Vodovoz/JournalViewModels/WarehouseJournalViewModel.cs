﻿using System;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Core;
using Vodovoz.Domain.Store;
using Vodovoz.EntityRepositories.Subdivisions;
using Vodovoz.Infrastructure.Permissions;
using Vodovoz.ViewModels.Journals.JournalNodes;
using Vodovoz.ViewModels.Warehouses;

namespace Vodovoz.JournalViewModels
{
    public class WarehouseJournalViewModel
        : SingleEntityJournalViewModelBase<Warehouse, WarehouseViewModel, WarehouseJournalNode>
    {
        public WarehouseJournalViewModel(
	        EntitiesJournalActionsViewModel journalActionsViewModel,
            IUnitOfWorkFactory unitOfWorkFactory,
            ICommonServices commonServices,
            ISubdivisionRepository subdivisionRepository)
                : base(journalActionsViewModel, unitOfWorkFactory, commonServices)
        {
            TabName = "Журнал складов";
            this.subdivisionRepository = subdivisionRepository ?? throw new ArgumentNullException(nameof(subdivisionRepository));
            warehousePermissions = new[] { WarehousePermissions.WarehouseView };

            UpdateOnChanges(
                typeof(Warehouse)
            );
        }

        private readonly ISubdivisionRepository subdivisionRepository;
        private WarehousePermissions[] warehousePermissions;

        protected override void InitializeJournalActionsViewModel()
        {
	        EntitiesJournalActionsViewModel.Initialize(SelectionMode, EntityConfigs, this, HideJournal, OnItemsSelected,
		        true, true, true, false);
        }

        protected override Func<IUnitOfWork, IQueryOver<Warehouse>> ItemsSourceQueryFunction => (uow) => {
            Warehouse warehouseAlias = null;
            WarehouseJournalNode warehouseNodeAlias = null;

            var query = uow.Session.QueryOver<Warehouse>(() => warehouseAlias).WhereNot(w => w.IsArchive);
            var disjunction = new Disjunction();

            foreach (var p in warehousePermissions)
            {
                disjunction.Add<Warehouse>(w => w.Id.IsIn(CurrentPermissions.Warehouse.Allowed(p).Select(x => x.Id).ToArray()));
            }
            query.Where(disjunction);

            query.Where(GetSearchCriterion(
                () => warehouseAlias.Id,
                () => warehouseAlias.Name
            ));
            var result = query.SelectList(list => list
                    .Select(w => w.Id).WithAlias(() => warehouseNodeAlias.Id)
                    .Select(w => w.Name).WithAlias(() => warehouseNodeAlias.Name))
                .OrderBy(w => w.Name).Asc
                .TransformUsing(Transformers.AliasToBean<WarehouseJournalNode>());
            return result;
        };

        protected override Func<WarehouseViewModel> CreateDialogFunction => () => new WarehouseViewModel(
            EntityUoWBuilder.ForCreate(),
            UnitOfWorkFactory,
            CommonServices,
            subdivisionRepository
        );

        protected override Func<JournalEntityNodeBase, WarehouseViewModel> OpenDialogFunction => node => new WarehouseViewModel(
            EntityUoWBuilder.ForOpen(node.Id),
            UnitOfWorkFactory,
            CommonServices,
            subdivisionRepository
        );
    }
}
