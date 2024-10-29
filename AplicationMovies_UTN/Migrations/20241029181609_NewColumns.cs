using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicationMovies_UTN.Migrations
{
    /// <inheritdoc />
    public partial class NewColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movie",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movie",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movie");
        }
    }
}
