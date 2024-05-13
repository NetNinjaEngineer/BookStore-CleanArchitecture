using AutoMapper;
using BookStore.Application.Dtos.Genre;
using BookStore.Domain;

public class GenreProfile : Profile
{
    public GenreProfile()
    {
        CreateMap<Genre, GenreDto>().ReverseMap();
        CreateMap<Genre, GenreForListDto>();
    }
}