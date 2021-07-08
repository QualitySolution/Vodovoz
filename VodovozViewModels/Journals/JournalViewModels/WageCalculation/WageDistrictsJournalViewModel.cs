﻿using System;
using NHibernate;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Project.Journal.DataLoader;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Domain.WageCalculation;
using Vodovoz.Journals.JournalNodes;
using Vodovoz.ViewModels.WageCalculation;

namespace Vodovoz.Journals.JournalViewModels.WageCalculation
{
	public class WageDistrictsJournalViewModel : SingleEntityJournalViewModelBase<WageDistrict, WageDistrictViewModel, WageDistrictJournalNode>
	{
		public WageDistrictsJournalViewModel(
			EntitiesJournalActionsViewModel journalActionsViewModel,
			IUnitOfWorkFactory unitOfWorkFactory, 
			ICommonServices commonServices) : base(journalActionsViewModel, unitOfWorkFactory, commonServices)
		{
			TabName = "Журнал групп зарплатных районов";

			var threadLoader = DataLoader as ThreadDataLoader<WageDistrictJournalNode>;
			threadLoader.MergeInOrderBy(x => x.IsArchive, false);
			threadLoader.MergeInOrderBy(x => x.Name, false);

			UpdateOnChanges(typeof(WageDistrict));
		}

		protected override Func<WageDistrictViewModel> CreateDialogFunction => () => new WageDistrictViewModel(
			EntityUoWBuilder.ForCreate(),
			UnitOfWorkFactory,
			CommonServices
		);

		protected override Func<JournalEntityNodeBase, WageDistrictViewModel> OpenDialogFunction => n => new WageDistrictViewModel(
			EntityUoWBuilder.ForOpen(n.Id),
			UnitOfWorkFactory,
			CommonServices
		);

		protected override Func<IUnitOfWork, IQueryOver<WageDistrict>> ItemsSourceQueryFunction => (uow) => {
			WageDistrictJournalNode resultAlias = null;

			var query = uow.Session.QueryOver<WageDistrict>();
			query.Where(
				GetSearchCriterion<WageDistrict>(
					x => x.Id
				)
			);

			var result = query.SelectList(list => list
									.Select(x => x.Id).WithAlias(() => resultAlias.Id)
									.Select(x => x.Name).WithAlias(() => resultAlias.Name)
									.Select(x => x.IsArchive).WithAlias(() => resultAlias.IsArchive)
								)
								.TransformUsing(Transformers.AliasToBean<WageDistrictJournalNode>())
								.OrderBy(x => x.Name).Asc
								.ThenBy(x => x.IsArchive).Asc
								;

			return result;
		};
	}
}
