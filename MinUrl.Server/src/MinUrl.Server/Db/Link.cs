using Microsoft.EntityFrameworkCore;

namespace MinUrl.Server.Db;

[Index(nameof(ShortCode), IsUnique = true)]
public record Link
{
    public int LinkId { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortCode { get; set; }
    public int Clicks { get; set; }
    public DateTime CreatedAt { get; set; }
}