using WebhookClient.API.Models;
using WebhookClient.Application.DTOs;
using WebhookClient.Application.Interfaces;
using WebhookClient.Application.Services;
using WebhookClient.Domain.Entities;

namespace WebhookClient.Infrastructure.Repositories
{
    public class WebhookRepository: IWebhookRepository
    {
        public void SaveWebhookUpdate(WebhookReceivedDto update)
        {
            //save to DB...
        }
    }
}
