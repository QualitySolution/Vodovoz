﻿using System;
using QS.DomainModel.UoW;
using QSOrmProject.RepresentationModel;
using Vodovoz.Domain.Cash;
using Vodovoz.Domain.Employees;
using Vodovoz.Filters.ViewModels;
using Vodovoz.ViewModel;

namespace Vodovoz
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class AccountableSlipFilter : RepresentationFilterBase<AccountableSlipFilter>, IAccountableSlipsFilter
	{
		protected override void ConfigureWithUow()
		{
			yentryExpense.ItemsQuery = Repository.Cash.CategoryRepository.ExpenseCategoriesQuery();

			var filter = new EmployeeFilterViewModel();
			filter.SetAndRefilterAtOnce(x => x.Status = EmployeeStatus.IsWorking);
			repEntryAccountable.RepresentationModel = new EmployeesVM(filter);
		}

		public AccountableSlipFilter(IUnitOfWork uow) : this()
		{
			UoW = uow;
		}

		public AccountableSlipFilter()
		{
			this.Build();
		}

		public ExpenseCategory RestrictExpenseCategory {
			get { return yentryExpense.Subject as ExpenseCategory; }
			set {
				yentryExpense.Subject = value;
				yentryExpense.Sensitive = false;
			}
		}

		public Employee RestrictAccountable {
			get { return repEntryAccountable.Subject as Employee; }
			set {
				repEntryAccountable.Subject = value;
				repEntryAccountable.Sensitive = false;
			}
		}

		public DateTime? RestrictStartDate {
			get { return dateperiod.StartDateOrNull; }
			set {
				dateperiod.StartDateOrNull = value;
				dateperiod.Sensitive = false;
			}
		}

		public DateTime? RestrictEndDate {
			get { return dateperiod.EndDateOrNull; }
			set {
				dateperiod.EndDateOrNull = value;
				dateperiod.Sensitive = false;
			}
		}

		public decimal? RestrictDebt => null;

		protected void OnYentryAccountableChanged(object sender, EventArgs e)
		{
			OnRefiltered();
		}

		protected void OnYentryExpenseChanged(object sender, EventArgs e)
		{
			OnRefiltered();
		}

		protected void OnDateperiodPeriodChanged(object sender, EventArgs e)
		{
			OnRefiltered();
		}
	}
}

