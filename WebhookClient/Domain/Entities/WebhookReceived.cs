using System.ComponentModel.DataAnnotations;

namespace WebhookClient.Domain.Entities
{
    public class WebhookReceived
    {
        [Required]
        public int DeliveryId { get; set; }
        [Required]
        public string Status { get; set; } = default!;
    }
}
