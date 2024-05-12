namespace BookStore.Application.Specifications.Features.Book;
public class SearchBooksSpecification : Specification<Domain.Book>
{
    public SearchBooksSpecification(string searchTerm) : base(x =>
        x.Title!.ToLower().Contains(searchTerm.ToLower()) || x.Genre.GenreName!.ToLower().Contains(searchTerm.ToLower()))
    {
        AddIncludes(x => x.Genre);
        AddIncludes(x => x.Authors);
    }
}
