//using BookStore.Application.Contracts.Infrastructure;
//using BookStore.Application.Responses;
//using BookStore.Application.UseCases.Author.Requests.Queries;
//using MediatR;

//namespace BookStore.Application.UseCases.Author.Handlers.Queries;
//public sealed class GetAuthorsWithDetailsHandler(
//    IUnitOfWork unitOfWork
//    )
//    : IRequestHandler<GetAuthorsWithDetailsQuery, IEnumerable<GetAuthorsWithDetailsResponse>>
//{
//    public Task<IEnumerable<GetAuthorsWithDetailsResponse>> Handle(
//        GetAuthorsWithDetailsQuery request,
//        CancellationToken cancellationToken)
//    {
//        var authorsWithDetailsResponse = unitOfWork.AuthorRepository
//            .FindAll(x => x.AuthorBooks, x => x.Books)
//            .Select(x => new GetAuthorsWithDetailsResponse
//            {
//                Author = x.AuthorName,
//                Books = x.Books.Select(book => book.Title!)
//            });

//        return Task.FromResult(authorsWithDetailsResponse);
//    }
//}
