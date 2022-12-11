using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ShareInvest.Models;
using ShareInvest.Server.Data;
using ShareInvest.Server.Data.Models;

namespace ShareInvest.Server.Controllers;

[Route("core-api/[controller]"),
 Produces("application/json"),
 ProducesResponseType(StatusCodes.Status200OK),
 ProducesResponseType(StatusCodes.Status204NoContent),
 ApiController]
public class AccountController : ControllerBase
{
    [ApiExplorerSettings(GroupName = "account"),
     HttpGet]
    public async Task<IActionResult> CheckOneSSecuritiesAccount([FromQuery] string acc)
    {
        if (context.Accounts != null &&
            context.ClosedAccounts != null)
        {
            var dao = context.Accounts.AsNoTracking()
                                      .Where(o => acc.Equals(o.AccNo));

            var latestDate = await context.Accounts.MaxAsync(o => o.Date);

            if (string.IsNullOrEmpty(latestDate))
            {
                logger.LogInformation("no information stored in the { } account.",
                                      acc);
            }
            else
            {
                var arr = (from o in dao
                           where latestDate.Equals(o.Date)
                           join x in context.ClosedAccounts.AsNoTracking() on o.AccNo equals x.AccNo
                           where latestDate.Equals(x.Date)
                           select new Account
                           {
                               AccNo = x.AccNo,
                               NumberOfPrints = o.NumberOfPrints,
                               Balance = o.Balance,
                               Asset = o.Asset,
                               PresumeAsset = o.PresumeAsset,
                               Deposit = o.Deposit,
                               PresumeDeposit = o.PresumeDeposit,
                               TotalPurchaseAmount = o.TotalPurchaseAmount,
                               OrderableCash = x.OrderableCash,
                               Date = x.Date,
                               Balances = GetBalances(acc, latestDate)
                           })
                           .ToArray();

                if (arr.Length > 0)
                    return Ok(arr.ElementAt(arr.Length - 1));
            }
        }
        logger.LogWarning("problem the kiwoom account of the { }.",
                          acc);

        return NoContent();
    }
    [ApiExplorerSettings(GroupName = "account"),
     HttpPost]
    public async Task<IActionResult> ExternalLoginSignInAsync([FromBody] IntegrationAccount acc)
    {
        var result = await signInManager.ExternalLoginSignInAsync(acc.LoginProvider,
                                                                  acc.ProviderKey,
                                                                  false);

        if (context.Integrations != null &&
            result.Succeeded)
        {
            return Ok(from o in context.Integrations.AsNoTracking()
                      where acc.LoginProvider!.Equals(o.LoginProvider) &&
                            acc.ProviderKey!.Equals(o.ProviderKey)
                      select o.AccountNumber);
        }
        return NoContent();
    }
    [ApiExplorerSettings(GroupName = "account"),
     HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] IntegrationAccount acc)
    {
        if (context.Integrations != null)
        {
            var result = await signInManager.ExternalLoginSignInAsync(acc.LoginProvider,
                                                                      acc.ProviderKey,
                                                                      false);

            if (string.IsNullOrEmpty(acc.SerialNumber) is false &&
                string.IsNullOrEmpty(acc.AccountNumber) is false &&
                result.Succeeded)

                try
                {
                    var integration = context.Integrations.AsNoTracking()
                                                          .Single(o => acc.ProviderKey!.Equals(o.ProviderKey) &&
                                                                       acc.LoginProvider!.Equals(o.LoginProvider) &&
                                                                       acc.SerialNumber.Equals(o.SerialNumber) &&
                                                                       acc.AccountNumber.Equals(o.AccountNumber));

                    logger.LogInformation("registered ID is { }.", integration.Id);

                    return Ok(integration);
                }
                catch (Exception ex)
                {
                    context.Integrations.Add(acc);

                    logger.LogError("{ }", ex.Message);

                    return Ok(context.SaveChanges());
                }
        }
        return NoContent();
    }
    public AccountController(CoreContext context,
                             SignInManager<CoreUser> signInManager,
                             ILogger<AccountController> logger)
    {
        this.context = context;
        this.logger = logger;
        this.signInManager = signInManager;
    }
    Balance[] GetBalances(string acc, string date)
    {
        if (context.Balances != null)
        {
            return (from o in context.Balances.AsNoTracking()
                    where acc.Equals(o.AccNo) && date.Equals(o.Date)
                    select new Balance
                    {
                        Code = o.Code,
                        Name = o.Name,
                        Quantity = o.Quantity,
                        PaymentBalance = o.PaymentBalance,
                        PreviousPurchaseQuantity = o.PreviousPurchaseQuantity,
                        PreviousSalesQuantity = o.PreviousSalesQuantity,
                        PurchaseQuantity = o.PurchaseQuantity,
                        SalesQuantity = o.SalesQuantity,
                        Average = o.Average,
                        Current = o.Current,
                        Amount = o.Amount,
                        Rate = o.Rate,
                        Purchase = o.Purchase,
                        Valuation = o.Evaluation
                    })
                    .ToArray();
        }
        return Array.Empty<Balance>();
    }
    readonly ILogger<AccountController> logger;
    readonly SignInManager<CoreUser> signInManager;
    readonly CoreContext context;
}