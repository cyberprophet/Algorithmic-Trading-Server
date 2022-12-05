using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;

using ShareInvest.Server.Extensions.Options;

namespace ShareInvest.Server.Extensions;

public static class ControllerExtensions
{
    public static WebApplicationBuilder ConfigureControllers(this WebApplicationBuilder builder)
    {
        SlugifyParameterTransformer paramTransformer = new();

        OpenApiInfo openApiInfo = new()
        {
            Contact = new OpenApiContact
            {
                Name = "Algorithmic-Trading",
                Url = new Uri("http://shareinvest.net")
            },
            Description = "this version that integrates all environments",
            TermsOfService = new Uri("http://shareinvest.net/terms"),
            Title = "Algorithmic-Trading-Server"
        };
        builder.Services
               .AddSwaggerGen(o =>
               {
                   o.SwaggerDoc("stock", openApiInfo);
                   o.SwaggerDoc("user", openApiInfo);
                   o.SwaggerDoc("account", openApiInfo);
                   o.SwaggerDoc("balance", openApiInfo);
                   o.SwaggerDoc("message", openApiInfo);
                   o.SwaggerDoc("file", openApiInfo);
               })
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