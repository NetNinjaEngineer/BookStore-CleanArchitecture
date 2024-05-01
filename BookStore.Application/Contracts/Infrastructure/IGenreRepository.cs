using BookStore.Domain;

namespace BookStore.Application.Contracts.Infrastructure;
public interface IGenreRepository : IGenericRepository<Genre>
{
    bool GenreExists(int genreId);
}
