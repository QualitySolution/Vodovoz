﻿using FluentNHibernate.Mapping;
using Vodovoz.Domain.Orders;

namespace Vodovoz.HibernateMapping
{
	public class PaymentFromMap : ClassMap<PaymentFrom>
	{
		public PaymentFromMap()
		{
			Table("payments_from");
			Id(x => x.Id).Column("id").GeneratedBy.Native();
			Map(x => x.Name).Column("name");
		}
	}
}