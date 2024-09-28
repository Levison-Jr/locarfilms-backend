using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocaFilms.Migrations
{
    /// <inheritdoc />
    public partial class MovieRentalIdColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RentalId",
                table: "MovieRentals",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MovieRentals",
                newName: "RentalId");
        }
    }
}
