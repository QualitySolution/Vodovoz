﻿using System;
using System.ComponentModel.DataAnnotations;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;

namespace Vodovoz.Domain
{
	[Appellative (Gender = GrammaticalGender.Masculine,
		NominativePlural = "типы оборудования",
		Nominative = "вид оборудования")]
	[EntityPermission]
	public class EquipmentKind : PropertyChangedBase, IDomainObject
	{
		#region Свойства

		public virtual int Id { get; set; }

		string name;

		[Required (ErrorMessage = "Название должно быть заполнено.")]
		[Display (Name = "Название")]
		public virtual string Name {
			get { return name; }
			set { SetField (ref name, value, () => Name); }
		}

		WarrantyCardType warrantyCardType;
		[Display (Name="Тип гарантийного талона")]
		public virtual WarrantyCardType WarrantyCardType{
			get{ return warrantyCardType; }
			set{ SetField (ref warrantyCardType, value, () => WarrantyCardType); }
		}
		#endregion

		public EquipmentKind ()
		{
			Name = String.Empty;
		}
	}

	public enum WarrantyCardType{
		[Display(Name="Нет")]
		WithoutCard,
		[Display (Name = "Гарrантийный талон на кулера")]
		CoolerWarranty,
		[Display (Name = "Гарантийный талон на помпы")]
		PumpWarranty
	}

	public enum EquipmentType
	{
		[Display(Name = "Кулер")]
		Cooler,
		[Display(Name = "Помпа")]
		Pump,
		[Display(Name = "Прочее")]
		Other
	}

	public class WarrantyCardTypeStringType : NHibernate.Type.EnumStringType
	{
		public WarrantyCardTypeStringType () : base (typeof(WarrantyCardType))
		{
		}
	}

	public class EquipmentTypeStringType : NHibernate.Type.EnumStringType
	{
		public EquipmentTypeStringType() : base(typeof(EquipmentType))
		{
		}
	}
}
