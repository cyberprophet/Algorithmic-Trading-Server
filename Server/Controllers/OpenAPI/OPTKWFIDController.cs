using Microsoft.AspNetCore.Mvc;

using ShareInvest.Models.OpenAPI.Response;
using ShareInvest.Server.Data;
using ShareInvest.Server.Services;

namespace ShareInvest.Server.Controllers.OpenAPI;

[ApiController,
 Produces("application/json"),
 Route("core/[controller]")]
public class OPTKWFIDController : ControllerBase
{
    [HttpPost]
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
                              ILogger<OPTKWFIDController> logger)
    {
        this.context = context;
        this.service = service;
        this.logger = logger;
    }
    readonly CoreContext context;
    readonly PropertyService service;
    readonly ILogger<OPTKWFIDController> logger;
}