using LocaFilms.Dtos.Request;
using LocaFilms.Dtos.Response;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services.Identity
{
    public interface IIdentityService
    {
        Task<UserResponse> Register(string email, string password);
        Task<UserLoginResponse> Login(string email, string password);
    }
}
