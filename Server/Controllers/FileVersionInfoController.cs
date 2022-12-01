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
                context.FileVersions.Add(fileVersionInfo);

            if (context.SaveChanges() > 0)
            {
                if (fileVersionInfo.File != null &&
                    string.IsNullOrEmpty(fileVersionInfo.Path) is false &&
                    string.IsNullOrEmpty(fileVersionInfo.FileName) is false)
                {
                    var path = Path.Combine(env.WebRootPath,
                                            fileVersionInfo.Path.Replace(nameof(FileVersionInfo.Publish),
                                                                         fileVersionInfo.App,
                                                                         StringComparison.OrdinalIgnoreCase),
                                            fileVersionInfo.FileName);

                    if (Path.GetDirectoryName(path) is string directory)
                    {
                        DirectoryInfo di = new(directory);

                        if (di.Exists is false)
                            di.Create();
                    }
                    await System.IO.File.WriteAllBytesAsync(path,
                                                            fileVersionInfo.File);

                    FileInfo fi = new(path);

                    if (fi.Exists)
                    {
                        logger.LogInformation("Installed file is { }.",
                                              fi.FullName);

                        return Ok(fi.LastWriteTime);
                    }
                }
                logger.LogInformation("Environment Name: { }\nApplication Name: { }\nContent Root Path: { }\nWeb Root Path: { }",
                                      env.EnvironmentName,
                                      env.ApplicationName,
                                      env.ContentRootPath,
                                      env.WebRootPath);
            }
            logger.LogWarning("{ } { } file not saved.",
                              fileVersionInfo.App,
                              fileVersionInfo.FileName);
        }
        logger.LogError("in the process of saving { } { }.",
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