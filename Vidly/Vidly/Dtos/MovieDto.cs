using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public GenreDto Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        
        [Range(1, 30)]
        //[Range(1,30, ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        public byte NumberInStock { get; set; }
    }
}