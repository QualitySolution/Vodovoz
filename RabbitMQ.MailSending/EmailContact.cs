namespace RabbitMQ.MailSending
{
	public class EmailContact
	{
		public string Email { get; set; }

		public string Name { get; set; }

		public EmailContact() {}

		public EmailContact(string email, string name)
		{
			Email = email;
			Name = name;
		}
	}
}
