using Microsoft.AspNetCore.Http.Connections;

using ShareInvest.Server.Hubs;

namespace ShareInvest.Server.Extensions;

public static class SignalRExtensions
{
    public static WebApplicationBuilder ConfigureHubs(this WebApplicationBuilder builder)
    {
        builder.Services.AddSignalR(o =>
        {
            o.EnableDetailedErrors = true;
        });
        return builder;
    }
    public static WebApplication ConfigureHubs(this WebApplication app)
    {
        app.MapHub<KiwoomHub>(app.Configuration["Hubs:Kiwoom"], o =>
        {
            o.Transports = HttpTransportType.WebSockets |
                           HttpTransportType.LongPolling;
        });
        return app;
    }
}