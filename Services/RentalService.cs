using LocaFilms.Enums;
using LocaFilms.Models;
using LocaFilms.Repository;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public RentalService(
            IRentalRepository rentalRepository,
            IUserService userService,
            IMovieService movieService)
        {
            _rentalRepository = rentalRepository;
            _userService = userService;
            _movieService = movieService;
        }

        public async Task<MovieRentals?> GetById(int id)
        {
            return await _rentalRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<MovieRentals>> GetByUserId(string userId)
        {
            return await _rentalRepository.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<MovieRentals>> GetByUserMovieIds(string userId, int movieId)
        {
            return await _rentalRepository.GetByUserMovieIds(userId, movieId, []);
        }

        public async Task<RentalResponse> CreateRental(MovieRentals movieRental)
        {
            var user = await _userService.GetUserByIdAsync(movieRental.UserId);
            var movie = await _movieService.GetMovieByIdAsync(movieRental.MovieId);
            if (user == null || movie == null)
                return new RentalResponse($"O usuário ({movieRental.UserId}) e/ou o filme {movieRental.MovieId} não está cadastrado.");

            var check = await CheckActiveExistingRental(movieRental.UserId, movieRental.MovieId);
            if (check)
                return new RentalResponse($"Já existe um aluguel NÃO FINALIZADO do usuário {movieRental.UserId} para o filme {movieRental.MovieId}");

            try
            {
                await _rentalRepository.AddAsync(movieRental);
                return new RentalResponse(movieRental);
            }
            catch (Exception ex)
            {
                return new RentalResponse($"Não foi possível criar o MovieRental. Erro: {ex.Message}");
            }        
        }

        public async Task<RentalResponse> UpdateRental(MovieRentals movieRental)
        {
            var rentalToUpdate = await GetById(movieRental.Id);

            if (rentalToUpdate == null)
                return new RentalResponse($"Não existe um aluguel do usuário com id {movieRental.UserId} para o filme com id {movieRental.MovieId}");

            rentalToUpdate.RentalEndDate = movieRental.RentalEndDate;
            rentalToUpdate.RentalStatus = movieRental.RentalStatus;
            rentalToUpdate.PaymentStatus = movieRental.PaymentStatus;

            try
            {
                await _rentalRepository.UpdateAsync(rentalToUpdate);
                return new RentalResponse(rentalToUpdate);
            }
            catch (Exception ex)
            {
                return new RentalResponse($"Não foi possível atualizar o MovieRental. Erro: {ex.Message}");
            }
        }

        public async Task<RentalResponse> DeleteRental(int id)
        {
            var rentalToDelete = await GetById(id);

            if (rentalToDelete == null)
                return new RentalResponse($"Não existe um aluguel com id {id}");

            try
            {
                await _rentalRepository.DeleteAsync(rentalToDelete);
                return new RentalResponse(rentalToDelete);
            }
            catch (Exception ex)
            {
                return new RentalResponse($"Não foi possível deletar o MovieRental. Erro: {ex.Message}");
            }
        }

        public async Task<bool> CheckActiveExistingRental(string userId, int movieId)
        {
            try
            {
                var rental = await _rentalRepository.GetByUserMovieIds(
                            userId,
                            movieId,
                            [RentalStatusEnum.AguardandoRetirada, RentalStatusEnum.EmAndamento]);

                return rental.Any();
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
