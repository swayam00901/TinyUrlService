// Controllers/UrlController.cs
using Microsoft.AspNetCore.Mvc;
using TinyUrl.Services;

[ApiController]
[Route("api/[controller]")]
public class UrlController : ControllerBase
{
    private readonly IUrlService _urlService;

    public UrlController(IUrlService urlService) => _urlService = urlService;

    [HttpPost]
    public async Task<IActionResult> CreateShortUrl([FromBody] CreateUrlRequest request)
    {
        try
        {
            var entry = await _urlService.CreateUrlAsync(request.LongUrl, request.CustomShortCode);
            return CreatedAtAction(nameof(GetUrlStats), new { shortCode = entry.ShortCode }, entry);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{shortCode}")]
    public async Task<IActionResult> DeleteUrl(string shortCode)
    {
        await _urlService.DeleteUrlAsync(shortCode);
        return NoContent();
    }

    [HttpGet("{shortCode}")]
    public async Task<IActionResult> GetUrl(string shortCode)
    {
        var entry = await _urlService.GetUrlAsync(shortCode);
        return entry != null
            ? Ok(new { entry.LongUrl }) // Return JSON with URL for tracking
            : NotFound();
    }

    [HttpGet("{shortCode}/stats")]
    public async Task<IActionResult> GetUrlStats(string shortCode)
    {
        var entry = await _urlService.GetUrlStatsAsync(shortCode);
        return entry != null ? Ok(entry) : NotFound();
    }

    [HttpGet]
    public IActionResult GetAllUrls() => Ok(_urlService.GetAllUrls());
}

public record CreateUrlRequest(string LongUrl, string? CustomShortCode = null);