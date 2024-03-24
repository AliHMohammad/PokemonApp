using PokemonApp.Data;
using PokemonApp.Models;

namespace PokemonApp
{

    //Application runner. Dummy data
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Pokemons.Any())
            {
                var pokemons = new List<Pokemon>()
                {
                    new Pokemon()
                    {
                        Name = "Pikachu",
                        BirthDate = new DateTime(1903, 1, 1),
                        Reviews = new List<Review>()
                            {
                                new Review { Title="Pikachu",Text = "Pickahu is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        
                    },
                };
                dataContext.Pokemons.AddRange(pokemons);
                dataContext.SaveChanges();
            }
        }
    }
}
