using LocaFilms.Models;
using LocaFilms.Services.Communication;
using System.Security.Claims;

namespace LocaFilms.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel?> GetUserByIdAsync(string id);
        Task<UserResponse> UpdateUserAsync(string id, UserModel user);
        Task<UserResponse> DeleteUserAsync(string id);
    }
}
