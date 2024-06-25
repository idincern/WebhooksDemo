using WebhookClient.Application.DTOs;

namespace WebhookClient.Application.Interfaces
{
    public interface IWebhookRepository
    {
        void SaveWebhookUpdate(WebhookReceivedMessage update);
    }
}
