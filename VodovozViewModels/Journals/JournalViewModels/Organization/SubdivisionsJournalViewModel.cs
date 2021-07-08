﻿using System;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Domain.Employees;
using Vodovoz.EntityRepositories.Permissions;
using Vodovoz.FilterViewModels.Organization;
using Vodovoz.Journals.JournalNodes;
using Vodovoz.ViewModels.ViewModels.Organizations;

namespace Vodovoz.Journals.JournalViewModels.Organization
{
	public class SubdivisionsJournalViewModel : FilterableSingleEntityJournalViewModelBase<Subdivision, SubdivisionViewModel, SubdivisionJournalNode, SubdivisionFilterViewModel>
	{
		private readonly IEntityAutocompleteSelectorFactory employeeSelectorFactory;

		public SubdivisionsJournalViewModel(
			EntitiesJournalActionsViewModel journalActionsViewModel,
			SubdivisionFilterViewModel filterViewModel,
			IUnitOfWorkFactory unitOfWorkFactory,
			ICommonServices commonServices,
			IEntityAutocompleteSelectorFactory employeeSelectorFactory
		) : base(journalActionsViewModel, filterViewModel, unitOfWorkFactory, commonServices)
		{
			this.employeeSelectorFactory = employeeSelectorFactory ?? throw new ArgumentNullException(nameof(employeeSelectorFactory));
			TabName = "Выбор подразделения";
		}

		protected override Func<IUnitOfWork, IQueryOver<Subdivision>> ItemsSourceQueryFunction => (uow) => {
			Subdivision subdivisionAlias = null;
			Employee chiefAlias = null;
			SubdivisionJournalNode resultAlias = null;
			var query = uow.Session.QueryOver<Subdivision>(() => subdivisionAlias);

			var firstLevelSubQuery = QueryOver.Of<Subdivision>().WhereRestrictionOn(x => x.ParentSubdivision).IsNull().Select(x => x.Id);
			var secondLevelSubquery = QueryOver.Of<Subdivision>().WithSubquery.WhereProperty(x => x.ParentSubdivision.Id).In(firstLevelSubQuery).Select(x => x.Id);

			query
				.WithSubquery.WhereProperty(x => x.Id).NotIn(firstLevelSubQuery)
				.WithSubquery.WhereProperty(x => x.Id).NotIn(secondLevelSubquery);

			if(FilterViewModel?.ExcludedSubdivisions?.Any() ?? false) {
				query.WhereRestrictionOn(() => subdivisionAlias.Id).Not.IsIn(FilterViewModel.ExcludedSubdivisions);
			}
			if(FilterViewModel?.SubdivisionType != null) {
				query.Where(Restrictions.Eq(Projections.Property<Subdivision>(x => x.SubdivisionType), FilterViewModel.SubdivisionType));
			}

			var chiefProjection = Projections.SqlFunction(
				new SQLFunctionTemplate(NHibernateUtil.String, "GET_PERSON_NAME_WITH_INITIALS(?1, ?2, ?3)"),
				NHibernateUtil.String,
				Projections.Property(() => chiefAlias.LastName),
				Projections.Property(() => chiefAlias.Name),
				Projections.Property(() => chiefAlias.Patronymic)
			);

			query.Where(GetSearchCriterion(() => subdivisionAlias.Name));

			return query
				.Left.JoinAlias(o => o.Chief, () => chiefAlias)
				.SelectList(list => list
				   .Select(s => s.Id).WithAlias(() => resultAlias.Id)
				   .Select(s => s.Name).WithAlias(() => resultAlias.Name)
				   .Select(chiefProjection).WithAlias(() => resultAlias.ChiefName)
				   .Select(s => s.ParentSubdivision.Id).WithAlias(() => resultAlias.ParentId)
				)
				.TransformUsing(Transformers.AliasToBean<SubdivisionJournalNode>());

		};

		protected override Func<SubdivisionViewModel> CreateDialogFunction => 
			() => new SubdivisionViewModel(
				EntityUoWBuilder.ForCreate(),
				UnitOfWorkFactory,
				CommonServices,
				employeeSelectorFactory,
				new PermissionRepository());

		protected override Func<JournalEntityNodeBase, SubdivisionViewModel> OpenDialogFunction => 
			node => new SubdivisionViewModel(
				EntityUoWBuilder.ForOpen(node.Id),
				UnitOfWorkFactory,
				CommonServices,
				employeeSelectorFactory,
				new PermissionRepository());
	}
}
