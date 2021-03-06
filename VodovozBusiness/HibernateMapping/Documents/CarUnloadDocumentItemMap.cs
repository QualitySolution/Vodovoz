﻿using FluentNHibernate.Mapping;
using Vodovoz.Domain.Documents;

namespace Vodovoz.HibernateMapping
{
    public class CarUnloadDocumentItemMap : ClassMap<CarUnloadDocumentItem>
    {
        public CarUnloadDocumentItemMap()
        {
            Table("store_car_unload_document_items");

            Id(x => x.Id).Column("id").GeneratedBy.Native();

            Map(x => x.Redhead).Column("redhead");
            Map(x => x.ReciveType).Column("receive_type").CustomType<ReciveTypesStringType>();
            Map(x => x.DefectSource).Column("source").CustomType<DefectSourceStringType>();

            References(x => x.Document).Column("car_unload_document_id");
            References(x => x.WarehouseMovementOperation).Column("warehouse_movement_operation_id").Cascade.All();
            References(x => x.EmployeeNomenclatureMovementOperation).Column("employee_nomenclature_movement_operation_id").Cascade.All();
            References(x => x.ServiceClaim).Column("service_claim_id");
            References(x => x.TypeOfDefect).Column("defect_type_id");
        }
    }
}