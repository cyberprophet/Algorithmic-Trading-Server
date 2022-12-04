using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;

using ShareInvest.Server.Extensions.Options;

namespace ShareInvest.Server.Extensions;

public static class ControllerExtensions
{
    public static WebApplicationBuilder ConfigureControllers(this WebApplicationBuilder builder)
    {
        var paramTransformer = new SlugifyParameterTransformer();

        builder.Services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("stock", new OpenApiInfo
            {
                Contact = new OpenApiContact
                {
                    Name = "Algorithmic-Trading",
                    Url = new Uri("http://shareinvest.net")
                },
                Description = "this version that integrates all environments",
                TermsOfService = new Uri("http://shareinvest.net/terms"),
                Title = "Algorithmic-Trading-Server"
            });
            o.SwaggerDoc("user", new OpenApiInfo
            {
                Contact = new OpenApiContact
                {
                    Name = "Algorithmic-Trading",
                    Url = new Uri("http://shareinvest.net")
                },
                Description = "this version that integrates all environments",
                TermsOfService = new Uri("http://shareinvest.net/terms"),
                Title = "Algorithmic-Trading-Server"
            });
            o.SwaggerDoc("account", new OpenApiInfo
            {
                Contact = new OpenApiContact
                {
                    Name = "Algorithmic-Trading",
                    Url = new Uri("http://shareinvest.net")
                },
                Description = "this version that integrates all environments",
                TermsOfService = new Uri("http://shareinvest.net/terms"),
                Title = "Algorithmic-Trading-Server"
            });
            o.SwaggerDoc("balance", new OpenApiInfo
            {
                Contact = new OpenApiContact
                {
                    Name = "Algorithmic-Trading",
                    Url = new Uri("http://shareinvest.net")
                },
                Description = "this version that integrates all environments",
                TermsOfService = new Uri("http://shareinvest.net/terms"),
                Title = "Algorithmic-Trading-Server"
            });
            o.SwaggerDoc("message", new OpenApiInfo
            {
                Contact = new OpenApiContact
                {
                    Name = "Algorithmic-Trading",
                    Url = new Uri("http://shareinvest.net")
                },
                Description = "this version that integrates all environments",
                TermsOfService = new Uri("http://shareinvest.net/terms"),
                Title = "Algorithmic-Trading-Server"
            });
            o.SwaggerDoc("file", new OpenApiInfo
            {
                Contact = new OpenApiContact
                {
                    Name = "Algorithmic-Trading",
                    Url = new Uri("http://shareinvest.net")
                },
                Description = "this version that integrates all environments",
                TermsOfService = new Uri("http://shareinvest.net/terms"),
                Title = "Algorithmic-Trading-Server"
            });
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