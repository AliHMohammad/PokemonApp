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
}


