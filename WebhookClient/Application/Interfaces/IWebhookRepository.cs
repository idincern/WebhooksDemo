using WebhookClient.Application.DTOs;
using WebhookClient.Domain.Entities;

namespace WebhookClient.Application.Interfaces
{
    public interface IWebhookRepository
    {
        void SaveWebhookUpdate(WebhookReceivedDto update);
    }
}
