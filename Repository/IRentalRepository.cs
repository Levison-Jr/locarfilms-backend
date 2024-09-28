using LocaFilms.Enums;
using LocaFilms.Models;
using System.Collections;

namespace LocaFilms.Repository
{
    public interface IRentalRepository
    {
        Task<MovieRentals?> GetByIdAsync(int id);
        Task<IEnumerable<MovieRentals>> GetByUserIdAsync(string id);
        Task<IEnumerable<MovieRentals>> GetByUserMovieIds(string userId, int movieId, List<RentalStatusEnum> rentalStatus);
        Task AddAsync(MovieRentals movieRental);
        Task UpdateAsync(MovieRentals movieRental);
        Task DeleteAsync(MovieRentals movieRental);
    }
}
