namespace ShareInvest.Server.Services;

public class StockService
{
    public Dictionary<string, string> Stocks
    {
        get;
    }
    public Dictionary<string, int> RemainingQueue
    {
        get;
    }
    public StockService()
    {
        Stocks = new Dictionary<string, string>();
        RemainingQueue = new Dictionary<string, int>();
    }
}