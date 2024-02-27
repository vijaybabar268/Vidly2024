using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}