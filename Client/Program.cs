using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using ShareInvest.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<HttpClient>(o => o.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddApiAuthorization(o =>
{
    o.AuthenticationPaths.LogInPath = "account/login";
    o.AuthenticationPaths.LogInCallbackPath = "account/login-callback";
    o.AuthenticationPaths.LogInFailedPath = "account/login-failed";
    o.AuthenticationPaths.LogOutPath = "account/logout";
    o.AuthenticationPaths.LogOutCallbackPath = "account/logout-callback";
    o.AuthenticationPaths.LogOutFailedPath = "account/logout-failed";
    o.AuthenticationPaths.LogOutSucceededPath = "account/logged-out";
    o.AuthenticationPaths.ProfilePath = "account/profile";
    o.AuthenticationPaths.RegisterPath = "account/register";
});
builder.Logging.AddDebug();

if (builder.Build() is WebAssemblyHost host)
{
    await host.RunAsync();
}