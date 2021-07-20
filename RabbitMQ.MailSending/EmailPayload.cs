namespace RabbitMQ.MailSending
{
	public class EmailPayload
	{
		public int Id { get; set; }
		public bool Trackable { get; set; }
		public string InstanceId { get; set; }
	}
}
