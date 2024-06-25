using WebhookClient.API.Models;
using WebhookClient.Application.Interfaces;
using static MassTransit.Monitoring.Performance.BuiltInCounters;

namespace WebhookClient.Application.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmail(NewLeadMessage message)
        {
            Console.WriteLine($"SendEmail success. DealId: {message.DealId}, LeadName: {message.LeadName}, Email: {message.Email}, EventType: {message.EventType}");
            return Task.CompletedTask;
        }
    }
}
