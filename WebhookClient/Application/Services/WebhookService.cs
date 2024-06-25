using WebhookClient.API.Models;
using WebhookClient.Application.DTOs;
using WebhookClient.Application.Interfaces;

namespace WebhookClient.Application.Services
{
    public class WebhookService(IWebhookRepository repository, ICrmService crmService) : IWebhookService
    {
        private readonly IWebhookRepository _repository = repository;
        private readonly ICrmService _crmService = crmService;

        public WebhookResponse<string> ProcessWebhook(WebhookReceivedMessage update)
        {
            try
            {
                _repository.SaveWebhookUpdate(update);

                var x = new DealStatusChangedDto ( update.DeliveryId, "empty", update.Status );
                var y = new NewLeadMessage ( update.DeliveryId, "newlead", update.Status, update.EventType );

                _crmService.UpdateDealStatus(x);
                _crmService.CreateNewLead(y);
                return WebhookResponse<string>.Success("Processed webhook successfully.");
            }
            catch (Exception ex)
            {
                return WebhookResponse<string>.Fail($"Error processing webhook. {ex.Message}");
            }
        }
    }
}
