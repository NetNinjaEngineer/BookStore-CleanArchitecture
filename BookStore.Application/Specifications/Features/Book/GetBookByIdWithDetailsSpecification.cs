namespace BookStore.Application.Specifications.Features.Book;
public class GetBookByIdWithDetailsSpecification : Specification<Domain.Book>
{
    public GetBookByIdWithDetailsSpecification(int bookId) : base(x => x.Id == bookId)
    {
        AddIncludes(x => x.Genre);
        AddIncludes(x => x.Authors);
        AddIncludes(x => x.AuthorBooks);
    }
}
