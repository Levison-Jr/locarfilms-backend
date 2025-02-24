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

        private readonly string[] movieCategories = ["Action", "Sci-Fi", "Comedy", "Adventure"];

        public MovieRepositoryTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            _appDbContext = new AppDbContext(dbContextOptions);
            _appDbContext.Database.OpenConnection();
            _appDbContext.Database.EnsureCreated();

            // Gerar mais 7 registros - No AppDbContext.OnModelCreating são inseridos 23 com o HasData()
            // Todos os 23 possuem MovieModel.Status == MovieStatusEnum.isAvailable
            var fakerMovies = new Faker<MovieModel>()
                .RuleFor(m => m.Id, f => f.IndexFaker + 24)
                .RuleFor(m => m.Title, f => f.Lorem.Word())
                .RuleFor(m => m.Description, f => f.Lorem.Text())
                .RuleFor(m => m.Duration, "00:00")
                .RuleFor(m => m.Category, f => f.Random.ArrayElement(movieCategories))
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
            var expectedCategoryFilter = _faker.Random.ArrayElement(movieCategories);
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
        public async Task AddAsync_GivenMovie_ShouldInsert()
        {
            // Arrange
            var expectedId = _faker.Random.Int(100);

            var fakerMovie = new Faker<MovieModel>()
                .RuleFor(m => m.Id, expectedId)
                .RuleFor(m => m.Title, f => f.Lorem.Word())
                .RuleFor(m => m.Description, f => f.Lorem.Text())
                .RuleFor(m => m.Duration, "00:00")
                .RuleFor(m => m.Category, f => f.Random.ArrayElement(movieCategories))
                .RuleFor(m => m.Status, MovieStatusEnum.isAvailable)
                .RuleFor(m => m.CostPerDay, f => f.Random.Decimal(0, 10))
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
    }
}
