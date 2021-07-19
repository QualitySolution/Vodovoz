using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.MailSending
{
	public class EmailPayload
	{
		public int Id { get; set; }
		public bool Trackable { get; set; }
	}
}
