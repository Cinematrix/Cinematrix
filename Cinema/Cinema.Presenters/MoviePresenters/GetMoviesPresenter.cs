using Cinema.Data.Models;
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

        public GetMoviesPresenter(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public IQueryable<Movie> GetAll()
        {
            return this.moviesService.GetAll();
        }
    }
}
