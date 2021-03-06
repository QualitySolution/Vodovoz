﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Operations;
using Vodovoz.Domain.Orders;
using Vodovoz.Services;

namespace VodovozBusinessTests.Domain.Logistic
{
	[TestFixture]
	public class RouteListItemTests
	{
		private static IEnumerable<OrderItem> ForfeitWaterAndEmptyBottles(int waterCount, int forfeitCount, int emptyBottlesCount = 0)
		{
			Nomenclature forfeitNomenclature = Substitute.For<Nomenclature>();
			forfeitNomenclature.Category.Returns(NomenclatureCategory.bottle);
			forfeitNomenclature.Id.Returns(33);

			Nomenclature emptyBottleNomenclature = Substitute.For<Nomenclature>();
			emptyBottleNomenclature.Category.Returns(NomenclatureCategory.bottle);

			Nomenclature waterNomenclature = Substitute.For<Nomenclature>();
			waterNomenclature.Category.Returns(NomenclatureCategory.water);
			waterNomenclature.IsDisposableTare.Returns(false);

			yield return new OrderItem { Nomenclature = forfeitNomenclature, ActualCount = forfeitCount };
			yield return new OrderItem { Nomenclature = emptyBottleNomenclature, ActualCount = emptyBottlesCount };
			yield return new OrderItem { Nomenclature = waterNomenclature, ActualCount = waterCount };
		}


		#region создание операций
		static IEnumerable WaterForfeitBottleOrderItems()
		{
			yield return new object[] { ForfeitWaterAndEmptyBottles(10, 10).ToList(), 10, 10 };
			yield return new object[] { ForfeitWaterAndEmptyBottles(7, 5).ToList(), 7, 5 };
			yield return new object[] { ForfeitWaterAndEmptyBottles(0, 2).ToList(), 0, 2 };
			yield return new object[] { ForfeitWaterAndEmptyBottles(3, 0).ToList(), 3, 0 };
			yield return new object[] { ForfeitWaterAndEmptyBottles(11, 11, 11).ToList(), 11, 11 };
		}
		[TestCaseSource(nameof(WaterForfeitBottleOrderItems))]
		[Test(Description = "Проверка создания операции перемещения бутылей")]
		public void Check_Bottle_Movement_Operation_Creation(List<OrderItem> orderItems, int delivered, int returned)
		{
			//arrange
			RouteListItem testRLItem = new RouteListItem();
			IUnitOfWork uow = Substitute.For<IUnitOfWork>();
			testRLItem.Order = new Order();
			testRLItem.Order.UoW = uow;
			testRLItem.Order.OrderItems = orderItems;
			testRLItem.Order.DeliveryDate = DateTime.Now;
			var standartNom = Substitute.For<IStandartNomenclatures>();
			standartNom.GetForfeitId().Returns(33);

			// act
			testRLItem.Order.UpdateBottleMovementOperation(uow,standartNom,testRLItem.BottlesReturned);

			// assert
			Assert.AreEqual(returned, testRLItem.Order.BottlesMovementOperation.Returned);
			Assert.AreEqual(delivered, testRLItem.Order.BottlesMovementOperation.Delivered);
		}
		#endregion создание операций
	}
}
