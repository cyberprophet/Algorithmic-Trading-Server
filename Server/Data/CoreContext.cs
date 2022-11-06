using Microsoft.EntityFrameworkCore;

namespace ShareInvest.Server.Data;

public class CoreContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {

    }
    public CoreContext(DbContextOptions options) : base(options)
    {

    }
}