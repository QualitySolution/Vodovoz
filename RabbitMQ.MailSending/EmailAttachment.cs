namespace RabbitMQ.MailSending
{
	public class EmailAttachment
	{
		public string ContentType { get; set; }
		public string Filename { get; set; }
		public string Base64Content { get; set; }
	}
}
