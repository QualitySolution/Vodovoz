﻿using System;
using System.ComponentModel.DataAnnotations;
using QS.DomainModel.Entity;
using QS.HistoryLog;

namespace Vodovoz.Domain.WageCalculation.AdvancedWageParameters
{
	[Appellative(
		Gender = GrammaticalGender.Masculine,
		Nominative = "Дополнительный параметр расчета зарплаты по кол-ву бутылей в заказе"
	)]
	[HistoryTrace]
	public class BottlesCountAdvancedWageParameter : AdvancedWageParameter
	{
		public override AdvancedWageParameterType AdvancedWageParameterType { get => AdvancedWageParameterType.BottlesCount; set { } }

		private int bottlesFrom;
		[Display(Name = "От")]
		public virtual int BottlesFrom {
			get => bottlesFrom;
			set => SetField(ref bottlesFrom, value);
		}

		private ComparisonSings leftSing;
		[Display(Name = "Левый знак сравнения")]
		public virtual ComparisonSings LeftSing {
			get => leftSing;
			set => SetField(ref leftSing, value);
		}

		private ComparisonSings rightSing;
		[Display(Name = "Правый знак сравнения")]
		public virtual ComparisonSings RightSing {
			get => rightSing;
			set => SetField(ref rightSing, value);
		}


		private int? bottlesTo;
		[Display(Name = "До")]
		public virtual int? BottlesTo {
			get => bottlesTo;
			set => SetField(ref bottlesTo, value);
		}

		public override string Name => this.ToString();

		public override bool HasConflicWith(IAdvancedWageParameter advancedWageParameter)
		{
			if(!(advancedWageParameter is BottlesCountAdvancedWageParameter))
				throw new ArgumentException();

			var wageParam = advancedWageParameter as BottlesCountAdvancedWageParameter;

			//if(wageParam.BottlesFrom>= BottlesFrom && wageParam.BottlesFrom <= BottlesFrom)
			//	return true;

			//if(wageParam.Bott >= StartTime && wageParam.EndTime <= EndTime)
			//	return true;

			//if(StartTime >= wageParam.StartTime && StartTime <= wageParam.EndTime)
				//return true;

			//if(EndTime >= wageParam.StartTime && EndTime <= wageParam.EndTime)
				//return true;

			return false;
		}

		public override string ToString()
		{
			return "aaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAA";
		}
	}

	public enum ComparisonSings
	{
		Equally,
		Less,
		LessOrEqual,
		More,
		MoreOrEqual
	}

	public class ComparisonSingStringType : NHibernate.Type.EnumStringType
	{
		public ComparisonSingStringType() : base(typeof(ComparisonSings))
		{
		}
	}
}
