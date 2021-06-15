﻿using DriverAPI.Library.Models;
using System;
using System.Collections.Generic;

namespace DriverAPI.Library.DataAccess
{
	public interface IAPIRouteListData
	{
		RouteListDto Get(int routeListId);
		IEnumerable<RouteListDto> Get(int[] routeListsIds);
		IEnumerable<int> GetRouteListsIdsForDriverByAndroidLogin(string login);
		void RegisterCoordinateForRouteListItem(int routeListAddressId, decimal latitude, decimal longitude, DateTime actionTime);
		string GetActualDriverPushNotificationsTokenByOrderId(int orderId);
	}
}