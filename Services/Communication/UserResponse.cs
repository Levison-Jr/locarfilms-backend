using LocaFilms.Models;

namespace LocaFilms.Services.Communication
{
    public class UserResponse : BaseResponse
    {
        public UserModel? User { get; set; }

        private UserResponse(bool success, string message, UserModel? user) : base(success, message)
        {
            User = user;
        }

        /// <summary>
        /// Cria uma resposta sinalizando sucesso da operação de criar um user.
        /// </summary>
        /// <param name="user">User que foi criado.</param>
        /// <returns>Resposta de sucesso formatada.</returns>
        public UserResponse(UserModel user) : this(true, string.Empty, user)
        { }

        /// <summary>
        /// Cria uma resposta sinalizando a falha da operação de criar um user.
        /// </summary>
        /// <param name="message">Mensagem de erro que ocorreu na operação.</param>
        /// <returns>Resposta de falha formatada.</returns>
        public UserResponse(string message) : this(false, message, null)
        { }
    }
}
