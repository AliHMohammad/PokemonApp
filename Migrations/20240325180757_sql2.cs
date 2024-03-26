using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApp.Migrations
{
    /// <inheritdoc />
    public partial class sql2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlStatements = File.ReadAllText("./SeedData.sql");
            if (sqlStatements == "" || sqlStatements == null) throw new Exception("SQL Could not be read. Try again");

            migrationBuilder.Sql(sqlStatements);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}


