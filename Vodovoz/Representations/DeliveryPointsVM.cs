﻿using Gamma.ColumnConfig;
using Gtk;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QSOrmProject.RepresentationModel;
using Vodovoz.Domain.Client;

namespace Vodovoz.ViewModel
{
	public class DeliveryPointsVM : RepresentationModelEntityBase<DeliveryPoint, DeliveryPointVMNode>
	{
		public DeliveryPointFilter Filter {
			get {
				return RepresentationFilter as DeliveryPointFilter;
			}
			set {
				RepresentationFilter = value as IRepresentationFilter;
			}
		}

		#region IRepresentationModel implementation

		public override void UpdateNodes()
		{
			DeliveryPoint deliveryPointAlias = null;
			Counterparty counterpartyAlias = null;
			DeliveryPointVMNode resultAlias = null;

			var pointsQuery = UoW.Session.QueryOver<DeliveryPoint>(() => deliveryPointAlias);
			if(Filter.RestrictOnlyNotFoundOsm)
				pointsQuery.Where(x => x.FoundOnOsm == false);
			if(Filter.RestrictOnlyWithoutStreet)
				pointsQuery
					.Where(new Disjunction()
						.Add(() => deliveryPointAlias.Street == null)
						.Add(Restrictions.Eq(
							Projections.SqlFunction(
								new SQLFunctionTemplate(
									NHibernateUtil.Boolean, "TRIM(?1)"),
								NHibernateUtil.Boolean,
								Projections.Property(() => deliveryPointAlias.Street)
								),
							"")
						)
					);
			if(Filter.Client != null)
				pointsQuery.Where(p => p.Counterparty.Id == Filter.Client.Id);

			var deliveryPointslist = pointsQuery
				.JoinAlias(c => c.Counterparty, () => counterpartyAlias, NHibernate.SqlCommand.JoinType.LeftOuterJoin)
				.SelectList(list => list
				   .Select(() => deliveryPointAlias.Id).WithAlias(() => resultAlias.Id)
				   .Select(() => deliveryPointAlias.CompiledAddress).WithAlias(() => resultAlias.CompiledAddress)
				   .Select(() => deliveryPointAlias.FoundOnOsm).WithAlias(() => resultAlias.FoundOnOsm)
				   .Select(() => deliveryPointAlias.IsFixedInOsm).WithAlias(() => resultAlias.FixedInOsm)
				   .Select(() => deliveryPointAlias.IsActive).WithAlias(() => resultAlias.IsActive)
				   .Select(() => deliveryPointAlias.Address1c).WithAlias(() => resultAlias.Address1c)
				   .Select(() => counterpartyAlias.FullName).WithAlias(() => resultAlias.Client)
				)
				.TransformUsing(Transformers.AliasToBean<DeliveryPointVMNode>())
				.List<DeliveryPointVMNode>();

			SetItemsSource(deliveryPointslist);
		}

		IColumnsConfig columnsConfig = FluentColumnsConfig<DeliveryPointVMNode>.Create()
			.AddColumn("OSM").AddTextRenderer(x => x.FoundOnOsm ? "Да" : "")
			.AddColumn("Испр.").AddTextRenderer(x => x.FixedInOsm ? "Да" : "")
			//.AddColumn("Логистический район").AddTextRenderer(x => x.LogisticsArea)
			.AddColumn("Адрес").SetDataProperty(node => node.CompiledAddress)
			.AddColumn("Адрес из 1с").AddTextRenderer(x => x.Address1c)
			.AddColumn("Клиент").AddTextRenderer(x => x.Client)
			.AddColumn("Номер").AddTextRenderer(x => x.IdString)
			.RowCells().AddSetter<CellRendererText>((c, n) => c.Foreground = n.RowColor)
			.Finish();

		public override IColumnsConfig ColumnsConfig {
			get { return columnsConfig; }
		}

		#endregion

		#region implemented abstract members of RepresentationModelBase

		protected override bool NeedUpdateFunc(DeliveryPoint updatedSubject)
		{
			return true;
		}

		#endregion

		public DeliveryPointsVM() : this(UnitOfWorkFactory.CreateWithoutRoot())
		{
			CreateRepresentationFilter = () => new DeliveryPointFilter();
		}

		public DeliveryPointsVM(IUnitOfWork uow)
		{
			this.UoW = uow;
		}

		public DeliveryPointsVM(DeliveryPointFilter filter) : this(filter.UoW)
		{
			Filter = filter;
		}
	}

	public class DeliveryPointVMNode
	{
		public int Id { get; set; }

		[UseForSearch]
		[SearchHighlight]
		public string CompiledAddress { get; set; }

		public string LogisticsArea { get; set; }

		[UseForSearch]
		[SearchHighlight]
		public string Address1c { get; set; }

		[UseForSearch]
		[SearchHighlight]
		public string Client { get; set; }

		public bool IsActive { get; set; }

		public bool FoundOnOsm { get; set; }

		public bool FixedInOsm { get; set; }

		public string RowColor { get { return IsActive ? "black" : "grey"; } }

		[UseForSearch]
		[SearchHighlight]
		public string IdString => Id.ToString();
	}
}

