using Cinema.Data.Services.Contracts;
using System.Linq;
using Cinema.Data.Repositories;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Models;
using Bytes2you.Validation;
using System;

namespace Cinema.Data.Services
{
    public class MoviesService : IMoviesService
    {
        private IRepository<Movie> movies;

        public MoviesService(IRepository<Movie> movies)
        {
            Guard.WhenArgument(movies, "movies").IsNull().Throw();

            this.movies = movies;
        }

        public void Create(Movie movieToCreate)
        {
            Guard.WhenArgument(movieToCreate, "movieToCreate").IsNull().Throw();

            this.movies.Add(movieToCreate);
            this.movies.SaveChanges();
        }

        public IQueryable<Movie> GetAll()
        {
            return this.movies.All();
        }

        public IMovie GetById(string id)
        {
            int parsedId;
            bool isNumber = int.TryParse(id, out parsedId);
            if (!isNumber)
            {
                throw new ArgumentException();
            }

            return this.movies.GetById(parsedId);
        }
    }
}
