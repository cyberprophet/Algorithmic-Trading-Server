using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;

namespace ShareInvest.Server.Controllers
{
    public class OidcConfigurationController : Controller
    {
        [HttpGet("_configuration/{clientId}"),
         ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        {
            logger.LogInformation(nameof(GetClientRequestParameters),
                                  clientId);

            return Ok(ClientRequestParametersProvider.GetClientParameters(HttpContext,
                                                                          clientId));
        }
        public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider,
                                           ILogger<OidcConfigurationController> logger)
        {
            ClientRequestParametersProvider = clientRequestParametersProvider;

            this.logger = logger;
        }
        IClientRequestParametersProvider ClientRequestParametersProvider
        {
            get;
        }
        readonly ILogger<OidcConfigurationController> logger;
    }
}