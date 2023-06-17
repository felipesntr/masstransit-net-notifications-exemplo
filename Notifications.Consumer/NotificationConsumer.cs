namespace Notifications.Consumer;

using MassTransit;
using Notifications.Contracts;
using System.Text.Json;

public class NotificationConsumer : IConsumer<Notification>
{
    public Task Consume(ConsumeContext<Notification> context)
    {
        Console.WriteLine($"[{DateTime.Now}] Notificação recebida");
        Task.Delay(1000).Wait();
        return Task.CompletedTask;
    }
}


