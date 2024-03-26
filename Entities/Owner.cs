using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonApp.Entities
{
    public class Owner
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("lastname")]
        public string LastName { get; set; }

        [Column("gym")]
        public string Gym { get; set; }

        //many-to-one

        [Column("country_id")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        //many-to-one
        public ICollection<Pokemon> Pokemons { get; set; }

    }
}
