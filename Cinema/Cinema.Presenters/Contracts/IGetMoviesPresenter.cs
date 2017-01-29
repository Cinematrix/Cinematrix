using Cinema.Data.Models;
using System.Linq;

namespace Cinema.Presenters.Contracts
{
    public interface IGetMoviesPresenter
    {
        IQueryable<Movie> GetAll();
    }
}
