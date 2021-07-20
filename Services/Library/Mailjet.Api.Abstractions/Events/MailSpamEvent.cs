using System.Text.Json.Serialization;

namespace Mailjet.Api.Abstractions.Events
{
	public class MailSpamEvent : MailEvent
	{
		[JsonPropertyName("source")]
		public string Source { get; set; }
	}
}
