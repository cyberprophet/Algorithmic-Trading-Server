using Microsoft.AspNetCore.Mvc;

using ShareInvest.Models.OpenAPI;

namespace ShareInvest.Server.Controllers.OpenAPI;

[ApiController,
 Produces("application/json"),
 Route("core/[controller]")]
public class KiwoomUserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] KiwoomUser user)
    {


        return NoContent();
    }
}