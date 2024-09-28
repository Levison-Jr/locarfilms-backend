using LocaFilms.Enums;
using LocaFilms.Models;

namespace LocaFilms.Dtos.Response
{
    public record UserDto(
        string Id,
        string FirstName,
        string LastName,
        string UserName,
        string Email,
        string PhoneNumber,
        decimal Balance);
}
