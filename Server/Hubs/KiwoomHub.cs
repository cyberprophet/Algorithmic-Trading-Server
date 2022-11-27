using Microsoft.AspNetCore.SignalR;

using ShareInvest.Infrastructure;
using ShareInvest.Server.Services;

namespace ShareInvest.Server.Hubs;

public class KiwoomHub : Hub<IHubs>
{
    public KiwoomHub(ILogger<KiwoomHub> logger,
                     StockService service)
    {
        this.logger = logger;
        this.service = service;
    }
    public Task GatherCluesToPrioritize(int count)
    {
        if (service.RemainingQueue.TryGetValue(Context.ConnectionId,
                                               out int queue) &&
            queue != count)
        {
            service.RemainingQueue[Context.ConnectionId] = count;

            logger.LogInformation("remaining queue for { } is { }.",
                                  Context.ConnectionId,
                                  count);
        }
        return Task.CompletedTask;
    }
    public override async Task OnConnectedAsync()
    {
        logger.LogInformation("[{ }] { } has joined the kiwoom.",
                              service.RemainingQueue.TryAdd(Context.ConnectionId,
                                                            int.MaxValue),
                              Context.ConnectionId);

        await base.OnConnectedAsync();
    }
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("[{ }] { } has left the kiwoom.",
                              service.RemainingQueue.Remove(Context.ConnectionId),
                              Context.ConnectionId);

        await base.OnDisconnectedAsync(exception);
    }
    public async Task AddToGroupAsync(string id, string code)
    {
        logger.LogInformation("{ } has joined the group { }.",
                              id,
                              code);

        await Groups.AddToGroupAsync(id, code);
    }
    public async Task RemoveFromGroupAsync(string id, string code)
    {
        logger.LogInformation("{ } has left the group { }.",
                              id,
                              code);

        await Groups.RemoveFromGroupAsync(id, code);
    }
    [HubMethodName("주식시세")]
    public void RealTypeMarketPrice(string key, string data)
    {

    }
    [HubMethodName("주식체결")]
    public void RealTypeSignStatus(string key, string data)
    {
        Clients.Group(key)
               .TransmitConclusionInformation(key, data);

        service.StocksConclusion[key] = data;
    }
    [HubMethodName("주식우선호가")]
    public void RealTypeFirstOfPrice(string key, string data)
    {

    }
    [HubMethodName("주식호가잔량")]
    public void RealTypeResidualQuantity(string key, string data)
    {

    }
    [HubMethodName("주식시간외호가")]
    public void RealTypeExtraHourPrice(string key, string data)
    {

    }
    [HubMethodName("주식당일거래원")]
    public void RealTypeMessage(string key, string data)
    {

    }
    [HubMethodName("ETF NAV")]
    public void RealTypeNAV(string key, string data)
    {

    }
    [HubMethodName("ELW 지표")]
    public void RealTypeIndicators(string key, string data)
    {

    }
    [HubMethodName("ELW 이론가")]
    public void RealTypeTheoreticalPrice(string key, string data)
    {

    }
    [HubMethodName("주식예상체결")]
    public void RealTypeEstimatedPrice(string key, string data)
    {
        Clients.Group(key)
               .TransmitConclusionInformation(key, data);

        service.StocksConclusion[key] = data;
    }
    [HubMethodName("주식종목정보")]
    public void RealTypeStockInformation(string key, string data)
    {
        logger.LogInformation("Stock Information Key is { }.\nData is { }.",
                              key,
                              data);
    }
    [HubMethodName("선물옵션우선호가")]
    public void RealTypePriorityPrice(string key, string data)
    {

    }
    [HubMethodName("선물시세")]
    public void RealTypeFuturesMarketPrice(string key, string data)
    {

    }
    [HubMethodName("선물호가잔량")]
    public void RealTypeFuturesResidualQuantity(string key, string data)
    {

    }
    [HubMethodName("선물이론가")]
    public void RealTypeFuturesTheoreticalPrice(string key, string data)
    {

    }
    [HubMethodName("옵션시세")]
    public void RealTypeOptionsMarketPrice(string key, string data)
    {

    }
    [HubMethodName("옵션호가잔량")]
    public void RealTypeOptionsResidualQuantity(string key, string data)
    {

    }
    [HubMethodName("옵션이론가")]
    public void RealTypeOptionsTheoreticalPrice(string key, string data)
    {

    }
    [HubMethodName("업종지수")]
    public void RealTypeIndex(string key, string data)
    {

    }
    [HubMethodName("업종등락")]
    public void RealTypeRate(string key, string data)
    {

    }
    [HubMethodName("장시작시간")]
    public void RealTypeOperation(string key, string data)
    {
        var operation = data.Split('\t');

        for (int i = 0; i < service.MarketOperation.Length; i++)
        {
            service.MarketOperation[i] = operation[i];
        }
        logger.LogInformation("Market Operation Key is { }.\nData is { }.",
                              key,
                              data);
    }
    [HubMethodName("VI발동/해제")]
    public void RealTypeVolatilityInterruption(string key, string data)
    {

    }
    [HubMethodName("주문체결")]
    public void RealTypeConclusion(string key, string data)
    {

    }
    [HubMethodName("파생잔고")]
    public void RealTypeFuturesBalances(string key, string data)
    {

    }
    [HubMethodName("잔고")]
    public void RealTypeBalances(string key, string data)
    {

    }
    [HubMethodName("종목프로그램매매")]
    public void RealTypeProgramTrading(string key, string data)
    {

    }
    readonly ILogger<KiwoomHub> logger;
    readonly StockService service;
}