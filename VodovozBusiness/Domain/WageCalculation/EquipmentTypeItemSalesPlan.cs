﻿using System.ComponentModel.DataAnnotations;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using QS.HistoryLog;

namespace Vodovoz.Domain.WageCalculation
{
	[Appellative(Gender = GrammaticalGender.Masculine,
		NominativePlural = "планы продаж типов оборудования",
		Nominative = "план продаж типа оборудования")]
	[HistoryTrace]
	[EntityPermission]
	public class EquipmentTypeItemSalesPlan : SalesPlanItem
	{
		private EquipmentType _equipmentType;

		[Display(Name = "Тип оборудования")]
		public virtual EquipmentType EquipmentType
		{
			get => _equipmentType;
			set => SetField(ref _equipmentType, value);
		}
	}
}