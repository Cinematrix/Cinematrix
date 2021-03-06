﻿using Cinema.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class FilmScreening : IFilmScreening
    {
        [Key]
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public decimal Price { get; set; }

        public int AvailableSeatsCount
        {
            get { return this.Seats.Where(u => u.IsFree == true).Count(); }
        }

        public virtual IList<Seat> Seats { get; set; }

        public int TargetMovieId { get; set; }

        public virtual Movie TargetMovie { get; set; }
    }
}
