﻿using DriverAPI.Library.DTOs;
using System.Collections.Generic;

namespace DriverAPI.Library.DataAccess
{
	public interface IAPIDriverComplaintData
	{
		IEnumerable<DriverComplaintReasonDto> GetPinnedComplaintReasons();
	}
}