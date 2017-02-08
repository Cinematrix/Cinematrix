using Cinema.Data.Models;
using System.Web.UI;

namespace Cinema.Presenters.Contracts
{
    public interface IAddMoviePresenter
    {
        void CreateMovie(Movie movieToAdd, Page page);
    }
}
