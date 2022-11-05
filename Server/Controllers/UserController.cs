using Microsoft.AspNetCore.Mvc;

namespace ShareInvest.Server.Controllers;

[ApiController,
 Produces("application/json"),
 Route("core/[controller]"),
 ProducesResponseType(StatusCodes.Status200OK),
 ProducesResponseType(StatusCodes.Status204NoContent)]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Models.OpenAPI.User user)
    {
        return NoContent();
    }
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return NoContent();
    }
}