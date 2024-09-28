using LocaFilms.Contexts;
using LocaFilms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LocaFilms.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        { }

        public async Task<IEnumerable<UserModel>> ListAsync()
        {
            return await _appDbContext.Users.ToListAsync();
        }
    }
}
