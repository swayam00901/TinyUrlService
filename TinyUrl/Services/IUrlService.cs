using System.Collections.Generic;
using System.Threading.Tasks;
using TinyUrl.Models;

public interface IUrlService
{
    Task<UrlEntry> CreateUrlAsync(string longUrl, string? customShortCode = null);
    Task DeleteUrlAsync(string shortCode);
    Task<UrlEntry?> GetUrlAsync(string shortCode);
    Task<UrlEntry?> GetUrlStatsAsync(string shortCode);
    IEnumerable<UrlEntry> GetAllUrls();
}
