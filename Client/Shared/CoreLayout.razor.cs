using Microsoft.AspNetCore.Components;

namespace ShareInvest.Client.Shared;

public partial class CoreLayoutBase : LayoutComponentBase
{
    protected override async Task OnInitializedAsync()
    {
        try
        {

        }
        catch (Exception ex)
        {
            Logger?.LogError("{ } that occurred in the CoreLayout.",
                             ex.Message);
        }
        finally
        {
            await base.OnInitializedAsync();
        }
    }
    [Inject]
    ILogger<CoreLayoutBase>? Logger
    {
        get; set;
    }
}