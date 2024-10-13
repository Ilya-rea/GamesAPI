using System;
using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Models
{
	public class GameForm
	{
		public int Id { get; set; }

        [Required]
        public string nameOfGame { get; set; }

        [Required]
        public string studio { get; set; }

        [Required]
        public string Genre { get; set; }
	}
}

