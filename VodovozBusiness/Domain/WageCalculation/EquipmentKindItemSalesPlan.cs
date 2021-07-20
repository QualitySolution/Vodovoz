﻿using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using QS.HistoryLog;
using System.ComponentModel.DataAnnotations;

namespace Vodovoz.Domain.WageCalculation
{
	[Appellative(Gender = GrammaticalGender.Masculine,
		NominativePlural = "планы продаж видов оборудования",
		Nominative = "план продаж вида оборудования")]
	[HistoryTrace]
	[EntityPermission]
	public class EquipmentKindItemSalesPlan : SalesPlanItem
	{
		private EquipmentKind _equipmentKind;
		
		[Display(Name = "Вид оборудования")]
		public virtual EquipmentKind EquipmentKind
		{
			get => _equipmentKind;
			set => SetField(ref _equipmentKind, value);
		}
	}
}