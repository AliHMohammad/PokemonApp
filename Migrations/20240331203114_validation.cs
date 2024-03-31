using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApp.Migrations
{
    /// <inheritdoc />
    public partial class validation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 3, 31, 22, 31, 13, 598, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 3, 31, 22, 31, 13, 598, DateTimeKind.Local).AddTicks(9880));

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 3, 31, 22, 31, 13, 598, DateTimeKind.Local).AddTicks(9883));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 3, 31, 22, 30, 15, 257, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 3, 31, 22, 30, 15, 257, DateTimeKind.Local).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 3, 31, 22, 30, 15, 257, DateTimeKind.Local).AddTicks(8114));
        }
    }
}
