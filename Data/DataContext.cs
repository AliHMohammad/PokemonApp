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

            var country1 = new Country() { Id = 1, Name = "Denmark" };

            var owner1 = new Owner() { Id = 1, FirstName = "Uncle", LastName = "Tom", Gym = "Sats", CountryId = 1 };
            var owner2 = new Owner() { Id = 2, FirstName = "Bette", LastName = "Hansen", Gym = "Sats", CountryId = 1 };

            var pokemon1 = new Pokemon() { Id = 1, Name = "Ali", BirthDate = new DateTime(2000, 12, 9), OwnerId = 1 };
            var pokemon2 = new Pokemon() { Id = 2, Name = "Berfin", BirthDate = new DateTime(2001, 6, 11), OwnerId = 2 };
            var pokemon3 = new Pokemon() { Id = 3, Name = "Jonathan", BirthDate = new DateTime(1999, 4, 22), OwnerId = 2 };



            modelBuilder.Entity<Country>().HasData(country1);
            modelBuilder.Entity<Owner>().HasData(owner1, owner2);
            modelBuilder.Entity<Pokemon>().HasData(pokemon1, pokemon2, pokemon3);
        }

    }
}
