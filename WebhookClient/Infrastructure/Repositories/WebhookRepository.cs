using WebhookClient.Application.DTOs;
using WebhookClient.Application.Interfaces;

namespace WebhookClient.Infrastructure.Repositories
{
    public class WebhookRepository: IWebhookRepository
    {
        public void SaveWebhookUpdate(WebhookReceivedMessage update)
        {
            Console.WriteLine("Saved to DB");
        }
    }
}
