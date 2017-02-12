using Cinema.Presenters.Contracts;
using System.Linq;
using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Services.Contracts;
using System;

namespace Cinema.Presenters.FilmScreeningPresenters
{
    public class GetFilmScreeningsPresenter : IGetFilmScreeningsPresenter
    {
        private readonly IFilmScreeningService screeningService;

        public GetFilmScreeningsPresenter(IFilmScreeningService screeningService)
        {
            this.screeningService = screeningService;
        }

        public IQueryable<FilmScreening> GetAllFutureScreenings()
        {
            return this.screeningService.GetAllFutureScreenings();
        }

        public IFilmScreening GetScreeningById(string id)
        {
            int parsedId = int.Parse(id);
            return this.screeningService.GetById(parsedId);
        }

        public int GetAvailableCount(string id)
        {
            int parsedId = int.Parse(id);
            return this.screeningService.GetAvailableCount(parsedId);
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
