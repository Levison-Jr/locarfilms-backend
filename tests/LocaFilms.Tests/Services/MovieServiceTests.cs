using Bogus;
using FluentAssertions;
using LocaFilms.Enums;
using LocaFilms.Models;
using LocaFilms.Repository;
using LocaFilms.Services;
using LocaFilms.Services.Communication;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using Xunit.Sdk;

namespace LocaFilms.Tests.Services
{
    public class MovieServiceTests
    {
        private readonly MovieService _movieService;
        private readonly IMovieRepository _mockMovieRepository;
        private readonly List<MovieModel> _movies;
        private readonly Faker _faker = new("pt_BR");

        private readonly string[] _movieCategories = [];

        public MovieServiceTests()
        {
            _movieCategories = _faker.Random.WordsArray(3, 5);

            _movies = new Faker<MovieModel>()
                .RuleFor(m => m.Id, f => f.IndexFaker + 1)
                .RuleFor(m => m.Title, f => f.Lorem.Word())
                .RuleFor(m => m.Description, f => f.Lorem.Text())
                .RuleFor(m => m.Duration, "00:00")
                .RuleFor(m => m.Category, f => f.Random.ArrayElement(_movieCategories))
                .RuleFor(m => m.Status, _faker.Random.Enum<MovieStatusEnum>())
                .RuleFor(m => m.CostPerDay, f => f.Random.Decimal(0, 10))
                .RuleFor(m => m.ReleaseDate, f => f.Date.PastDateOnly())
                .RuleFor(m => m.RegistrationDateTime, f => f.Date.Past())
                .RuleFor(m => m.LastModifiedDateTime, f => f.Date.Past())
                .RuleFor(m => m.ImageBannerUrl, f => f.Internet.Url())
                .RuleFor(m => m.ImageIconUrl, f => f.Internet.Url())
                .RuleFor(m => m.YouTubeTraillerUrl, f => f.Internet.Url())
                .Generate(30);

            _mockMovieRepository = Substitute.For<IMovieRepository>();
            _movieService = new MovieService(_mockMovieRepository);
        }

        [Fact]
        public async Task GetAllMoviesAsync_GivenNullArguments_ThenShouldReturnAllMovies()
        {
            // Arrange
            var expectedCountMovies = 30;
            _mockMovieRepository.ListAsync(null, null)
                .Returns(_movies);

            // Act
            var actualMovies = await _movieService.GetAllMoviesAsync(null, null);

            // Assert
            actualMovies.Should().HaveCount(expectedCountMovies);
        }

        [Fact]
        public async Task GetAllMoviesAsync_GivenFilters_ThenShouldJustReturnMoviesInFilters()
        {
            // Arrange
            var expectedCategoryFilter = _faker.Random.ArrayElement(_movieCategories);
            var expectedMovieStatusFilter = _faker.Random.Enum<MovieStatusEnum>();

            _mockMovieRepository.ListAsync(expectedCategoryFilter, expectedMovieStatusFilter)
                .Returns(
                    _movies.Where(m =>
                        m.Category == expectedCategoryFilter &&
                        m.Status == expectedMovieStatusFilter));

            // Act
            var actualMovies = await _movieService.GetAllMoviesAsync(expectedCategoryFilter, expectedMovieStatusFilter);

            // Assert
            actualMovies.Should().NotBeNull();
            actualMovies.Should().OnlyContain(m => m.Category == expectedCategoryFilter);
            actualMovies.Should().OnlyContain(m => m.Status == expectedMovieStatusFilter);

        }

        [Fact]
        public async Task GetMovieByIdAsync_GivenId_ThenShouldReturnMovieWithIdSpecified()
        {
            // Arrange
            var expectedId = 10;
            _mockMovieRepository.GetByIdAsync(expectedId)
                .Returns(_movies.Single(m => m.Id == expectedId));

            // Act
            var actualMovie = await _movieService.GetMovieByIdAsync(expectedId);

            // Assert
            actualMovie.Should().NotBeNull();
            actualMovie.Id.Should().Be(expectedId);
        }

        [Fact]
        public async Task GetMovieByIdAsync_GivenInvalidId_ThenShouldReturnNull()
        {
            // Arrange
            _mockMovieRepository.GetByIdAsync(Arg.Any<int>())
                .ReturnsNull();

            // Act
            var actualMovie = await _movieService.GetMovieByIdAsync(_faker.Random.Int(1));

            // Assert
            actualMovie.Should().BeNull();
        }

        [Fact]
        public async Task CreateMovieAsync_GivenValidMovie_ThenShouldReturnSuccessMovieResponse()
        {
            // Arrange
            var expectedId = _faker.Random.Int(100);

            var validMovie = new Faker<MovieModel>()
                .RuleFor(m => m.Id, expectedId)
                .RuleFor(m => m.Title, f => f.Lorem.Word())
                .RuleFor(m => m.Description, f => f.Lorem.Text())
                .RuleFor(m => m.Duration, "00:00")
                .RuleFor(m => m.Category, f => f.Random.ArrayElement(_movieCategories))
                .RuleFor(m => m.Status, MovieStatusEnum.isAvailable)
                .RuleFor(m => m.CostPerDay, f => f.Random.Decimal(0.01m, 10))
                .RuleFor(m => m.ReleaseDate, f => f.Date.PastDateOnly())
                .RuleFor(m => m.RegistrationDateTime, f => f.Date.Past())
                .RuleFor(m => m.LastModifiedDateTime, f => f.Date.Past())
                .RuleFor(m => m.ImageBannerUrl, f => f.Internet.Url())
                .RuleFor(m => m.ImageIconUrl, f => f.Internet.Url())
                .RuleFor(m => m.YouTubeTraillerUrl, f => f.Internet.Url());

            var expectedMovieResponse = new MovieResponse(validMovie);

            _mockMovieRepository.AddAsync(validMovie)
                .Returns(Task.CompletedTask);

            // Act
            var actualMovieResponse = await _movieService.CreateMovieAsync(validMovie);

            // Assert
            actualMovieResponse.Should().Match<MovieResponse>(m =>
                m.Success == expectedMovieResponse.Success &&
                m.Message == expectedMovieResponse.Message &&
                m.Movie!.Id == expectedId);
        }

        [Fact]
        public async Task CreateMovieAsync_WhenAddAsyncThrowsException_ThenShouldReturnFailedMovieResponse()
        {
            // Arrange
            var expectedFailedResponse = new MovieResponse("");

            _mockMovieRepository.AddAsync(Arg.Any<MovieModel>())
                .ThrowsAsync(new Exception());

            // Act
            var actualMovieResponse = await _movieService.CreateMovieAsync(new MovieModel());

            // Assert
            actualMovieResponse.Should().Match<MovieResponse>(m =>
                m.Success == expectedFailedResponse.Success &&
                m.Movie == expectedFailedResponse.Movie);
        }

        [Fact]
        public async Task UpdateMovieAsync_GivenValidId_ThenShouldUpdate()
        {
            // Arrange
            var movieIdToBeUpdated = 5;
            var lastModifiedDateTimeBeforeUpdate = _movies.Single(m => m.Id == movieIdToBeUpdated).LastModifiedDateTime;

            var dataToUpdateInMovie = new Faker<MovieModel>()
                .RuleFor(m => m.Id, movieIdToBeUpdated)
                .RuleFor(m => m.Title, f => f.Lorem.Word())
                .RuleFor(m => m.Description, f => f.Lorem.Text())
                .RuleFor(m => m.Duration, "00:00")
                .RuleFor(m => m.Category, f => f.Random.ArrayElement(_movieCategories))
                .RuleFor(m => m.Status, MovieStatusEnum.isAvailable)
                .RuleFor(m => m.CostPerDay, f => f.Random.Decimal(0.01m, 10))
                .RuleFor(m => m.ReleaseDate, f => f.Date.PastDateOnly())
                .RuleFor(m => m.RegistrationDateTime, f => f.Date.Past())
                .RuleFor(m => m.LastModifiedDateTime, f => f.Date.Past())
                .RuleFor(m => m.ImageBannerUrl, f => f.Internet.Url())
                .RuleFor(m => m.ImageIconUrl, f => f.Internet.Url())
                .RuleFor(m => m.YouTubeTraillerUrl, f => f.Internet.Url());

            var expectedMovieResponse = new MovieResponse(dataToUpdateInMovie);

            _mockMovieRepository.GetByIdAsync(movieIdToBeUpdated)
                .Returns(_movies.Single(m => m.Id == movieIdToBeUpdated));

            _mockMovieRepository.UpdateAsync(Arg.Any<MovieModel>())
                .Returns(Task.CompletedTask);

            // Act
            var actualMovieResponse = await _movieService.UpdateMovieAsync(movieIdToBeUpdated, expectedMovieResponse.Movie!);

            // Assert
            actualMovieResponse.Should().Match<MovieResponse>(mr => 
                mr.Success == expectedMovieResponse.Success &&
                mr.Message == expectedMovieResponse.Message);
            
            actualMovieResponse.Movie.Should().Match<MovieModel>(m =>
                m.Title == expectedMovieResponse.Movie!.Title &&
                m.SubTitle == expectedMovieResponse.Movie.SubTitle &&
                m.Description == expectedMovieResponse.Movie.Description &&
                m.Category == expectedMovieResponse.Movie.Category &&
                m.Status == expectedMovieResponse.Movie.Status &&
                m.CostPerDay == expectedMovieResponse.Movie.CostPerDay &&
                m.LastModifiedDateTime > lastModifiedDateTimeBeforeUpdate &&
                m.ReleaseDate == expectedMovieResponse.Movie.ReleaseDate &&
                m.ImageBannerUrl == expectedMovieResponse.Movie.ImageBannerUrl &&
                m.ImageIconUrl == expectedMovieResponse.Movie.ImageIconUrl);
        }

        [Fact]
        public async Task UpdateMovieAsync_GivenInvalidId_ThenShouldReturnFailedMovieResponse()
        {
            // Arrange
            var invalidMovieId = _faker.Random.Int(100);
            var expectedFailedResponse = new MovieResponse("");

            // Act
            var actualMovieResponse = await _movieService.UpdateMovieAsync(invalidMovieId, new MovieModel());

            // Assert
            actualMovieResponse.Movie.Should().BeNull();

            actualMovieResponse.Should().Match<MovieResponse>(mr =>
                mr.Success == expectedFailedResponse.Success);
        }

        [Fact]
        public async Task UpdateMovieAsync_WhenUpdateAsyncThrowsException_ThenShouldReturnFailedMovieResponse()
        {
            // Arrange
            var expectedFailedResponse = new MovieResponse("");
            var validMovieId = _faker.Random.Int(1, 30);
            _mockMovieRepository.UpdateAsync(Arg.Any<MovieModel>())
                .ThrowsAsync(new Exception());

            // Act
            var actualMovieResponse = await _movieService.UpdateMovieAsync(validMovieId, new MovieModel());

            // Assert
            actualMovieResponse.Movie.Should().BeNull();

            actualMovieResponse.Should().Match<MovieResponse>(mr =>
                mr.Success == expectedFailedResponse.Success);
        }

        [Fact]
        public async Task ChangeMovieStatus_GivenValidId_ThenShouldReturnTrue()
        {
            // Arrange
            var validMovieId = _faker.Random.Int(1, 30);
            var movieStatus = _faker.Random.Enum<MovieStatusEnum>();

            _mockMovieRepository.GetByIdAsync(validMovieId)
                .Returns(_movies.Single(m => m.Id == validMovieId));

            _mockMovieRepository.UpdateAsync(Arg.Any<MovieModel>())
                .Returns(Task.CompletedTask);

            // Act
            var actualChangeResponse = await _movieService.ChangeMovieStatus(validMovieId, movieStatus);

            // Assert
            actualChangeResponse.Should().BeTrue();
        }

        [Fact]
        public async Task ChangeMovieStatus_GivenInvalidId_ThenShouldReturnFalse()
        {
            // Arrange
            var invalidMovieId = _faker.Random.Int(31);
            var movieStatus = _faker.Random.Enum<MovieStatusEnum>();

            // Act
            var actualChangeResponse = await _movieService.ChangeMovieStatus(invalidMovieId, movieStatus);

            // Assert
            actualChangeResponse.Should().BeFalse();
        }

        [Fact]
        public async Task ChangeMovieStatus_WhenUpdateAsyncThrowsException_ThenShouldReturnFalse()
        {
            // Arrange
            var validMovieId = _faker.Random.Int(1, 30);
            var expectedMovieStatus = _faker.Random.Enum<MovieStatusEnum>();

            _mockMovieRepository.UpdateAsync(Arg.Any<MovieModel>())
                .ThrowsAsync(new Exception());

            // Act
            var actualChangeResponse = await _movieService.ChangeMovieStatus(validMovieId, expectedMovieStatus);

            // Assert
            actualChangeResponse.Should().BeFalse();
        }

        [Fact]
        public async Task DeleteMovieAsync_GivenValidId_ThenShouldDelete()
        {
            // Arrange
            var validMovieId = _faker.Random.Int(1, 30);
            var expectedMovieResponse = new MovieResponse(new MovieModel());

            _mockMovieRepository.GetByIdAsync(validMovieId)
                .Returns(_movies.Single(m => m.Id == validMovieId));

            _mockMovieRepository.DeleteAsync(Arg.Any<MovieModel>())
                .Returns(Task.CompletedTask);

            // Act
            var actualMovieResponse = await _movieService.DeleteMovieAsync(validMovieId);

            // Assert
            actualMovieResponse.Movie.Should().NotBeNull();
            actualMovieResponse.Should().Match<MovieResponse>(mr =>
                mr.Success == expectedMovieResponse.Success);
        }

        [Fact]
        public async Task DeleteMovieAsync_GivenInvalidId_ThenShouldReturnFailedMovieResponse()
        {
            // Arrange
            var invalidMovieId = _faker.Random.Int(31);
            var expectedFailedResponse = new MovieResponse("");

            // Act
            var actualMovieResponse = await _movieService.DeleteMovieAsync(invalidMovieId);

            // Assert
            actualMovieResponse.Movie.Should().BeNull();
            actualMovieResponse.Should().Match<MovieResponse>(mr =>
                mr.Success == expectedFailedResponse.Success);
        }

        [Fact]
        public async Task DeleteMovieAsync_WhenUpdateAsyncThrowsException_ThenShouldReturnFailedMovieResponse()
        {
            // Arrange
            var validMovieId = _faker.Random.Int(1, 30);
            var expectedFailedResponse = new MovieResponse("");

            _mockMovieRepository.GetByIdAsync(validMovieId)
                .Returns(_movies.Single(m => m.Id == validMovieId));

            _mockMovieRepository.DeleteAsync(Arg.Any<MovieModel>())
                .ThrowsAsync(new Exception());

            // Act
            var actualMovieResponse = await _movieService.DeleteMovieAsync(validMovieId);

            // Assert
            actualMovieResponse.Movie.Should().BeNull();
            actualMovieResponse.Should().Match<MovieResponse>(mr =>
                mr.Success == expectedFailedResponse.Success);
        }
    }
}
