using LocaFilms.Models;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieModel>> GetAllMoviesAsync();
        Task<MovieModel?> GetMovieByIdAsync(int id);
        Task<MovieResponse> CreateMovieAsync(MovieModel movie);
        Task<MovieResponse> UpdateMovieAsync(int id, MovieModel movie);
        Task<MovieResponse> DeleteMovieAsync(int id);
    }
}
