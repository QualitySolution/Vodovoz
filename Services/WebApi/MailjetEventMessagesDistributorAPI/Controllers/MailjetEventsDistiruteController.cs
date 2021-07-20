using Mailjet.Api.Abstractions.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MailjetEventMessagesDistributorAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MailjetEventsDistiruteController : ControllerBase
	{
		private readonly ILogger<MailjetEventsDistiruteController> _logger;

		public MailjetEventsDistiruteController(ILogger<MailjetEventsDistiruteController> logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/EventCallback")]
		public async Task<IActionResult> EventCallback([FromBody]MailEvent mailSentEvent)
		{
			_logger.LogInformation($"Recieved Event { mailSentEvent.EventType }");

			if(mailSentEvent.EventType == MailEventType.sent)
			{
				return await new ValueTask<IActionResult>(RedirectToActionPreserveMethod(nameof(SentEventCallback)));
			}

			if(mailSentEvent.EventType == MailEventType.open)
			{
				return await new ValueTask<IActionResult>(RedirectToActionPreserveMethod(nameof(OpenEventCallback)));
			}

			if(mailSentEvent.EventType == MailEventType.click)
			{
				return await new ValueTask<IActionResult>(RedirectToActionPreserveMethod(nameof(ClickEventCallback)));
			}

			if(mailSentEvent.EventType == MailEventType.bounce)
			{
				return await new ValueTask<IActionResult>(RedirectToActionPreserveMethod(nameof(BounceEventCallback)));
			}

			if(mailSentEvent.EventType == MailEventType.blocked)
			{
				return await new ValueTask<IActionResult>(RedirectToActionPreserveMethod(nameof(BlockedEventCallback)));
			}

			if(mailSentEvent.EventType == MailEventType.spam)
			{
				return await new ValueTask<IActionResult>(RedirectToActionPreserveMethod(nameof(SpamEventCallback)));
			}

			if(mailSentEvent.EventType == MailEventType.unsub)
			{
				return await new ValueTask<IActionResult>(RedirectToActionPreserveMethod(nameof(UnsubscribeEventCallback)));
			}

			return BadRequest("Something goes wrong 0_o");
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/SentEventCallback")]
		public async Task SentEventCallback([FromBody]MailSentEvent mailSentEvent)
		{
			_logger.LogInformation($"Recieved Sent Event for: { mailSentEvent.MessageGuid }");
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/OpenEventCallback")]
		public async Task OpenEventCallback([FromBody]MailOpenEvent mailOpenEvent)
		{
			_logger.LogInformation($"Recieved Open Event for: { mailOpenEvent.MessageGuid }");
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/ClickEventCallback")]
		public async Task ClickEventCallback([FromBody]MailClickEvent mailClickEvent)
		{
			_logger.LogInformation($"Recieved Click Event for: { mailClickEvent.MessageGuid }");
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/BounceEventCallback")]
		public async Task BounceEventCallback([FromBody] MailBounceEvent mailBounceEvent)
		{
			_logger.LogInformation($"Recieved Bounce Event for: { mailBounceEvent.MessageGuid }");
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/BlockedEventCallback")]
		public async Task BlockedEventCallback([FromBody] MailBlockedEvent mailBlockedEvent)
		{
			_logger.LogInformation($"Recieved Blocked Event for: { mailBlockedEvent.MessageGuid }");
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/BounceEventCallback")]
		public async Task SpamEventCallback([FromBody] MailSpamEvent mailSpamEvent)
		{
			_logger.LogInformation($"Recieved Spam Event for: { mailSpamEvent.MessageGuid }");
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/BounceEventCallback")]
		public async Task UnsubscribeEventCallback([FromBody] MailUnsubscribeEvent mailUnsubscribeEvent)
		{
			_logger.LogInformation($"Recieved Unsubscribe Event for: { mailUnsubscribeEvent.MessageGuid }");
		}
	}
}
