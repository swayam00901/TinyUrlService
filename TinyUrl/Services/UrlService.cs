using System.Collections.Concurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyUrl.Models;

namespace TinyUrl.Services
{
    public class UrlService : IUrlService
    {
        private readonly ConcurrentDictionary<string, UrlEntry> _urls = new();
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const int ShortCodeLength = 8;
        private static readonly Random _random = new();

        public async Task<UrlEntry> CreateUrlAsync(string longUrl, string? customShortCode = null)
        {
            var shortCode = string.IsNullOrWhiteSpace(customShortCode) ? await GenerateRandomShortCodeAsync() : customShortCode.ToLower();

            var entry = new UrlEntry
            {
                ShortCode = shortCode,
                LongUrl = longUrl,
                ClickCount = 0,
                CreatedAt = DateTime.UtcNow
            };

            if (!_urls.TryAdd(shortCode, entry))
                throw new ArgumentException("Short code already exists");

            return entry;
        }

        private async Task<string> GenerateRandomShortCodeAsync()
        {
            return await Task.Run(() =>
                new string(Enumerable.Repeat(Characters, ShortCodeLength)
                    .Select(s => s[_random.Next(s.Length)]).ToArray()));
        }

        public Task DeleteUrlAsync(string shortCode)
        {
            _urls.TryRemove(shortCode, out _);
            return Task.CompletedTask;
        }

        public Task<UrlEntry?> GetUrlAsync(string shortCode)
        {
            //shortCode = shortCode.ToLower();

            return _urls.TryGetValue(shortCode, out var entry)
                ? Task.FromResult<UrlEntry?>(_urls.AddOrUpdate(
                    shortCode,
                    _ => entry, // Will never be called for existing entries
                    (_, existing) => new UrlEntry
                    {
                        ShortCode = existing.ShortCode,
                        LongUrl = existing.LongUrl,
                        ClickCount = existing.ClickCount + 1,
                        CreatedAt = existing.CreatedAt
                    }))
                : Task.FromResult<UrlEntry?>(null);
        }

        public Task<UrlEntry?> GetUrlStatsAsync(string shortCode)
        {
            _urls.TryGetValue(shortCode.ToLower(), out var entry);
            return Task.FromResult(entry);
        }

        public IEnumerable<UrlEntry> GetAllUrls() => _urls.Values;
    }
}
