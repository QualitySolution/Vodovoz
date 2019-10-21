﻿using QS.Project.Domain;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Domain.WageCalculation;

namespace Vodovoz.ViewModels.WageCalculation
{
	public class WageDistrictViewModel : EntityTabViewModelBase<WageDistrict>
	{
		public WageDistrictViewModel(IEntityUoWBuilder ctorParam, ICommonServices commonServices) : base(ctorParam, commonServices)
		{
		}
	}
}
