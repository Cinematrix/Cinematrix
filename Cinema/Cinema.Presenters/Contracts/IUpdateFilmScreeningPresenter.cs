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
    public interface IUpdateFilmScreeningPresenter
    {
        void UpdateScreening(string screeningId, FilmScreening updatedScreening);

        IFilmScreening GetScreeningById(string id);
    }
}
