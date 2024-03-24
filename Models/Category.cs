using System.ComponentModel.DataAnnotations;

namespace PokemonApp.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //many-to-many
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}


