﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gamma.ColumnConfig;
using Gamma.Utilities;
using NHibernate.Criterion;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QSOrmProject.RepresentationModel;
using Vodovoz.Additions.Store;
using Vodovoz.Domain.Documents;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Orders;
using Vodovoz.Filters.ViewModels;
using Vodovoz.Infrastructure.Permissions;

namespace Vodovoz.ViewModel
{
	public class ReadyForReceptionVM : RepresentationModelWithoutEntityBase<ReadyForReceptionVMNode>
	{
		public ReadyForReceptionVM() : this(UnitOfWorkFactory.CreateWithoutRoot()) { }

		public ReadyForReceptionVM(IUnitOfWork uow) : base(typeof(RouteList), typeof(Domain.Orders.Order))
		{
			this.UoW = uow;
            var warehousesList = StoreDocumentHelper.GetRestrictedWarehousesList(UoW, WarehousePermissions.WarehouseView);
            Filter = new WarehouseJournalFilterViewModel
            {
                Warehouses = warehousesList,
                WarehousesAmount = warehousesList.Count(),
                RestrictWarehouse = CurrentUserSettings.Settings.DefaultWarehouse ?? null
            };
        }

        public WarehouseJournalFilterViewModel Filter { get; }

        #region implemented abstract members of RepresentationModelBase

        public override void UpdateNodes()
		{
			Domain.Orders.Order orderAlias = null;
			OrderItem orderItemsAlias = null;
			OrderEquipment orderEquipmentAlias = null;
			Equipment equipmentAlias = null;
			CarUnloadDocument carUnloadDocAlias = null;
			Nomenclature orderItemNomenclatureAlias = null, orderEquipmentNomenclatureAlias = null, orderNewEquipmentNomenclatureAlias = null;

			RouteList routeListAlias = null;
			RouteListItem routeListAddressAlias = null;
			ReadyForReceptionVMNode resultAlias = null;
			Employee employeeAlias = null;
			Car carAlias = null;

			List<ReadyForReceptionVMNode> items = new List<ReadyForReceptionVMNode>();

			var orderitemsSubqury = QueryOver.Of<OrderItem>(() => orderItemsAlias)
				.Where(() => orderItemsAlias.Order.Id == orderAlias.Id)
				.JoinAlias(() => orderItemsAlias.Nomenclature, () => orderItemNomenclatureAlias)
				.Select(i => i.Order);

			var orderEquipmentSubquery = QueryOver.Of<OrderEquipment>(() => orderEquipmentAlias)
				.Where(() => orderEquipmentAlias.Order.Id == orderAlias.Id)
				.JoinAlias(() => orderEquipmentAlias.Equipment, () => equipmentAlias, NHibernate.SqlCommand.JoinType.LeftOuterJoin)
				.JoinAlias(() => equipmentAlias.Nomenclature, () => orderEquipmentNomenclatureAlias, NHibernate.SqlCommand.JoinType.LeftOuterJoin)
				.JoinAlias(() => orderEquipmentAlias.Nomenclature, () => orderNewEquipmentNomenclatureAlias, NHibernate.SqlCommand.JoinType.LeftOuterJoin)
				.Select(i => i.Order);

			var queryRoutes = UoW.Session.QueryOver<RouteList>(() => routeListAlias)
				.JoinAlias(rl => rl.Driver, () => employeeAlias)
				.JoinAlias(rl => rl.Car, () => carAlias)
				.Where(r => routeListAlias.Status == RouteListStatus.OnClosing 
						 || routeListAlias.Status == RouteListStatus.MileageCheck
						 || routeListAlias.Status == RouteListStatus.Delivered);

			if(Filter.RestrictWarehouse != null) {
				queryRoutes.JoinAlias(rl => rl.Addresses, () => routeListAddressAlias)
					.JoinAlias(() => routeListAddressAlias.Order, () => orderAlias)
					.Where(new Disjunction()
						.Add(Subqueries.WhereExists(orderitemsSubqury))
						.Add(Subqueries.WhereExists(orderEquipmentSubquery))
					);
			}

			if(Filter.RestrictWithoutUnload == true) {
				var HasUnload = QueryOver.Of<CarUnloadDocument>(() => carUnloadDocAlias)
					.Where(() => carUnloadDocAlias.RouteList.Id == routeListAlias.Id)
					.Select(i => i.RouteList);

				queryRoutes.WithSubquery.WhereNotExists(HasUnload);
			}

			items.AddRange(
				queryRoutes.SelectList(list => list
				   .SelectGroup(() => routeListAlias.Id).WithAlias(() => resultAlias.Id)
				   .Select(() => employeeAlias.Name).WithAlias(() => resultAlias.Name)
				   .Select(() => employeeAlias.LastName).WithAlias(() => resultAlias.LastName)
				   .Select(() => employeeAlias.Patronymic).WithAlias(() => resultAlias.Patronymic)
				   .Select(() => carAlias.RegistrationNumber).WithAlias(() => resultAlias.Car)
				   .Select(() => routeListAlias.Date).WithAlias(() => resultAlias.Date)
				   .Select(() => routeListAlias.Status).WithAlias(() => resultAlias.Status)
				)
				.OrderBy(x => x.Date).Desc
				.TransformUsing(Transformers.AliasToBean<ReadyForReceptionVMNode>())
				.List<ReadyForReceptionVMNode>());

			SetItemsSource(items);
		}

		IColumnsConfig columnsConfig = FluentColumnsConfig<ReadyForReceptionVMNode>.Create()
			.AddColumn("Маршрутный лист").AddTextRenderer(node => node.Id.ToString())
			.AddColumn("Водитель").AddTextRenderer(node => node.Driver)
			.AddColumn("Машина").AddTextRenderer(node => node.Car)
			.AddColumn("Дата").AddTextRenderer(node => node.Date.ToShortDateString())
			.AddColumn("Статус МЛ").SetDataProperty(node => node.Status.GetEnumTitle())
			.Finish();

		public override IColumnsConfig ColumnsConfig => columnsConfig;

		protected override bool NeedUpdateFunc(object updatedSubject) => true;

		#endregion
	}

	public class ReadyForReceptionVMNode
	{
		[UseForSearch]
		[SearchHighlight]
		public int Id { get; set; }

		public string Name { get; set; }

		public string LastName { get; set; }

		public RouteListStatus Status { get; set; }

		public string Patronymic { get; set; }

		[UseForSearch]
		[SearchHighlight]
		public string Driver => String.Format("{0} {1} {2}", LastName, Name, Patronymic);

		[UseForSearch]
		[SearchHighlight]
		public string Car { get; set; }

		public DateTime Date { get; set; }
	}
}