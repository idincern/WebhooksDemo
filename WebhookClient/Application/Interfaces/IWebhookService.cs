using WebhookClient.API.Models;
using WebhookClient.Application.DTOs;

namespace WebhookClient.Application.Interfaces
{
    public interface IWebhookService
    {
        WebhookResponse<string> ProcessWebhook(WebhookReceivedMessage receivedDto);
    }
}
