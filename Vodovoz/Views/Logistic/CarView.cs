﻿using System;
using QS.Views.GtkUI;
using Vodovoz.ViewModels.ViewModels.Logistic;

namespace Vodovoz.Views.Logistic
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class CarView : TabViewBase<CarViewModel>
	{
		public CarView(CarViewModel viewModel) : base(viewModel)
		{
			Build();

			ConfigureDlg();
		}

		private void ConfigureDlg()
		{

		}
	}
}
