using System;
using System.Collections.Generic;

namespace Cinema.Data.Models.Contracts
{
    public interface IFilmScreening
    {
        DateTime StartDateTime { get; set; }

        DateTime EndDateTime { get; set; }

        Movie TargetMovie { get; set; }

        IEnumerable<ISeat> Seats { get; set; }
    }
}
