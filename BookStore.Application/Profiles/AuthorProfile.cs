using AutoMapper;
using BookStore.Application.Dtos.Author;
using BookStore.Application.Responses;
using BookStore.Domain;

namespace BookStore.Application.Profiles;
public sealed class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Author, AuthorForListDto>().ReverseMap();
        CreateMap<Author, GetAuthorsWithDetailsResponse>()
            .ForMember(x => x.Author, mappingOptions => mappingOptions.MapFrom(a => a.AuthorName))
            .ForMember(x => x.Books, mappingOptions => mappingOptions.MapFrom(a => a.Books.Select(b => b.Title)));
    }
}
