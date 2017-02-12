using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Presenters.Contracts
{
    public interface IGetFilmScreeningsPresenter
    {
        IQueryable<FilmScreening> GetAllFutureScreenings();

        IFilmScreening GetScreeningById(string id);

        IQueryable<FilmScreening> GetScreeningsByDate(string date);

        IQueryable<FilmScreening> GetScreeningsByMovieTitle(string title);

        int GetAvailableCount(string id);
    }
}
