using AutoMapper;
using BookStore.Application.Dtos.AuthorBooks;
using BookStore.Domain;

namespace BookStore.Application.Profiles;
public class AuthorBooksProfile : Profile
{
    public AuthorBooksProfile()
    {
        CreateMap<AuthorBooks, AuthorBooksDto>();
    }
}
