using Microsoft.EntityFrameworkCore;
using PokemonApp.Entities;

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().HasData(
                new Pokemon() { Id = 1, Name = "Ali", BirthDate = new DateTime(2000, 12, 9) },
                new Pokemon() { Id = 2, Name = "Berfin", BirthDate = new DateTime(2001, 6, 11) }
            );

        }

    }
}
