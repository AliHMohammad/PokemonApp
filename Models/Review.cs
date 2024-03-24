﻿using System.ComponentModel.DataAnnotations;

namespace PokemonApp.Models
{
    public class Review
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        //many-to-one
        public Reviewer Reviewer { get; set; }

        public Pokemon Pokemon { get; set; }
    }
}
