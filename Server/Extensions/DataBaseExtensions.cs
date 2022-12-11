using Microsoft.EntityFrameworkCore;

using ShareInvest.Server.Data;
using ShareInvest.Server.Data.Models;
using ShareInvest.Server.Properties;

namespace ShareInvest.Server.Extensions;

public static class DataBaseExtensions
{
    public static WebApplicationBuilder ConfigureDataBases(this WebApplicationBuilder builder)
    {
        builder.Services
               .AddDbContext<CoreContext>(o =>
               {
                   o.UseSqlServer(builder.Configuration.GetConnectionString(Resources.CORE));
               })
               .AddDatabaseDeveloperPageExceptionFilter()
               .AddDefaultIdentity<CoreUser>(o =>
               {
                   o.Lockout.AllowedForNewUsers = false;
                   o.Lockout.MaxFailedAccessAttempts = 0xA;
                   o.Password.RequireUppercase = false;
                   o.Password.RequiredLength = 0xA;
                   o.User.RequireUniqueEmail = true;
               })
               .AddEntityFrameworkStores<CoreContext>();

        return builder;
    }
}