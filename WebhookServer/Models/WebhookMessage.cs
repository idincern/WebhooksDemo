using System.ComponentModel.DataAnnotations;

namespace WebhookServer.Models
{
    public class WebhookMessage
    {
        [Required]
        public int DeliveryId { get; set; }
        [Required]
        public string Status { get; set; } = default!;
        [Required]
        public string EventType { get; set; } = default!;
    }
}
