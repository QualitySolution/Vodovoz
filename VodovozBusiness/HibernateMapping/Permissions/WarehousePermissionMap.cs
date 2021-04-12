using FluentNHibernate.Mapping;
using Vodovoz.Domain.Permissions.Warehouse;

namespace Vodovoz.HibernateMapping.Permissions
{
    public class WarehousePermissionMap: ClassMap<WarehousePermission>
    {
        public WarehousePermissionMap()
        {
            Table("warehouse_permissions");
            Not.LazyLoad();

            Id(x => x.Id).Column("id").GeneratedBy.Native();
            DiscriminateSubClassesOnColumn("type_permission");
            
            Map(x => x.ValuePermission).Column("value");
            References(x => x.Warehouse).Column("warehouse_id");
            References(x => x.WarehousePermissionType).Column("warehouse_permission_type");
        }
    }

    public class UserWarehousePermissionMap : SubclassMap<UserWarehousePermission>
    {
        public UserWarehousePermissionMap()
        {
            DiscriminatorValue("User");

            References(x => x.User).Column("user_id");
        }
    }

    public class SubdivisionWarehousePermissionMap : SubclassMap<SubdivisionWarehousePermission>
    {
        public SubdivisionWarehousePermissionMap()
        {
            DiscriminatorValue("Subdivision");

            References(x => x.Subdivision).Column("subdivision_id");
        }
    }
}