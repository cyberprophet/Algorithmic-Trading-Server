using Microsoft.AspNetCore.Mvc;

using ShareInvest.Mappers;
using ShareInvest.Models.OpenAPI;
using ShareInvest.Server.Data;

namespace ShareInvest.Server.Controllers.OpenAPI;

public class KiwoomUserController : KiwoomController
{
    [ApiExplorerSettings(GroupName = "user"),
     HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] KiwoomUser user)
    {
        if (context.KiwoomUsers is not null &&
            string.IsNullOrEmpty(user.Key) is false)
        {
            var length = 1;

            do
            {
                user.AccNo = user.Accounts?[length - 1];

                var tuple = await context.KiwoomUsers.FindAsync(user.Key, user.AccNo);

                if (tuple is not null)

                    service.SetValuesOfColumn(tuple, user);

                else
                    context.KiwoomUsers.Add(user);
            }
            while (length++ < user.Accounts?.Length);

            return Ok(context.SaveChanges());
        }
        logger.LogWarning(nameof(KiwoomUserController), user.Key);

        return NoContent();
    }
    public KiwoomUserController(CoreContext context,
                                IPropertyService service,
                                ILogger<KiwoomUserController> logger)
    {
        this.context = context;
        this.service = service;
        this.logger = logger;
    }
    readonly CoreContext context;
    readonly IPropertyService service;
    readonly ILogger<KiwoomUserController> logger;
}