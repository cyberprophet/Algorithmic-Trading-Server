using Microsoft.EntityFrameworkCore;

using ShareInvest.Server.Data;
using ShareInvest.Server.Properties;

namespace ShareInvest.Server.Extensions;

public static class DataBaseExtensions
{
    public static WebApplicationBuilder ConfigureDataBases(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<CoreContext>(o =>
        {
            o.UseSqlServer(builder.Configuration.GetConnectionString(Resources.CORE));
        })
            .AddDatabaseDeveloperPageExceptionFilter();

        return builder;
    }
}