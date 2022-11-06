using Microsoft.AspNetCore.Mvc.ApplicationModels;

using ShareInvest.Server.Extensions.Options;

namespace ShareInvest.Server.Extensions;

public static class ControllerExtensions
{
    public static WebApplicationBuilder ConfigureControllers(this WebApplicationBuilder builder)
    {
        var paramTransformer = new SlugifyParameterTransformer();

        builder.Services
            .AddControllersWithViews(o =>
            {
                o.Conventions.Add(new RouteTokenTransformerConvention(paramTransformer));
            })
            .AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.WriteIndented = Status.IsDebugging;
            });
        return builder;
    }
}