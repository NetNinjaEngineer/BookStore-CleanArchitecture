using AutoMapper;
using BookStore.Domain;

public class GenreProfile : Profile
{
    public GenreProfile()
    {
        CreateMap<Genre, GenreForListDto>()
        .ForMember(x => x.Id, x => x.MapFrom(x => x.Id))
        .ReverseMap();
    }
}