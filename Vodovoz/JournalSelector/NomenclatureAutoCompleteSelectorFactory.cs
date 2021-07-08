﻿using System;
using QS.DomainModel.UoW;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Services;
using QS.ViewModels;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.FilterViewModels.Goods;

namespace Vodovoz.JournalSelector
{
	public class NomenclatureAutoCompleteSelectorFactory<Nomenclature, NomenclaturesJournalViewModel> :
			NomenclatureSelectorFactory<Nomenclature, NomenclaturesJournalViewModel>, IEntityAutocompleteSelectorFactory
		where NomenclaturesJournalViewModel : JournalViewModelBase, IEntityAutocompleteSelector
	{
		public NomenclatureAutoCompleteSelectorFactory(
			ICommonServices commonServices, 
			NomenclatureFilterViewModel filterViewModel,
			EntitiesJournalActionsViewModel journalActionsViewModel,
			IEntityAutocompleteSelectorFactory counterpartySelectorFactory,
			INomenclatureRepository nomenclatureRepository,
			IUserRepository userRepository) 
			: base(commonServices, filterViewModel, journalActionsViewModel, counterpartySelectorFactory, nomenclatureRepository,
				userRepository) { }

		public IEntityAutocompleteSelector CreateAutocompleteSelector(bool multipleSelect = false)
		{
			NomenclaturesJournalViewModel selectorViewModel = (NomenclaturesJournalViewModel)Activator
			.CreateInstance(typeof(NomenclaturesJournalViewModel), new object[] { journalActionsViewModel, filter, 
				UnitOfWorkFactory.GetDefaultFactory, commonServices, VodovozGtkServicesConfig.EmployeeService, 
				this, counterpartySelectorFactory, nomenclatureRepository, userRepository});
			
			selectorViewModel.SelectionMode = JournalSelectionMode.Single;
			return selectorViewModel;
		}
	}
}
