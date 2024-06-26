﻿using System.ComponentModel.DataAnnotations;
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
        [Column("reviewer_id")]
        [ForeignKey("Reviewer")]
        public int ReviwerId { get; set; }
        public Reviewer Reviewer { get; set; }

        [Column("pokemon_id")]
        [ForeignKey("Pokemon")]
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}


