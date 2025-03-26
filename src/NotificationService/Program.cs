using MassTransit;
using NotificationService.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x => 
{   
    x.AddConsumersFromNamespaceContaining<AuctionCreatedConsumer>();

    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("nt", false));

    x.UsingRabbitMq((contxt, cfg) => 
    { 
        cfg.Host(builder.Configuration["RabbitMq:Host"], "/", host => {
            host.Username(builder.Configuration.GetValue("RabbitMq:Username", "guest"));
            host.Password(builder.Configuration.GetValue("RabbitMq:Password", "guest"));
        }); 

        cfg.ConfigureEndpoints(contxt);
    });
});

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<NotificationHub>("/notifications");

app.Run();
