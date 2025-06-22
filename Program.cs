using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Services;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlite("Data Source=urlshortener.db"));

builder.Services.AddScoped<IUrlService, UrlService>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


app.UseDefaultFiles();
app.UseStaticFiles();


app.MapPost("/shorten", async (IUrlService svc, HttpRequest httpReq) =>
{
    var body = await httpReq.ReadFromJsonAsync<UrlRequest>();
    if (body == null || string.IsNullOrWhiteSpace(body.OriginalUrl))
        return Results.BadRequest("URL inválida");

    var mapping = await svc.CreateAsync(body.OriginalUrl);

    
    var origin = $"{httpReq.Scheme}://{httpReq.Host}";
    var shortUrl = $"{origin}/{mapping.Key}";

    return Results.Created($"/{mapping.Key}", new { key = mapping.Key, shortUrl });
});

app.MapGet("/{key}", async (IUrlService svc, string key) =>
{
    var mapping = await svc.GetByKeyAsync(key);
    if (mapping is null)
        return Results.NotFound("Chave não encontrada");

    return Results.Redirect(mapping.OriginalUrl);
});

app.Run();

public record UrlRequest(string OriginalUrl);
