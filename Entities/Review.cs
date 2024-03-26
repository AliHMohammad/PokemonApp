using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonApp.Entities
{
    public class Review
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("rating")]
        public int Rating { get; set; }

        //many-to-one
        
        public Reviewer Reviewer { get; set; }

        
        public Pokemon Pokemon { get; set; }
    }
}


