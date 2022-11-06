using ShareInvest.Server.Services;

namespace ShareInvest.Server.Extensions;

public static class ServiceExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<PropertyService>();

        return builder;
    }
}