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
    public class AddMoviePresenter : IAddMoviePresenter
    {
        private readonly IMoviesService moviesService;

        //TODO: add navigation service

        public AddMoviePresenter(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public void CreateMovie(Movie movieToAdd)
        {
            this.moviesService.Create(movieToAdd);
        }

    }
}
