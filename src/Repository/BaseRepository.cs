using LocaFilms.Contexts;

namespace LocaFilms.Repository
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _appDbContext;

        protected BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
