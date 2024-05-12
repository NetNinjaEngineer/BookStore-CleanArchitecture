namespace BookStore.Application.Specifications.Features.Book;
public class GetAllBooksWithGenreAndAuthorsSpecification : Specification<Domain.Book>
{
    public GetAllBooksWithGenreAndAuthorsSpecification()
    {
        AddIncludes(book => book.Genre);
        AddIncludes(book => book.Authors);
    }
}
