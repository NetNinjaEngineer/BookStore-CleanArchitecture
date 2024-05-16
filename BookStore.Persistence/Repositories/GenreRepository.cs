using BookStore.Application.Contracts.Persistence;
using BookStore.Domain;

namespace BookStore.Persistence.Repositories;
public sealed class GenreRepository(ApplicationDbContext dbContext)
    : GenericRepository<Genre>(dbContext),
    IGenreRepository
{
    public bool GenreExists(int genreId)
        => _dbContext.Genres.Any(x => x.Id == genreId);
}
