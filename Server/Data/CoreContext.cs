using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using ShareInvest.Models.OpenAPI;
using ShareInvest.Models.OpenAPI.Response;

namespace ShareInvest.Server.Data;

public class CoreContext : DbContext
{
    public CoreContext(DbContextOptions options) : base(options)
    {

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
    protected override void OnModelCreating(ModelBuilder builder)
    {
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
        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.ConfigureWarnings(o =>
        {
            o.Log((RelationalEventId.ConnectionOpened, LogLevel.Information),
                  (RelationalEventId.ConnectionClosed, LogLevel.Information));
        })
            .EnableDetailedErrors();
    }
}