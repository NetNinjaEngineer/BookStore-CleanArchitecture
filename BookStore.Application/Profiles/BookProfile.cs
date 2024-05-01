using AutoMapper;
using BookStore.Application.Dtos.Book;
using BookStore.Domain;

namespace BookStore.Application.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, BookForCreationDto>().ReverseMap();
        CreateMap<Book, BookForUpdateDto>().ReverseMap();
        CreateMap<Book, BookForListDto>().ReverseMap();
    }
}
