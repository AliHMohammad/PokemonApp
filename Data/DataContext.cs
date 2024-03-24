using Microsoft.EntityFrameworkCore;
using PokemonApp.Models;

namespace PokemonApp.Data
{
    //DataContext extender DbContext
    public class DataContext : DbContext
    {

        //Alle mine models
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        //Contructor. Modtager DbContextOptions, som smides i super(options) [base() i c#]
        public DataContext(DbContextOptions options) : base(options)
        {

        }

    }
}
