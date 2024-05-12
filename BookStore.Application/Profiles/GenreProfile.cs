using AutoMapper;
using BookStore.Domain;

public class GenreProfile : Profile
{
    public GenreProfile()
    {
        CreateMap<Genre, GenreForListDto>();
    }
}