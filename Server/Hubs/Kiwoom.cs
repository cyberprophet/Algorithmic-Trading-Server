using Microsoft.AspNetCore.SignalR;

using ShareInvest.Infrastructure;
using ShareInvest.Observers;

namespace ShareInvest.Server.Hubs;

public class Kiwoom : Hub<IHubs>
{
    public event EventHandler<MessageEventArgs>? Send;

    public Kiwoom(ILogger<Kiwoom> logger)
    {
        this.logger = logger;
    }
    public void GatherCluesToPrioritize(int count)
    {

    }
    public override async Task OnConnectedAsync()
    {
        logger.LogInformation("{id} has joined the kiwoom.",
                              Context.ConnectionId);

        await base.OnConnectedAsync();
    }
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("{id} has left the kiwoom.",
                              Context.ConnectionId);

        await base.OnDisconnectedAsync(exception);
    }
    readonly ILogger<Kiwoom> logger;
}