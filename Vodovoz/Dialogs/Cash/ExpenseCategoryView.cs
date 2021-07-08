﻿using QS.DomainModel.UoW;
using QS.Project.Journal.EntitySelector;
using QS.Project.Services;
using QS.ViewModels;
using QS.Views.GtkUI;
using Vodovoz.Domain.Cash;
using Vodovoz.Domain.Employees;
using Vodovoz.Filters.ViewModels;
using Vodovoz.FilterViewModels.Organization;
using Vodovoz.Journals.JournalActionsViewModels;
using Vodovoz.Journals.JournalViewModels.Organization;
using Vodovoz.JournalViewModels;
using Vodovoz.ViewModels.ViewModels.Cash;

namespace Vodovoz.Dialogs.Cash
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ExpenseCategoryView : TabViewBase<ExpenseCategoryViewModel>
	{
		public ExpenseCategoryView(ExpenseCategoryViewModel viewModel) : base(viewModel)
		{
			this.Build();
			ConfigureDlg();
		}
		
		private void ConfigureDlg()
		{
			yentryName.Binding
				.AddBinding(ViewModel.Entity, e => e.Name, (widget) => widget.Text)
				.InitializeFromSource();
			
			yentryNumbering.Binding
				.AddBinding(ViewModel.Entity, e => e.Numbering, (widget) => widget.Text)
				.InitializeFromSource();
			
			#region ParentEntityviewmodelentry
			ParentEntityviewmodelentry.SetEntityAutocompleteSelectorFactory(ViewModel.ExpenseCategoryAutocompleteSelectorFactory);
			ParentEntityviewmodelentry.Binding.AddBinding(ViewModel.Entity, s => s.Parent, w => w.Subject).InitializeFromSource();
			ParentEntityviewmodelentry.CanEditReference = true;
			#endregion
			
			
			#region SubdivisionEntityviewmodelentry
			//Это создается тут, а не в ExpenseCategoryViewModel потому что EmployeesJournalViewModel и EmployeeFilterViewModel нет в ViewModels
			var employeeSelectorFactory =
				new EntityAutocompleteSelectorFactory<EmployeesJournalViewModel>(typeof(Employee),
					() =>
					{
						var employeeFilter = new EmployeeFilterViewModel();

						var employeesJournalActions =
							new EmployeesJournalActionsViewModel(ServicesConfig.InteractiveService, UnitOfWorkFactory.GetDefaultFactory);

						return new EmployeesJournalViewModel(
							employeesJournalActions,
							employeeFilter,
							UnitOfWorkFactory.GetDefaultFactory,
							ServicesConfig.CommonServices);
					});
			
			var filter = new SubdivisionFilterViewModel(){ SubdivisionType = SubdivisionType.Default };
			var journalActions = new EntitiesJournalActionsViewModel(ServicesConfig.InteractiveService);
			SubdivisionEntityviewmodelentry.SetEntityAutocompleteSelectorFactory(
				new EntityAutocompleteSelectorFactory<SubdivisionsJournalViewModel>(typeof(Subdivision), () => {
					return new SubdivisionsJournalViewModel(
						journalActions,
						filter,
						UnitOfWorkFactory.GetDefaultFactory,
						ServicesConfig.CommonServices,
						employeeSelectorFactory
					);
				})
			);
			SubdivisionEntityviewmodelentry.Binding.AddBinding(ViewModel.Entity, s => s.Subdivision, w => w.Subject).InitializeFromSource();
			#endregion

			ycheckArchived.Binding.AddBinding(ViewModel, e => e.IsArchive, w => w.Active).InitializeFromSource();
			
			

			yenumTypeDocument.ItemsEnum = typeof(ExpenseInvoiceDocumentType);
			yenumTypeDocument.Binding.AddBinding(ViewModel.Entity, e => e.ExpenseDocumentType, w => w.SelectedItem).InitializeFromSource();

			buttonSave.Clicked += (sender, e) => { ViewModel.SaveAndClose(); };
			buttonCancel.Clicked += (sender, e) => { ViewModel.Close(true, QS.Navigation.CloseSource.Cancel); };
		}
	}
}
