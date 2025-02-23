using LocaFilms.Models;

namespace LocaFilms.Services.Communication
{
    public class MovieResponse : BaseResponse
    {
        public MovieModel? Movie { get; set; }

        private MovieResponse(bool success, string message, MovieModel? movie) : base(success, message)
        {
            Movie = movie;
        }

        /// <summary>
        /// Cria uma resposta sinalizando sucesso da operação de criar um movie.
        /// </summary>
        /// <param name="movie">Movie que foi criado.</param>
        /// <returns>Resposta de sucesso formatada.</returns>
        public MovieResponse(MovieModel movie) : this(true, string.Empty, movie)
        { }

        /// <summary>
        /// Cria uma resposta sinalizando falha da operação de criar um movie.
        /// </summary>
        /// <param name="message">Mensagem de erro que ocorreu na operação.</param>
        /// <returns>Resposta de falha formatada.</returns>
        public MovieResponse(string message) : this(false, message, null)
        { }
    }
}
