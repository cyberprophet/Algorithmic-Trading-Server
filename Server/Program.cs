using ShareInvest;
using ShareInvest.Server.Extensions;

using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

Status.SetDebug();

builder.ConfigureControllers().Services
       .AddRazorPages(o =>
       {
#if DEBUG
           Debug.WriteLine(o.RootDirectory);
#endif
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
       .UseRouting()
       .UseAuthentication()
       .UseAuthorization();

    app.MapRazorPages();
    app.MapControllers();
    app.MapFallbackToFile("index.html");

    app.Run();
}