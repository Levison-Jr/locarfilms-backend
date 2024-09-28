using LocaFilms.Contexts;
using LocaFilms.Enums;
using LocaFilms.Models;
using Microsoft.EntityFrameworkCore;

namespace LocaFilms.Repository
{
    public class RentalRepository : BaseRepository, IRentalRepository
    {
        public RentalRepository(AppDbContext appDbContext) : base(appDbContext)
        {}

        public async Task<MovieRentals?> GetByIdAsync(int id)
        {
            return await _appDbContext.MovieRentals
                .Where(mr => mr.Id == id)
                .Include(mr => mr.Movie)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MovieRentals>> GetByUserIdAsync(string id)
        {
            return await _appDbContext.MovieRentals
                .Where(u => u.UserId == id)
                .Include(mr => mr.Movie)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieRentals>> GetByUserMovieIds(
            string userId,
            int movieId,
            List<RentalStatusEnum> rentalStatusFilter)
        {
            var query = _appDbContext.MovieRentals
                .Where(mr => mr.UserId == userId && mr.MovieId == movieId);

            if (rentalStatusFilter.Count != 0)
                query = query.Where(mr => rentalStatusFilter.Contains(mr.RentalStatus));

            return await query.ToListAsync();
        }

        public async Task AddAsync(MovieRentals movieRental)
        {
            await _appDbContext.MovieRentals.AddAsync(movieRental);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MovieRentals movieRental)
        {
            _appDbContext.MovieRentals.Update(movieRental);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MovieRentals movieRental)
        {
            _appDbContext.MovieRentals.Remove(movieRental);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
