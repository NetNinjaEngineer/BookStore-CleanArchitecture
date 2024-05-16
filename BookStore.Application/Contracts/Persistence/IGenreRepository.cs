using BookStore.Domain;

namespace BookStore.Application.Contracts.Persistence;
public interface IGenreRepository : IGenericRepository<Genre>
{
    bool GenreExists(int genreId);
}
