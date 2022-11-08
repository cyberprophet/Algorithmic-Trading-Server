using Microsoft.AspNetCore.Mvc;

using ShareInvest.Models.OpenAPI.Response;
using ShareInvest.Server.Data;
using ShareInvest.Server.Services;

namespace ShareInvest.Server.Controllers.OpenAPI;

[Route("open-api")]
public class OPW00004Controller : KiwoomController
{
    [HttpPost,
     Route("balance")]
    public async Task<IActionResult> PostAsync([FromBody] Balance bal)
    {
        if (context.Balances is not null)
        {
            bal.Lookup = DateTime.Now.Ticks;

            var tuple = await context.Balances.FindAsync(bal.AccNo,
                                                         bal.Date,
                                                         bal.Code);
            if (tuple is null)
                context.Balances.Add(bal);

            else
                service.SetValuesOfColumn(tuple, bal);

            return Ok(context.SaveChanges());
        }
        logger.LogWarning(nameof(OPW00004Controller), bal.Name);

        return NoContent();
    }
    [HttpPost,
     Route("account")]
    public async Task<IActionResult> PostAsync([FromBody] Account acc)
    {
        if (context.Accounts is not null)
        {
            acc.Lookup = DateTime.Now.Ticks;

            var tuple = await context.Accounts.FindAsync(acc.AccNo, acc.Date);

            if (tuple is null)
                context.Accounts.Add(acc);

            else
                service.SetValuesOfColumn(tuple, acc);

            return Ok(context.SaveChanges());
        }
        logger.LogWarning(nameof(OPW00004Controller), acc.AccNo);

        return NoContent();
    }
    public OPW00004Controller(CoreContext context,
                              PropertyService service,
                              ILogger<OPW00004Controller> logger)
    {
        this.context = context;
        this.service = service;
        this.logger = logger;
    }
    readonly CoreContext context;
    readonly PropertyService service;
    readonly ILogger<OPW00004Controller> logger;
}