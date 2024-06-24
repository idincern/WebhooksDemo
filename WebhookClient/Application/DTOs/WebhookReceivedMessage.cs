namespace WebhookClient.Application.DTOs
{
    public interface WebhookReceivedMessage
    {
        Guid Id { get; }
        int DeliveryId { get; }
        string Status { get; }
        DateTime Timestamp { get; }
    }
}