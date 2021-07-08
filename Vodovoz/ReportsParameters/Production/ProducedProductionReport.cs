﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QS.Project.Journal.EntitySelector;
using QS.Project.Services;
using QS.Report;
using QS.ViewModels;
using QSReport;
using Vodovoz.CommonEnums;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Store;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.FilterViewModels.Goods;
using Vodovoz.Infrastructure.Services;
using Vodovoz.JournalViewModels;

namespace Vodovoz.ReportsParameters.Production
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ProducedProductionReport : SingleUoWWidgetBase, IParametersWidget
	{
		public ProducedProductionReport(
			IEntityAutocompleteSelectorFactory nomenclatureSelectorFactory,
			IEntityAutocompleteSelectorFactory counterpartySelectorFactory,
			INomenclatureRepository nomenclatureRepository)
		{
			this.Build();
			
			UoW = UnitOfWorkFactory.CreateWithoutRoot();
			yenumcomboboxMonths.ItemsEnum = typeof(Month);
			yenumcomboboxMonths.SelectedItem = (Month)(DateTime.Now.AddMonths(-1).Month);
			
            ylistcomboboxYear.ItemsList = Enumerable.Range(DateTime.Now.AddYears(-10).Year, 21).Reverse();
            ylistcomboboxYear.SelectedItem = DateTime.Today.Year;

            ycomboboxProduction.SetRenderTextFunc<Warehouse>(x => x.Name);
			ycomboboxProduction.ItemsList = UoW.Session.QueryOver<Warehouse>().Where(x => x.TypeOfUse == WarehouseUsing.Production).List();

			entryreferenceNomenclature.SetEntityAutocompleteSelectorFactory(
				new EntityAutocompleteSelectorFactory<NomenclaturesJournalViewModel>(typeof(Nomenclature),
					() =>
					{
						var nomenclatureFilter = new NomenclatureFilterViewModel();
						var journalActions = new EntitiesJournalActionsViewModel(ServicesConfig.InteractiveService);
							
						return new NomenclaturesJournalViewModel(
							journalActions,
							nomenclatureFilter,
							UnitOfWorkFactory.GetDefaultFactory,
							ServicesConfig.CommonServices,
							new EmployeeService(),
							nomenclatureSelectorFactory, 
							counterpartySelectorFactory,
							nomenclatureRepository,
							UserSingletonRepository.GetInstance()
							);
					})
			);
			buttonCreateReport.Sensitive = true;
			buttonCreateReport.Clicked += OnButtonCreateReportClicked;
		}
		
		void OnButtonCreateReportClicked (object sender, EventArgs e)
		{
			OnUpdate (true);
		}

		#region IParametersWidget implementation

		public string Title => "Отчет по произведенной продукции";

		public event EventHandler<LoadReportEventArgs> LoadReport;

		#endregion

		private ReportInfo GetReportInfo()
		{
			CultureInfo ci = new CultureInfo("ru-RU");
			DateTimeFormatInfo mfi = ci.DateTimeFormat;

            var monthNum = (int)yenumcomboboxMonths.SelectedItem;
			string strMonthName = mfi.GetMonthName(monthNum);

            var year = (int)ylistcomboboxYear.SelectedItem;
            var reportDate = new DateTime(year, monthNum, 1);

            var monthNumMinus1 = reportDate.AddMonths(-1).Month;
            string strMonthNameMinus1 = mfi.GetMonthName(monthNumMinus1);
			
			var monthNumMinus2 = reportDate.AddMonths(-2).Month;
			string strMonthNameMinus2 = mfi.GetMonthName(monthNumMinus2);

            return new ReportInfo {
				Identifier = "Production.ProducedProduction",
				Parameters = new Dictionary<string, object> {
					{ "month_start",         MonthStart(reportDate) },
					{ "month_end",             MonthEnd(reportDate) },
					{ "month_minus_1_start", MonthStart(reportDate.AddMonths(-1)) },
					{ "month_minus_1_end",     MonthEnd(reportDate.AddMonths(-1)) },
					{ "month_minus_2_start", MonthStart(reportDate.AddMonths(-2)) },
					{ "month_minus_2_end",     MonthEnd(reportDate.AddMonths(-2)) },
					{ "month_name",    strMonthName },
					{ "month_name_minus_1",  strMonthNameMinus1  },
					{ "month_name_minus_2",  strMonthNameMinus2  },
					
					{ "nomenclature_id", (entryreferenceNomenclature.Subject as Nomenclature)?.Id ?? -1},
					{ "warehouse_id", (ycomboboxProduction.SelectedItem as Warehouse)?.Id ?? -1 },
					{ "creation_date", DateTime.Now},
					
					{ "nomenclature_footer_name", (entryreferenceNomenclature.Subject as Nomenclature)?.Name ?? ""},
					{ "warehouse_footer_name", (ycomboboxProduction.SelectedItem as Warehouse)?.Name ?? "" },
					
				}
			};
		}

		void OnUpdate(bool hide = false) => LoadReport?.Invoke(this, new LoadReportEventArgs(GetReportInfo(), hide));

		private DateTime MonthStart(DateTime date)
		{
			return new DateTime(date.Year,date.Month, 1);
		}
		private DateTime MonthEnd(DateTime date)
		{
			return new DateTime(date.Year,date.Month, DateTime.DaysInMonth(date.Year,date.Month));
		}
	}
}
