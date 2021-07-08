﻿using System;
using System.Collections.Generic;
using System.Data.Bindings.Collections.Generic;
using System.Linq;
using QS.Commands;
using QS.DomainModel.UoW;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Project.Services;
using QS.Services;
using QS.Tdi;
using QS.ViewModels;
using Vodovoz.Domain.Complaints;
using Vodovoz.FilterViewModels.Organization;
using Vodovoz.Infrastructure.Services;
using Vodovoz.Journals.JournalViewModels.Organization;

namespace Vodovoz.ViewModels.Complaints
{
	public class ComplaintDiscussionsViewModel : EntityWidgetViewModelBase<Complaint>
	{
		private readonly ITdiTab dialogTab;
		private readonly IFilePickerService filePickerService;
		private readonly IEmployeeService employeeService;
		readonly IEntityAutocompleteSelectorFactory employeeSelectorFactory;

		public ComplaintDiscussionsViewModel(
			Complaint entity, 
			ITdiTab dialogTab,
			IUnitOfWork uow,
			IFilePickerService filePickerService,
			IEmployeeService employeeService,
			ICommonServices commonServices,
			IEntityAutocompleteSelectorFactory employeeSelectorFactory
		) : base(entity, commonServices)
		{
			this.employeeSelectorFactory = employeeSelectorFactory ?? throw new ArgumentNullException(nameof(employeeSelectorFactory));
			this.filePickerService = filePickerService ?? throw new ArgumentNullException(nameof(filePickerService));
			this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
			this.dialogTab = dialogTab ?? throw new ArgumentNullException(nameof(dialogTab));

			UoW = uow;
			CreateCommands();
			ConfigureEntityPropertyChanges();
			FillDiscussionsViewModels();
		}

		public bool CanEdit => PermissionResult.CanUpdate;

		private Dictionary<int, ComplaintDiscussionViewModel> viewModelsCache = new Dictionary<int, ComplaintDiscussionViewModel>();

		private void ConfigureEntityPropertyChanges()
		{
			Entity.ObservableComplaintDiscussions.ElementAdded += ObservableComplaintDiscussions_ElementAdded;
			Entity.ObservableComplaintDiscussions.ElementRemoved += ObservableComplaintDiscussions_ElementRemoved;
		}

		void ObservableComplaintDiscussions_ElementAdded(object aList, int[] aIdx)
		{
			FillDiscussionsViewModels();
		}

		void ObservableComplaintDiscussions_ElementRemoved(object aList, int[] aIdx, object aObject)
		{
			FillDiscussionsViewModels();
		}

		private void FillDiscussionsViewModels()
		{
			foreach(ComplaintDiscussion discussion in Entity.ObservableComplaintDiscussions) {
				var discussionViewModel = GetDiscussionViewModel(discussion);
				if(!ObservableComplaintDiscussionViewModels.Contains(discussionViewModel)) {
					ObservableComplaintDiscussionViewModels.Add(discussionViewModel);
				}
			}
		}

		private ComplaintDiscussionViewModel GetDiscussionViewModel(ComplaintDiscussion complaintDiscussion)
		{
			int subdivisionId = complaintDiscussion.Subdivision.Id;
			if(viewModelsCache.ContainsKey(subdivisionId)) {
				return viewModelsCache[subdivisionId];
			}
			var viewModel = new ComplaintDiscussionViewModel(complaintDiscussion, filePickerService, employeeService, CommonServices, UoW);
			viewModelsCache.Add(subdivisionId, viewModel);
			return viewModel;
		}

		GenericObservableList<ComplaintDiscussionViewModel> observableComplaintDiscussionViewModels = new GenericObservableList<ComplaintDiscussionViewModel>();

		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<ComplaintDiscussionViewModel> ObservableComplaintDiscussionViewModels {
			get => observableComplaintDiscussionViewModels;
			set => SetField(ref observableComplaintDiscussionViewModels, value, () => ObservableComplaintDiscussionViewModels);
		}

		#region Commands

		private void CreateCommands()
		{
			CreateAttachSubdivisionCommand();
		}

		#region AttachSubdivisionCommand

		public bool CanAttachSubdivision => CanEdit;

		public DelegateCommand AttachSubdivisionCommand { get; private set; }

		private void CreateAttachSubdivisionCommand()
		{
			AttachSubdivisionCommand = new DelegateCommand(
				() => {
					var filter = new SubdivisionFilterViewModel();
					filter.ExcludedSubdivisions = Entity.ObservableComplaintDiscussions.Select(x => x.Subdivision.Id).ToArray();
					var journalActions = new EntitiesJournalActionsViewModel(CommonServices.InteractiveService);
					var subdivisionSelector = new SubdivisionsJournalViewModel(
						journalActions,
						filter,
						UnitOfWorkFactory.GetDefaultFactory,
						CommonServices,
						employeeSelectorFactory
					) {
						SelectionMode = JournalSelectionMode.Single
					};
					subdivisionSelector.OnEntitySelectedResult += (sender, e) => {
						var selectedNode = e.SelectedNodes.FirstOrDefault();
						if(selectedNode == null) {
							return;
						}
						Subdivision subdivision = UoW.GetById<Subdivision>(selectedNode.Id);
						Entity.AttachSubdivisionToDiscussions(subdivision);
					};
					dialogTab.TabParent.AddSlaveTab(dialogTab, subdivisionSelector);
				},
				() => CanAttachSubdivision
			);
			AttachSubdivisionCommand.CanExecuteChangedWith(this, x => x.CanAttachSubdivision);
		}

		#endregion AttachSubdivisionCommand

		#endregion Commands
	}
}
