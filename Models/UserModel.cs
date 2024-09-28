using LocaFilms.Enums;
using Microsoft.AspNetCore.Identity;

namespace LocaFilms.Models
{
    public class UserModel : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal? Balance { get; set; }

        public IList<MovieRentals> MovieRentals { get; set; }
    }
}
