using System;
using System.Collections.Generic;

namespace Cinema.Data.Models.Contracts
{
    public interface IFilmScreening
    {
        DateTime Start { get; set; }
        
        int TargetMovieId { get; set; }

        ICollection<Seat> Seats { get; set; }
    }
}
