using Microsoft.IdentityModel.Tokens;

namespace LocaFilms.Services.Identity.Configurations
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
