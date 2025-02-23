using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocaFilms.Migrations
{
    /// <inheritdoc />
    public partial class MovieAndRentalStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieRentals",
                table: "MovieRentals");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "NumberPhysicalMedia",
                table: "Movies",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RentalId",
                table: "MovieRentals",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieRentals",
                table: "MovieRentals",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRentals_UserId",
                table: "MovieRentals",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieRentals",
                table: "MovieRentals");

            migrationBuilder.DropIndex(
                name: "IX_MovieRentals_UserId",
                table: "MovieRentals");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "MovieRentals");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Movies",
                newName: "NumberPhysicalMedia");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieRentals",
                table: "MovieRentals",
                columns: new[] { "UserId", "MovieId" });
        }
    }
}
