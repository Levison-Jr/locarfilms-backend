using LocaFilms.Enums;
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
        Task<bool> ChangeMovieStatus(int movieId, MovieStatusEnum newStatus);
        Task<MovieResponse> DeleteMovieAsync(int id);
    }
}
