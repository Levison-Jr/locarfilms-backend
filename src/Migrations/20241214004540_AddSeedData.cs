using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocaFilms.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Category", "CostPerDay", "Description", "Duration", "ImageBannerUrl", "ImageIconUrl", "LastModifiedDateTime", "RegistrationDateTime", "ReleaseDate", "Status", "SubTitle", "Title", "YouTubeTraillerUrl" },
                values: new object[,]
                {
                    { 1, "Drama", 7m, "Uma emocionante saga sobre uma família mafiosa nos EUA, lidando com poder, traição e honra.", "02:55", "https://image.tmdb.org/t/p/original/7nfMHfkiu8Z8JxQranJvYWwPHtS.jpg", "https://image.tmdb.org/t/p/original/8GM0cNIZKsnczJYDT8odzivDsEo.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(1972, 3, 24), 1, "", "O Poderoso Chefão", "https://www.youtube.com/embed/y_-YWEot_7w" },
                    { 2, "Ficção Científica", 5m, "Em busca de um novo lar para a humanidade, uma equipe viaja através de um buraco de minhoca em busca de respostas.", "02:49", "https://image.tmdb.org/t/p/original/Ys8UIGWJpd2TMuQk8fU77W3mBz.jpg", "https://image.tmdb.org/t/p/original/96LZNXbXW6lNIuNlnn5rbmx5SVS.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2014, 11, 7), 1, "", "Interestelar", "https://www.youtube.com/embed/i6avfCqKcQo" },
                    { 3, "Ação", 6m, "Um especialista em roubo de ideias entra nos sonhos de outros para implantar uma ideia.", "02:28", "https://image.tmdb.org/t/p/original/ii8QGacT3MXESqBckQlyrATY0lT.jpg", "https://image.tmdb.org/t/p/original/ocSXOjaUDHYsCCpmBWcQs78iHXd.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2010, 7, 16), 1, "", "A Origem", "https://www.youtube.com/embed/R_VX0e0PX90" },
                    { 4, "Ação", 4m, "Os heróis restantes tentam reverter as consequências do estalo de Thanos e salvar o universo.", "03:01", "https://image.tmdb.org/t/p/original/vfCYyWwujI5EE160GhKJx80cZ4f.jpg", "https://image.tmdb.org/t/p/original/3tgd7r2JT7GtB2gJ5C2eeZo3rmF.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2019, 4, 26), 1, "", "Vingadores: Ultimato", "https://www.youtube.com/embed/LMOqLeoP2yw" },
                    { 5, "Animação", 3m, "Woody e seus amigos embarcam em uma jornada cheia de diversão e significado para salvar Forky.", "01:40", "https://image.tmdb.org/t/p/original/iG3Gu0T0AkL4D8T8ci2PcufuLyX.jpg", "https://image.tmdb.org/t/p/original/1fXc66h9KU73g74VLWsjtMa5RrS.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2019, 6, 21), 1, "", "Toy Story 4", "https://www.youtube.com/embed/cstg99eiG4E" },
                    { 6, "Ficção Científica", 6m, "Um programador descobre que o mundo em que vive é uma simulação criada por máquinas.", "02:16", "https://image.tmdb.org/t/p/original/nZi1IAiLS4UyW3PVWwN7XZWVX3M.jpg", "https://image.tmdb.org/t/p/original/vK8HPVNYwVAFhMz4QXiHvl36mTd.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(1999, 3, 31), 1, "", "Matrix", "https://www.youtube.com/embed/mPYfd6PCmYY" },
                    { 7, "Fantasia", 7m, "Um hobbit e seus amigos embarcam em uma jornada épica para destruir um anel maligno.", "03:28", "https://image.tmdb.org/t/p/original/juxKiJ6diF06YZokVxIe6cWKgio.jpg", "https://image.tmdb.org/t/p/original/7oPNnmHicGG1eDYTpInGK0jqDa9.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2001, 12, 19), 1, "A Sociedade do Anel", "O Senhor dos Anéis", "https://www.youtube.com/embed/0i86oM1nHjM" },
                    { 8, "Drama", 5m, "A origem do icônico vilão do Batman, mostrando sua transformação em um símbolo de anarquia.", "02:02", "https://image.tmdb.org/t/p/original/n6bUvigpRFqSwmPp1m2YADdbRBc.jpg", "https://image.tmdb.org/t/p/original/kWbwz0JTiEULk2u4bDIdNEG6Oml.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2019, 10, 4), 1, "", "Coringa", "https://www.youtube.com/embed/621pfj0EfIc" },
                    { 9, "Ficção Científica", 6m, "Luke Skywalker embarca em uma aventura para salvar a galáxia do Império.", "02:01", "https://image.tmdb.org/t/p/original/2w4xG178RpB4MDAIfTkqAuSJzec.jpg", "https://image.tmdb.org/t/p/original/tKf7WKYeSlDFo2BjBEHvMpV6faD.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(1977, 5, 25), 1, "Uma Nova Esperança", "Star Wars: Episódio IV", "https://www.youtube.com/embed/Q8b09bE1iGQ" },
                    { 10, "Animação", 3m, "Duas irmãs enfrentam desafios mágicos em uma jornada emocionante de amor e autodescoberta.", "01:42", "https://image.tmdb.org/t/p/original/u2bZhH3nTf0So0UIC1QxAqBvC07.jpg", "https://image.tmdb.org/t/p/original/AnjnNleCMib4uJ64NViCFxCNnC5.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2013, 11, 27), 1, "Uma Aventura Congelante", "Frozen", "https://www.youtube.com/embed/EBEbqLvrf7w" },
                    { 11, "Fantasia", 5m, "Um jovem bruxo descobre seu destino enquanto embarca em sua primeira aventura em Hogwarts.", "02:32", "https://image.tmdb.org/t/p/original/5jkE2SzR5uR2egEb1rRhF22JyWN.jpg", "https://image.tmdb.org/t/p/original/tq2NwrrRxwvEsYCzef0Lg0yIonz.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2001, 11, 16), 1, "", "Harry Potter e a Pedra Filosofal", "https://www.youtube.com/embed/SFzft_2dcV0" },
                    { 12, "Ação", 6m, "O rei de Wakanda luta para proteger seu povo e manter sua nação em segredo do mundo exterior.", "02:14", "https://image.tmdb.org/t/p/original/b6ZJZHUdMEFECvGiDpJjlfUWela.jpg", "https://image.tmdb.org/t/p/original/ubXNpxL2ASSzY0f8Hxv08pOsV2L.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2018, 2, 16), 1, "", "Pantera Negra", "https://www.youtube.com/embed/FR9iLjOubWc" },
                    { 13, "Ação", 7m, "Peter Parker enfrenta desafios quando o multiverso é aberto e vilões do passado retornam.", "02:28", "https://image.tmdb.org/t/p/original/14QbnygCuTO0vl7CAFmPf1fgZfV.jpg", "https://image.tmdb.org/t/p/original/8qBccgSj0Ru9Odm1Mjv82cxDr7l.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2021, 12, 17), 1, "", "Homem-Aranha: Sem Volta Para Casa", "https://www.youtube.com/embed/CyiiEJRZjSU" },
                    { 14, "Comédia", 4m, "As aventuras de João Grilo e Chicó em um sertão repleto de humor, desafios e dilemas morais.", "01:44", "https://image.tmdb.org/t/p/original/alQqTpmEkxSLgajfEYTsTH6nAKB.jpg", "https://image.tmdb.org/t/p/original/imcOp1kJsCsAFCoOtY5OnPrFbAf.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2000, 9, 15), 1, "", "O Auto da Compadecida", "https://www.youtube.com/embed/XPuMu_ENzlg" },
                    { 15, "Aventura", 5m, "Cientistas criam um parque com dinossauros clonados, mas tudo sai de controle.", "02:07", "https://image.tmdb.org/t/p/original/mzFjAVLdZAD6UDT5BMRItHL5IVf.jpg", "https://image.tmdb.org/t/p/original/oU7Oq2kFAAlGqbU4VoAE36g4hoI.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(1993, 6, 11), 1, "", "Jurassic Park: O Parque dos Dinossauros", "https://www.youtube.com/embed/fLDR-YYK7jQ" },
                    { 16, "Ficção Científica", 5m, "Um grupo de jovens descobre como viajar no tempo, mas as consequências são imprevisíveis.", "01:46", "https://image.tmdb.org/t/p/original/eyJk5LTMLIeAN2kVsP0yXrPZJfl.jpg", "https://image.tmdb.org/t/p/original/2krLUKMsKbnZk6j647IlkqlMZ2u.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2015, 1, 28), 1, "", "Projeto Almanaque", "https://www.youtube.com/embed/MmnLVu43z6s" },
                    { 17, "Drama", 4m, "Um professor encontra um cachorro que lhe ensina lições sobre amor e lealdade.", "01:33", "https://image.tmdb.org/t/p/original/a5pOEjOLvr04Hr8qktIDM75OZi0.jpg", "https://image.tmdb.org/t/p/original/6fQ9xOMduIIn4U1lzoiNwex5KSU.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2009, 6, 13), 1, "", "Sempre ao Seu Lado", "https://www.youtube.com/embed/UFY8vW5IedY" },
                    { 18, "Animação", 5m, "Um jovem leão enfrenta desafios para aceitar seu destino como rei da savana.", "01:58", "https://image.tmdb.org/t/p/original/wXsQvli6tWqja51pYxXNG1LFIGV.jpg", "https://image.tmdb.org/t/p/original/8aIvm8OaJISOpVTt7rMIh7X35G5.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(1994, 6, 24), 1, "", "O Rei Leão", "https://www.youtube.com/embed/rHiHRhbTv-Q" },
                    { 19, "Drama", 6m, "A história de dois jovens crescendo em uma favela violenta do Rio de Janeiro, com caminhos opostos na vida.", "02:10", "https://image.tmdb.org/t/p/original/uvitbjFU4JqvMwIkMWHp69bmUzG.jpg", "https://image.tmdb.org/t/p/original/uchp7b4goGM78HlD8f1NQbG8rxm.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2002, 8, 30), 1, "", "Cidade de Deus", "https://www.youtube.com/embed/fZJUKixyeXM" },
                    { 20, "Ação", 5m, "Um capitão do BOPE enfrenta os desafios da criminalidade e corrupção no Rio de Janeiro.", "01:55", "https://image.tmdb.org/t/p/original/pstB0q2QloZBU8csDurLwR0fYdN.jpg", "https://image.tmdb.org/t/p/original/atl4a9VFVP7JYvk4GeSgqhLOfjC.jpg", new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 21, 0, 0, 500, DateTimeKind.Unspecified), new DateOnly(2007, 10, 5), 1, "", "Tropa de Elite", "https://www.youtube.com/embed/A6W-nNPl1T8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
