﻿using DriverAPI.Library.Converters;
using DriverAPI.Library.Models;
using Microsoft.Extensions.Logging;
using QS.DomainModel.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using Vodovoz.Domain;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Complaints;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Logistic;
using Vodovoz.EntityRepositories.Complaints;
using Vodovoz.EntityRepositories.Logistic;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.Services;

namespace DriverAPI.Library.DataAccess
{
	public class APIOrderData : IAPIOrderData
	{
		private readonly ILogger<APIOrderData> logger;
		private readonly IOrderRepository orderRepository;
		private readonly IRouteListRepository routeListRepository;
		private readonly OrderConverter orderConverter;
		private readonly IOrderParametersProvider orderParametersProvider;
		private readonly IDriverApiParametersProvider webApiParametersProvider;
		private readonly IComplaintsRepository complaintsRepository;
		private readonly IAPISmsPaymentData aPISmsPaymentData;
		private readonly IDriverMobileAppActionRecordData driverMobileAppActionRecordData;
		private readonly IUnitOfWork unitOfWork;

		private const int maxClosingRating = 5;

		public APIOrderData(ILogger<APIOrderData> logger,
			IOrderRepository orderRepository,
			IRouteListRepository routeListRepository,
			OrderConverter orderConverter,
			IOrderParametersProvider orderParametersProvider,
			IDriverApiParametersProvider webApiParametersProvider,
			IComplaintsRepository complaintsRepository,
			IAPISmsPaymentData aPISmsPaymentData,
			IDriverMobileAppActionRecordData driverMobileAppActionRecordData,
			IUnitOfWork unitOfWork
			)
		{
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
			this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
			this.routeListRepository = routeListRepository ?? throw new ArgumentNullException(nameof(routeListRepository));
			this.orderConverter = orderConverter ?? throw new ArgumentNullException(nameof(orderConverter));
			this.orderParametersProvider = orderParametersProvider ?? throw new ArgumentNullException(nameof(orderParametersProvider));
			this.webApiParametersProvider = webApiParametersProvider ?? throw new ArgumentNullException(nameof(webApiParametersProvider));
			this.complaintsRepository = complaintsRepository ?? throw new ArgumentNullException(nameof(complaintsRepository));
			this.aPISmsPaymentData = aPISmsPaymentData ?? throw new ArgumentNullException(nameof(aPISmsPaymentData));
			this.driverMobileAppActionRecordData = driverMobileAppActionRecordData ?? throw new ArgumentNullException(nameof(driverMobileAppActionRecordData));
			this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		/// <summary>
		/// Получение заказа в требуемом формате из заказа программы ДВ (использует функцию ниже)
		/// </summary>
		/// <param name="orderId">Идентификатор заказа</param>
		/// <returns>APIOrder</returns>
		public APIOrder Get(int orderId)
		{
			var order = orderRepository.GetOrder(unitOfWork, orderId)
				?? throw new DataNotFoundException(nameof(orderId), $"Заказ {orderId} не найден");

			return orderConverter.convertToAPIOrder(order, aPISmsPaymentData.GetOrderPaymentStatus(orderId));
		}

		/// <summary>
		/// Получение списка заказов в требуемом формате из заказов программы ДВ по списку идентификаторов
		/// </summary>
		/// <param name="orderIds">Список идентификаторов заказов</param>
		/// <returns>IEnumerable APIOrder</returns>
		public IEnumerable<APIOrder> Get(int[] orderIds)
		{
			var result = new List<APIOrder>();
			var vodovozOrders = orderRepository.GetOrders(unitOfWork, orderIds);

			foreach (var vodovozOrder in vodovozOrders)
			{
				var smsPaymentStatus = aPISmsPaymentData.GetOrderPaymentStatus(vodovozOrder.Id);
				var order = orderConverter.convertToAPIOrder(vodovozOrder, smsPaymentStatus);
				order.OrderAdditionalInfo = GetAdditionalInfo(vodovozOrder);
				result.Add(order);
			}

			return result;
		}

		/// <summary>
		/// Получение типов оплаты на которые можно изменить тип оплаты заказа переданного в аргументе
		/// </summary>
		/// <param name="orderId">Идентификатор заказа</param>
		/// <returns>IEnumerable APIPaymentType</returns>
		public IEnumerable<APIPaymentType> GetAvailableToChangePaymentTypes(int orderId)
		{
			var vodovozOrder = orderRepository.GetOrder(unitOfWork, orderId)
				?? throw new DataNotFoundException(nameof(orderId), $"Заказ {orderId} не найден");

			return GetAvailableToChangePaymentTypes(vodovozOrder);
		}

		/// <summary>
		/// Получение типов оплаты на которые можно изменить тип оплаты заказа переданного в аргументе
		/// </summary>
		/// <param name="order">Заказ программы ДВ</param>
		/// <returns>IEnumerable APIPaymentType</returns>
		public IEnumerable<APIPaymentType> GetAvailableToChangePaymentTypes(Vodovoz.Domain.Orders.Order order)
		{
			var availablePaymentTypes = new List<APIPaymentType>();

			if (order.PaymentType == PaymentType.cash)
			{
				availablePaymentTypes.Add(APIPaymentType.Terminal);
			}

			if (order.PaymentType == PaymentType.Terminal)
			{
				availablePaymentTypes.Add(APIPaymentType.Cash);
			}

			return availablePaymentTypes;
		}

		/// <summary>
		/// Получение дополнительной информации для заказа по идентификатору
		/// </summary>
		/// <param name="orderId">Идентификатор заказа</param>
		/// <returns>APIOrderAdditionalInfo</returns>
		public APIOrderAdditionalInfo GetAdditionalInfo(int orderId)
		{
			var vodovozOrder = orderRepository.GetOrder(unitOfWork, orderId)
				?? throw new DataNotFoundException(nameof(orderId), $"Заказ {orderId} не найден");

			return GetAdditionalInfo(vodovozOrder);
		}

		/// <summary>
		/// Получение дополнительной информации для заказа из заказа программы ДВ
		/// </summary>
		/// <param name="order">Заказ программы ДВ</param>
		/// <returns>APIOrderAdditionalInfo</returns>
		public APIOrderAdditionalInfo GetAdditionalInfo(Vodovoz.Domain.Orders.Order order)
		{
			return new APIOrderAdditionalInfo()
			{
				AvailablePaymentTypes = GetAvailableToChangePaymentTypes(order),
				CanSendSms = CanSendSmsForPayment(order, aPISmsPaymentData.GetOrderPaymentStatus(order.Id)),
			};
		}

		/// <summary>
		/// Проверка возможности отправки СМС для оплаты
		/// </summary>
		/// <param name="order">Заказ программы ДВ</param>
		/// <param name="smsPaymentStatus">Статус оплаты СМС</param>
		/// <returns></returns>
		private bool CanSendSmsForPayment(Vodovoz.Domain.Orders.Order order, SmsPaymentStatus? smsPaymentStatus)
		{
			return order.PaymentType == PaymentType.ByCard
				&& order.PaymentByCardFrom.Id == orderParametersProvider.PaymentByCardFromSmsId
				&& smsPaymentStatus != SmsPaymentStatus.Paid;
		}

		public void ChangeOrderPaymentType(int orderId, PaymentType paymentType)
		{
			var vodovozOrder = orderRepository.GetOrder(unitOfWork, orderId)
				?? throw new DataNotFoundException(nameof(orderId), $"Заказ {orderId} не найден");

			vodovozOrder.PaymentType = paymentType;
			unitOfWork.Save(vodovozOrder);
			unitOfWork.Commit();
		}

		public void CompleteOrderDelivery(
			Employee driver,
			int orderId,
			int bottlesReturnCount,
			int rating,
			int driverComplaintReasonId,
			string otherDriverComplaintReasonComment,
			DateTime actionTime)
		{
			var vodovozOrder = orderRepository.GetOrder(unitOfWork, orderId);
			var routeList = routeListRepository.GetRouteListByOrder(unitOfWork, vodovozOrder);
			var routeListAddress = routeList.Addresses.Where(x => x.Order.Id == orderId).SingleOrDefault();

			routeListAddress.DriverBottlesReturned = bottlesReturnCount;

			if (routeListAddress.Status == RouteListItemStatus.Transfered)
			{
				var error = $"Попытка завершения заказа, который был передан: {orderId}";
				logger.LogWarning(error);
				throw new InvalidOperationException(error);
			}

			routeListAddress.UpdateStatus(unitOfWork, RouteListItemStatus.Completed);

			if (rating < maxClosingRating)
			{
				var complaintReason = complaintsRepository.GetDriverComplaintReasonById(unitOfWork, driverComplaintReasonId);
				var complaintSource = complaintsRepository.GetComplaintSourceById(unitOfWork, webApiParametersProvider.ComplaintSourceId);
				var reason = complaintReason?.Name ?? otherDriverComplaintReasonComment;

				var complaint = new Complaint
				{
					ComplaintSource = complaintSource,
					ComplaintType = ComplaintType.Driver,
					Order = vodovozOrder,
					DriverRating = rating,
					DeliveryPoint = vodovozOrder.DeliveryPoint,
					CreationDate = actionTime,
					ComplaintText = $"Заказ номер {orderId}\n" +
						$"По причине {reason}"
				};

				unitOfWork.Save(complaint);
			}

			if (routeList.Status == RouteListStatus.EnRoute && routeList.Addresses.All(a => a.Status != RouteListItemStatus.EnRoute))
			{
				routeList.ChangeStatus(RouteListStatus.Delivered);
				unitOfWork.Save(routeList);
			}

			unitOfWork.Save(routeListAddress);
			unitOfWork.Commit();

			driverMobileAppActionRecordData.RegisterAction(
				driver,
				new APIDriverAction()
				{
					ActionType = APIActionType.CompleteOrderClicked,
					ActionTime = actionTime
				});
		}
	}
}