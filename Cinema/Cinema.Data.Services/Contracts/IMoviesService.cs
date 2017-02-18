using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using System.Linq;

namespace Cinema.Data.Services.Contracts
{
    public interface IMoviesService
    {
        IQueryable<Movie> GetAll();

        IMovie GetById(string id);

        void Create(Movie movieToCreate);
    }
}
