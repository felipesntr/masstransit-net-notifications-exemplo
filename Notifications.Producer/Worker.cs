namespace Notifications.Producer;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Notifications.Contracts;
using System.Text.Json;

public class Worker : BackgroundService
{
    private readonly IBus _bus;

    public Worker(IBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = new Notification
            {
                Title = "Notificação",
                Body = $"Teste"
            };
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:notification"));
            await endpoint.Send(message, stoppingToken);
            string notificationStr = JsonSerializer.Serialize(message);
            Console.WriteLine($"[{DateTime.Now}] Notificação enviada ");
            Task.Delay(1000).Wait();
        }
    }
}


