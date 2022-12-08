using Microsoft.AspNetCore.Server.Kestrel.Core;

using ShareInvest.Mappers;
using ShareInvest.Server.Services;

using System.Security.Cryptography.X509Certificates;

namespace ShareInvest.Server.Extensions;

public static class ServiceExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services
               .AddScoped<IPropertyService, PropertyService>()
               .AddSingleton<StockService>()
               .AddHostedService<HubService>()
               .Configure<KestrelServerOptions>(o =>
               {
                   o.ListenAnyIP(0x2527/*, o =>
                   {
                       o.UseHttps(StoreName.My,
                                  builder.Configuration["Certificate"],
                                  true)
                        .UseConnectionLogging();
                   }*/);
                   o.Limits.MaxRequestBodySize = null;
               });
        return builder;
    }
}