using System.Security.Claims;

namespace BookStore.RazorPages.Models;

public sealed class DecodedToken
{
    public string? KeyId { get; set; }
    public string? Issuer { get; set; }
    public DateTime ValidTo { get; set; }
    public DateTime ValidFrom { get; set; }
    public List<Claim> Claims { get; set; } = [];
}
