namespace BookStore.Shared.Models;
public sealed class ResetPasswordModel : BaseModel
{
    public string? NewPassword { get; set; }
    public string? Token { get; set; }

}
