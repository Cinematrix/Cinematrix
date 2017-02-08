using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Cinema.Presenters.Contracts
{
    public interface IAddFilmScreeningPresenter
    {
        void CreateFilmScreening(string date, string movieId, Page page);

        IQueryable<Movie> GetAllMovies();
    }
}
