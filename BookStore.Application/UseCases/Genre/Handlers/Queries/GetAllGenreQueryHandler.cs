//using AutoMapper;
//using BookStore.Application.Contracts.Infrastructure;
//using BookStore.Application.UseCases.Genre.Requests.Queries;
//using MediatR;

//namespace BookStore.Application.UseCases.Genre.Handlers.Queries;

//public sealed class GetAllGenreQueryHandler(
//    IUnitOfWork unitOfWork,
//    IMapper mapper
//)
//: IRequestHandler<GetAllGenreQuery, IEnumerable<GenreForListDto>>
//{
//    public Task<IEnumerable<GenreForListDto>> Handle(
//        GetAllGenreQuery request,
//        CancellationToken cancellationToken)
//    {
//        var genres = unitOfWork.GenreRepository.FindAll();
//        return Task.FromResult(genres.Select(x => new GenreForListDto
//        {
//            Id = x.GenreId,
//            GenreName = x.GenreName
//        }));
//    }
//}