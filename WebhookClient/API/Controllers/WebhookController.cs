using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebhookClient.API.Models;
using WebhookClient.Application.DTOs;
using WebhookClient.Application.Interfaces;

namespace WebhookClient.API.Controllers
{
    public class WebhookController : CustomBaseController
    {
        private readonly IWebhookService _webhookService;
        private readonly ILogger<WebhookController> _logger;

        public WebhookController(IWebhookService webhookService, ILogger<WebhookController> logger)
        {
            _webhookService = webhookService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult ReceiveWebhook(WebhookReceivedDto receivedMessage)
        {
            return CreateActionResult(_webhookService.ProcessWebhook(receivedMessage), nameof(ReceiveWebhook), new {receivedMessage.DeliveryId, receivedMessage.Status});
        }
    }
}

