using Microsoft.Extensions.Logging;
using System.Net;
using WebhookClient.API.Models;
using WebhookClient.Application.DTOs;
using WebhookClient.Application.Interfaces;
using WebhookClient.Domain.Entities;

namespace WebhookClient.Application.Services
{
    public class WebhookService(IWebhookRepository repository, ILogger<WebhookService> logger) : IWebhookService
    {
        private readonly IWebhookRepository _repository = repository;
        private readonly ILogger<WebhookService> _logger = logger;

        public WebhookResponse<string> ProcessWebhook(WebhookReceivedDto update)
        {
            try
            {
                _repository.SaveWebhookUpdate(update);
                _logger.LogInformation($"{DateTime.UtcNow}: Update {update.DeliveryId}: {update.Status} has saved to database.");
                return WebhookResponse<string>.Success("Processed webhook successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing webhook.");
                return WebhookResponse<string>.Fail("Error processing webhook.");
            }
        }
    }
}
