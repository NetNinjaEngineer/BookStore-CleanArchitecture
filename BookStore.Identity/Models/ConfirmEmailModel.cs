namespace BookStore.Identity.Models
{
    public class ConfirmEmailModel
    {
        public string? UserId { get; set; }
        public string? Token { get; set; }
    }
}
