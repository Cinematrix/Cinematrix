using Cinema.Data.Services.Contracts;
using Cinema.Presenters.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Models;

namespace Cinema.Presenters.FilmScreeningPresenters
{
    public class AddFilmScreeningPresenter : IAddFilmScreeningPresenter
    {
        private readonly IFilmScreeningService screeningService;
        private readonly IMoviesService moviesService;
        private IFilmScreening filmScreening;
        private IEnumerable<Seat> seats;

        public AddFilmScreeningPresenter(IFilmScreeningService screeningService, IMoviesService moviesService, IFilmScreening filmScreening, IEnumerable<Seat> seats)
        {
            this.screeningService = screeningService;
            this.moviesService = moviesService;
            this.filmScreening = filmScreening;
            this.seats = seats;
        }

        public void CreateFilmScreening(string date, string movieId)
        {
            this.filmScreening.Start = DateTime.Parse(date);
            this.filmScreening.TargetMovieId = int.Parse(movieId);
            this.filmScreening.Seats = new List<Seat>();

            this.screeningService.Create((FilmScreening)this.filmScreening);
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return this.moviesService.GetAll();
        }
    }
}
