﻿using NHibernate;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Services;
using System;
using QS.ViewModels;
using Vodovoz.Domain.Logistic;
using Vodovoz.ViewModels.Journals.JournalNodes.Logistic;
using Vodovoz.ViewModels.ViewModels.Employees;
using Vodovoz.ViewModels.ViewModels.Logistic;

namespace Vodovoz.ViewModels.Journals.JournalViewModels.Logistic
{
	public class CarEventTypeJournalViewModel : SingleEntityJournalViewModelBase<CarEventType, CarEventTypeViewModel,
		CarEventTypeJournalNode>
	{
		public CarEventTypeJournalViewModel(
			EntitiesJournalActionsViewModel journalActionsViewModel,
			IUnitOfWorkFactory unitOfWorkFactory,
			ICommonServices commonServices)
			: base(journalActionsViewModel, unitOfWorkFactory, commonServices)
		{
			TabName = "Виды событий ТС";

			UpdateOnChanges(typeof(CarEventType));
		}

		protected override Func<IUnitOfWork, IQueryOver<CarEventType>> ItemsSourceQueryFunction => (uow) =>
		{
			CarEventType carEventTypeAlias = null;
			CarEventTypeJournalNode resultAlias = null;

			var itemsQuery = uow.Session.QueryOver(() => carEventTypeAlias);

			itemsQuery.Where(GetSearchCriterion(
				() => carEventTypeAlias.Id,
				() => carEventTypeAlias.Name,
				() => carEventTypeAlias.ShortName)
			);

			itemsQuery.SelectList(list => list
					.Select(() => carEventTypeAlias.Id).WithAlias(() => resultAlias.Id)
					.Select(() => carEventTypeAlias.Name).WithAlias(() => resultAlias.Name)
					.Select(() => carEventTypeAlias.ShortName).WithAlias(() => resultAlias.ShortName)
					.Select(() => carEventTypeAlias.NeedComment).WithAlias(() => resultAlias.NeedComment)
					.Select(() => carEventTypeAlias.IsArchive).WithAlias(() => resultAlias.IsArchive)
				)
				.TransformUsing(Transformers.AliasToBean<CarEventTypeJournalNode>());

			return itemsQuery;
		};

		protected override Func<CarEventTypeViewModel> CreateDialogFunction => () =>
			new CarEventTypeViewModel(EntityUoWBuilder.ForCreate(), UnitOfWorkFactory, CommonServices);

		protected override Func<JournalEntityNodeBase, CarEventTypeViewModel> OpenDialogFunction =>
			(node) => new CarEventTypeViewModel(EntityUoWBuilder.ForOpen(node.Id), UnitOfWorkFactory, CommonServices);
	}
}
