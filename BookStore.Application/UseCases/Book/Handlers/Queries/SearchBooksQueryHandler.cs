//using BookStore.Application.Contracts.Infrastructure;
//using BookStore.Application.Dtos.Book;
//using BookStore.Application.UseCases.Book.Requests.Queries;
//using MediatR;
//using Microsoft.AspNetCore.Http;

//namespace BookStore.Application.UseCases.Book.Handlers.Queries;
//public sealed class SearchBooksQueryHandler(
//    IUnitOfWork unitOfWork,
//    IHttpContextAccessor accessor)
//    : IRequestHandler<SearchBooksQuery, IEnumerable<BookForListDto>>
//{
//    public Task<IEnumerable<BookForListDto>> Handle(
//        SearchBooksQuery request,
//        CancellationToken cancellationToken)
//    {
//        var httpRequest = (accessor?.HttpContext?.Request)
//            ?? throw new InvalidOperationException("HTTP context is not available.");

//        var baseUrl = $"{httpRequest.Scheme}://{httpRequest.Host}";

//        return Task.FromResult(
//            unitOfWork.BookRepository
//            .FindByCondition(x =>
//                x.Title!
//                .ToLower()
//                .Contains(
//                request.SearchTerm!.ToLower()), x => x.Genre)
//            .Select(book => new BookForListDto
//            {
//                Id = book.Id,
//                Title = book.Title,
//                Price = book.Price,
//                PublicationYear = book.PublicationYear,
//                Genre = book.Genre.GenreName,
//                Authors = book.Authors.Select(x => x.AuthorName),
//                ImageUrl = GetImageUrl(book, baseUrl),
//                ImageName = book.ImageName
//            }));
//    }

//    private static string GetImageUrl(Domain.Book book, string baseUrl)
//        => Path.Combine(baseUrl, $"Files/Images/Books/{book.ImageName}");
//}
