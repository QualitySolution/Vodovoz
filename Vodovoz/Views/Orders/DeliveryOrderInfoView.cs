﻿using Autofac;
using QS.Views.GtkUI;
using QS.Views.Resolve;
using Vodovoz.ViewModels.ViewModels.Orders;

namespace Vodovoz.Views.Orders
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class DeliveryOrderInfoView : WidgetViewBase<DeliveryOrderInfoViewModel>
    {
        public DeliveryOrderInfoView(DeliveryOrderInfoViewModel viewModel) : base(viewModel)
        {
            this.Build();
            Configure();
        }

        private void Configure()
        {
            CreateOrderItemsView();
            CreateDeliveryOrderInfoPanelView();
        }

        private void CreateOrderItemsView()
        {
            var orderItemsView = ViewModel.AutofacScope.Resolve<IGtkViewResolver>()
                .Resolve(ViewModel.OrderItemsViewModel);

            hboxOrderItems.Add(orderItemsView);
            orderItemsView.Show();
        }

        private void CreateDeliveryOrderInfoPanelView()
        {
            var orderInfoPanelView = ViewModel.AutofacScope.Resolve<IGtkViewResolver>()
                .Resolve(ViewModel.DeliveryOrderInfoPanelViewModel);

            orderInfoExpandedPanelView.ViewModel = ViewModel.ExpandedPanelViewModel;
            orderInfoExpandedPanelView.AddPanel(orderInfoPanelView);
        }
    }
}
