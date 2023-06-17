using MassTransit;
using Microsoft.Extensions.Hosting;
using Notifications.Consumer;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<NotificationConsumer>();
            x.SetKebabCaseEndpointNameFormatter();
            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host("service-bus-endpoint");
                cfg.ConfigureEndpoints(context);
            });
        });
    })
    .Build();
host.Run();
