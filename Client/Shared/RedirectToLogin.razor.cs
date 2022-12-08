using Microsoft.AspNetCore.Components;

namespace ShareInvest.Client.Shared;

public partial class RedirectToLoginBase : ComponentBase
{
    protected override void OnInitialized()
    {
        Navigation?.NavigateTo($"account/login?returnUrl={Uri.EscapeDataString(Navigation.Uri)}");
    }
    [Inject]
    NavigationManager? Navigation
    {
        get; set;
    }
}