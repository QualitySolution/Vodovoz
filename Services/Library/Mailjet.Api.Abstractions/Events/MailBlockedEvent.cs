﻿using System.Text.Json.Serialization;

namespace Mailjet.Api.Abstractions.Events
{
	public class MailBlockedEvent : MailEvent
	{
		[JsonPropertyName("error_related_to")]
		public string ErrorRelatedTo { get; set; }
		[JsonPropertyName("error")]
		public string Error { get; set; }
	}
}
