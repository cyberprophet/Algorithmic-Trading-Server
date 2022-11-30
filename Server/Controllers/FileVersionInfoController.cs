using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using ShareInvest.Mappers;
using ShareInvest.Models;
using ShareInvest.Server.Data;

namespace ShareInvest.Server.Controllers;

[ApiController,
 Produces("application/json"),
 Route("open-api/[controller]"),
 ProducesResponseType(StatusCodes.Status200OK),
 ProducesResponseType(StatusCodes.Status204NoContent)]
public class FileVersionInfoController : ControllerBase
{
    [ApiExplorerSettings(GroupName = "file"),
     HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] FileVersionInfo fileVersionInfo)
    {
        if (context.FileVersions != null)
        {
            var tuple = await context.FileVersions.FindAsync(fileVersionInfo.App,
                                                             fileVersionInfo.Path,
                                                             fileVersionInfo.FileName);
            if (tuple != null)
            {
                property.SetValuesOfColumn(tuple,
                                           fileVersionInfo);
            }
            else
                context.FileVersions.Add(fileVersionInfo);

            if (context.SaveChanges() > 0)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(new
                {
                    env.EnvironmentName,
                    env.ApplicationName,
                    env.ContentRootPath,
                    env.WebRootPath
                },
                Formatting.Indented));
#endif
            }
            logger.LogInformation("{ } { } file not saved.",
                                  fileVersionInfo.App,
                                  fileVersionInfo.FileName);
        }
        logger.LogWarning("in the process of saving { } { }.",
                          fileVersionInfo.App,
                          fileVersionInfo.FileName);

        return NoContent();
    }
    public FileVersionInfoController(ILogger<FileVersionInfoController> logger,
                                     IWebHostEnvironment env,
                                     IPropertyService property,
                                     CoreContext context)
    {
        this.env = env;
        this.property = property;
        this.logger = logger;
        this.context = context;
    }
    readonly ILogger<FileVersionInfoController> logger;
    readonly IWebHostEnvironment env;
    readonly IPropertyService property;
    readonly CoreContext context;
}