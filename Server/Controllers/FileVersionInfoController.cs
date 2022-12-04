using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ShareInvest.Identifies;
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
     HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] string app,
                                              [FromQuery] string? path,
                                              [FromQuery] string? name)
    {
        app = Parameter.TransformInbound(app);

        if (context.FileVersions != null &&
            env.ApplicationName.Equals(app,
                                       StringComparison.OrdinalIgnoreCase) is false)
        {
            var dao = context.FileVersions.AsNoTracking()
                                          .Where(o => app.Equals(o.App));

            name = Parameter.TransformInbound(name);

            if (string.IsNullOrEmpty(name))
                return Ok(dao);

            path = Parameter.TransformInbound(path);

            Infrastructure.Local.File file = string.IsNullOrEmpty(path) ?

                                             new(Path.Combine(env.WebRootPath,
                                                              app,
                                                              name)) :

                                             new(Path.Combine(env.WebRootPath,
                                                              app,
                                                              path,
                                                              name));
            FileVersionInfo? res = null;

            try
            {
                res = dao.Single(o => name.Equals(o.FileName));
            }
            catch (Exception exception)
            {
                res = context.FileVersions.Find(app,
                                                string.IsNullOrEmpty(path) ?
                                                nameof(FileVersionInfo.Publish) :
                                                string.Concat(nameof(FileVersionInfo.Publish),
                                                              @"\",
                                                              path),
                                                name);
                if (res != null)
                    logger.LogTrace(exception,
                                    "occured while browsing { }.",
                                    name);

                else
                    logger.LogError(exception,
                                    "\napp: { }\n\tpath: { }\n\tname: { }",
                                    app,
                                    path,
                                    name);
            }
            if (res != null)
            {
                logger.LogInformation("sends { } file of { }.", name, app);

                res.File = await file.ReadAllBytesAsync();

                return Ok(res);
            }
        }
        return NoContent();
    }
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

                    var file = await new Infrastructure.Local.File(path)
                                                             .WriteAllBytesAsync(fileVersionInfo.File);

                    if (file.Exists)
                    {
                        logger.LogInformation("Installed file is { }.",
                                              file.FullName);

                        return Ok(file.LastWriteTime);
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