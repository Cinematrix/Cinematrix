using Cinema.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Data.Models;
using Cinema.Data.Repositories;

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

        public Movie GetById(int id)
        {
            return this.movies.GetById(id);
        }

        public void UpdateById(int id, Movie updatedMovie)
        {
            Movie movieToUpdate = this.movies.GetById(id);

            //TODO 
            movieToUpdate = updatedMovie;

            this.movies.SaveChanges();
        }
    }
}
