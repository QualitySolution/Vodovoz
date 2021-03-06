﻿using System.Collections.Generic;
using QS.DomainModel.UoW;
using QS.Project.Services;
using Vodovoz.Domain.Chats;
using Vodovoz.Domain.Employees;

namespace Vodovoz.Repository.Chats
{
	public static class ChatRepository
	{
		public static Chat GetChatForDriver(IUnitOfWork uow, Employee driver) {
			Chat chatAlias = null;

			return uow.Session.QueryOver<Chat> (() => chatAlias)
				.Where (() => chatAlias.ChatType == ChatType.DriverAndLogists)
				.Where (() => chatAlias.Driver.Id == driver.Id)
				.SingleOrDefault();
		}

		public static IList<Chat> GetCurrentUserChats(IUnitOfWork uow, Employee employee) {
			//employee пригодится в дальнейшем
			Chat chatAlias = null;

			if (ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("logistican")) {
				return uow.Session.QueryOver<Chat> (() => chatAlias)
				.Where (() => chatAlias.ChatType == ChatType.DriverAndLogists)
				.List ();
			} else
				return null;
		}
	}
}