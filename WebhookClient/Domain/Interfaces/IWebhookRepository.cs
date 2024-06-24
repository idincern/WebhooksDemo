using WebhookClient.Application.DTOs;
using WebhookClient.Domain.Entities;

namespace WebhookClient.Domain.Interfaces
{
    public interface IWebhookRepository
    {
        void SaveWebhookUpdate(WebhookReceivedDto update);
    }
}
