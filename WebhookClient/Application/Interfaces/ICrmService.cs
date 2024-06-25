using WebhookClient.API.Models;

namespace WebhookClient.Application.Interfaces
{
    public interface ICrmService
    {
        Task CreateNewLead(NewLeadMessage message);
        Task UpdateDealStatus(DealStatusChangedDto message);
    }
}
