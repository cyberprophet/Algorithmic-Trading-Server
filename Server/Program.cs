using ShareInvest;
using ShareInvest.Server.Extensions;

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
        app.UseSwagger(o =>
           {
               o.SerializeAsV2 = true;
           })
           .UseSwaggerUI(o =>
           {
               o.SwaggerEndpoint("/swagger/stock/swagger.json", "Stock");
               o.SwaggerEndpoint("/swagger/message/swagger.json", "Message");
               o.SwaggerEndpoint("/swagger/user/swagger.json", "User");
               o.SwaggerEndpoint("/swagger/account/swagger.json", "Account");
               o.SwaggerEndpoint("/swagger/balance/swagger.json", "Balance");
               o.SwaggerEndpoint("/swagger/file/swagger.json", "File");

               o.RoutePrefix = "api";
           })
           .UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error")
           .UseHsts();
    }
#if DEBUG
    app.UseHttpsRedirection();
#endif

    app.UseBlazorFrameworkFiles()
       .UseStaticFiles()
       .UseRouting();

    app.MapRazorPages();
    app.MapControllers();
    app.MapFallbackToFile("index.html");
    app.ConfigureHubs();
    app.Run();
}