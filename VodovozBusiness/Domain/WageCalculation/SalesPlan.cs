using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using Gamma.Utilities;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using QS.HistoryLog;
using Vodovoz.Domain.Goods;

namespace Vodovoz.Domain.WageCalculation
{
	[
		Appellative(
			Gender = GrammaticalGender.Feminine,
			NominativePlural = "планы продаж",
			Nominative = "план продаж"
		)
	]
	[HistoryTrace]
	[EntityPermission]
	public class SalesPlan : PropertyChangedBase, IDomainObject, IValidatableObject
	{
		//private IList<Nomenclature> _nomenclatures = new List<Nomenclature>();
		private IList<NomenclatureSalesPlanItem> _nomenclatureItemSalesPlans = new List<NomenclatureSalesPlanItem>();
		private IList<EquipmentKindSalesPlanItem> _equipmentKindItemSalesPlans = new List<EquipmentKindSalesPlanItem>();
		//private IList<EquipmentType> _equipmentTypes = new List<EquipmentType>();
		private IList<EquipmentTypeSalesPlanItem> _equipmentTypeItemSalesPlans = new List<EquipmentTypeSalesPlanItem>();
		//private GenericObservableList<Nomenclature> _observableNomenclatures;
		private GenericObservableList<NomenclatureSalesPlanItem> _observableNomenclatureItemSalesPlan;
		private GenericObservableList<EquipmentKindSalesPlanItem> _observableEquipmentKindItemSalesPlans;
		//private GenericObservableList<EquipmentType> _observableEquipmentTypes;
		private GenericObservableList<EquipmentTypeSalesPlanItem> _observableEquipmentTypeItemSalesPlans;
		public virtual int Id { get; set; }

		string name;
		[Display(Name = "Название")]
		public virtual string Name {
			get => name;
			set => SetField(ref name, value);
		}

		bool isArchive;
		[Display(Name = "Архивный")]
		public virtual bool IsArchive {
			get => isArchive;
			set => SetField(ref isArchive, value);
		}

		int fullBottlesToSell;
		[Display(Name = "Кол-во полных бутылей для продажи")]
		public virtual int FullBottleToSell {
			get => fullBottlesToSell;
			set => SetField(ref fullBottlesToSell, value);
		}

		int emptyBottlesToTake;
		[Display(Name = "Кол-во пустых бутылей для забора")]
		public virtual int EmptyBottlesToTake {
			get => emptyBottlesToTake;
			set => SetField(ref emptyBottlesToTake, value);
		}

		public virtual string Title {
			get {
				return string.Format(
					"продажа - {1} бут., забор - {2} бут. (№{0})",
					Id,
					FullBottleToSell,
					EmptyBottlesToTake
				);
			}
		}

		//[Display(Name = "Номенклатуры")]
		//public virtual IList<Nomenclature> Nomenclatures
		//{
		//	get => _nomenclatures;
		//	set => SetField(ref _nomenclatures, value);
		//}

		[Display(Name = "Номенклатуры")]
		public virtual IList<NomenclatureSalesPlanItem> NomenclatureItemSalesPlans
		{
			get => _nomenclatureItemSalesPlans;
			set => SetField(ref _nomenclatureItemSalesPlans, value);
		}

		[Display(Name = "Виды оборудования")]
		public virtual IList<EquipmentKindSalesPlanItem> EquipmentKindItemSalesPlans
		{
			get => _equipmentKindItemSalesPlans;
			set => SetField(ref _equipmentKindItemSalesPlans, value);
		}

		//[Display(Name = "Типы оборудования")]
		//public virtual IList<EquipmentType> EquipmentTypes
		//{
		//	get => _equipmentTypes;
		//	set => SetField(ref _equipmentTypes, value);
		//}

		[Display(Name = "Типы оборудования")]
		public virtual IList<EquipmentTypeSalesPlanItem> EquipmentTypeItemSalesPlans
		{
			get => _equipmentTypeItemSalesPlans;
			set => SetField(ref _equipmentTypeItemSalesPlans, value);
		}

		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.

		public virtual GenericObservableList<NomenclatureSalesPlanItem> ObservableNomenclatureItemSalesPlans => 
			_observableNomenclatureItemSalesPlan ?? 
			(_observableNomenclatureItemSalesPlan = new GenericObservableList<NomenclatureSalesPlanItem>(NomenclatureItemSalesPlans));
		public virtual GenericObservableList<EquipmentKindSalesPlanItem> ObservableEquipmentKindItemSalesPlans => 
			_observableEquipmentKindItemSalesPlans ?? (_observableEquipmentKindItemSalesPlans = new GenericObservableList<EquipmentKindSalesPlanItem>(EquipmentKindItemSalesPlans));
		public virtual GenericObservableList<EquipmentTypeSalesPlanItem> ObservableEquipmentTypeItemSalesPlans =>
			_observableEquipmentTypeItemSalesPlans ?? (_observableEquipmentTypeItemSalesPlans = new GenericObservableList<EquipmentTypeSalesPlanItem>(EquipmentTypeItemSalesPlans));

		public virtual void AddNomenclatureItem(NomenclatureSalesPlanItem nomenclatureSalesPlanItem)
		{
			if(ObservableNomenclatureItemSalesPlans.Contains(nomenclatureSalesPlanItem))
			{
				return;
			}

			ObservableNomenclatureItemSalesPlans.Add(nomenclatureSalesPlanItem);
		}

		public virtual void RemoveNomenclatureItem(NomenclatureSalesPlanItem nomenclatureSalesPlanItem)
		{
			if(ObservableNomenclatureItemSalesPlans.Contains(nomenclatureSalesPlanItem))
			{
				ObservableNomenclatureItemSalesPlans.Remove(nomenclatureSalesPlanItem);
			}
		}

		public virtual void AddEquipmentKind(EquipmentKindSalesPlanItem equipmentKindSalesPlanItem)
		{
			if(ObservableEquipmentKindItemSalesPlans.Contains(equipmentKindSalesPlanItem))
			{
				return;
			}

			ObservableEquipmentKindItemSalesPlans.Add(equipmentKindSalesPlanItem);
		}

		public virtual void RemoveEquipmentKindItem(EquipmentKindSalesPlanItem equipmentKindSalesPlanItem)
		{
			if(ObservableEquipmentKindItemSalesPlans.Contains(equipmentKindSalesPlanItem))
			{
				ObservableEquipmentKindItemSalesPlans.Remove(equipmentKindSalesPlanItem);
			}
		}

		public virtual void AddEquipmentType(EquipmentTypeSalesPlanItem equipmentTypeSalesPlanItem)
		{
			if(ObservableEquipmentTypeItemSalesPlans.Contains(equipmentTypeSalesPlanItem))
			{
				return;
			}

			ObservableEquipmentTypeItemSalesPlans.Add(equipmentTypeSalesPlanItem);
		}

		public virtual void RemoveEquipmentTypeItem(EquipmentTypeSalesPlanItem equipmentTypeSalesPlanItem)
		{
			if(ObservableEquipmentTypeItemSalesPlans.Contains(equipmentTypeSalesPlanItem))
			{
				ObservableEquipmentTypeItemSalesPlans.Remove(equipmentTypeSalesPlanItem);
			}
		}



		#region IValidatableObject implementation

		public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if(FullBottleToSell <= 0)
				yield return new ValidationResult(
					"Должно быть указано планируемое количество бутылей для продажи",
					new[] { this.GetPropertyName(o => o.FullBottleToSell) }
				);

			if(EmptyBottlesToTake <= 0)
				yield return new ValidationResult(
					"Должно быть указано планируемое количество бутылей для забора",
					new[] { this.GetPropertyName(o => o.EmptyBottlesToTake) }
				);
		}

		#endregion IValidatableObject implementation
	}
}
