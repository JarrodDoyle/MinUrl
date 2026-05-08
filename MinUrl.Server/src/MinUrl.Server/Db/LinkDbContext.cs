using Microsoft.EntityFrameworkCore;

namespace MinUrl.Server.Db;

public class LinkDbContext : DbContext
{
    public DbSet<Link> Links { get; set; }

    public string DbPath { get; }

    public LinkDbContext(ILogger<LinkDbContext> logger)
    {
        var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = Path.Join(localFolder, "MinUrl", "links.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}