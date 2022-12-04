using ShareInvest.Client.Components;
using ShareInvest.Client.Properties;
using ShareInvest.Models;

namespace ShareInvest.Client.Pages;

public partial class MapBase : ConsoleLogger<Map>
{
    protected override async Task OnInitializedAsync()
    {
        try
        {
            await Task.Delay(0x400 * 3);
        }
        catch (Exception ex)
        {
            LogError(ex.Message);
        }
        finally
        {
            Stocks = new Dictionary<string, Stock>();

            await base.OnInitializedAsync();
        }
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        try
        {
            switch (RenderingCount++)
            {
                case 2:

                    break;

                case 1:

                    await InvokeVoidAsync(Resources.INITIALIZATION);

                    break;
            }
        }
        catch (Exception ex)
        {
            LogError(ex.Message);
        }
        finally
        {
            if (firstRender)
            {
                await InvokeVoidAsync(Resources.GEO);
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
    protected internal Dictionary<string, Stock>? Stocks
    {
        get; private set;
    }
    uint RenderingCount
    {
        get; set;
    }
}