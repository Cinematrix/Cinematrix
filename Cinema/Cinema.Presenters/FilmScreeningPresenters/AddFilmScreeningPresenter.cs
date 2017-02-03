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

        public AddFilmScreeningPresenter(IFilmScreeningService screeningService)
        {
            this.screeningService = screeningService;
        }

        public void CreateFilmScreening(FilmScreening screaningToCreate)
        {
            this.screeningService.Create(screaningToCreate);
        }
    }
}
