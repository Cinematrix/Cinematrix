using Cinema.Presenters.Contracts;
using System.Linq;
using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Services.Contracts;
using Bytes2you.Validation;

namespace Cinema.Presenters.FilmScreeningPresenters
{
    public class GetFilmScreeningsPresenter : IGetFilmScreeningsPresenter
    {
        private readonly IFilmScreeningService screeningService;

        public GetFilmScreeningsPresenter(IFilmScreeningService screeningService)
        {
            Guard.WhenArgument(screeningService, "screeningService").IsNull().Throw();
            this.screeningService = screeningService;
        }

        public IQueryable<FilmScreening> GetAllFutureScreenings()
        {
            return this.screeningService.GetAllFutureScreenings();
        }

        public IFilmScreening GetScreeningById(string id)
        {
            Guard.WhenArgument(id, "id").IsNullOrEmpty().Throw();
            return this.screeningService.GetById(id);
        }

        public int GetAvailableCount(string id)
        {
            Guard.WhenArgument(id, "id").IsNullOrEmpty().Throw();
            return this.screeningService.GetAvailableCount(id);
        }

        public IQueryable<FilmScreening> GetScreeningsByDate(string date)
        {
            return this.screeningService.GetAllScreeningsByDate(date);
        }

        public IQueryable<FilmScreening> GetScreeningsByMovieTitle(string title)
        {
            return this.screeningService.GetScreeningsByMovieTitle(title);
        }
    }
}
