using AutoMapper;
using BookStore.Application.Dtos.Author;
using BookStore.Domain;

namespace BookStore.Application.Profiles;
public sealed class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorDto>().ReverseMap();
    }
}
