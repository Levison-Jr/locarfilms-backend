using LocaFilms.Models;
using System.Text.Json.Serialization;

namespace LocaFilms.Services.Communication
{
    public class UserLoginResponse : BaseResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AccessToken { get; private set; }

        public UserLoginResponse(bool success, string message, string accessToken) : base(success, message)
        {
            if (!string.IsNullOrEmpty(accessToken))
                AccessToken = accessToken;
        }
    }
}
