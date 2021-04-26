﻿using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using NHibernate.Transform;
using QS.Banks.Domain;
using QS.DomainModel.UoW;
using QS.Project.Services;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Logistic;

namespace Vodovoz.EntityRepositories.Employees
{
	public class EmployeeSingletonRepository : IEmployeeRepository
	{
		private static EmployeeSingletonRepository instance;

		[Obsolete("Необходимо избавляться от синглтонов")]
		public static EmployeeSingletonRepository GetInstance()
		{
			if(instance == null)
				instance = new EmployeeSingletonRepository();
			return instance;
		}

		public Employee GetEmployeeForCurrentUser(IUnitOfWork uow)
		{
			User userAlias = null;

			return uow.Session.QueryOver<Employee>()
				.JoinAlias(e => e.User, () => userAlias)
				.Where(() => userAlias.Id == ServicesConfig.UserService.CurrentUserId)
				.SingleOrDefault();
		}

		public Employee GetDriverByAuthKey(IUnitOfWork uow, string authKey)
		{
			Employee employeeAlias = null;

			return uow.Session.QueryOver<Employee>(() => employeeAlias)
				.Where(() => employeeAlias.AndroidSessionKey == authKey)
				.Where(() => employeeAlias.Status != EmployeeStatus.IsFired)
				.SingleOrDefault();
		}

		public Employee GetDriverByAndroidLogin(IUnitOfWork uow, string login)
		{
			return uow.Session.QueryOver<Employee>()
				.Where(e => e.AndroidLogin == login)
				.SingleOrDefault();
		}

		public IList<Employee> GetEmployeesForUser(IUnitOfWork uow, int userId)
		{
			User userAlias = null;

			return uow.Session.QueryOver<Employee>()
				.JoinAlias(e => e.User, () => userAlias)
				.Where(() => userAlias.Id == userId)
				.List();
		}

		public IList<Employee> GetWorkingDriversAtDay(IUnitOfWork uow, DateTime date)
		{
			Employee employeeAlias = null;
			DriverWorkScheduleSet driverWorkScheduleSetAlias = null;
			DriverWorkSchedule driverWorkScheduleAlias = null;
			DeliveryDaySchedule deliveryDayScheduleAlias = null;
			DeliveryShift shiftAlias = null;

			return uow.Session.QueryOver(() => employeeAlias)
				.Inner.JoinAlias(() => employeeAlias.DriverWorkScheduleSets, () => driverWorkScheduleSetAlias)
				.Inner.JoinAlias(() => driverWorkScheduleSetAlias.DriverWorkSchedules, () => driverWorkScheduleAlias)
				.Inner.JoinAlias(() => driverWorkScheduleAlias.DaySchedule, () => deliveryDayScheduleAlias)
				.Inner.JoinAlias(() => deliveryDayScheduleAlias.Shifts, () => shiftAlias)
				.Where(() =>
					employeeAlias.Status == EmployeeStatus.IsWorking
					&& (int)driverWorkScheduleAlias.WeekDay == (int)date.DayOfWeek
					&& driverWorkScheduleSetAlias.IsActive
				)
				.TransformUsing(Transformers.DistinctRootEntity)
				.List<Employee>();
		}

		public Employee GetEmployeeByINNAndAccount(IUnitOfWork uow, string inn, string account)
		{
			IList<Account> accountsAlias = null;
			var employees = uow.Session.QueryOver<Employee>()
				.JoinAlias(e => e.Accounts, () => accountsAlias)
				.Where(e => e.INN == inn)
				.List();
			return employees.FirstOrDefault(e => e.Accounts.Any(acc => acc.Number == account));
		}

		public IList<EmployeeWorkChart> GetWorkChartForEmployeeByDate(IUnitOfWork uow, Employee employee, DateTime date)
		{
			EmployeeWorkChart ewcAlias = null;

			return uow.Session.QueryOver<EmployeeWorkChart>(() => ewcAlias)
				.Where(() => ewcAlias.Employee.Id == employee.Id)
				.Where(() => ewcAlias.Date.Month == date.Month)
				.Where(() => ewcAlias.Date.Year == date.Year)
				.List();
		}

		public QueryOver<Employee> DriversQuery()
		{
			return QueryOver.Of<Employee>().Where(e => e.Category == EmployeeCategory.driver);
		}

		public QueryOver<Employee> OfficeWorkersQuery()
		{
			return QueryOver.Of<Employee>().Where(e => e.Category == EmployeeCategory.office);
		}

		public QueryOver<Employee> ForwarderQuery()
		{
			return QueryOver.Of<Employee>().Where(e => e.Category == EmployeeCategory.forwarder);
		}

		public QueryOver<Employee> ActiveEmployeeQuery()
		{
			return QueryOver.Of<Employee>().Where(e => e.Status != EmployeeStatus.IsFired);
		}

		public QueryOver<Employee> ActiveDriversOrderedQuery()
		{
			return QueryOver.Of<Employee>().Where(e => e.Category == EmployeeCategory.driver && e.Status != EmployeeStatus.IsFired)
							.OrderBy(e => e.LastName).Asc.ThenBy(e => e.Name).Asc.ThenBy(e => e.Patronymic).Asc;
		}

		public QueryOver<Employee> ActiveForwarderOrderedQuery()
		{
			return QueryOver.Of<Employee>().Where(e => e.Category == EmployeeCategory.forwarder && e.Status != EmployeeStatus.IsFired)
							.OrderBy(e => e.LastName).Asc.ThenBy(e => e.Name).Asc.ThenBy(e => e.Patronymic).Asc;
		}

		public QueryOver<Employee> ActiveEmployeeOrderedQuery()
		{
			return QueryOver.Of<Employee>().Where(e => e.Status != EmployeeStatus.IsFired).OrderBy(e => e.LastName).Asc.ThenBy(e => e.Name).Asc.ThenBy(e => e.Patronymic).Asc;
		}
	}
}
