using Cinema.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Services.Contracts
{
    public interface IMoviesService
    {
        IQueryable<Movie> GetAll();

        Movie GetById(int id);

        void UpdateById(int id, Movie updatedMovie);

        void DeleteById(int id);

        void Create(Movie movieToCreate);
    }
}
