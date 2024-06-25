using WebhookClient.API.Models;

namespace WebhookClient.Application.Interfaces
{
    public interface INotificationService
    {
        Task NotifySalesTeam(NewLeadMessage message);
        Task NotifyAccountManagement(DealStatusChangedDto message);
        Task NotifySalesManager(DealStatusChangedDto message);
    }
}
