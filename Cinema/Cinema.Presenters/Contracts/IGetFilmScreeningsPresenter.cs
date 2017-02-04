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
        IQueryable<FilmScreening> GetAllScreenings();

        IFilmScreening GetScreeningById(string id);
    }
}
