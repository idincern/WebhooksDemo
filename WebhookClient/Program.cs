using MassTransit;
using WebhookClient.Application.Consumers;
using WebhookClient.Application.Interfaces;
using WebhookClient.Application.Services;
using WebhookClient.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IWebhookRepository, WebhookRepository>();
builder.Services.AddScoped<IWebhookService, WebhookService>();

// Configure MassTransit
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<WebhookReceivedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        var rabbitConfig = builder.Configuration.GetSection("RabbitMQ");
        cfg.Host(rabbitConfig["Host"], ushort.Parse(rabbitConfig["Port"]), rabbitConfig["VirtualHost"], h =>
        {
            h.Username(rabbitConfig["Username"]);
            h.Password(rabbitConfig["Password"]);
        });
        cfg.ConfigureEndpoints(context);
    });
});

// Add MassTransit hosted service
builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();