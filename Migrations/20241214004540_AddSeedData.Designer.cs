﻿// <auto-generated />
using System;
using LocaFilms.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocaFilms.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241214004540_AddSeedData")]
    partial class AddSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocaFilms.Models.MovieModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CostPerDay")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageBannerUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageIconUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RegistrationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("SubTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YouTubeTraillerUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Drama",
                            CostPerDay = 7m,
                            Description = "Uma emocionante saga sobre uma família mafiosa nos EUA, lidando com poder, traição e honra.",
                            Duration = "02:55",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/7nfMHfkiu8Z8JxQranJvYWwPHtS.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/8GM0cNIZKsnczJYDT8odzivDsEo.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(1972, 3, 24),
                            Status = 1,
                            SubTitle = "",
                            Title = "O Poderoso Chefão",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/y_-YWEot_7w"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Ficção Científica",
                            CostPerDay = 5m,
                            Description = "Em busca de um novo lar para a humanidade, uma equipe viaja através de um buraco de minhoca em busca de respostas.",
                            Duration = "02:49",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/Ys8UIGWJpd2TMuQk8fU77W3mBz.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/96LZNXbXW6lNIuNlnn5rbmx5SVS.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2014, 11, 7),
                            Status = 1,
                            SubTitle = "",
                            Title = "Interestelar",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/i6avfCqKcQo"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Ação",
                            CostPerDay = 6m,
                            Description = "Um especialista em roubo de ideias entra nos sonhos de outros para implantar uma ideia.",
                            Duration = "02:28",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/ii8QGacT3MXESqBckQlyrATY0lT.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/ocSXOjaUDHYsCCpmBWcQs78iHXd.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2010, 7, 16),
                            Status = 1,
                            SubTitle = "",
                            Title = "A Origem",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/R_VX0e0PX90"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Ação",
                            CostPerDay = 4m,
                            Description = "Os heróis restantes tentam reverter as consequências do estalo de Thanos e salvar o universo.",
                            Duration = "03:01",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/vfCYyWwujI5EE160GhKJx80cZ4f.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/3tgd7r2JT7GtB2gJ5C2eeZo3rmF.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2019, 4, 26),
                            Status = 1,
                            SubTitle = "",
                            Title = "Vingadores: Ultimato",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/LMOqLeoP2yw"
                        },
                        new
                        {
                            Id = 5,
                            Category = "Animação",
                            CostPerDay = 3m,
                            Description = "Woody e seus amigos embarcam em uma jornada cheia de diversão e significado para salvar Forky.",
                            Duration = "01:40",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/iG3Gu0T0AkL4D8T8ci2PcufuLyX.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/1fXc66h9KU73g74VLWsjtMa5RrS.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2019, 6, 21),
                            Status = 1,
                            SubTitle = "",
                            Title = "Toy Story 4",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/cstg99eiG4E"
                        },
                        new
                        {
                            Id = 6,
                            Category = "Ficção Científica",
                            CostPerDay = 6m,
                            Description = "Um programador descobre que o mundo em que vive é uma simulação criada por máquinas.",
                            Duration = "02:16",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/nZi1IAiLS4UyW3PVWwN7XZWVX3M.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/vK8HPVNYwVAFhMz4QXiHvl36mTd.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(1999, 3, 31),
                            Status = 1,
                            SubTitle = "",
                            Title = "Matrix",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/mPYfd6PCmYY"
                        },
                        new
                        {
                            Id = 7,
                            Category = "Fantasia",
                            CostPerDay = 7m,
                            Description = "Um hobbit e seus amigos embarcam em uma jornada épica para destruir um anel maligno.",
                            Duration = "03:28",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/juxKiJ6diF06YZokVxIe6cWKgio.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/7oPNnmHicGG1eDYTpInGK0jqDa9.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2001, 12, 19),
                            Status = 1,
                            SubTitle = "A Sociedade do Anel",
                            Title = "O Senhor dos Anéis",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/0i86oM1nHjM"
                        },
                        new
                        {
                            Id = 8,
                            Category = "Drama",
                            CostPerDay = 5m,
                            Description = "A origem do icônico vilão do Batman, mostrando sua transformação em um símbolo de anarquia.",
                            Duration = "02:02",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/n6bUvigpRFqSwmPp1m2YADdbRBc.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/kWbwz0JTiEULk2u4bDIdNEG6Oml.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2019, 10, 4),
                            Status = 1,
                            SubTitle = "",
                            Title = "Coringa",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/621pfj0EfIc"
                        },
                        new
                        {
                            Id = 9,
                            Category = "Ficção Científica",
                            CostPerDay = 6m,
                            Description = "Luke Skywalker embarca em uma aventura para salvar a galáxia do Império.",
                            Duration = "02:01",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/2w4xG178RpB4MDAIfTkqAuSJzec.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/tKf7WKYeSlDFo2BjBEHvMpV6faD.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(1977, 5, 25),
                            Status = 1,
                            SubTitle = "Uma Nova Esperança",
                            Title = "Star Wars: Episódio IV",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/Q8b09bE1iGQ"
                        },
                        new
                        {
                            Id = 10,
                            Category = "Animação",
                            CostPerDay = 3m,
                            Description = "Duas irmãs enfrentam desafios mágicos em uma jornada emocionante de amor e autodescoberta.",
                            Duration = "01:42",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/u2bZhH3nTf0So0UIC1QxAqBvC07.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/AnjnNleCMib4uJ64NViCFxCNnC5.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2013, 11, 27),
                            Status = 1,
                            SubTitle = "Uma Aventura Congelante",
                            Title = "Frozen",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/EBEbqLvrf7w"
                        },
                        new
                        {
                            Id = 11,
                            Category = "Fantasia",
                            CostPerDay = 5m,
                            Description = "Um jovem bruxo descobre seu destino enquanto embarca em sua primeira aventura em Hogwarts.",
                            Duration = "02:32",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/5jkE2SzR5uR2egEb1rRhF22JyWN.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/tq2NwrrRxwvEsYCzef0Lg0yIonz.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2001, 11, 16),
                            Status = 1,
                            SubTitle = "",
                            Title = "Harry Potter e a Pedra Filosofal",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/SFzft_2dcV0"
                        },
                        new
                        {
                            Id = 12,
                            Category = "Ação",
                            CostPerDay = 6m,
                            Description = "O rei de Wakanda luta para proteger seu povo e manter sua nação em segredo do mundo exterior.",
                            Duration = "02:14",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/b6ZJZHUdMEFECvGiDpJjlfUWela.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/ubXNpxL2ASSzY0f8Hxv08pOsV2L.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2018, 2, 16),
                            Status = 1,
                            SubTitle = "",
                            Title = "Pantera Negra",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/FR9iLjOubWc"
                        },
                        new
                        {
                            Id = 13,
                            Category = "Ação",
                            CostPerDay = 7m,
                            Description = "Peter Parker enfrenta desafios quando o multiverso é aberto e vilões do passado retornam.",
                            Duration = "02:28",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/14QbnygCuTO0vl7CAFmPf1fgZfV.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/8qBccgSj0Ru9Odm1Mjv82cxDr7l.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2021, 12, 17),
                            Status = 1,
                            SubTitle = "",
                            Title = "Homem-Aranha: Sem Volta Para Casa",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/CyiiEJRZjSU"
                        },
                        new
                        {
                            Id = 14,
                            Category = "Comédia",
                            CostPerDay = 4m,
                            Description = "As aventuras de João Grilo e Chicó em um sertão repleto de humor, desafios e dilemas morais.",
                            Duration = "01:44",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/alQqTpmEkxSLgajfEYTsTH6nAKB.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/imcOp1kJsCsAFCoOtY5OnPrFbAf.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2000, 9, 15),
                            Status = 1,
                            SubTitle = "",
                            Title = "O Auto da Compadecida",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/XPuMu_ENzlg"
                        },
                        new
                        {
                            Id = 15,
                            Category = "Aventura",
                            CostPerDay = 5m,
                            Description = "Cientistas criam um parque com dinossauros clonados, mas tudo sai de controle.",
                            Duration = "02:07",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/mzFjAVLdZAD6UDT5BMRItHL5IVf.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/oU7Oq2kFAAlGqbU4VoAE36g4hoI.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(1993, 6, 11),
                            Status = 1,
                            SubTitle = "",
                            Title = "Jurassic Park: O Parque dos Dinossauros",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/fLDR-YYK7jQ"
                        },
                        new
                        {
                            Id = 16,
                            Category = "Ficção Científica",
                            CostPerDay = 5m,
                            Description = "Um grupo de jovens descobre como viajar no tempo, mas as consequências são imprevisíveis.",
                            Duration = "01:46",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/eyJk5LTMLIeAN2kVsP0yXrPZJfl.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/2krLUKMsKbnZk6j647IlkqlMZ2u.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2015, 1, 28),
                            Status = 1,
                            SubTitle = "",
                            Title = "Projeto Almanaque",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/MmnLVu43z6s"
                        },
                        new
                        {
                            Id = 17,
                            Category = "Drama",
                            CostPerDay = 4m,
                            Description = "Um professor encontra um cachorro que lhe ensina lições sobre amor e lealdade.",
                            Duration = "01:33",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/a5pOEjOLvr04Hr8qktIDM75OZi0.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/6fQ9xOMduIIn4U1lzoiNwex5KSU.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2009, 6, 13),
                            Status = 1,
                            SubTitle = "",
                            Title = "Sempre ao Seu Lado",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/UFY8vW5IedY"
                        },
                        new
                        {
                            Id = 18,
                            Category = "Animação",
                            CostPerDay = 5m,
                            Description = "Um jovem leão enfrenta desafios para aceitar seu destino como rei da savana.",
                            Duration = "01:58",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/wXsQvli6tWqja51pYxXNG1LFIGV.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/8aIvm8OaJISOpVTt7rMIh7X35G5.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(1994, 6, 24),
                            Status = 1,
                            SubTitle = "",
                            Title = "O Rei Leão",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/rHiHRhbTv-Q"
                        },
                        new
                        {
                            Id = 19,
                            Category = "Drama",
                            CostPerDay = 6m,
                            Description = "A história de dois jovens crescendo em uma favela violenta do Rio de Janeiro, com caminhos opostos na vida.",
                            Duration = "02:10",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/uvitbjFU4JqvMwIkMWHp69bmUzG.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/uchp7b4goGM78HlD8f1NQbG8rxm.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2002, 8, 30),
                            Status = 1,
                            SubTitle = "",
                            Title = "Cidade de Deus",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/fZJUKixyeXM"
                        },
                        new
                        {
                            Id = 20,
                            Category = "Ação",
                            CostPerDay = 5m,
                            Description = "Um capitão do BOPE enfrenta os desafios da criminalidade e corrupção no Rio de Janeiro.",
                            Duration = "01:55",
                            ImageBannerUrl = "https://image.tmdb.org/t/p/original/pstB0q2QloZBU8csDurLwR0fYdN.jpg",
                            ImageIconUrl = "https://image.tmdb.org/t/p/original/atl4a9VFVP7JYvk4GeSgqhLOfjC.jpg",
                            LastModifiedDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            RegistrationDateTime = new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified),
                            ReleaseDate = new DateOnly(2007, 10, 5),
                            Status = 1,
                            SubTitle = "",
                            Title = "Tropa de Elite",
                            YouTubeTraillerUrl = "https://www.youtube.com/embed/A6W-nNPl1T8"
                        });
                });

            modelBuilder.Entity("LocaFilms.Models.MovieRentals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentalEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentalStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RentalStatus")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("MovieRentals");
                });

            modelBuilder.Entity("LocaFilms.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LocaFilms.Models.MovieRentals", b =>
                {
                    b.HasOne("LocaFilms.Models.MovieModel", "Movie")
                        .WithMany("MovieRentals")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocaFilms.Models.UserModel", "User")
                        .WithMany("MovieRentals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LocaFilms.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LocaFilms.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocaFilms.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LocaFilms.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocaFilms.Models.MovieModel", b =>
                {
                    b.Navigation("MovieRentals");
                });

            modelBuilder.Entity("LocaFilms.Models.UserModel", b =>
                {
                    b.Navigation("MovieRentals");
                });
#pragma warning restore 612, 618
        }
    }
}
