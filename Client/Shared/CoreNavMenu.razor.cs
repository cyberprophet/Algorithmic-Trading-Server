using ShareInvest.Client.Components;

namespace ShareInvest.Client.Shared;

public partial class CoreNavMenuBase : ConsoleLogger<CoreNavMenu>
{
    protected override async Task OnInitializedAsync()
    {
        try
        {

        }
        catch (Exception ex)
        {
            LogError(ex.Message);
        }
        finally
        {
            await base.OnInitializedAsync();
        }
    }
    protected internal void ToggleNavMenu()
    {
        CollapseNavMenu = CollapseNavMenu is false;
    }
    bool CollapseNavMenu
    {
        get; set;
    }
}