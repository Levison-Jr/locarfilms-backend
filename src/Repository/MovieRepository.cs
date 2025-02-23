using LocaFilms.Contexts;
using LocaFilms.Enums;
using LocaFilms.Models;
using Microsoft.EntityFrameworkCore;

namespace LocaFilms.Repository
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        public MovieRepository(AppDbContext appDbContext) : base(appDbContext)
        { }

        public async Task<IEnumerable<MovieModel>> ListAsync(string? category, MovieStatusEnum? movieStatus)
        {
            var query = _appDbContext.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(m => m.Category == category);

            if (movieStatus.HasValue)
                query = query.Where(m => m.Status == movieStatus);
            
            return await query.ToListAsync();

        }

        public async Task<MovieModel?> GetByIdAsync(int id)
        {
            return await _appDbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(MovieModel movie)
        {
            await _appDbContext.AddAsync(movie);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MovieModel movie)
        {
            _appDbContext.Update(movie);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MovieModel movie)
        {
            _appDbContext.Remove(movie);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
