using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required][MaxLength(500)]
        public string Name { get; set; }

        public Ganre Ganre { get; set; }
        public int GanreId { get; set; }
        [Required]
        public DateTime DateReleased { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        
    }
}