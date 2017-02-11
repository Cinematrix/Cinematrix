using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Services.Contracts;
using Cinema.Presenters.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Presenters.MoviePresenters
{
    public class GetMoviesPresenter : IGetMoviesPresenter
    {
        private readonly IMoviesService moviesService;

        public IMovieListView View { get; set; }

        public GetMoviesPresenter(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return this.moviesService.GetAll();
        }

        public IMovie GetMovieById(string id)
        {
            int parsedId = int.Parse(id);
            return this.moviesService.GetById(parsedId);
        }

        public void DeleteMovieById(string id)
        {
            int parsedId = int.Parse(id);
            this.moviesService.DeleteById(parsedId);
        }
    }
}
