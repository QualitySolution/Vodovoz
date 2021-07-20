using Mailjet.Api.Abstractions.Events;
using System.Text.Json.Serialization;

namespace Mailjet.Api.Abstractions.Events
{
	public class MailSentEvent : MailEvent
	{
		[JsonPropertyName("mj_message_id")]
		public string MailjetMessageId { get; set; }
		[JsonPropertyName("smtp_reply")]
		public string SmtpReply { get; set; }
	}
}
