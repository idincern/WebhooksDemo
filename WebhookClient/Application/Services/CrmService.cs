using WebhookClient.API.Models;
using WebhookClient.Application.Interfaces;

namespace WebhookClient.Application.Services
{
    public class CrmService : ICrmService
    {
        private readonly IEmailService _emailService;
        private readonly INotificationService _notificationService;

        public CrmService(IEmailService emailService, INotificationService notificationService)
        {
            _emailService = emailService;
            _notificationService = notificationService;
        }

        public async Task CreateNewLead(NewLeadMessage newLeadMessage)
        {
            await _emailService.SendEmail(newLeadMessage);
            await _notificationService.NotifySalesTeam(newLeadMessage);
        }

        public async Task UpdateDealStatus(DealStatusChangedDto message)
        {
            if (message.NewStatus == "Won")
            {
                await _notificationService.NotifyAccountManagement(message);
            }
            else if (message.NewStatus == "Lost")
            {
                await _notificationService.NotifySalesManager(message);
            }
        }
    }
}
