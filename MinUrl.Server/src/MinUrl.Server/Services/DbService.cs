using System.Diagnostics.CodeAnalysis;
using MinUrl.Server.Db;

namespace MinUrl.Server.Services;

public interface IDbService
{
    public Task<Link> CreateLink(string url);
    public bool TryGetLink(string shortCode, [NotNullWhen(true)] out Link? link);
}

public class DbService(LinkDbContext linkDbContext) : IDbService
{
    private Random Rnd { get; } = new();

    public async Task<Link> CreateLink(string url)
    {
        var shortCode = GenerateShortCode();
        while (linkDbContext.Links.Any(l => l.ShortCode == shortCode))
        {
            shortCode = GenerateShortCode();
        }

        var link = new Link
        {
            OriginalUrl = url,
            ShortCode = shortCode,
            CreatedAt = DateTime.Now
        };
        linkDbContext.Add(link);
        await linkDbContext.SaveChangesAsync();
        return link;
    }

    public bool TryGetLink(string shortCode, [NotNullWhen(true)] out Link? link)
    {
        link = linkDbContext.Links.FirstOrDefault(l => l.ShortCode == shortCode);
        return link != null;
    }

    private string GenerateShortCode()
    {
        const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        return Rnd.GetString(chars, 8);
    }
}