﻿using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;

namespace Vodovoz.Domain.Employees
{
	[Appellative(Gender = GrammaticalGender.Masculine,
		NominativePlural = "стажеры",
		Nominative = "стажер")]
	[EntityPermission]
	public class Trainee : Personnel, ITrainee
	{
		public override EmployeeType EmployeeType {
			get { return EmployeeType.Trainee; }
			set {}
		}
	}

	public interface ITrainee : IPersonnel
	{
		
	}
}
