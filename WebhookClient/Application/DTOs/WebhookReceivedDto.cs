using System.ComponentModel.DataAnnotations;

namespace WebhookClient.Application.DTOs
{
    public record WebhookReceivedDto(int DeliveryId, string Status);
}
