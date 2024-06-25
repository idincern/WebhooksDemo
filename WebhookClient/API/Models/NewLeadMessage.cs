namespace WebhookClient.API.Models
{
    public record NewLeadMessage(int DealId, string LeadName, string Email, string EventType);
}
