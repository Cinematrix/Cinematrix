using System;
using System.Collections.Generic;

namespace Cinema.Data.Models.Contracts
{
    public interface IFilmScreening
    {
        DateTime Start { get; set; }

        decimal Price { get; set; }

        int AvailableSeatsCount { get; }

        int TargetMovieId { get; set; }

        IList<Seat> Seats { get; set; }
    }
}
