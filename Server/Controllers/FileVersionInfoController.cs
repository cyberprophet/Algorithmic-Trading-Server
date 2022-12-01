using Microsoft.AspNetCore.Mvc;

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
        if (context.FileVersions != null &&
            string.IsNullOrEmpty(fileVersionInfo.App) is false)
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
            {
                DirectoryInfo di = new(Path.Combine(env.WebRootPath,
                                                    fileVersionInfo.App));

                context.FileVersions.Add(fileVersionInfo);

                if (di.Exists is false)
                    di.Create();
            }
            if (context.SaveChanges() > 0)
            {
                string? path = null;

                if (env.ApplicationName.Equals(fileVersionInfo.App,
                                               StringComparison.OrdinalIgnoreCase))
                {

                }
                else
                {
                    if (string.IsNullOrEmpty(fileVersionInfo.Path) is false &&
                        string.IsNullOrEmpty(fileVersionInfo.FileName) is false)
                    {
                        if (nameof(FileVersionInfo.Publish).Equals(fileVersionInfo.Path,
                                                                   StringComparison.OrdinalIgnoreCase))
                        {
                            path = Path.Combine(env.WebRootPath,
                                                fileVersionInfo.App,
                                                fileVersionInfo.FileName);
                        }
                        else
                            path = Path.Combine(env.WebRootPath,
                                                fileVersionInfo.App,
                                                fileVersionInfo.Path[8..],
                                                fileVersionInfo.FileName);

                        if (fileVersionInfo.File != null)
                            await System.IO.File.WriteAllBytesAsync(path,
                                                                    fileVersionInfo.File);
                    }
                    logger.LogInformation("Environment Name: { }\nApplication Name: { }\nContent Root Path: { }\nWeb Root Path: { }",
                                          env.EnvironmentName,
                                          env.ApplicationName,
                                          env.ContentRootPath,
                                          env.WebRootPath);
                }
                return Ok(string.IsNullOrEmpty(path) is false &&
                          new FileInfo(path).Exists);
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