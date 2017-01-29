using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Info { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public int LengthInMinutes { get; set; }
    }
}
