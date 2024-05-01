using BookStore.Application.Contracts.Infrastructure;
using BookStore.Domain;

namespace BookStore.Persistence.Repositories;
public sealed class GenreRepository(ApplicationDbContext dbContext)
    : GenericRepository<Genre>(dbContext),
    IGenreRepository
{
    public bool GenreExists(int genreId)
        => dbContext.Genres.Any(x => x.GenreId == genreId);
}
