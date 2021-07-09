using System.Linq;
using QS.Dialog;
using QS.DomainModel.UoW;
using QSOrmProject.RepresentationModel;
using Vodovoz.Additions.Store;
using Vodovoz.Domain.Permissions.Warehouse;
using Vodovoz.Domain.Store;
using Vodovoz.TempAdapters;

namespace Vodovoz
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ReadyForShipmentFilter : RepresentationFilterBase<ReadyForShipmentFilter>, ISingleUoWDialog
	{
        public Warehouse RestrictWarehouse { get; set; }

        protected override void ConfigureWithUow()
        {
	        var storeDocument = new StoreDocumentHelper();
            var warehousesList = storeDocument.GetRestrictedWarehousesList(UoW, new[] { WarehousePermissions.WarehouseView })
                                    .OrderBy(w => w.Name).ToList();
            if (warehousesList.Count > 5)
            {
                entryWarehouses.Subject = CurrentUserSettings.Settings.DefaultWarehouse ?? null;
                entryWarehouses.SetEntityAutocompleteSelectorFactory(new WarehouseSelectorFactory());

                entryWarehouses.Visible = true;
                yspeccomboWarehouse.Visible = false;
            }
            else
            {
                yspeccomboWarehouse.ItemsList = warehousesList;
                yspeccomboWarehouse.SelectedItem = CurrentUserSettings.Settings.DefaultWarehouse ?? null;

                entryWarehouses.Visible = false;
                yspeccomboWarehouse.Visible = true;
            }
		}

		public ReadyForShipmentFilter(IUnitOfWork uow) : this()
		{
			UoW = uow;
		}

		public ReadyForShipmentFilter()
		{
			this.Build();
		}

		void UpdateCreteria()
		{
			OnRefiltered();
		}

		protected void OnYspeccomboWarehouseItemSelected(object sender, Gamma.Widgets.ItemSelectedEventArgs e)
		{
            RestrictWarehouse = e.SelectedItem as Warehouse;
            UpdateCreteria();
		}

        protected void OnEntryWarehousesChangedByUser(object sender, System.EventArgs e)
        {
            RestrictWarehouse = entryWarehouses.Subject as Warehouse;
            UpdateCreteria();
        }
    }
}

