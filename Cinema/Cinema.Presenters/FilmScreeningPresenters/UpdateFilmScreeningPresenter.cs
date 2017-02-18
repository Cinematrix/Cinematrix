using Bytes2you.Validation;
using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Services.Contracts;
using Cinema.Presenters.Contracts;

namespace Cinema.Presenters.FilmScreeningPresenters
{
    public class UpdateFilmScreeningPresenter : IUpdateFilmScreeningPresenter
    {
        private readonly IFilmScreeningService screeningService;

        public UpdateFilmScreeningPresenter(IFilmScreeningService screeningService)
        {
            Guard.WhenArgument(screeningService, "screeningService").IsNull().Throw();
            this.screeningService = screeningService;
        }

        public void UpdateScreening(string screeningId, FilmScreening updatedScreening)
        {
            int parsedId = int.Parse(screeningId);
            this.screeningService.UpdateById(parsedId, updatedScreening);
        }

        public IFilmScreening GetScreeningById(string id)
        {
            return this.screeningService.GetById(id);
        }
    }
}
