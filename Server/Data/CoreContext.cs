using Duende.IdentityServer.EntityFramework.Extensions;
using Duende.IdentityServer.EntityFramework.Options;

using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

using ShareInvest.Models;
using ShareInvest.Models.OpenAPI;
using ShareInvest.Models.OpenAPI.Response;
using ShareInvest.Server.Data.Models;

namespace ShareInvest.Server.Data;

public class CoreContext : ApiAuthorizationDbContext<CoreUser>
{
    public CoreContext(DbContextOptions options,
                       IOptions<OperationalStoreOptions> store) : base(options, store)
    {
        this.store = store;
    }
    public DbSet<KiwoomUser>? KiwoomUsers
    {
        get; set;
    }
    public DbSet<KiwoomMessage>? KiwoomMessages
    {
        get; set;
    }
    public DbSet<OPTKWFID>? OPTKWFID
    {
        get; set;
    }
    public DbSet<BalanceOPW00004>? Balances
    {
        get; set;
    }
    public DbSet<AccountOPW00004>? Accounts
    {
        get; set;
    }
    public DbSet<BalanceOPW00005>? ClosedBalances
    {
        get; set;
    }
    public DbSet<AccountOPW00005>? ClosedAccounts
    {
        get; set;
    }
    public DbSet<FileVersionInfo>? FileVersions
    {
        get; set;
    }
    public DbSet<IntegrationAccount>? Integrations
    {
        get; set;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IntegrationAccount>(o =>
        {
            o.HasKey(o => o.Id);
            o.Property(o => o.SerialNumber).IsRequired();
            o.Property(o => o.AccountNumber).IsRequired();
            o.ToTable(nameof(IntegrationAccount));
        });
        builder.Entity<FileVersionInfo>(o =>
        {
            o.HasKey(o => new
            {
                o.App,
                o.Path,
                o.FileName
            });
            o.ToTable(nameof(FileVersionInfo));
        });
        builder.Entity<AccountOPW00005>(o =>
        {
            o.HasKey(o => new
            {
                o.AccNo,
                o.Date
            });
            o.ToTable(nameof(AccountOPW00005));
        });
        builder.Entity<BalanceOPW00005>(o =>
        {
            o.HasKey(o => new
            {
                o.AccNo,
                o.Date,
                o.Code
            });
            o.ToTable(nameof(BalanceOPW00005));
        });
        builder.Entity<AccountOPW00004>(o =>
        {
            o.HasKey(o => new
            {
                o.AccNo,
                o.Date
            });
            o.ToTable(nameof(AccountOPW00004));
        });
        builder.Entity<BalanceOPW00004>(o =>
        {
            o.HasKey(o => new
            {
                o.AccNo,
                o.Date,
                o.Code
            });
            o.ToTable(nameof(BalanceOPW00004));
        });
        builder.Entity<OPTKWFID>(o =>
        {
            o.HasKey(o => o.Code);
            o.ToTable(nameof(OPTKWFID));
        });
        builder.Entity<KiwoomMessage>(o =>
        {
            o.HasKey(o => new
            {
                o.Key,
                o.Lookup
            });
            o.ToTable(nameof(KiwoomMessage));
        });
        builder.Entity<KiwoomUser>(o =>
        {
            o.HasKey(o => new
            {
                o.Key,
                o.AccNo
            });
            o.ToTable(nameof(KiwoomUser));
        });
        builder.ConfigurePersistedGrantContext(store.Value);
        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.ConfigureWarnings(o =>
        {
            o.Log((RelationalEventId.ConnectionOpened,
                   LogLevel.Information),
                  (RelationalEventId.ConnectionClosed,
                   LogLevel.Information));
        })
               .EnableDetailedErrors();
    }
    readonly IOptions<OperationalStoreOptions> store;
}