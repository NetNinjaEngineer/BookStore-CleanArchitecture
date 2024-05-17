namespace BookStore.Shared.Models;
public sealed class UserInfoModel : BaseModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? NormalizedEmail { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserName { get; set; }
    public bool EmailConfirmed { get; set; }
    public List<string> UserRoles { get; set; } = [];
}
