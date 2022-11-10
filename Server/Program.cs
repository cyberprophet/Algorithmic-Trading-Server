using ShareInvest;
using ShareInvest.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

Status.SetDebug();

builder.ConfigureServices()
       .ConfigureDataBases()
       .ConfigureControllers().Services
       .AddRazorPages(o =>
       {

       });
if (builder.Build() is WebApplication app)
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

               o.RoutePrefix = "api";
           })
           .UseWebAssemblyDebugging();
    }
    else
        app.UseExceptionHandler("/Error")
           .UseHsts();

    app.UseHttpsRedirection()
       .UseBlazorFrameworkFiles()
       .UseStaticFiles()
       .UseRouting();

    app.MapRazorPages();
    app.MapControllers();
    app.MapFallbackToFile("index.html");

    app.Run();
}