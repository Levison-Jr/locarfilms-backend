using LocaFilms.Enums;
using LocaFilms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocaFilms.Contexts
{
    public class AppDbContext : IdentityDbContext<UserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieRentals>()
                .HasOne<UserModel>(mr => mr.User)
                .WithMany(u => u.MovieRentals)
                .HasForeignKey(mr => mr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieRentals>()
                .HasOne<MovieModel>(mr => mr.Movie)
                .WithMany(m => m.MovieRentals)
                .HasForeignKey(mr => mr.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieModel>()
                .Property(m => m.CostPerDay)
                .HasColumnType("decimal")
                .HasPrecision(18, 2);

            modelBuilder.Entity<MovieModel>().HasData(
                new MovieModel
                {
                    Id = 1,
                    Title = "O Poderoso Chefão",
                    SubTitle = "",
                    Description = "Uma emocionante saga sobre uma família mafiosa nos EUA, lidando com poder, traição e honra.",
                    Duration = "02:55",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Drama",
                    CostPerDay = 7,
                    ReleaseDate = new DateOnly(1972, 3, 24),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/7nfMHfkiu8Z8JxQranJvYWwPHtS.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/8GM0cNIZKsnczJYDT8odzivDsEo.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/y_-YWEot_7w"
                },
                new MovieModel
                {
                    Id = 2,
                    Title = "Interestelar",
                    SubTitle = "",
                    Description = "Em busca de um novo lar para a humanidade, uma equipe viaja através de um buraco de minhoca em busca de respostas.",
                    Duration = "02:49",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Ficção Científica",
                    CostPerDay = 5,
                    ReleaseDate = new DateOnly(2014, 11, 7),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/Ys8UIGWJpd2TMuQk8fU77W3mBz.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/96LZNXbXW6lNIuNlnn5rbmx5SVS.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/i6avfCqKcQo"
                },
                new MovieModel
                {
                    Id = 3,
                    Title = "A Origem",
                    SubTitle = "",
                    Description = "Um especialista em roubo de ideias entra nos sonhos de outros para implantar uma ideia.",
                    Duration = "02:28",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Ação",
                    CostPerDay = 6,
                    ReleaseDate = new DateOnly(2010, 7, 16),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/ii8QGacT3MXESqBckQlyrATY0lT.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/ocSXOjaUDHYsCCpmBWcQs78iHXd.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/R_VX0e0PX90"
                },
                new MovieModel
                {
                    Id = 4,
                    Title = "Vingadores: Ultimato",
                    SubTitle = "",
                    Description = "Os heróis restantes tentam reverter as consequências do estalo de Thanos e salvar o universo.",
                    Duration = "03:01",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Ação",
                    CostPerDay = 4,
                    ReleaseDate = new DateOnly(2019, 4, 26),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/vfCYyWwujI5EE160GhKJx80cZ4f.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/3tgd7r2JT7GtB2gJ5C2eeZo3rmF.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/LMOqLeoP2yw"
                },
                new MovieModel
                {
                    Id = 5,
                    Title = "Toy Story 4",
                    SubTitle = "",
                    Description = "Woody e seus amigos embarcam em uma jornada cheia de diversão e significado para salvar Forky.",
                    Duration = "01:40",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Animação",
                    CostPerDay = 3,
                    ReleaseDate = new DateOnly(2019, 6, 21),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/iG3Gu0T0AkL4D8T8ci2PcufuLyX.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/1fXc66h9KU73g74VLWsjtMa5RrS.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/cstg99eiG4E"
                },
                new MovieModel
                {
                    Id = 6,
                    Title = "Matrix",
                    SubTitle = "",
                    Description = "Um programador descobre que o mundo em que vive é uma simulação criada por máquinas.",
                    Duration = "02:16",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Ficção Científica",
                    CostPerDay = 6,
                    ReleaseDate = new DateOnly(1999, 3, 31),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/nZi1IAiLS4UyW3PVWwN7XZWVX3M.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/vK8HPVNYwVAFhMz4QXiHvl36mTd.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/mPYfd6PCmYY"
                },
                new MovieModel
                {
                    Id = 7,
                    Title = "O Senhor dos Anéis",
                    SubTitle = "A Sociedade do Anel",
                    Description = "Um hobbit e seus amigos embarcam em uma jornada épica para destruir um anel maligno.",
                    Duration = "03:28",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Fantasia",
                    CostPerDay = 7,
                    ReleaseDate = new DateOnly(2001, 12, 19),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/juxKiJ6diF06YZokVxIe6cWKgio.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/7oPNnmHicGG1eDYTpInGK0jqDa9.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/0i86oM1nHjM"
                },
                new MovieModel
                {
                    Id = 8,
                    Title = "Coringa",
                    SubTitle = "",
                    Description = "A origem do icônico vilão do Batman, mostrando sua transformação em um símbolo de anarquia.",
                    Duration = "02:02",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Drama",
                    CostPerDay = 5,
                    ReleaseDate = new DateOnly(2019, 10, 4),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/n6bUvigpRFqSwmPp1m2YADdbRBc.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/kWbwz0JTiEULk2u4bDIdNEG6Oml.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/621pfj0EfIc"
                },
                new MovieModel
                {
                    Id = 9,
                    Title = "Star Wars: Episódio IV",
                    SubTitle = "Uma Nova Esperança",
                    Description = "Luke Skywalker embarca em uma aventura para salvar a galáxia do Império.",
                    Duration = "02:01",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Ficção Científica",
                    CostPerDay = 6,
                    ReleaseDate = new DateOnly(1977, 5, 25),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/2w4xG178RpB4MDAIfTkqAuSJzec.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/tKf7WKYeSlDFo2BjBEHvMpV6faD.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/Q8b09bE1iGQ"
                },
                new MovieModel
                {
                    Id = 10,
                    Title = "Frozen",
                    SubTitle = "Uma Aventura Congelante",
                    Description = "Duas irmãs enfrentam desafios mágicos em uma jornada emocionante de amor e autodescoberta.",
                    Duration = "01:42",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Animação",
                    CostPerDay = 3,
                    ReleaseDate = new DateOnly(2013, 11, 27),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/u2bZhH3nTf0So0UIC1QxAqBvC07.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/AnjnNleCMib4uJ64NViCFxCNnC5.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/EBEbqLvrf7w"
                },
                new MovieModel
                {
                    Id = 11,
                    Title = "Harry Potter e a Pedra Filosofal",
                    SubTitle = "",
                    Description = "Um jovem bruxo descobre seu destino enquanto embarca em sua primeira aventura em Hogwarts.",
                    Duration = "02:32",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Fantasia",
                    CostPerDay = 5,
                    ReleaseDate = new DateOnly(2001, 11, 16),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/5jkE2SzR5uR2egEb1rRhF22JyWN.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/tq2NwrrRxwvEsYCzef0Lg0yIonz.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/SFzft_2dcV0"
                },
                new MovieModel
                {
                    Id = 12,
                    Title = "Pantera Negra",
                    SubTitle = "",
                    Description = "O rei de Wakanda luta para proteger seu povo e manter sua nação em segredo do mundo exterior.",
                    Duration = "02:14",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Ação",
                    CostPerDay = 6,
                    ReleaseDate = new DateOnly(2018, 2, 16),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/b6ZJZHUdMEFECvGiDpJjlfUWela.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/ubXNpxL2ASSzY0f8Hxv08pOsV2L.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/FR9iLjOubWc"
                },
                new MovieModel
                {
                    Id = 13,
                    Title = "Homem-Aranha: Sem Volta Para Casa",
                    SubTitle = "",
                    Description = "Peter Parker enfrenta desafios quando o multiverso é aberto e vilões do passado retornam.",
                    Duration = "02:28",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Ação",
                    CostPerDay = 7,
                    ReleaseDate = new DateOnly(2021, 12, 17),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/14QbnygCuTO0vl7CAFmPf1fgZfV.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/8qBccgSj0Ru9Odm1Mjv82cxDr7l.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/CyiiEJRZjSU"
                },
                new MovieModel
                {
                    Id = 14,
                    Title = "O Auto da Compadecida",
                    SubTitle = "",
                    Description = "As aventuras de João Grilo e Chicó em um sertão repleto de humor, desafios e dilemas morais.",
                    Duration = "01:44",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Comédia",
                    CostPerDay = 4,
                    ReleaseDate = new DateOnly(2000, 9, 15),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/alQqTpmEkxSLgajfEYTsTH6nAKB.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/imcOp1kJsCsAFCoOtY5OnPrFbAf.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/XPuMu_ENzlg"
                },
                new MovieModel
                {
                    Id = 15,
                    Title = "Jurassic Park: O Parque dos Dinossauros",
                    SubTitle = "",
                    Description = "Cientistas criam um parque com dinossauros clonados, mas tudo sai de controle.",
                    Duration = "02:07",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Aventura",
                    CostPerDay = 5,
                    ReleaseDate = new DateOnly(1993, 6, 11),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/mzFjAVLdZAD6UDT5BMRItHL5IVf.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/oU7Oq2kFAAlGqbU4VoAE36g4hoI.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/fLDR-YYK7jQ"
                },
                new MovieModel
                {
                    Id = 16,
                    Title = "Projeto Almanaque",
                    SubTitle = "",
                    Description = "Um grupo de jovens descobre como viajar no tempo, mas as consequências são imprevisíveis.",
                    Duration = "01:46",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Ficção Científica",
                    CostPerDay = 5,
                    ReleaseDate = new DateOnly(2015, 1, 28),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/eyJk5LTMLIeAN2kVsP0yXrPZJfl.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/2krLUKMsKbnZk6j647IlkqlMZ2u.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/MmnLVu43z6s"
                },
                new MovieModel
                {
                    Id = 17,
                    Title = "Sempre ao Seu Lado",
                    SubTitle = "",
                    Description = "Um professor encontra um cachorro que lhe ensina lições sobre amor e lealdade.",
                    Duration = "01:33",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Drama",
                    CostPerDay = 4,
                    ReleaseDate = new DateOnly(2009, 6, 13),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/a5pOEjOLvr04Hr8qktIDM75OZi0.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/6fQ9xOMduIIn4U1lzoiNwex5KSU.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/UFY8vW5IedY"
                },
                new MovieModel
                {
                    Id = 18,
                    Title = "O Rei Leão",
                    SubTitle = "",
                    Description = "Um jovem leão enfrenta desafios para aceitar seu destino como rei da savana.",
                    Duration = "01:58",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Animação",
                    CostPerDay = 5,
                    ReleaseDate = new DateOnly(1994, 6, 24),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/wXsQvli6tWqja51pYxXNG1LFIGV.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/8aIvm8OaJISOpVTt7rMIh7X35G5.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/rHiHRhbTv-Q"
                },
                new MovieModel
                {
                    Id = 19,
                    Title = "Cidade de Deus",
                    SubTitle = "",
                    Description = "A história de dois jovens crescendo em uma favela violenta do Rio de Janeiro, com caminhos opostos na vida.",
                    Duration = "02:10",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Drama",
                    CostPerDay = 6,
                    ReleaseDate = new DateOnly(2002, 8, 30),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/uvitbjFU4JqvMwIkMWHp69bmUzG.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/uchp7b4goGM78HlD8f1NQbG8rxm.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/fZJUKixyeXM"
                },
                new MovieModel
                {
                    Id = 20,
                    Title = "Tropa de Elite",
                    SubTitle = "",
                    Description = "Um capitão do BOPE enfrenta os desafios da criminalidade e corrupção no Rio de Janeiro.",
                    Duration = "01:55",
                    Status = MovieStatusEnum.isAvailable,
                    RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500),
                    Category = "Ação",
                    CostPerDay = 5,
                    ReleaseDate = new DateOnly(2007, 10, 5),
                    ImageBannerUrl = "https://image.tmdb.org/t/p/original/pstB0q2QloZBU8csDurLwR0fYdN.jpg",
                    ImageIconUrl = "https://image.tmdb.org/t/p/original/atl4a9VFVP7JYvk4GeSgqhLOfjC.jpg",
                    YouTubeTraillerUrl = "https://www.youtube.com/embed/A6W-nNPl1T8"
                }
            );
        }

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<MovieRentals> MovieRentals { get; set; }
    }
}
