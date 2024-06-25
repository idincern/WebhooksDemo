using WebhookClient.API.Models;

namespace WebhookClient.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(NewLeadMessage newLeadMessage);
    }
}
