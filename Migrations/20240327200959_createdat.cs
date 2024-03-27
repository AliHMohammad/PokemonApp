using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApp.Migrations
{
    /// <inheritdoc />
    public partial class createdat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Pokemons",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: DateTime.Now);

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: DateTime.Now);

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: DateTime.Now);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Pokemons");
        }
    }
}
