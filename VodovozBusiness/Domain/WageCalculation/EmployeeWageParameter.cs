using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Gamma.Utilities;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using QS.HistoryLog;
using Vodovoz.Domain.Employees;

namespace Vodovoz.Domain.WageCalculation
{
	[Appellative(
		Gender = GrammaticalGender.Masculine,
		NominativePlural = "параметры расчёта зарплаты",
		Nominative = "параметр расчёта зарплаты",
		Accusative = "параметра расчёта зарплаты",
		Genitive = "параметра расчёта зарплаты"
	)]
	[HistoryTrace]
	[EntityPermission]
	public class EmployeeWageParameter : WageParameter
	{
		public override string Title => WageParameterItem.Title;
		
		private Employee employee;
		[Display(Name = "Сотрудник")]
		public virtual Employee Employee {
			get => employee;
			set => SetField(ref employee, value);
		}

		private WageParameterItem wageParameterItem;
		public virtual WageParameterItem WageParameterItem {
			get => wageParameterItem;
			set => SetField(ref wageParameterItem, value);
		}

		private WageParameterItem driverWithOurCarsWageParameterItem;
		public virtual WageParameterItem DriverWithOurCarsWageParameterItem {
			get => driverWithOurCarsWageParameterItem;
			set => SetField(ref driverWithOurCarsWageParameterItem, value);
		}
		
		public virtual void CreateWageParameterItems(WageParameterItemTypes wageParameterItemType)
		{
			DriverWithOurCarsWageParameterItem = null;

			WageParameterItem = CreateCreateWageParameterItem(wageParameterItemType);

			var typesWithoutOurCarsItems = new WageParameterItemTypes[] { WageParameterItemTypes.Manual, WageParameterItemTypes.OldRates, WageParameterItemTypes.SalesPlan };
			if(Employee.Category == EmployeeCategory.driver && !typesWithoutOurCarsItems.Contains(wageParameterItemType)) {
				DriverWithOurCarsWageParameterItem = CreateCreateWageParameterItem(wageParameterItemType);
			}
		}

		private WageParameterItem CreateCreateWageParameterItem(WageParameterItemTypes wageParameterItemType)
		{
			switch(wageParameterItemType) {
				case WageParameterItemTypes.Manual:
					return new ManualWageParameterItem();
				case WageParameterItemTypes.OldRates:
					return new OldRatesWageParameterItem();
				case WageParameterItemTypes.Fixed:
					return new FixedWageParameterItem();
				case WageParameterItemTypes.Percent:
					return new PercentWageParameterItem();
				case WageParameterItemTypes.RatesLevel:
					return new RatesLevelWageParameterItem();
				case WageParameterItemTypes.SalesPlan:
					return new SalesPlanWageParameterItem();
				default:
					throw new NotImplementedException($"Не описано какой параметер должен создаваться для типа {wageParameterItemType.GetEnumTitle()}");
			}
		}
	}
}