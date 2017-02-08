﻿using Cinema.Data.Services.Contracts;
using Cinema.Presenters.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Models;
using System.Web.UI;

namespace Cinema.Presenters.FilmScreeningPresenters
{
    public class AddFilmScreeningPresenter : IAddFilmScreeningPresenter
    {
        private const string FilmScreeningsListViewUrl = "/FilmScreeningsView.aspx";

        private readonly IFilmScreeningService screeningService;
        private readonly IMoviesService moviesService;
        private readonly INavigationService navigationService;

        public AddFilmScreeningPresenter(
            IFilmScreeningService screeningService,
            IMoviesService moviesService,
            INavigationService navigationService)
        {
            this.screeningService = screeningService;
            this.moviesService = moviesService;
            this.navigationService = navigationService;
        }

        public void CreateFilmScreening(string date, string movieId, Page page)
        {
            this.screeningService.Create(date, movieId);

            this.navigationService.Redirect(page, FilmScreeningsListViewUrl);
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return this.moviesService.GetAll();
        }
    }
}
