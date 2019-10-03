﻿using System.ComponentModel.DataAnnotations;

namespace Vodovoz.Domain.Sms
{
	public enum SmsNotificationStatus
	{
		[Display(Name = "Новое")]
		New,
		[Display(Name = "Отправлено")]
		Sended,
		[Display(Name = "Приятно")]
		Accepted,
		[Display(Name = "Ошибка")]
		Error,
		[Display(Name = "Отправка просрочена")]
		SendExpired
	}

	public class SmsNotificationStatusStringType : NHibernate.Type.EnumStringType
	{
		public SmsNotificationStatusStringType() : base(typeof(SmsNotificationStatus))
		{
		}
	}
}
