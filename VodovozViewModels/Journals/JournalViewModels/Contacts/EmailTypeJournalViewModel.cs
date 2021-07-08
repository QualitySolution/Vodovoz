﻿using System;
using NHibernate;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Domain.Contacts;
using Vodovoz.EntityRepositories;
using Vodovoz.ViewModels;

namespace Vodovoz.Journals.JournalViewModels
{
	public class EmailTypeJournalViewModel : SingleEntityJournalViewModelBase<EmailType, EmailTypeViewModel, EmailTypeJournalNode>
	{
		public EmailTypeJournalViewModel
		(
			EntitiesJournalActionsViewModel journalActionsViewModel,
			IEmailRepository emailRepository,
			IUnitOfWorkFactory unitOfWorkFactory, ICommonServices commonServices)
			: base(journalActionsViewModel, unitOfWorkFactory, commonServices)
		{
			this.emailRepository = emailRepository ?? throw new ArgumentNullException(nameof(emailRepository));

			TabName = "Типы e-mail адресов";
			UpdateOnChanges(typeof(EmailType));
		}

		IEmailRepository emailRepository;

		protected override Func<IUnitOfWork, IQueryOver<EmailType>> ItemsSourceQueryFunction => (uow) => {

			EmailTypeJournalNode resultAlias = null;

			var query = uow.Session.QueryOver<EmailType>()
				.SelectList(list => list
				.Select(x => x.Id).WithAlias(() => resultAlias.Id)
				.Select(x => x.Name).WithAlias(() => resultAlias.Name)
				.Select(x => x.EmailPurpose).WithAlias(() => resultAlias.EmailPurpose))
				.TransformUsing(Transformers.AliasToBean<EmailTypeJournalNode>()).OrderBy(x => x.Id).Desc;

			query.Where(
			GetSearchCriterion<EmailType>(
				x => x.Id,
				x => x.EmailPurpose,
				x => x.Name
				)
			);

			return query;
		};

		protected override Func<EmailTypeViewModel> CreateDialogFunction => () => new EmailTypeViewModel(
			emailRepository,
			EntityUoWBuilder.ForCreate(),
			UnitOfWorkFactory,
			CommonServices
		);

		protected override Func<JournalEntityNodeBase, EmailTypeViewModel> OpenDialogFunction => node => new EmailTypeViewModel(
			emailRepository,
			EntityUoWBuilder.ForOpen(node.Id),
			UnitOfWorkFactory,
			CommonServices
		);

		protected override void InitializeJournalActionsViewModel()
		{
			EntitiesJournalActionsViewModel.Initialize(
				SelectionMode, EntityConfigs, this, HideJournal, OnItemsSelected,
				true, true, true, false);
		}
	}

	public class EmailTypeJournalNode : JournalEntityNodeBase<EmailType>
	{
		public string Name { get; set; }
		public EmailPurpose EmailPurpose { get; set; }
	}
}
