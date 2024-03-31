using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonApp.Entities
{
    public class Category
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        //many-to-many
        public ICollection<Pokemon> Pokemons { get; set; }
    }


    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Category").WithTags(nameof(Category));

            group.MapGet("/", async (DataContext db) =>
            {
                return await db.Categories.ToListAsync();
            })
            .WithName("GetAllCategories")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<Category>, NotFound>> (int id, DataContext db) =>
            {
                return await db.Categories.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.Id == id)
                    is Category model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetCategoryById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Category category, DataContext db) =>
            {
                var affected = await db.Categories
                    .Where(model => model.Id == id)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.Id, category.Id)
                      .SetProperty(m => m.Name, category.Name)
                      );
                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateCategory")
            .WithOpenApi();

            group.MapPost("/", async (Category category, DataContext db) =>
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/Category/{category.Id}", category);
            })
            .WithName("CreateCategory")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, DataContext db) =>
            {
                var affected = await db.Categories
                    .Where(model => model.Id == id)
                    .ExecuteDeleteAsync();
                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteCategory")
            .WithOpenApi();
        }
    }
}


