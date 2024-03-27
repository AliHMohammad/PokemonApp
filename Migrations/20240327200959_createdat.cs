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
                value: new DateTime(2024, 3, 27, 21, 9, 59, 561, DateTimeKind.Local).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 3, 27, 21, 9, 59, 561, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 3, 27, 21, 9, 59, 561, DateTimeKind.Local).AddTicks(8549));
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
