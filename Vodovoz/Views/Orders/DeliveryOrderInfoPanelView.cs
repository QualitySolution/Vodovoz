﻿using QS.DomainModel.UoW;
using QS.ViewModels.Control.EEVM;
using QS.Views.GtkUI;
using Vodovoz.Domain.Orders;
using Vodovoz.JournalViewModels;
using Vodovoz.ViewModels.Dialogs.Orders;

namespace Vodovoz.Views.Orders
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class DeliveryOrderInfoPanelView : WidgetViewBase<DeliveryOrderInfoPanelViewModel>
    {
        public DeliveryOrderInfoPanelView(DeliveryOrderInfoPanelViewModel viewModel) : base(viewModel)
        {
            this.Build();
            Configure();
        }

        private void Configure()
        {
            var counterpatryBuilder =
                new CommonEEVMBuilderFactory<DeliveryOrder>(ViewModel.ParentTab, ViewModel.Order,
                    UnitOfWorkFactory.CreateWithoutRoot(), MainClass.MainWin.NavigationManager, ViewModel.AutofacScope);

            var counterpartyViewModel = counterpatryBuilder.ForProperty(x => x.Counterparty)
                .UseViewModelJournalAndAutocompleter<CounterpartyJournalViewModel>()
                .Finish();

            counterpartyEntry.ViewModel = counterpartyViewModel;
            
            var deliveryPointBuilder =
                new CommonEEVMBuilderFactory<DeliveryOrder>(ViewModel.ParentTab, ViewModel.Order,
                    UnitOfWorkFactory.CreateWithoutRoot(), MainClass.MainWin.NavigationManager, ViewModel.AutofacScope);

            var deliveryPointViewModel = deliveryPointBuilder.ForProperty(x => x.DeliveryPoint)
                .UseViewModelJournalAndAutocompleter<DeliveryPointJournalViewModel>()
                .Finish();

            deliveryPointEntry.ViewModel = deliveryPointViewModel;
        }
    }
}