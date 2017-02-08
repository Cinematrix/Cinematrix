﻿using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Services.Contracts;
using Cinema.Presenters.Contracts;
using System.Web.UI;

namespace Cinema.Presenters.MoviePresenters
{
    public class AddMoviePresenter : IAddMoviePresenter
    {
        private const string MoviesListViewUrl = "/MoviesListView.aspx";

        private readonly IMoviesService moviesService;
        private readonly INavigationService navigationService;

        public AddMoviePresenter(IMoviesService moviesService, INavigationService navigationService)
        {
            this.moviesService = moviesService;
            this.navigationService = navigationService;
        }

        public void CreateMovie(Movie movieToAdd, Page page)
        {
            this.moviesService.Create(movieToAdd);

            this.navigationService.Redirect(page, MoviesListViewUrl);
        }

    }
}
