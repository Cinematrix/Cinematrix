using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Services.Contracts;
using Cinema.Presenters.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Presenters.FilmScreeningPresenters
{
    public class UpdateFilmScreeningPresenter : IUpdateFilmScreeningPresenter
    {
        private readonly IFilmScreeningService screeningService;
        private IFilmScreening filmScreening;

        public UpdateFilmScreeningPresenter(IFilmScreeningService screeningService, IFilmScreening filmScreening)
        {
            this.screeningService = screeningService;
            this.filmScreening = filmScreening;
        }

        public void UpdateScreening(string screeningId, IList<Seat> seats)
        {
            int parsedId = int.Parse(screeningId);
            this.filmScreening = this.screeningService.GetById(parsedId);

            this.filmScreening.Seats = seats;
            this.screeningService.UpdateById(parsedId, (FilmScreening)this.filmScreening);
        }

        public IFilmScreening GetScreeningById(string id)
        {
            int parsedId = int.Parse(id);
            return this.screeningService.GetById(parsedId);
        }
    }
}
