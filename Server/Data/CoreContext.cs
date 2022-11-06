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
    protected override void OnModelCreating(ModelBuilder builder)
    {
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
            o.HasKey(o => o.Key);
            o.HasIndex(o => o.Id).IsUnique();
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