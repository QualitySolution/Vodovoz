﻿using System;
using QS.Project.Filter;
using QS.Project.Journal.EntitySelector;
using QS.Services;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Suppliers;

namespace Vodovoz.FilterViewModels.Suppliers
{
	public class RequestsToSuppliersFilterViewModel : FilterViewModelBase<RequestsToSuppliersFilterViewModel>
	{
		public IEntitySelectorFactory NomenclatureSelectorFactory { get; set; }

		public RequestsToSuppliersFilterViewModel(IEntitySelectorFactory nomenclatureSelectorFactory)
		{
			NomenclatureSelectorFactory = nomenclatureSelectorFactory ?? throw new ArgumentNullException(nameof(nomenclatureSelectorFactory));
		}

		private DateTime? restrictStartDate;
		public virtual DateTime? RestrictStartDate {
			get => restrictStartDate;
			set {
				if(UpdateFilterField(ref restrictStartDate, value))
					CanChangeStartDate = false;
			}
		}
		public bool CanChangeStartDate { get; private set; } = true;

		private DateTime? restrictEndDate;
		public virtual DateTime? RestrictEndDate {
			get => restrictEndDate;
			set {
				if(UpdateFilterField(ref restrictEndDate, value))
					CanChangeEndDate = false;
			}
		}
		public bool CanChangeEndDate { get; private set; } = true;

		Nomenclature restrictNomenclature;
		public virtual Nomenclature RestrictNomenclature {
			get => restrictNomenclature;
			set {
				if(UpdateFilterField(ref restrictNomenclature, value))
					CanChangeNomenclature = false;
			}
		}
		public bool CanChangeNomenclature { get; private set; } = true;

		RequestStatus? restrictStatus = RequestStatus.InProcess;
		public virtual RequestStatus? RestrictStatus {
			get => restrictStatus;
			set {
				if(UpdateFilterField(ref restrictStatus, value))
					CanChangeStatus = false;
			}
		}
		public bool CanChangeStatus { get; private set; } = true;
	}
}