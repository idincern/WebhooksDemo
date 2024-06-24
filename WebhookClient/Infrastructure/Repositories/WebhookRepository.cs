using WebhookClient.API.Models;
using WebhookClient.Application.DTOs;
using WebhookClient.Application.Services;
using WebhookClient.Domain.Entities;
using WebhookClient.Domain.Interfaces;

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
