﻿using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Services.Contracts
{
    public interface IFilmScreeningService
    {
        IQueryable<FilmScreening> GetAllScreenings();

        IQueryable<FilmScreening> GetAllScreeningsByDate(string date);

        IQueryable<FilmScreening> GetScreeningsByMovieTitle(string title);

        IQueryable<FilmScreening> GetAllFutureScreenings();

        IFilmScreening GetById(int id);

        int GetAvailableCount(int id);

        void UpdateById(int id, FilmScreening updatedFilmScreening);

        void DeleteById(int id);

        void Create(string date, string movieId, string price);
    }
}
