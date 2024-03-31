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

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //many-to-one

        [Column("country_id")]
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        //one-to-many
        public ICollection<Pokemon> Pokemons { get; set; } = new HashSet<Pokemon>();

    }
}


