using FluentNHibernate.Mapping;
using Vodovoz.Domain.Orders.OrdersWithoutShipment;

namespace Vodovoz.HibernateMapping.Order.OrdersWithoutShipment
{
    public class OrderWithoutShipmentForDebtMap : ClassMap<OrderWithoutShipmentForDebt>
    {
        public OrderWithoutShipmentForDebtMap()
        {
            Table("orders_without_delivery_for_debt");

            Id(x => x.Id).Column("id").GeneratedBy.Native();
            Map(x => x.CreateDate).Column("create_date");
            Map(x => x.DebtName).Column("debt_name");
            Map(x => x.DebtSum).Column("debt_sum");
            
            References(x => x.Author).Column("author_id");
            References(x => x.Client).Column("client_id");
        }
    }
}