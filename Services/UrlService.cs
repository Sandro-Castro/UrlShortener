using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Models;
using UrlShortener.Utils;

namespace UrlShortener.Services;

public class UrlService : IUrlService
{
    private readonly AppDbContext _db;

    public UrlService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<UrlMapping> CreateAsync(string originalUrl)
    {
        var mapping = new UrlMapping { OriginalUrl = originalUrl, Key = "" };
        _db.UrlMappings.Add(mapping);
        await _db.SaveChangesAsync();

        mapping.Key = Base62Converter.Encode(mapping.Id);
        await _db.SaveChangesAsync();

        return mapping;
    }

    public async Task<UrlMapping?> GetByKeyAsync(string key)
        => await _db.UrlMappings
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Key == key);
}
