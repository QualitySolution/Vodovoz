﻿using System;
using QSOrmProject;
using QSReport;
using System.Collections.Generic;
using Vodovoz.Domain.Employees;

namespace Vodovoz.Reports
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class WagesOperationsReport: Gtk.Bin, IOrmDialog, IParametersWidget
	{
		public WagesOperationsReport()
		{
			this.Build();

			UoW = UnitOfWorkFactory.CreateWithoutRoot ();

			yentryreferenceEmployee.SubjectType = typeof(Employee);
			yentryreferenceEmployee.ItemsQuery = Repository.EmployeeRepository.ActiveEmployeeQuery();
		}

		#region IOrmDialog implementation

		public IUnitOfWork UoW { get; private set; }

		public object EntityObject {
			get {
				return null;
			}
		}

		#endregion

		#region IParametersWidget implementation

		public event EventHandler<LoadReportEventArgs> LoadReport;

		public string Title {
			get {
				return "Отчет по зарплатным операциям";
			}
		}

		private ReportInfo GetReportInfo()
		{			
			return new ReportInfo
			{
				Identifier = "Employees.WagesOperations",
				UseUserVariables = true,
				Parameters = new Dictionary<string, object>
				{ 
					{ "start_date", dateperiodpicker.StartDate },
					{ "end_date", dateperiodpicker.EndDate },
					{ "employee_id", ((Employee)yentryreferenceEmployee.Subject).Id }
				}
			};
		}

		void OnUpdate(bool hide = false)
		{
			if (LoadReport != null) {
				LoadReport(this, new LoadReportEventArgs(GetReportInfo(), hide));
			}
		}

		protected void OnButtonCreateReportClicked (object sender, EventArgs e)
		{
			OnUpdate(true);
		}
		#endregion
	}
}

