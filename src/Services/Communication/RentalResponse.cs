using LocaFilms.Models;

namespace LocaFilms.Services.Communication
{
    public class RentalResponse :  BaseResponse
    {
        public MovieRentals? MovieRental { get; set; }

        private RentalResponse(bool success, string message, MovieRentals? movieRental) : base(success, message)
        {
            MovieRental = movieRental;
        }

        /// <summary>
        /// Cria uma resposta sinalizando sucesso da operação envolvendo um MovieRental.
        /// </summary>
        /// <param name="movieRental">MovieRental envolvido na operação.</param>
        /// <returns>Resposta de sucesso formatada.</returns>
        public RentalResponse(MovieRentals movieRental) : this(true, string.Empty, movieRental)
        { }

        /// <summary>
        /// Cria uma resposta sinalizando falha da operação envolvendo um MovieRental.
        /// </summary>
        /// <param name="message">Mensagem de erro que ocorreu na operação.</param>
        /// <returns>Resposta de falha formatada.</returns>
        public RentalResponse(string message) : this(false, message, null)
        { }
    }
}
