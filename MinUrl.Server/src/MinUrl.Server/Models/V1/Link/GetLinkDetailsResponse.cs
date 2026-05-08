namespace MinUrl.Server.Models.V1.Link;

public record GetLinkDetailsResponse(string OriginalUrl, string ShortCode, int Clicks, DateTime CreatedAt);