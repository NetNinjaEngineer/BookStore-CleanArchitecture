using BookStore.Application.Contracts.Infrastructure;
using BookStore.Domain;

namespace BookStore.Persistence.Repositories;
public sealed class GenreRepository(ApplicationDbContext dbContext)
    : GenericRepository<Genre>(dbContext),
    IGenreRepository
{
}
