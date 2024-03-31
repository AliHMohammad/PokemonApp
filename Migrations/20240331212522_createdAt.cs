using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApp.Migrations
{
    /// <inheritdoc />
    public partial class createdAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Owners",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 3, 31, 23, 25, 21, 920, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 3, 31, 23, 25, 21, 920, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 3, 31, 23, 25, 21, 920, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 3, 31, 23, 25, 21, 920, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 3, 31, 23, 25, 21, 920, DateTimeKind.Local).AddTicks(593));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Owners");

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
    }
}
