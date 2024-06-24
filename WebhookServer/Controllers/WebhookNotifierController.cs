using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using WebhookServer.Models;
using WebhookServer.Options;

namespace WebhookServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebhookNotifierController(IOptions<WebhookOptions> webhookOptions) : ControllerBase
    {
        private readonly WebhookOptions _webhookOptions = webhookOptions.Value;
        private static readonly HttpClient client = new HttpClient();
        //private const string WebhookUrl = "https://localhost:7145/webhook"; // URL of the webhook receiver

        [HttpPost]
        public async Task<IActionResult> NotifyWebhook(WebhookMessage webhookMessage)
        {
            var webhookUrl = _webhookOptions.Url; // Get webhook Url from env variables
            if (webhookUrl is null)
            {
                return StatusCode(404, "No webhook url was found.");
            }

            var json = JsonSerializer.Serialize(webhookMessage);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(webhookUrl, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Message {webhookMessage.DeliveryId} sent to webhook {webhookMessage.Status}");
                return Ok("Webhook notification sent successfully.");
            }
            Console.WriteLine($"Failed to send webhook notification.");
            return StatusCode(500, "Failed to send webhook notification.");
        }
    }
}
