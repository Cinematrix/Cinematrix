using Cinema.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class FilmScreening : IFilmScreening
    {
        public int Id { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public IEnumerable<ISeat> Seats { get; set; }
        
        public int TargetMovieId { get; set; }

        public virtual Movie TargetMovie { get; set; }
    }
}
