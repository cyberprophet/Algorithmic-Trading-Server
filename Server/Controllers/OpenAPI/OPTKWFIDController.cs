using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ShareInvest.Identifies;
using ShareInvest.Mappers.Kiwoom;
using ShareInvest.Models.OpenAPI.Response;
using ShareInvest.Server.Data;
using ShareInvest.Server.Services;

namespace ShareInvest.Server.Controllers.OpenAPI;

public class OPTKWFIDController : KiwoomController
{
    [ApiExplorerSettings(GroupName = "stock"),
     HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] string? order,
                                              [FromQuery] bool asc)
    {
        if (context.OPTKWFID != null)
        {
            var db = context.OPTKWFID.AsNoTracking();

            if (await db.MaxAsync(o => o.Date) is string today)
            {
                IEnumerable<OPTKWFID> res = from o in db
                                            where today.Equals(o.Date)
                                            select o;

                res = asc ? service.OrderBy(Parameter.TransformInbound(order), res) :
                            service.OrderByDescending(Parameter.TransformInbound(order), res);

                return Ok(res.Select(o =>
                {
                    var operation = MarketOperation.Get(stock.MarketOperation[0]);

                    if (operation >= EnumMarketOperation.장시작 &&
                        operation < EnumMarketOperation.장마감 &&
                        o.Code?.Length == 6 &&
                        stock.StocksConclusion.TryGetValue(o.Code, out string? data))
                    {
                        var stock = data.Split('\t');

                        return new Models.Stock
                        {
                            Code = o.Code,
                            Name = o.Name,
                            Current = stock[1],
                            Rate = stock[3],
                            CompareToPreviousDay = stock[2],
                            CompareToPreviousSign = stock[0xC],
                            Volume = stock[7],
                            TransactionAmount = stock[8],
                            State = o.State
                        };
                    }
                    return new Models.Stock
                    {
                        Code = o.Code,
                        Name = o.Name,
                        Current = o.Current,
                        Rate = o.Rate,
                        CompareToPreviousDay = o.CompareToPreviousDay,
                        CompareToPreviousSign = o.CompareToPreviousSign,
                        Volume = o.Volume,
                        TransactionAmount = o.TransactionAmount,
                        State = o.State
                    };
                }));
            }
        }
        return NoContent();
    }
    [ApiExplorerSettings(GroupName = "stock"),
     HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] OPTKWFID param)
    {
        if (context.OPTKWFID is not null &&
            string.IsNullOrEmpty(param.Code) is false)
        {
            var tuple = await context.OPTKWFID.FindAsync(param.Code);

            if (tuple is not null)

                service.SetValuesOfColumn(tuple, param);

            else
                context.OPTKWFID.Add(param);

            return Ok(context.SaveChanges());
        }
        logger.LogWarning(nameof(OPTKWFIDController), param.Name);

        return NoContent();
    }
    public OPTKWFIDController(CoreContext context,
                              PropertyService service,
                              StockService stock,
                              ILogger<OPTKWFIDController> logger)
    {
        this.context = context;
        this.service = service;
        this.logger = logger;
        this.stock = stock;
    }
    readonly CoreContext context;
    readonly StockService stock;
    readonly PropertyService service;
    readonly ILogger<OPTKWFIDController> logger;
}