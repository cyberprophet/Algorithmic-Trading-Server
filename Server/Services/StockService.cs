namespace ShareInvest.Server.Services;

public class StockService
{
    public Dictionary<string, string> StocksConclusion
    {
        get;
    }
    public Dictionary<string, int> RemainingQueue
    {
        get;
    }
    public string[] MarketOperation
    {
        get;
    }
    public StockService()
    {
        StocksConclusion = new Dictionary<string, string>();
        RemainingQueue = new Dictionary<string, int>();
        MarketOperation = new string[3];
    }
}