﻿namespace DriverAPI.Library.DTOs
{
	public class FCMSendPushMessageDto
	{
		public string notificationType { get; set; }
		public string message { get; set; }
		public string sender { get; set; }
	}
}
