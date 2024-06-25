using WebhookClient.API.Models;
using WebhookClient.Application.Interfaces;

namespace WebhookClient.Application.Services
{
    public class NotificationService : INotificationService
    {
        public Task NotifyAccountManagement(DealStatusChangedDto message)
        {
            Console.WriteLine($"NotifyAccountManagement success. DealId: {message.DealId}, OldStatus: {message.OldStatus}, NewStatus: {message.NewStatus}");
            return Task.CompletedTask;
        }

        public Task NotifySalesManager(DealStatusChangedDto message)
        {
            Console.WriteLine($"NotifySalesManager success. DealId: {message.DealId}, OldStatus: {message.OldStatus}, NewStatus: {message.NewStatus}");
            return Task.CompletedTask;
        }

        public Task NotifySalesTeam(NewLeadMessage message)
        {
            Console.WriteLine($"NotifySalesManager success. LeadName: {message.LeadName}, Email: {message.Email}, Source: {message.EventType}");
            return Task.CompletedTask;
        }
    }
}
