using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ShareInvest.Client.Components;

public partial class ConsoleLoggerBase<T> : ComponentBase
{
    protected void LogError(string message)
    {
        Logger?.LogError("{ } that occurred in the { }.",
                         message,
                         typeof(T).Name);
    }
    protected async Task InvokeVoidAsync(string identifier,
                                         params object?[]? args)
    {
        if (Js != null)
            await Js.InvokeVoidAsync(identifier, args);
    }
    [Inject]
    ILogger<T>? Logger
    {
        get; set;
    }
    [Inject]
    IJSRuntime? Js
    {
        get; set;
    }
}