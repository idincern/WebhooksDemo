// Application/Consumers/WebhookReceivedConsumer.cs
using MassTransit;
using WebhookClient.Application.DTOs;
using WebhookClient.Application.Interfaces;

namespace WebhookClient.Application.Consumers
{
    public class WebhookReceivedConsumer : IConsumer<WebhookReceivedMessage>
    {
        private readonly IWebhookService _webhookService;
        private readonly ILogger<WebhookReceivedConsumer> _logger;

        public WebhookReceivedConsumer(IWebhookService webhookService, ILogger<WebhookReceivedConsumer> logger)
        {
            _webhookService = webhookService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<WebhookReceivedMessage> context)
        {
            var message = context.Message;
            _logger.LogInformation($"Processing webhook: {message.DeliveryId}");

            var receivedDto = new WebhookReceivedDto(message.DeliveryId, message.Status);

            var response = _webhookService.ProcessWebhook(receivedDto);

            if (response.StatusCodes == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"Webhook processed successfully: {message.DeliveryId}");
            }
            else
            {
                _logger.LogWarning($"Webhook processing failed: {message.DeliveryId}");
            }

            await Task.CompletedTask;
        }
    }
}