using Microsoft.AspNetCore.SignalR;

using ShareInvest.Infrastructure;
using ShareInvest.Server.Hubs;

namespace ShareInvest.Server.Services;

public class HubService : BackgroundService
{
    public HubService(ILogger<HubService> logger,
                      IHubContext<KiwoomHub, IHubs> kiwoom)
    {
        this.logger = logger;
        this.kiwoom = kiwoom;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (stoppingToken.IsCancellationRequested is false)
        {
            await Task.Delay(0x400 * 9, stoppingToken);
        }
        logger.LogInformation(nameof(HubService));
    }
    readonly IHubContext<KiwoomHub, IHubs> kiwoom;
    readonly ILogger<HubService> logger;
}