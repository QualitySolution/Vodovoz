using System;
using QS.DomainModel.UoW;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Project.Services;
using QS.ViewModels;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Goods;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.Filters.ViewModels;
using Vodovoz.FilterViewModels.Goods;
using Vodovoz.Infrastructure.Services;
using Vodovoz.JournalSelector;
using Vodovoz.JournalViewModels;
using Vodovoz.Parameters;

namespace Vodovoz.TempAdapters
{
    public class WaterJournalFactory : IEntityAutocompleteSelectorFactory
    {
        public Type EntityType => typeof(Nomenclature);
        public IEntitySelector CreateSelector(bool multipleSelect = false)
        {
            return CreateAutocompleteSelector(multipleSelect);
        }

        public IEntityAutocompleteSelector CreateAutocompleteSelector(bool multipleSelect = false)
        {
	        NomenclatureFilterViewModel nomenclatureFilter = new NomenclatureFilterViewModel
	        {
		        RestrictCategory = NomenclatureCategory.fuel, RestrictArchive = false
	        };

	        var nomenclatureRepository = new NomenclatureRepository(new NomenclatureParametersProvider());
			
            var counterpartySelectorFactory =
                new DefaultEntityAutocompleteSelectorFactory<Counterparty, CounterpartyJournalViewModel, CounterpartyJournalFilterViewModel>(
                    ServicesConfig.CommonServices);
			
            var nomenclatureSelectorFactory =
                new NomenclatureAutoCompleteSelectorFactory<Nomenclature, NomenclaturesJournalViewModel>(ServicesConfig.CommonServices,
	                nomenclatureFilter, new EntitiesJournalActionsViewModel(ServicesConfig.InteractiveService),
	                counterpartySelectorFactory, nomenclatureRepository, UserSingletonRepository.GetInstance());
            
            var journalActions = new EntitiesJournalActionsViewModel(ServicesConfig.InteractiveService);

            WaterJournalViewModel waterJournal = new WaterJournalViewModel(
	            journalActions,
	            UnitOfWorkFactory.GetDefaultFactory,
	            ServicesConfig.CommonServices,
	            new EmployeeService(),
	            nomenclatureSelectorFactory,
	            counterpartySelectorFactory,
	            nomenclatureRepository,
	            UserSingletonRepository.GetInstance()
            )
            {
	            SelectionMode = multipleSelect ? JournalSelectionMode.Multiple : JournalSelectionMode.Single
            };

            return waterJournal;
        }
    }
}