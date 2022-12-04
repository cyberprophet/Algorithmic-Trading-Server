using Microsoft.AspNetCore.Server.Kestrel.Core;

using ShareInvest.Mappers;
using ShareInvest.Server.Services;

namespace ShareInvest.Server.Extensions;

public static class ServiceExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPropertyService, PropertyService>()
                        .AddSingleton<StockService>()
                        .AddHostedService<HubService>()
                        .Configure<KestrelServerOptions>(o =>
                        {
                            o.ListenAnyIP(0x2527);
                            o.Limits.MaxRequestBodySize = null;
                        });
        return builder;
    }
}