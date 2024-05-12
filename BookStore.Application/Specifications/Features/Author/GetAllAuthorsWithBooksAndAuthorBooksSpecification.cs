namespace BookStore.Application.Specifications.Features.Author;
public class GetAllAuthorsWithBooksAndAuthorBooksSpecification : Specification<Domain.Author>
{
    public GetAllAuthorsWithBooksAndAuthorBooksSpecification()
    {
        AddIncludes(x => x.Books);
        AddIncludes(x => x.AuthorBooks);
    }
}
