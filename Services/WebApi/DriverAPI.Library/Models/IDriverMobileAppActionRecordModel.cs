﻿using DriverAPI.Library.DTOs;
using System.Collections.Generic;
using Vodovoz.Domain.Employees;

namespace DriverAPI.Library.Models
{
	public interface IDriverMobileAppActionRecordModel
	{
		void RegisterAction(Employee driver, DriverActionDto driverAction);
		void RegisterActionsRangeForDriver(Employee driver, IEnumerable<DriverActionDto> driverActionModels);
	}
}