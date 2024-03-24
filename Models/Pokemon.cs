using System.ComponentModel.DataAnnotations;

namespace PokemonApp.Models
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        //One-to-many relation
        public ICollection<Review> Reviews { get; set; }

        //Many-to-many relation
        public ICollection<Category> Categories { get; set; }

        public ICollection<Owner> owners { get; set; }
    }
}



