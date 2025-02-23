using LocaFilms.Models;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public interface IRentalService
    {
        Task<MovieRentals?> GetById(int id);
        Task<IEnumerable<MovieRentals>> GetByUserId(string userId);
        Task<IEnumerable<MovieRentals>> GetByUserMovieIds(string userId, int movieId);
        Task<RentalResponse> CreateRental(MovieRentals movieRental);
        Task<RentalResponse> UpdateRental(MovieRentals movieRental);
        Task<RentalResponse> DeleteRental(int id);
    }
}
