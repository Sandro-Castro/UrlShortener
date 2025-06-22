using UrlShortener.Models;

namespace UrlShortener.Services;

public interface IUrlService
{
    Task<UrlMapping> CreateAsync(string originalUrl);
    Task<UrlMapping?> GetByKeyAsync(string key);
}
