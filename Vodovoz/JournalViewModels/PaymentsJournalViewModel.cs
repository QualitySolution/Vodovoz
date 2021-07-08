﻿using Vodovoz.Domain.Payments;
using Vodovoz.Filters.ViewModels;
using Vodovoz.JournalNodes;
using Vodovoz.ViewModels;
using System;
using QS.DomainModel.UoW;
using QS.Services;
using QS.Navigation;
using NHibernate;
using NHibernate.Transform;
using BaseOrg = Vodovoz.Domain.Organizations.Organization;
using NHibernate.Dialect.Function;
using VodOrder = Vodovoz.Domain.Orders.Order;
using NHibernate.Criterion;
using QS.Project.Domain;
using QS.Project.Journal;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.Journals.JournalActionsViewModels;
using Vodovoz.Services;

namespace Vodovoz.JournalViewModels
{
	public class PaymentsJournalViewModel : FilterableMultipleEntityJournalViewModelBase<PaymentJournalNode, PaymentsJournalFilterViewModel>
	{
		private readonly PaymentsJournalActionsViewModel _paymentsJournalActionsViewModel;
		private readonly INavigationManager _navigationManager;
		private readonly IOrderRepository _orderRepository;
		private readonly IOrganizationParametersProvider _organizationParametersProvider;
		private readonly IProfitCategoryProvider _profitCategoryProvider;

		public PaymentsJournalViewModel(
			PaymentsJournalActionsViewModel journalActionsViewModel,
			PaymentsJournalFilterViewModel filterViewModel,
			IUnitOfWorkFactory unitOfWorkFactory,
			ICommonServices commonServices,
			INavigationManager navigationManager,
			IOrderRepository orderRepository,
			IOrganizationParametersProvider organizationParametersProvider,
			IProfitCategoryProvider profitCategoryProvider) 
			: base(journalActionsViewModel, filterViewModel, unitOfWorkFactory, commonServices)
		{
			_paymentsJournalActionsViewModel = journalActionsViewModel;
			
			TabName = "Журнал платежей из банк-клиента";
			_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
			_organizationParametersProvider = organizationParametersProvider ?? throw new ArgumentNullException(nameof(organizationParametersProvider));
			_profitCategoryProvider = profitCategoryProvider ?? throw new ArgumentNullException(nameof(profitCategoryProvider));
			_navigationManager = navigationManager;

			RegisterPayments();

			FinishJournalConfiguration();

			UpdateOnChanges(
				typeof(Payment),
				typeof(PaymentItem),
				typeof(VodOrder)
			);
		}

		private IQueryOver<Payment> GetPaymentQuery(IUnitOfWork uow)
		{
			PaymentJournalNode resultAlias = null;
			Payment paymentAlias = null;
			BaseOrg organizationAlias = null;
			PaymentItem paymentItemAlias = null;
			CategoryProfit categoryProfitAlias = null;

			var paymentQuery = uow.Session.QueryOver(() => paymentAlias)
				.Left.JoinAlias(() => paymentAlias.Organization, () => organizationAlias)
				.Left.JoinAlias(() => paymentAlias.ProfitCategory, () => categoryProfitAlias)
				.Left.JoinAlias(() => paymentAlias.PaymentItems, () => paymentItemAlias);

			#region filter

			if(FilterViewModel != null) 
			{
				if(FilterViewModel.StartDate.HasValue)
				{
					paymentQuery.Where(x => x.Date >= FilterViewModel.StartDate);
				}

				if(FilterViewModel.EndDate.HasValue)
				{
					paymentQuery.Where(x => x.Date <= FilterViewModel.EndDate.Value.AddDays(1).AddMilliseconds(-1));
				}

				if(FilterViewModel.HideCompleted)
				{
					paymentQuery.Where(x => x.Status != PaymentState.completed);
				}

				if(FilterViewModel.PaymentState.HasValue)
				{
					paymentQuery.Where(x => x.Status == FilterViewModel.PaymentState);
				}
			}

			#endregion filter

			var numOrders = Projections.SqlFunction(
							new SQLFunctionTemplate(NHibernateUtil.String, "GROUP_CONCAT( ?1 SEPARATOR ?2)"),
							NHibernateUtil.String,
							Projections.Property(() => paymentItemAlias.Order.Id),
							Projections.Constant("\n"));

			paymentQuery.Where(GetSearchCriterion(
				() => paymentAlias.PaymentNum,
				() => paymentAlias.Total,
				() => paymentAlias.CounterpartyName,
				() => paymentItemAlias.Order.Id
			));

			var resultQuery = paymentQuery
				.SelectList(list => list
				   .SelectGroup(() => paymentAlias.Id).WithAlias(() => resultAlias.Id)
				   .Select(() => paymentAlias.PaymentNum).WithAlias(() => resultAlias.PaymentNum)
				   .Select(() => paymentAlias.Date).WithAlias(() => resultAlias.Date)
				   .Select(() => paymentAlias.Total).WithAlias(() => resultAlias.Total)
				   .Select(numOrders).WithAlias(() => resultAlias.Orders)
				   .Select(() => paymentAlias.CounterpartyName).WithAlias(() => resultAlias.Counterparty)
				   .Select(() => organizationAlias.FullName).WithAlias(() => resultAlias.Organization)
				   .Select(() => paymentAlias.PaymentPurpose).WithAlias(() => resultAlias.PaymentPurpose)
				   .Select(() => categoryProfitAlias.Name).WithAlias(() => resultAlias.ProfitCategory)
				   .Select(() => paymentAlias.Status).WithAlias(() => resultAlias.Status)
				)
				.OrderBy(() => paymentAlias.Status).Asc
				.OrderBy(() => paymentAlias.CounterpartyName).Asc
				.OrderBy(() => paymentAlias.Total).Asc
				.TransformUsing(Transformers.AliasToBean<PaymentJournalNode>());
			return resultQuery;
		}

		protected override void InitializeJournalActionsViewModel()
		{
			_paymentsJournalActionsViewModel.Initialize(SelectionMode, EntityConfigs, this, HideJournal, OnItemsSelected,
				false, true, true, false);
		}

		private void RegisterPayments()
		{
			var complaintConfig = RegisterEntity<Payment>(GetPaymentQuery)
				.AddDocumentConfiguration(
					//функция диалога создания документа
					() => new PaymentLoaderViewModel(
						UnitOfWorkFactory,
						CommonServices,
						_navigationManager,
						_organizationParametersProvider,
						_profitCategoryProvider
					),
					//функция диалога открытия документа
					node => new ManualPaymentMatchingViewModel(
						EntityUoWBuilder.ForOpen(node.Id),
						UnitOfWorkFactory,
						CommonServices,
						_orderRepository
					),
					//функция идентификации документа 
					node => node.EntityType == typeof(Payment),
					"Платежи",
					new JournalParametersForDocument { HideJournalForCreateDialog = true, HideJournalForOpenDialog = true }
				);

			//завершение конфигурации
			complaintConfig.FinishConfiguration();
		}
	}
}
