using Microsoft.AspNetCore.Mvc;

using ShareInvest.Models.OpenAPI;
using ShareInvest.Server.Data;
using ShareInvest.Server.Services;

namespace ShareInvest.Server.Controllers.OpenAPI;

public class KiwoomMessageController : KiwoomController
{
    [ApiExplorerSettings(GroupName = "message"),
     HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] KiwoomMessage message)
    {
        if (context.KiwoomMessages is not null)
        {
            var tuple = await context.KiwoomMessages.FindAsync(message.Key, message.Lookup);

            if (tuple is null)
                context.KiwoomMessages.Add(message);

            else
                service.SetValuesOfColumn(tuple, message);

            return Ok(context.SaveChanges());
        }
        logger.LogWarning(nameof(KiwoomMessageController), message.Code);

        return NoContent();
    }
    public KiwoomMessageController(CoreContext context,
                                   PropertyService service,
                                   ILogger<KiwoomMessageController> logger)
    {
        this.context = context;
        this.service = service;
        this.logger = logger;
    }
    readonly CoreContext context;
    readonly PropertyService service;
    readonly ILogger<KiwoomMessageController> logger;
}