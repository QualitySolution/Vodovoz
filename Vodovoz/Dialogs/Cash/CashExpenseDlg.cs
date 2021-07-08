﻿using System;
using System.Collections.Generic;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QSOrmProject;
using QS.Validation;
using Vodovoz.Domain.Cash;
using Vodovoz.Domain.Employees;
using Vodovoz.Filters.ViewModels;
using Vodovoz.Repositories.HumanResources;
using QS.Services;
using Vodovoz.EntityRepositories;
using System.Linq;
using NHibernate.Criterion;
using QS.DomainModel.Entity.EntityPermissions.EntityExtendedPermission;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Project.Services;
using QS.ViewModels;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.Parameters;
using Vodovoz.PermissionExtensions;
using Vodovoz.ViewModels.Journals.FilterViewModels;
using Vodovoz.ViewModels.ViewModels.Cash;
using VodovozInfrastructure.Interfaces;
using Vodovoz.Domain.Documents;
using Vodovoz.Domain.Organizations;
using Vodovoz.EntityRepositories.Cash;
using Vodovoz.Repository.Cash;

namespace Vodovoz
{
	public partial class CashExpenseDlg : QS.Dialog.Gtk.EntityDialogBase<Expense>
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();
		private decimal currentEmployeeWage = default(decimal);
		private bool canEdit = true;
		private readonly bool canCreate;
		private readonly bool canEditRectroactively;
		private readonly bool canEditDate = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_edit_cash_income_expense_date");

		private RouteListCashOrganisationDistributor routeListCashOrganisationDistributor = 
			new RouteListCashOrganisationDistributor(
				new CashDistributionCommonOrganisationProvider(
					new OrganizationParametersProvider(SingletonParametersProvider.Instance)),
				new RouteListItemCashDistributionDocumentRepository(),
				OrderSingletonRepository.GetInstance());
		
		private ExpenseCashOrganisationDistributor expenseCashOrganisationDistributor = 
			new ExpenseCashOrganisationDistributor();
		
		private FuelCashOrganisationDistributor fuelCashOrganisationDistributor = 
			new FuelCashOrganisationDistributor(
				new CashDistributionCommonOrganisationProvider(
					new OrganizationParametersProvider(SingletonParametersProvider.Instance)));

		public CashExpenseDlg (IPermissionService permissionService)
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Expense>();
			Entity.Casher = EmployeeRepository.GetEmployeeForCurrentUser (UoW);
			if(Entity.Casher == null)
			{
				MessageDialogHelper.RunErrorDialog ("Ваш пользователь не привязан к действующему сотруднику, вы не можете создавать кассовые документы, так как некого указывать в качестве кассира.");
				FailInitialize = true;
				return;
			}

			var userPermission = permissionService.ValidateUserPermission(typeof(Expense), UserSingletonRepository.GetInstance().GetCurrentUser(UoW).Id);
			canCreate = userPermission.CanCreate;
			if(!userPermission.CanCreate) {
				MessageDialogHelper.RunErrorDialog("Отсутствуют права на создание расходного ордера");
				FailInitialize = true;
				return;
			}

			if(!accessfilteredsubdivisionselectorwidget.Configure(UoW, false,  typeof(Expense))) {
				MessageDialogHelper.RunErrorDialog(accessfilteredsubdivisionselectorwidget.ValidationErrorMessage);
				FailInitialize = true;
				return;
			}

			Entity.Date = DateTime.Now;
			ConfigureDlg();
		}

		public CashExpenseDlg (int id, IPermissionService permissionService)
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<Expense>(id);

			if(!accessfilteredsubdivisionselectorwidget.Configure(UoW, false, typeof(Expense))) {

				MessageDialogHelper.RunErrorDialog(accessfilteredsubdivisionselectorwidget.ValidationErrorMessage);
				FailInitialize = true;
				return;
			}

			var userPermission = permissionService.ValidateUserPermission(typeof(Expense), UserSingletonRepository.GetInstance().GetCurrentUser(UoW).Id);
			if(!userPermission.CanRead) {
				MessageDialogHelper.RunErrorDialog("Отсутствуют права на просмотр расходного ордера");
				FailInitialize = true;
				return;
			}
			canEdit = userPermission.CanUpdate;

			var permmissionValidator = new EntityExtendedPermissionValidator(PermissionExtensionSingletonStore.GetInstance(), EmployeeSingletonRepository.GetInstance());
			canEditRectroactively = permmissionValidator.Validate(typeof(Expense), UserSingletonRepository.GetInstance().GetCurrentUser(UoW).Id, nameof(RetroactivelyClosePermission));

			ConfigureDlg();
		}

		public CashExpenseDlg (Expense sub, IPermissionService permissionService) : this (sub.Id, permissionService) {}

		private bool CanEdit => (UoW.IsNew && canCreate) ||
		                        (canEdit && Entity.Date.Date == DateTime.Now.Date) ||
		                        canEditRectroactively;

		void ConfigureDlg()
		{
			if (!UoW.IsNew) {
				enumcomboOperation.Sensitive = false;
				specialListCmbOrganisation.Sensitive = false;
			}
			
			accessfilteredsubdivisionselectorwidget.OnSelected += Accessfilteredsubdivisionselectorwidget_OnSelected;
			if(Entity.RelatedToSubdivision != null) {
				accessfilteredsubdivisionselectorwidget.SelectIfPossible(Entity.RelatedToSubdivision);
			}

			enumcomboOperation.ItemsEnum = typeof(ExpenseType);
			enumcomboOperation.Binding.AddBinding (Entity, s => s.TypeOperation, w => w.SelectedItem).InitializeFromSource ();

			var filterCasher = new EmployeeFilterViewModel {Status = EmployeeStatus.IsWorking};
			yentryCasher.RepresentationModel = new ViewModel.EmployeesVM(filterCasher);
			yentryCasher.Binding.AddBinding(Entity, s => s.Casher, w => w.Subject).InitializeFromSource();

			var filterEmployee = new EmployeeFilterViewModel {Status = EmployeeStatus.IsWorking};
			yentryEmployee.RepresentationModel = new ViewModel.EmployeesVM(filterEmployee);
			yentryEmployee.Binding.AddBinding(Entity, s => s.Employee, w => w.Subject).InitializeFromSource();
			yentryEmployee.ChangedByUser += (sender, e) => UpdateEmployeeBalaceInfo();

			ydateDocument.Binding.AddBinding (Entity, s => s.Date, w => w.Date).InitializeFromSource ();
			ydateDocument.Sensitive = canEditDate;

			IFileChooserProvider fileChooserProvider = new FileChooser("Расход " + DateTime.Now + ".csv");
			var filterViewModel = new ExpenseCategoryJournalFilterViewModel {
				ExcludedIds = CategoryRepository.ExpenseSelfDeliveryCategories(UoW).Select(x => x.Id),
				HidenByDefault = true
			};
			var journalActions = new EntitiesJournalActionsViewModel(ServicesConfig.InteractiveService);
			
			var expenseCategorySelectorFactory = new SimpleEntitySelectorFactory<ExpenseCategory, ExpenseCategoryViewModel>(
				() => {
					var expenseCategoryJournalViewModel = new SimpleEntityJournalViewModel<ExpenseCategory, ExpenseCategoryViewModel>(
						journalActions,
						x => x.Name,
						() => new ExpenseCategoryViewModel(
							EntityUoWBuilder.ForCreate(),
							UnitOfWorkFactory.GetDefaultFactory,
							ServicesConfig.CommonServices,
							fileChooserProvider,
							filterViewModel
						),
						node => new ExpenseCategoryViewModel(
							EntityUoWBuilder.ForOpen(node.Id),
							UnitOfWorkFactory.GetDefaultFactory,
							ServicesConfig.CommonServices,
							fileChooserProvider,
							filterViewModel
						),
						UnitOfWorkFactory.GetDefaultFactory,
						ServicesConfig.CommonServices
					) {
						SelectionMode = JournalSelectionMode.Single
					};
					expenseCategoryJournalViewModel.SetFilter(filterViewModel,
						filter => Restrictions.Not(Restrictions.In("Id", filter.ExcludedIds.ToArray())));
					
					return expenseCategoryJournalViewModel;
				}
			);
			entityVMEntryExpenseCategory.SetEntityAutocompleteSelectorFactory(expenseCategorySelectorFactory);
			entityVMEntryExpenseCategory.Binding.AddBinding(Entity, e => e.ExpenseCategory, w => w.Subject).InitializeFromSource();

			specialListCmbOrganisation.ShowSpecialStateNot = true;
			specialListCmbOrganisation.ItemsList = UoW.GetAll<Organization>();
			specialListCmbOrganisation.Binding.AddBinding(Entity, e => e.Organisation, w => w.SelectedItem).InitializeFromSource();

			yspinMoney.Binding.AddBinding (Entity, s => s.Money, w => w.ValueAsDecimal).InitializeFromSource ();

			ytextviewDescription.Binding.AddBinding (Entity, s => s.Description, w => w.Buffer.Text).InitializeFromSource ();

			ExpenseType type = (ExpenseType)enumcomboOperation.SelectedItem;
			ylabelEmployeeWageBalance.Visible = type == ExpenseType.EmployeeAdvance
											 || type == ExpenseType.Salary
											 || (type == ExpenseType.Advance && (new EmployeeCategory[] { EmployeeCategory.office }).All(x => x != Entity?.Employee?.Category));
			UpdateEmployeeBalaceInfo();
			UpdateSubdivision();

			if(!CanEdit) {
				table1.Sensitive = false;
				accessfilteredsubdivisionselectorwidget.Sensitive = false;
				buttonSave.Sensitive = false;
				ytextviewDescription.Editable = false;
			}
		}

		public void CopyExpenseFrom(Expense doc)
		{
			Entity.TypeOperation = doc.TypeOperation;
			Entity.ExpenseCategory = doc.ExpenseCategory;
			Entity.Description = doc.Description;
			Entity.RelatedToSubdivision = doc.RelatedToSubdivision;
			accessfilteredsubdivisionselectorwidget.SelectIfPossible(Entity.RelatedToSubdivision);
			UpdateSubdivision();
		}

		void Accessfilteredsubdivisionselectorwidget_OnSelected(object sender, EventArgs e)
		{
			UpdateSubdivision();
		}

		private void UpdateSubdivision()
		{
			if(accessfilteredsubdivisionselectorwidget.SelectedSubdivision != null && accessfilteredsubdivisionselectorwidget.NeedChooseSubdivision) {
				Entity.RelatedToSubdivision = accessfilteredsubdivisionselectorwidget.SelectedSubdivision;
			}
		}

		public override bool Save ()
		{
			var valid = new QSValidator<Expense> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			Entity.UpdateWagesOperations(UoW);

			if (UoW.IsNew) {
				DistributeCash();
			}
			else {
				UpdateCashDistributionsDocuments();
			}
			
			logger.Info ("Сохраняем расходный ордер...");
			UoWGeneric.Save();
			logger.Info ("Ok");
			return true;
		}

		private void DistributeCash()
		{
			if (Entity.TypeOperation == ExpenseType.Expense && 
			    Entity.ExpenseCategory.Id == CategoryRepository.RouteListClosingExpenseCategory(UoW)?.Id) {
				routeListCashOrganisationDistributor.DistributeExpenseCash(UoW, Entity.RouteListClosing, Entity, Entity.Money);
			}
			else if (Entity.TypeOperation == ExpenseType.EmployeeAdvance
			         || Entity.TypeOperation == ExpenseType.Salary) {
				expenseCashOrganisationDistributor.DistributeCashForExpense(UoW, Entity, true);
			}
			else {
				expenseCashOrganisationDistributor.DistributeCashForExpense(UoW, Entity);
			}
		}
		
		private void UpdateCashDistributionsDocuments()
		{
			var editor = EmployeeSingletonRepository.GetInstance().GetEmployeeForCurrentUser(UoW);
			var document = UoW.Session.QueryOver<CashOrganisationDistributionDocument>()
				.Where(x => x.Expense.Id == Entity.Id).List().FirstOrDefault();

			if (document != null)
			{
				switch (document.Type)
				{
					case CashOrganisationDistributionDocType.ExpenseCashDistributionDoc:
						expenseCashOrganisationDistributor.UpdateRecords(UoW, (ExpenseCashDistributionDocument)document, Entity, editor);
						break;
					case CashOrganisationDistributionDocType.FuelExpenseCashOrgDistributionDoc:
						fuelCashOrganisationDistributor.UpdateRecords(UoW, (FuelExpenseCashDistributionDocument)document, Entity, editor);
						break;
				}
			}
		}

		protected void OnEnumcomboOperationEnumItemSelected (object sender, Gamma.Widgets.ItemSelectedEventArgs e)
		{
			if (Entity.TypeOperation == ExpenseType.Salary || Entity.TypeOperation == ExpenseType.EmployeeAdvance) {
				if (Entity.Organisation != null) {
					Entity.Organisation = null;
				}

				ylabel1.Visible = specialListCmbOrganisation.Visible = false;
			}
			else {
				ylabel1.Visible = specialListCmbOrganisation.Visible = true;
			}

			UpdateEmployeeBalaceInfo();
		}

		private void UpdateEmployeeBalaceInfo()
		{
			UpdateEmployeeBalanceVisibility();

			currentEmployeeWage = 0;
			string labelTemplate = "Текущий баланс сотрудника: {0}";
			Employee employee = yentryEmployee.Subject as Employee;

			if (employee != null)
			{
				currentEmployeeWage =
					Repository.Operations.WagesMovementRepository.GetCurrentEmployeeWageBalance(UoW, employee.Id);
			}

			ylabelEmployeeWageBalance.LabelProp = string.Format(labelTemplate, currentEmployeeWage);
		}

		private void UpdateEmployeeBalanceVisibility()
		{
			switch((ExpenseType)enumcomboOperation.SelectedItem) {
				case ExpenseType.Advance:
					labelEmployee.LabelProp = "Подотчетное лицо:";
					ylabelEmployeeWageBalance.Visible = (new EmployeeCategory[] {EmployeeCategory.office}).All(x => x != Entity?.Employee?.Category);
					break;
				case ExpenseType.Expense:
					labelEmployee.LabelProp = "Сотрудник:";
					ylabelEmployeeWageBalance.Visible = false;
					break;
				case ExpenseType.EmployeeAdvance:
					labelEmployee.LabelProp = "Сотрудник:";
					ylabelEmployeeWageBalance.Visible = true;
					break;
				case ExpenseType.Salary:
					labelEmployee.LabelProp = "Сотрудник:";
					ylabelEmployeeWageBalance.Visible = true;
					break;
			}
		}

		protected void OnButtonPrintClicked (object sender, EventArgs e)
		{
			if (UoWGeneric.HasChanges && CommonDialogs.SaveBeforePrint (typeof(Expense), "квитанции"))
				Save ();

			var reportInfo = new QS.Report.ReportInfo {
				Title = String.Format ("Квитанция №{0} от {1:d}", Entity.Id, Entity.Date),
				Identifier = "Cash.Expense",
				Parameters = new Dictionary<string, object> {
					{ "id",  Entity.Id }
				}
			};
				
			var report = new QSReport.ReportViewDlg (reportInfo);
			TabParent.AddTab (report, this, false);
		}

		protected void OnYspinMoneyFocusInEvent(object o, Gtk.FocusInEventArgs args)
		{
			if(yspinMoney.ValueAsDecimal == Decimal.Zero)
				yspinMoney.Text = "";
		}
	}
}

