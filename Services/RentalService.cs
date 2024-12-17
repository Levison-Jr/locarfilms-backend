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

            if (await _rentalRepository.CheckPendingRentalsByUser(movieRental.UserId) >= 2)
                return new RentalResponse($"Não é possível ter mais do que 2 filmes pendentes.");

            var check = await CheckActiveExistingRental(movieRental.MovieId);
            if (check)
                return new RentalResponse($"Este filmes já está com um aluguel em andamento.");

            try
            {
                await _rentalRepository.AddAsync(movieRental);
                await _movieService.ChangeMovieStatus(movieRental.MovieId, MovieStatusEnum.isRented);
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

                var movieStatusShouldChange = movieRental.RentalStatus == RentalStatusEnum.Cancelado ||
                                            movieRental.RentalStatus == RentalStatusEnum.Finalizado;

                if (movieStatusShouldChange)
                    await _movieService.ChangeMovieStatus(movieRental.MovieId, MovieStatusEnum.isAvailable);

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
            
            if (rentalToDelete.RentalStatus != RentalStatusEnum.AguardandoRetirada)
                return new RentalResponse($"Só é possível excluir um aluguel que está pendente de retirada.");

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

        public async Task<bool> CheckActiveExistingRental(int movieId)
        {
            try
            {
                var rental = await _rentalRepository.GetByMovieIdAsync(
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
