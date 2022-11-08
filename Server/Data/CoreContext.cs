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
    public DbSet<Balance>? Balances
    {
        get; set;
    }
    public DbSet<Account>? Accounts
    {
        get; set;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Account>(o =>
        {
            o.HasKey(o => new
            {
                o.AccNo,
                o.Date
            });
            o.ToTable(nameof(Account));
        });
        builder.Entity<Balance>(o =>
        {
            o.HasKey(o => new
            {
                o.AccNo,
                o.Date,
                o.Code
            });
            o.ToTable(nameof(Balance));
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