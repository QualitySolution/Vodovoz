﻿using System;
using System.ComponentModel.DataAnnotations;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using Vodovoz.Domain.Logistic;

namespace Vodovoz.Domain.Employees
{
	[Appellative(Gender = GrammaticalGender.Feminine,
		NominativePlural = "автопремии для раскатных газелей",
		Nominative = "автопремия для раскатных газелей")]
	[EntityPermission]

	public class PremiumRaskatGAZelle : PremiumBase
	{
		RouteList routeList;
	}
}