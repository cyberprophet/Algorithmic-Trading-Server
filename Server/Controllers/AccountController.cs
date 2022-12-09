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
    public async Task<IActionResult> CheckOneSSecuritiesAccount([FromQuery] string? id)
    {
        if (context.Accounts != null)
        {
            if (string.IsNullOrEmpty(id))
            {
                var dao = await context.Accounts.AsNoTracking().AnyAsync();

                return Ok(dao);
            }
        }
        logger.LogWarning("problem the kiwoom account of the { }.",
                          id);

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
    public AccountController(CoreContext context,
                             SignInManager<CoreUser> signInManager,
                             ILogger<AccountController> logger)
    {
        this.context = context;
        this.logger = logger;
        this.signInManager = signInManager;
    }
    readonly ILogger<AccountController> logger;
    readonly SignInManager<CoreUser> signInManager;
    readonly CoreContext context;
}