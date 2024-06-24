# WebhookTraining

Server creates message end sends it over to the Client(postman can also be used), which is the webhook, using HttpClient. Using MassTransit and RabbitMQ to publish and consume the webhook messages.

Requirements:
```sh
setx WEBHOOK_URL "https://localhost:7145/webhook"
```

```sh
docker pull rabbitmq:3-management
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```
