using Cinema.Presenters.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Services.Contracts;

namespace Cinema.Presenters.FilmScreeningPresenters
{
    public class GetFilmScreeningsPresenter : IGetFilmScreeningsPresenter
    {
        private readonly IFilmScreeningService screeningService;

        public GetFilmScreeningsPresenter(IFilmScreeningService screeningService)
        {
            this.screeningService = screeningService;
        }

        public IQueryable<FilmScreening> GetAllScreenings()
        {
            return this.screeningService.GetAll().Where(x => x.Start > DateTime.Now);
        }

        public IFilmScreening GetScreeningById(string id)
        {
            int parsedId = int.Parse(id);
            return this.screeningService.GetAll().Where(x=>x.Id==parsedId).FirstOrDefault();
        }

        public int GetAvailableCount(string id)
        {
            int parsedId = int.Parse(id);
            return this.screeningService.GetAvailableCount(parsedId);
        }
    }
}
