using Microsoft.AspNetCore.Mvc;

using ShareInvest.Models.OpenAPI.Response;
using ShareInvest.Server.Data;
using ShareInvest.Server.Services;

namespace ShareInvest.Server.Controllers.OpenAPI;

[Route("open-api/[action]")]
public class AccountBookController : KiwoomController
{
    [ApiExplorerSettings(GroupName = "balance"),
     HttpPost]
    public async Task<IActionResult> BalanceOPW00005([FromBody] BalanceOPW00005 bal)
    {
        if (context.ClosedBalances is not null)
        {
            if (bal.Lookup == 0)
            {
                bal.Lookup = DateTime.Now.Ticks;
            }
            var tuple = await context.ClosedBalances.FindAsync(bal.AccNo,
                                                               bal.Date,
                                                               bal.Code);
            if (tuple is null)
                context.ClosedBalances.Add(bal);

            else
                service.SetValuesOfColumn(tuple, bal);

            return Ok(context.SaveChanges());
        }
        logger.LogWarning(nameof(AccountBookController), bal.Name);

        return NoContent();
    }
    [ApiExplorerSettings(GroupName = "balance"),
     HttpPost]
    public async Task<IActionResult> BalanceOPW00004([FromBody] BalanceOPW00004 bal)
    {
        if (context.Balances is not null)
        {
            if (bal.Lookup == 0)
            {
                bal.Lookup = DateTime.Now.Ticks;
            }
            var tuple = await context.Balances.FindAsync(bal.AccNo,
                                                         bal.Date,
                                                         bal.Code);
            if (tuple is null)
                context.Balances.Add(bal);

            else
                service.SetValuesOfColumn(tuple, bal);

            return Ok(context.SaveChanges());
        }
        logger.LogWarning(nameof(AccountBookController), bal.Name);

        return NoContent();
    }
    [ApiExplorerSettings(GroupName = "account"),
     HttpPost]
    public async Task<IActionResult> AccountOPW00005([FromBody] AccountOPW00005 acc)
    {
        if (context.ClosedAccounts is not null)
        {
            if (acc.Lookup == 0)
            {
                acc.Lookup = DateTime.Now.Ticks;
            }
            var tuple = await context.ClosedAccounts.FindAsync(acc.AccNo, acc.Date);

            if (tuple is null)
                context.ClosedAccounts.Add(acc);

            else
                service.SetValuesOfColumn(tuple, acc);

            return Ok(context.SaveChanges());
        }
        logger.LogWarning(nameof(AccountBookController), acc.AccNo);

        return NoContent();
    }
    [ApiExplorerSettings(GroupName = "account"),
     HttpPost]
    public async Task<IActionResult> AccountOPW00004([FromBody] AccountOPW00004 acc)
    {
        if (context.Accounts is not null)
        {
            if (acc.Lookup == 0)
            {
                acc.Lookup = DateTime.Now.Ticks;
            }
            var tuple = await context.Accounts.FindAsync(acc.AccNo, acc.Date);

            if (tuple is null)
                context.Accounts.Add(acc);

            else
                service.SetValuesOfColumn(tuple, acc);

            return Ok(context.SaveChanges());
        }
        logger.LogWarning(nameof(AccountBookController), acc.AccNo);

        return NoContent();
    }
    public AccountBookController(CoreContext context,
                                 PropertyService service,
                                 ILogger<AccountBookController> logger)
    {
        this.context = context;
        this.service = service;
        this.logger = logger;
    }
    readonly CoreContext context;
    readonly PropertyService service;
    readonly ILogger<AccountBookController> logger;
}