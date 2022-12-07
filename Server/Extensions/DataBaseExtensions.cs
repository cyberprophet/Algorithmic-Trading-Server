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
                   o.SignIn.RequireConfirmedAccount = true;
               })
               .AddEntityFrameworkStores<CoreContext>();

        builder.Services
               .AddIdentityServer(o =>
               {
                   o.LicenseKey = builder.Configuration["DuendeLicenseKey"];
                   o.KeyManagement.Enabled = false;
               })
               .AddApiAuthorization<CoreUser, CoreContext>(o =>
               {
                   
               });
        return builder;
    }
}