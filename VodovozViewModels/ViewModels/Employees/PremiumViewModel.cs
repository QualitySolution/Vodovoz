﻿using QS.Commands;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Services;
using QS.ViewModels;
using System;
using System.Linq;
using Vodovoz.Domain.Employees;
using Vodovoz.Infrastructure.Services;
using Vodovoz.TempAdapters;
using Vodovoz.ViewModels.Journals.JournalNodes;

namespace Vodovoz.ViewModels.ViewModels.Employees
{
	public class PremiumViewModel : EntityTabViewModelBase<Premium>
	{
		private readonly IEmployeeService _employeeService;
		private string _employeesSum;
		private DelegateCommand _addEmployeeCommand;
		private DelegateCommand<PremiumItem> _deleteEmployeeCommand;
		private DelegateCommand _divideAtAllCommand;
		private DelegateCommand _getReasonFromTemplateCommand;

		public PremiumViewModel(
			IEntityUoWBuilder uowBuilder,
			IUnitOfWorkFactory uowFactory,
			ICommonServices commonServices,
			IEmployeeService employeeService,
			IEmployeeJournalFactory employeeJournalFactory,
			IPremiumTemplateJournalFactory premiumTemplateJournalFactory)
			: base(uowBuilder, uowFactory, commonServices)
		{
			_employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));

			TabName = Entity.Title;

			CanEdit = (Entity.Id == 0 && PermissionResult.CanCreate) || (Entity.Id != 0 && PermissionResult.CanUpdate);
			Entity.ObservableItems.ListContentChanged += OnObservableItemsListContentChanged;
			EmployeeJournalFactory = employeeJournalFactory;
			PremiumTemplateAutocompleteSelectorFactory = premiumTemplateJournalFactory.CreatePremiumTemplateAutocompleteSelectorFactory();
		}

		public string EmployeesSum
		{
			get => _employeesSum;
			set => SetField(ref _employeesSum, value);
		}

		public bool CanEdit { get; private set; }
		public IEmployeeJournalFactory EmployeeJournalFactory { get; }
		public IEntityAutocompleteSelectorFactory PremiumTemplateAutocompleteSelectorFactory { get; }

		#region Commands

		public DelegateCommand AddEmployeeCommand => _addEmployeeCommand ?? (_addEmployeeCommand =
			new DelegateCommand(() =>
				{
					var selectorEmployee = 
						EmployeeJournalFactory.CreateEmployeeAutocompleteSelectorFactory().CreateAutocompleteSelector();
					selectorEmployee.OnEntitySelectedResult += OnEmployeeAdd;
					TabParent.AddSlaveTab(this, selectorEmployee);
				},
				() => CanEdit
				));

		public DelegateCommand<PremiumItem> DeleteEmployeeCommand => _deleteEmployeeCommand ?? (_deleteEmployeeCommand =
			new DelegateCommand<PremiumItem>((node) =>
				{
					if(node?.Id > 0)
					{
						UoW.Delete(node);
						if(node.WageOperation != null)
						{
							UoW.Delete(node.WageOperation);
						}
						Entity.ObservableItems.Remove(node);
					}
				},
				(node) => CanEdit
				));

		public DelegateCommand DivideAtAllCommand => _divideAtAllCommand ?? (_divideAtAllCommand =
			new DelegateCommand(() =>
				{
					Entity.DivideAtAll();
				},
				() => CanEdit
				));

		public DelegateCommand GetReasonFromTemplate => _getReasonFromTemplateCommand ?? (_getReasonFromTemplateCommand =
			new DelegateCommand(() =>
				{
					var selectorPremiumTemplate = PremiumTemplateAutocompleteSelectorFactory.CreateAutocompleteSelector();
					selectorPremiumTemplate.OnEntitySelectedResult += OnPremiumTemplateSelect;
					this.TabParent.AddSlaveTab(this, selectorPremiumTemplate);
				},
				() => CanEdit
				));

		#endregion

		#region Events
		private void OnEmployeeAdd(object sender, JournalSelectedNodesEventArgs e)
		{
			var selectedEmplyeeNode = e.SelectedNodes.FirstOrDefault();
			if(selectedEmplyeeNode == null)
			{
				return;
			}

			var employee = UoW.GetById<Employee>(selectedEmplyeeNode.Id);
			if(Entity.Items.Any(x => x.Employee.Id == employee.Id))
			{
				ShowErrorMessage($"Сотрудник {employee.ShortName} уже присутствует в списке.");
				return;
			}
			Entity.AddItem(employee);
		}

		private void OnPremiumTemplateSelect(object sender, JournalSelectedNodesEventArgs e)
		{
			var selectedEmplyeeNode = e.SelectedNodes.OfType<PremiumTemplateJournalNode>().FirstOrDefault();

			if(selectedEmplyeeNode == null)
			{
				return;
			}

			Entity.PremiumReasonString = selectedEmplyeeNode.Reason;
			Entity.TotalMoney = selectedEmplyeeNode.PremiumMoney;
		}

		private void OnObservableItemsListContentChanged(object sender, EventArgs e)
		{
			decimal sum = Entity.Items.Sum(x => x.Money);
			EmployeesSum = $"Итого по сотрудникам: {sum:N2} ₽";
		}

		#endregion

		private bool GetAuthor(out Employee cashier)
		{
			cashier = _employeeService.GetEmployeeForUser(UoW, CurrentUser.Id);
			if(cashier == null)
			{
				ShowErrorMessage("Ваш пользователь не привязан к действующему сотруднику.");
				return false;
			}
			return true;
		}

		public override bool Save(bool close)
		{
			if(!CanEdit)
			{
				return false;
			}

			Employee author;
			if(!GetAuthor(out author))
			{
				return false;
			}

			if(Entity.Author == null)
			{
				Entity.Author = author;
			}

			Entity.UpdateWageOperations(UoW);

			return base.Save(close);
		}
	}
}
