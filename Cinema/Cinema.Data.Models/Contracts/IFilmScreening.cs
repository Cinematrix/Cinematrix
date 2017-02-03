using System;
using System.Collections.Generic;

namespace Cinema.Data.Models.Contracts
{
    public interface IFilmScreening
    {
        DateTime Start { get; set; }

        Movie TargetMovie { get; set; }

        IEnumerable<Seat> Seats { get; set; }
    }
}
