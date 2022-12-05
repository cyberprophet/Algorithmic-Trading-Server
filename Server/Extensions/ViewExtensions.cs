using Microsoft.AspNetCore.ResponseCompression;

namespace ShareInvest.Server.Extensions;

public static class ViewExtensions
{
    public static WebApplicationBuilder ConfigureViews(this WebApplicationBuilder builder)
    {
        builder.Services
               .AddResponseCompression(o =>
               {
                   o.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
                   o.EnableForHttps = true;
               })
               .AddRazorPages(o =>
               {

               });
        return builder;
    }
}