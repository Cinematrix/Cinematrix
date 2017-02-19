using System;
using System.Collections.Generic;

namespace Cinema.Data.Models.Contracts
{
    public interface IFilmScreening
    {
        DateTime Start { get; set; }

        decimal Price { get; set; }

        int TargetMovieId { get; set; }

        int AvailableSeatsCount { get; }

        IList<Seat> Seats { get; set; }
    }
}
