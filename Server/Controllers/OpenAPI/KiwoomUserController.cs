using Microsoft.AspNetCore.Mvc;

using ShareInvest.Models.OpenAPI;
using ShareInvest.Server.Data;
using ShareInvest.Server.Services;

namespace ShareInvest.Server.Controllers.OpenAPI;

[ApiController,
 Produces("application/json"),
 Route("core/[controller]")]
public class KiwoomUserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] KiwoomUser user)
    {
        if (context.KiwoomUsers is not null &&
            string.IsNullOrEmpty(user.Key) is false)
        {
            var tuple = await context.KiwoomUsers.FindAsync(user.Key);

            if (tuple is not null)

                service.SetValueOfColumn(tuple, user);

            else
                context.KiwoomUsers.Add(user);

            return Ok(context.SaveChanges());
        }
        logger.LogWarning(nameof(KiwoomUserController), user.Key);

        return NoContent();
    }
    public KiwoomUserController(CoreContext context,
                                PropertyService service,
                                ILogger<KiwoomUserController> logger)
    {
        this.context = context;
        this.service = service;
        this.logger = logger;
    }
    readonly CoreContext context;
    readonly PropertyService service;
    readonly ILogger<KiwoomUserController> logger;
}