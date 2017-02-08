using Cinema.Data.Services.Contracts;
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
        private readonly IFilmScreeningService screeningService;
        private readonly IMoviesService moviesService;
        private readonly INavigationService navigationService;
        private IFilmScreening filmScreening;
        private IEnumerable<Seat> seats;

        public AddFilmScreeningPresenter(
            IFilmScreeningService screeningService,
            IMoviesService moviesService,
            INavigationService navigationService,
            IFilmScreening filmScreening,
            IEnumerable<Seat> seats)
        {
            this.screeningService = screeningService;
            this.moviesService = moviesService;
            this.navigationService = navigationService;
            this.filmScreening = filmScreening;
            this.seats = seats;
        }

        public void CreateFilmScreening(string date, string movieId, Page page)
        {
            this.filmScreening.Start = DateTime.Parse(date);
            this.filmScreening.TargetMovieId = int.Parse(movieId);
            this.filmScreening.Seats = new List<Seat>(20);

            this.screeningService.Create((FilmScreening)this.filmScreening);

            this.navigationService.Redirect(page, "/FilmScreeningsView.aspx");
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return this.moviesService.GetAll();
        }
    }
}
