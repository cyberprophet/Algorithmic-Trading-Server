using Microsoft.AspNetCore.Mvc;

namespace ShareInvest.Server.Controllers;

[ApiController,
 Produces("application/json"),
 Route("open-api/[controller]"),
 ProducesResponseType(StatusCodes.Status200OK),
 ProducesResponseType(StatusCodes.Status204NoContent)]
public class KiwoomController : ControllerBase
{

}