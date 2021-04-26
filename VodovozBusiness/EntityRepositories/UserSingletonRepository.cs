﻿using System;
using System.IO;
using System.Linq;
using NHibernate;
using QS.DomainModel.UoW;
using QS.Project.Services;
using Vodovoz.Domain.Employees;

namespace Vodovoz.EntityRepositories
{
	public class UserSingletonRepository : IUserRepository
	{
		private static UserSingletonRepository instance;

		[Obsolete("Необходимо избавляться от синглтонов")]
		public static UserSingletonRepository GetInstance()
		{
			if(instance == null)
				instance = new UserSingletonRepository();
			return instance;
		}

		public User GetCurrentUser(IUnitOfWork uow)
		{
			return uow.Session.QueryOver<User>()
				.Where(u => u.Id == ServicesConfig.UserService.CurrentUserId)
				.SingleOrDefault();
		}

		public string GetTempDirForCurrentUser(IUnitOfWork uow)
		{
			var userId = GetCurrentUser(uow)?.Id;

			if(userId == null)
				return string.Empty;

			return Path.Combine(Path.GetTempPath(), "Vodovoz", userId.ToString());
		}

		/// <summary>
		/// По возможности не используйте напрямую этот метод, для получения настроек используйте класс CurrentUserSettings
		/// </summary>
		public UserSettings GetCurrentUserSettings(IUnitOfWork uow)
		{
			return GetUserSettings(uow, ServicesConfig.UserService.CurrentUserId);
		}

		public UserSettings GetUserSettings(IUnitOfWork uow, int userId)
		{
			return uow.Session.QueryOver<UserSettings>()
				.Where(s => s.User.Id == userId)
				.SingleOrDefault();
		}

		public User GetUserByLogin(IUnitOfWork uow, string login)
		{
			return uow.Session.QueryOver<User>()
				.Where(e => e.Login == login)
				.SingleOrDefault();
		}

		public bool MySQLUserWithLoginExists(IUnitOfWork uow, string login)
		{
			var query = $"SELECT COUNT(*) AS c from mysql.user WHERE USER = '{login}'";
			int count = uow.Session.CreateSQLQuery(query).AddScalar("c", NHibernateUtil.Int32).List<int>().FirstOrDefault();
			return count > 0;
		}
	}
}
