﻿using System;
using NHibernate;
using NHibernate.Criterion;
using QS.DomainModel.UoW;
using QSOrmProject;
using Vodovoz.Domain;

namespace Vodovoz
{
	public partial class EquipmentFilter : Gtk.Bin, IReferenceFilter
	{
		public EquipmentFilter (IUnitOfWork uow)
		{
			this.Build ();
			UoW = uow;
			IsFiltred = false;
			entryrefEquipmentKind.SubjectType = typeof(EquipmentKind);
		}

		#region IReferenceFilter implementation

		public event EventHandler Refiltered;

		public IUnitOfWork UoW { set; get;}

		public ICriteria BaseCriteria { get; set; }

		ICriteria filtredCriteria;

		public ICriteria FiltredCriteria {
			private set {
				filtredCriteria = value;
			}
			get {
				if (filtredCriteria == null)
					UpdateCreteria ();
				return filtredCriteria;
			}		
		}

		void OnRefiltered ()
		{
			if (Refiltered != null)
				Refiltered (this, new EventArgs ());
		}

		public bool IsFiltred { get; private set; }

		#endregion

		void UpdateCreteria ()
		{
			IsFiltred = false;
			if (BaseCriteria == null)
				return;
			FiltredCriteria = (ICriteria)BaseCriteria.Clone ();
			if (checkSelectOutdated.Active) {
				FiltredCriteria.Add (Restrictions.Lt ("LastServiceDate", DateTime.Now.AddMonths (-5).AddDays (-14)));
				IsFiltred = true;
			}
			if(entryrefEquipmentKind.Subject != null)
			{
				FiltredCriteria.CreateAlias("Nomenclature", "nomenclatureAlias");
				FiltredCriteria.Add(Restrictions.Eq("nomenclatureAlias.Type", entryrefEquipmentKind.Subject));
			}
			OnRefiltered ();
		}

		protected void OnCheckSelectOutdatedToggled (object sender, EventArgs e)
		{
			UpdateCreteria ();
		}

		protected void OnEntryrefEquipmentKindChangedByUser(object sender, EventArgs e)
		{
			UpdateCreteria();
		}
	}
}

