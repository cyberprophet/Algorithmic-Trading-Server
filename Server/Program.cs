using ShareInvest;
using ShareInvest.Models;
using ShareInvest.Models.OpenAPI.Response;
using ShareInvest.Server.Extensions;
using ShareInvest.Server.Extensions.Options;

Status.SetDebug();

using (var app = WebApplication.CreateBuilder(args)
                               .ConfigureHubs()
                               .ConfigureServices()
                               .ConfigureDataBases()
                               .ConfigureControllers()
                               .ConfigureViews()
                               .Build())
{
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint()
           .UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error")
           .UseHsts();
    }
    app.UseHttpsRedirection()
       .UseResponseCompression()
       .UseSwagger(o =>
        {
            o.SerializeAsV2 = true;
        })
       .UseSwaggerUI(o =>
       {
           o.SwaggerEndpoint(Swagger.TransformOutbound("stock"),
                             nameof(Stock));

           o.SwaggerEndpoint(Swagger.TransformOutbound("message"),
                             nameof(Message));

           o.SwaggerEndpoint(Swagger.TransformOutbound("user"),
                             nameof(User));

           o.SwaggerEndpoint(Swagger.TransformOutbound("account"),
                             nameof(AccountBook)[..^4]);

           o.SwaggerEndpoint(Swagger.TransformOutbound("balance"),
                             nameof(BalanceOPW00004)[..7]);

           o.SwaggerEndpoint(Swagger.TransformOutbound("file"),
                             nameof(File));

           o.DocumentTitle = "Algorithmic-Trading";
           o.RoutePrefix = "api";
       })
       .UseBlazorFrameworkFiles()
       .UseStaticFiles()
       .UseRouting()
       .UseHttpLogging()
       .UseIdentityServer()
       .UseAuthentication()
       .UseAuthorization();

    app.MapRazorPages();
    app.MapControllers();
    app.MapFallbackToFile("index.html",
                          new StaticFileOptions
                          {

                          });
    app.ConfigureHubs()
       .Run();
}