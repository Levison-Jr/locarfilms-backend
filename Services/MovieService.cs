using LocaFilms.Models;
using LocaFilms.Repository;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieModel>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.ListAsync();
            
            return movies;
        }

        public async Task<MovieModel?> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            return movie;
        }

        public async Task<MovieResponse> CreateMovieAsync(MovieModel movie)
        {
            try
            {
                await _movieRepository.AddAsync(movie);
                return new MovieResponse(movie);
            }
            catch (Exception ex)
            {
                return new MovieResponse($"Houve um erro ao tentar criar o movie. Erro: {ex.Message}");
            }
        }

        public async Task<MovieResponse> UpdateMovieAsync(int id, MovieModel movie)
        {
            var movieToUpdate = await GetMovieByIdAsync(id);

            if (movieToUpdate == null)
                return new MovieResponse($"O Movie com o id = {id} não existe.");

            movieToUpdate.Title = movie.Title;
            movieToUpdate.SubTitle = movie.SubTitle;
            movieToUpdate.Description = movie.Description;
            movieToUpdate.Category = movie.Category;
            movieToUpdate.Status = movie.Status;
            movieToUpdate.CostPerDay = movie.CostPerDay;
            movieToUpdate.LastModifiedDateTime = movie.LastModifiedDateTime;
            movieToUpdate.ReleaseDate = movie.ReleaseDate;
            movieToUpdate.ImageBannerUrl = movie.ImageBannerUrl;
            movieToUpdate.ImageIconUrl = movie.ImageIconUrl;

            try
            {
                await _movieRepository.UpdateAsync(movieToUpdate);
                return new MovieResponse(movieToUpdate);
            }
            catch (Exception ex)
            {
                return new MovieResponse($"Houve um erro ao tentar atualizar o Movie (id = {id}). Erro: {ex.Message}");
            }
        }

        public async Task<MovieResponse> DeleteMovieAsync(int id)
        {
            var movieToDelete = await GetMovieByIdAsync(id);

            if (movieToDelete == null)
                return new MovieResponse($"O Movie com o id = {id} não existe.");

            try
            {
                await _movieRepository.DeleteAsync(movieToDelete);
                return new MovieResponse(movieToDelete);
            }
            catch (Exception ex)
            {
                return new MovieResponse($"Houve um erro ao tentar deletar o Movie (id = {id}). Erro: {ex.Message}");
            }
        }
    }
}
