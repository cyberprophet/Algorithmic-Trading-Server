using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using ShareInvest.Models.OpenAPI;

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
    protected override void OnModelCreating(ModelBuilder builder)
    {
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
        builder.EnableDetailedErrors()
               .ConfigureWarnings(o =>
               {
                   o.Log((RelationalEventId.ConnectionOpened, LogLevel.Information),
                         (RelationalEventId.ConnectionClosed, LogLevel.Information));
               });
    }
}