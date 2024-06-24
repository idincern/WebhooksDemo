using Microsoft.AspNetCore.Mvc;
using WebhookClient.API.Models;
using WebhookClient.Application.DTOs;
using WebhookClient.Application.Interfaces;
using MassTransit;

namespace WebhookClient.API.Controllers
{
    public class WebhookController : CustomBaseController
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<WebhookController> _logger;

        public WebhookController(IPublishEndpoint publishEndpoint, ILogger<WebhookController> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveWebhook(WebhookReceivedDto receivedMessage)
        {
            try
            {
                await _publishEndpoint.Publish<WebhookReceivedMessage>(new
                {
                    Id = Guid.NewGuid(),
                    receivedMessage.DeliveryId,
                    receivedMessage.Status,
                    Timestamp = DateTime.UtcNow
                });

                _logger.LogInformation($"Webhook message queued: {receivedMessage.DeliveryId}");
                return CreateActionResult(WebhookResponse<string>.Success("Webhook received and queued."), nameof(ReceiveWebhook), new { receivedMessage.DeliveryId, receivedMessage.Status });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error queueing webhook message.");
                return CreateActionResult(WebhookResponse<string>.Fail("Error processing webhook."), nameof(ReceiveWebhook), new { receivedMessage.DeliveryId, receivedMessage.Status });
            }
        }
    }
}