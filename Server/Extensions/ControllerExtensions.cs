using Microsoft.AspNetCore.Mvc.ApplicationModels;

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