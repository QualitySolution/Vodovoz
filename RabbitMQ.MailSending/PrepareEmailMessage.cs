namespace RabbitMQ.MailSending
{
	public class PrepareEmailMessage
	{
		public string DocumentToPrepare { get; set; }
		public int StoredEmailId { get; set; }
		public int SendAttemptsCount { get; set; }
	}
}
