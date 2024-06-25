namespace WebhookClient.API.Models
{
    public record DealStatusChangedDto(int DealId, string OldStatus, string NewStatus);
}
