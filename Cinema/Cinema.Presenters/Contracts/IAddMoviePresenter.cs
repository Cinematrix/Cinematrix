using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;

namespace Cinema.Presenters.Contracts
{
    public interface IAddMoviePresenter
    {
        void CreateMovie(Movie movieToAdd);
    }
}
