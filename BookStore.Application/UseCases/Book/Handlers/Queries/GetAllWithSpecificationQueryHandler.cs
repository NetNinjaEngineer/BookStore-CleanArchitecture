using AutoMapper;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Specifications.Features.Book;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Queries;
public sealed class GetAllWithSpecificationQueryHandler
    : IRequestHandler<GetAllWithSpecificationQuery, IEnumerable<Domain.Book>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllWithSpecificationQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Book>> Handle(
        GetAllWithSpecificationQuery request,
        CancellationToken cancellationToken)
    {
        var books = await _unitOfWork.BookRepository
            .GetAllWithSpec(new GetAllBooksWithGenreAndAuthorsSpecification());
        return books;
    }
}
