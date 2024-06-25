// Application/Consumers/WebhookReceivedConsumer.cs
using MassTransit;
using WebhookClient.Application.DTOs;
using WebhookClient.Application.Interfaces;

namespace WebhookClient.Application.Consumers
{
    public class WebhookReceivedConsumer : IConsumer<WebhookReceivedMessage>
    {
        private readonly IWebhookService _webhookService;

        public WebhookReceivedConsumer(IWebhookService webhookService)
        {
            _webhookService = webhookService;
        }

        public async Task Consume(ConsumeContext<WebhookReceivedMessage> context)
        {
            var message = context.Message;
            await Console.Out.WriteLineAsync($"Processing webhook: {message.DeliveryId}");

            var response = _webhookService.ProcessWebhook(message);

            if (response.StatusCodes == System.Net.HttpStatusCode.OK)
            {
                await Console.Out.WriteLineAsync($"Webhook processed successfully: {message.DeliveryId}");
            }
            else
            {
                await Console.Out.WriteLineAsync($"Webhook processing failed: {message.DeliveryId}");
            }

            await Task.CompletedTask;
        }
    }
}