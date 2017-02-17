using Cinema.Data.Services.Contracts;
using Cinema.Presenters.Contracts;
using System.Linq;
using Cinema.Data.Models;
using System.Web.UI;
using Bytes2you.Validation;

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
            Guard.WhenArgument(screeningService, "screeningService").IsNull().Throw();
            Guard.WhenArgument(moviesService, "moviesService").IsNull().Throw();
            Guard.WhenArgument(navigationService, "navigationService").IsNull().Throw();

            this.screeningService = screeningService;
            this.moviesService = moviesService;
            this.navigationService = navigationService;
        }

        public void CreateFilmScreening(string date, string movieId, string price, Page page)
        {
            this.screeningService.Create(date, movieId, price);

            this.navigationService.Redirect(page, FilmScreeningsListViewUrl);
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return this.moviesService.GetAll();
        }
    }
}
