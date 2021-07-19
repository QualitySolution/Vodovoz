using System;

namespace RabbitMQ.MailSending
{
	public class UpdateStoredEmailStatusMessage
	{
		public EmailPayload EventPayload { get; set; }
		public string Status { get; set; }
		public DateTime RecievedAt { get; set; }
	}
}
