using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using System.Linq;

namespace Cinema.Presenters.Contracts
{
    public interface IGetMoviesPresenter
    {
        IQueryable<Movie> GetAll();

        IMovie GetMovieById(string id);
    }
}
