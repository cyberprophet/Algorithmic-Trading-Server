using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using ShareInvest.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped(o => new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    })
    .AddLogging(o =>
    {
        o.AddDebug();
    });
builder.Logging.AddDebug();

if (builder.Build() is WebAssemblyHost host)
{
    await host.RunAsync();
}