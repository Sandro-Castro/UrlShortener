using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.Models;

public class UrlMapping
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public string OriginalUrl { get; set; } = null!;

    [Required]
    public string Key { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
