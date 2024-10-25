using LocaFilms.Enums;
using LocaFilms.Models;

namespace LocaFilms.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieModel>> ListAsync(string? category, MovieStatusEnum? movieStatus);
        Task<MovieModel?> GetByIdAsync(int id);
        Task AddAsync(MovieModel movie);
        Task UpdateAsync(MovieModel movie);
        Task DeleteAsync(MovieModel movie);
    }
}
