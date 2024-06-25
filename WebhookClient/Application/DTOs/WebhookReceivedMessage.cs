namespace WebhookClient.Application.DTOs
{
    public class WebhookReceivedMessage 
    {
        public int DeliveryId { get; set; }
        public string Status { get; set; } = default!;
        public string EventType { get; set; } = default!;
        public DateTime Timestamp {  get; set; }
    };
}