using ShareInvest;
using ShareInvest.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

Status.SetDebug();

builder.ConfigureDataBase()
       .ConfigureControllers().Services
       .AddRazorPages(o =>
       {

       });
if (builder.Build() is WebApplication app)
{
    if (app.Environment.IsDevelopment())

        app.UseWebAssemblyDebugging();

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