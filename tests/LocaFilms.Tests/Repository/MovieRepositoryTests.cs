using Bogus;
using FluentAssertions;
using LocaFilms.Contexts;
using LocaFilms.Enums;
using LocaFilms.Models;
using LocaFilms.Repository;
using Microsoft.EntityFrameworkCore;

namespace LocaFilms.Tests.Repository
{
    public class MovieRepositoryTests
    {
        private readonly Faker _faker = new("pt_BR");
        private readonly AppDbContext _appDbContext;
        private readonly MovieRepository _movieRepository;

        private readonly string[] _movieCategories = [];

        public MovieRepositoryTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            _appDbContext = new AppDbContext(dbContextOptions);
            _appDbContext.Database.OpenConnection();
            _appDbContext.Database.EnsureCreated();

            _movieCategories = _faker.Random.WordsArray(3, 5);

            // Gerar mais 7 registros - No AppDbContext.OnModelCreating são inseridos 23 com o HasData()
            // Todos os 23 possuem MovieModel.Status == MovieStatusEnum.isAvailable
            var fakerMovies = new Faker<MovieModel>()
                .RuleFor(m => m.Id, f => f.IndexFaker + 24)
                .RuleFor(m => m.Title, f => f.Lorem.Word())
                .RuleFor(m => m.Description, f => f.Lorem.Text())
                .RuleFor(m => m.Duration, "00:00")
                .RuleFor(m => m.Category, f => f.Random.ArrayElement(_movieCategories))
                .RuleFor(m => m.Status, MovieStatusEnum.isRented)
                .RuleFor(m => m.CostPerDay, f => f.Random.Decimal(0, 10))
                .RuleFor(m => m.ReleaseDate, f => f.Date.PastDateOnly())
                .RuleFor(m => m.RegistrationDateTime, f => f.Date.Past())
                .RuleFor(m => m.LastModifiedDateTime, f => f.Date.Past())
                .RuleFor(m => m.ImageBannerUrl, f => f.Internet.Url())
                .RuleFor(m => m.ImageIconUrl, f => f.Internet.Url())
                .RuleFor(m => m.YouTubeTraillerUrl, f => f.Internet.Url())
                .Generate(7);

            _appDbContext.Movies.AddRange(fakerMovies);
            _appDbContext.SaveChanges();

            _movieRepository = new MovieRepository(_appDbContext);
        }

        [Fact]
        public async Task ListAsync_GivenNullArguments_ThenShouldReturnAllMovies()
        {
            // Act
            var moviesInDatabase = await _movieRepository.ListAsync(null, null);

            // Assert
            moviesInDatabase.Should().HaveCount(30);
        }

        [Fact]
        public async Task ListAsync_GivenFilters_ThenShouldJustReturnMoviesInFilters()
        {
            // Arrange
            var expectedCategoryFilter = _faker.Random.ArrayElement(_movieCategories);
            var expectedMovieStatusFilter = _faker.Random.Enum<MovieStatusEnum>();

            // Act
            var moviesFiltered = await _movieRepository.ListAsync(expectedCategoryFilter, expectedMovieStatusFilter);

            // Assert
            moviesFiltered.Should().NotBeNull();
            moviesFiltered.Should().OnlyContain(m => m.Category == expectedCategoryFilter);
            moviesFiltered.Should().OnlyContain(m => m.Status == expectedMovieStatusFilter);
        }

        [Fact]
        public async Task GetByIdAsync_GivenId_ThenShouldReturnMovieWithIdSpecified()
        {
            // Arrange
            var expectedMovieId = _faker.Random.Int(1, 30);

            // Act
            var resultMovie = await _movieRepository.GetByIdAsync(expectedMovieId);

            // Assert
            resultMovie.Should().NotBeNull();
            resultMovie.Id.Should().Be(expectedMovieId);
        }

        [Fact]
        public async Task GetByIdAsync_GivenInvalidId_ThenShouldReturnNull()
        {
            // Arrange
            var invalidMovieId = _faker.Random.Int(31);

            // Act
            var resultMovie = await _movieRepository.GetByIdAsync(invalidMovieId);

            // Assert
            resultMovie.Should().BeNull();
        }

        [Fact]
        public async Task AddAsync_GivenMovie_ThenShouldInsert()
        {
            // Arrange
            var expectedId = _faker.Random.Int(100);

            var fakerMovie = new Faker<MovieModel>()
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

            // Act
            await _movieRepository.AddAsync(fakerMovie);
            var insertedMovie = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.Id == expectedId);

            // Assert
            insertedMovie.Should().NotBeNull();
            insertedMovie.Id.Should().Be(expectedId);
        }

        [Fact]
        public async Task UpdateAsync_GivenMovie_ThenShouldUpdate()
        {
            // Arrange
            var movieIdToBeUpdated = _faker.Random.Int(1, 30);
            var movieToBeUpdated = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieIdToBeUpdated);

            var expectedTitle = _faker.Person.FullName;
            var expectedCostPerDay = _faker.Random.Decimal(0.01m, 10);
            var expectedMovieStatus = _faker.Random.Enum<MovieStatusEnum>();

            movieToBeUpdated!.Title = expectedTitle;
            movieToBeUpdated.CostPerDay = expectedCostPerDay;
            movieToBeUpdated.Status = expectedMovieStatus;

            // Act
            await _movieRepository.UpdateAsync(movieToBeUpdated);
            var movieUpdated = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieIdToBeUpdated);

            // Assert
            movieUpdated.Should().NotBeNull().And.Match<MovieModel>(m =>
                m.Title == expectedTitle &&
                m.CostPerDay == expectedCostPerDay &&
                m.Status == expectedMovieStatus
            );
        }

        [Fact]
        public async Task DeleteAsync_GivenMovie_ThenShouldDelete()
        {
            // Arrange
            var movieIdToBeDeleted = _faker.Random.Int(1, 30);
            var movieToBeDeleted = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieIdToBeDeleted);

            // Act
            await _movieRepository.DeleteAsync(movieToBeDeleted!);
            var movieDeleted = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieIdToBeDeleted);

            // Assert
            movieDeleted.Should().BeNull();
        }
    }
}
