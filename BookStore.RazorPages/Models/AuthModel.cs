namespace BookStore.RazorPages.Models;

public record AuthModel(
    string? Message,
    string? Token,
    string? UserName,
    string? Email,
    bool IsAuthenticated,
    DateTime ExpiresOn,
    string? UserId,
    bool IsEmailConfirmed)
{
    public List<string> Roles { get; set; } = new();
}