using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using System.Linq;

namespace Cinema.Data.Services.Contracts
{
    public interface IMoviesService
    {
        IQueryable<Movie> GetAll();

        IMovie GetById(int id);

        void UpdateById(int id, Movie updatedMovie);

        void DeleteById(int id);

        void Create(Movie movieToCreate);
    }
}
