﻿using System;
using System.Linq;
using NHibernate;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Project.Services;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Domain.Goods;
using Vodovoz.ViewModels.Journals.FilterViewModels.Orders;
using Vodovoz.ViewModels.Journals.JournalNodes;
using Vodovoz.ViewModels.ViewModels.Orders;

namespace Vodovoz.ViewModels.Journals.JournalViewModels.Orders
{
    public class NomenclaturesPlanJournalViewModel : FilterableSingleEntityJournalViewModelBase<Nomenclature, NomenclaturePlanViewModel, NomenclaturePlanJournalNode, NomenclaturePlanFilterViewModel>
    {
        public NomenclaturesPlanJournalViewModel(
	        EntitiesJournalActionsViewModel journalActionsViewModel,
	        NomenclaturePlanFilterViewModel filterViewModel,
	        IUnitOfWorkFactory unitOfWorkFactory,
	        ICommonServices commonServices)
            : base(journalActionsViewModel, filterViewModel, unitOfWorkFactory, commonServices)
        {
            TabName = "Журнал План продаж для КЦ";
            UpdateOnChanges(typeof(Nomenclature));
        }

        protected override void InitializeJournalActionsViewModel()
        {
	        bool canEdit = 
		        ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_save_callcenter_motivation_report_filter");

	        EntitiesJournalActionsViewModel.Initialize(
		        SelectionMode, EntityConfigs, this, HideJournal, OnItemsSelected,
		        true, true, canEdit);
        }

        protected override Func<IUnitOfWork, IQueryOver<Nomenclature>> ItemsSourceQueryFunction => (uow) =>
        {
            Nomenclature nomenclatureAlias = null;
            NomenclaturePlanJournalNode resultAlias = null;

            var itemsQuery = uow.Session.QueryOver(() => nomenclatureAlias);

            if (!FilterViewModel.RestrictArchive)
                itemsQuery.Where(() => !nomenclatureAlias.IsArchive);

            if (!FilterViewModel.RestrictDilers)
                itemsQuery.Where(() => !nomenclatureAlias.IsDiler);

            if (FilterViewModel.RestrictCategory == NomenclatureCategory.water)
                itemsQuery.Where(() => nomenclatureAlias.IsDisposableTare == FilterViewModel.RestrictDisposbleTare);

            if (FilterViewModel.RestrictCategory.HasValue)
                itemsQuery.Where(() => nomenclatureAlias.Category == FilterViewModel.RestrictCategory.Value);

            if (FilterViewModel.SelectCategory.HasValue && FilterViewModel.SelectSaleCategory.HasValue
                && Nomenclature.GetCategoriesWithSaleCategory().Contains(FilterViewModel.SelectCategory.Value))
                itemsQuery.Where(() => nomenclatureAlias.SaleCategory == FilterViewModel.SelectSaleCategory);

            if (FilterViewModel.IsOnlyPlanned)
                itemsQuery.Where(n => n.PlanDay != null || n.PlanMonth != null);

            itemsQuery.Where(GetSearchCriterion(
                () => nomenclatureAlias.Name,
                () => nomenclatureAlias.Id,
                () => nomenclatureAlias.OnlineStoreExternalId)
            );

            itemsQuery.Where(() => !nomenclatureAlias.IsSerial)
                .SelectList(list => list
                    .SelectGroup(() => nomenclatureAlias.Id).WithAlias(() => resultAlias.Id)
                    .Select(() => nomenclatureAlias.Name).WithAlias(() => resultAlias.Name)
                    .Select(() => nomenclatureAlias.Category).WithAlias(() => resultAlias.Category)
                    .Select(() => nomenclatureAlias.OnlineStoreExternalId).WithAlias(() => resultAlias.OnlineStoreExternalId)
                    .Select(() => nomenclatureAlias.PlanDay).WithAlias(() => resultAlias.PlanDay)
                    .Select(() => nomenclatureAlias.PlanMonth).WithAlias(() => resultAlias.PlanMonth)
                )
                .OrderBy(x => x.Name).Asc
                .TransformUsing(Transformers.AliasToBean<NomenclaturePlanJournalNode>());

            return itemsQuery;
        };

        protected override Func<NomenclaturePlanViewModel> CreateDialogFunction => 
	        () => throw new InvalidOperationException("Нельзя создавать номенклатуры из данного журнала");

        protected override Func<JournalEntityNodeBase, NomenclaturePlanViewModel> OpenDialogFunction =>
            node => new NomenclaturePlanViewModel(
	            EntityUoWBuilder.ForOpen(node.Id),
	            UnitOfWorkFactory,
	            CommonServices);
    }
}
