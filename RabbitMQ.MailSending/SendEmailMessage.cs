using System.Collections.Generic;

namespace RabbitMQ.MailSending
{
	public class SendEmailMessage
	{
		public EmailContact From { get; set; }
		public EmailContact To { get; set; }
		public string Subject { get; set; }
		public string TextPart { get; set; }
		public string HTMLPart { get; set; }
		public IEnumerable<EmailAttachment> Attachments { get; set; }
		public IEnumerable<InlinedEmailAttachment> InlinedAttachments { get; set; }
		public EmailPayload EventPayload { get; set; }
	}
}
