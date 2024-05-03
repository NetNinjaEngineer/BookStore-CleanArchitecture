namespace BookStore.Application.Responses;
public class GetAuthorsWithDetailsResponse
{
    public string? Author { get; set; }
    public IEnumerable<string>? Books { get; set; } = [];

}
