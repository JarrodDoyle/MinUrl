using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinUrl.Server.Models.V1.Link;
using MinUrl.Server.Services;

namespace MinUrl.Server.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class LinkController(IDbService dbService) : ControllerBase
{
    [HttpPost(Name = "CreateLink")]
    public async Task<Results<Ok<CreateLinkResponse>, BadRequest>> CreateLink(CreateLinkRequest req)
    {
        if (!UrlIsValid(req.Url))
        {
            return TypedResults.BadRequest();
        }

        var link = await dbService.CreateLink(req.Url);
        var res = new CreateLinkResponse(link.ShortCode);
        return TypedResults.Ok(res);
    }

    [HttpGet("{shortCode}", Name = "GetLinkDetails")]
    public Results<Ok<GetLinkDetailsResponse>, NotFound> GetLinkDetails(string shortCode)
    {
        if (!dbService.TryGetLink(shortCode, out var link))
        {
            return TypedResults.NotFound();
        }

        var res = new GetLinkDetailsResponse(link.OriginalUrl, link.ShortCode, link.Clicks, link.CreatedAt);
        return TypedResults.Ok(res);
    }

    private static bool UrlIsValid(string source)
    {
        return Uri.TryCreate(source, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
    }
}