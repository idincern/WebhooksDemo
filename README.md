Using MassTransit.RabbitMQ to publish and consume the incoming webhook messages.

Requirements:
```sh
setx WEBHOOK_URL "https://localhost:7145/webhook"
```

```sh
docker pull rabbitmq:3-management
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```
