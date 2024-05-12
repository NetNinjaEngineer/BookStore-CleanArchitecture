using AutoMapper;
using BookStore.Application.Dtos.Book;
using BookStore.Domain;

namespace BookStore.Application.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<BookForCreationDto, Book>();
        CreateMap<BookForUpdateDto, Book>();
        CreateMap<Book, BookForListDto>()
            .ForMember(x => x.Genre, mappingOptions => mappingOptions.MapFrom(b => b.Genre.GenreName))
            .ForMember(x => x.Authors, mappingOptions => mappingOptions.MapFrom(b => b.Authors.Select(a => a.AuthorName)))
            .ForMember(x => x.ImageUrl, mappingOptions => mappingOptions.MapFrom(x => Utility.Utility.GetImageUrl(x.ImageName!)));
    }
}
