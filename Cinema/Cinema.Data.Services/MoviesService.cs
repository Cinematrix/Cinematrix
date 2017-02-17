using Cinema.Data.Services.Contracts;
using System.Linq;
using Cinema.Data.Repositories;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Models;

namespace Cinema.Data.Services
{
    public class MoviesService : IMoviesService
    {
        private IRepository<Movie> movies;

        public MoviesService(IRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public void Create(Movie movieToCreate)
        {
            this.movies.Add(movieToCreate);
            this.movies.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.movies.Delete(id);
            this.movies.SaveChanges();
        }

        public IQueryable<Movie> GetAll()
        {
            return this.movies.All();
        }

        public IMovie GetById(string id)
        {
            int parsedId = int.Parse(id);
            return this.movies.GetById(parsedId);
        }

        public void UpdateById(int id, Movie updatedMovie)
        {
            IMovie movieToUpdate = this.movies.GetById(id);

            //TODO 
            movieToUpdate = updatedMovie;

            this.movies.SaveChanges();
        }
    }
}
