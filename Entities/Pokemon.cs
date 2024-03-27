using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonApp.Entities
{
    public class Pokemon
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("birthdate")]
        public DateTime BirthDate { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //One-to-many relation
        public ICollection<Review> Reviews { get; set; }

        //Many-to-many relation
        public ICollection<Category> Categories { get; set; }

        public ICollection<Owner> owners { get; set; }


    }
}



