using Microsoft.AspNetCore.Mvc;
using WebhookClient.API.Models;
using WebhookClient.Application.DTOs;
using WebhookClient.Application.Interfaces;
using MassTransit;
using System.Net.WebSockets;

namespace WebhookClient.API.Controllers
{
    public class WebhookController : CustomBaseController
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public WebhookController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveWebhook(WebhookReceivedMessage receivedMessage)
        {
            try
            {
                await _publishEndpoint.Publish(new WebhookReceivedMessage
                {
                    DeliveryId = receivedMessage.DeliveryId,
                    Status = receivedMessage.Status,
                    EventType = receivedMessage.EventType,
                    Timestamp = DateTime.UtcNow
                });

                await Console.Out.WriteLineAsync($"Webhook message queued: {receivedMessage.DeliveryId}, Event Type: {receivedMessage.EventType}");
                return CreateActionResult(WebhookResponse<string>.Success("Webhook received and queued."),
                    nameof(ReceiveWebhook),
                    new { receivedMessage.DeliveryId, receivedMessage.Status, receivedMessage.EventType });
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error queueing webhook message. {ex.Message}");
                return CreateActionResult(WebhookResponse<string>.Fail("Error processing webhook."),
                    nameof(ReceiveWebhook),
                    new { receivedMessage.DeliveryId, receivedMessage.Status, receivedMessage.EventType });
            }
        }
    }
}