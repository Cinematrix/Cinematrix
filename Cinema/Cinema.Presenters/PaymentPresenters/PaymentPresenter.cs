using Bytes2you.Validation;
using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Cinema.Presenters.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Presenters.PaymentPresenters
{
    public class PaymentPresenter : IPaymentPresenter
    {
        private readonly IFilmScreeningService screeningService;
        private readonly ISeatService seatService;

        public PaymentPresenter(IFilmScreeningService screeningService, ISeatService seatService)
        {
            Guard.WhenArgument(screeningService, "screeningService").IsNull().Throw();
            Guard.WhenArgument(seatService, "seatService").IsNull().Throw();

            this.screeningService = screeningService;
            this.seatService = seatService;
        }

        public IQueryable<FilmScreening> GetAllFutureScreenings()
        {
            return this.screeningService.GetAllFutureScreenings();
        }

        public IEnumerable<User> GetUniqueBookersByScreeningId(string id)
        {
            Guard.WhenArgument(id, "id").IsNullOrEmpty().Throw();

            return this.screeningService.GetUniqueBookersFromScreeningById(id);
        }

        public string GetMovieTitleByScreeningId(string id)
        {
            Guard.WhenArgument(id, "id").IsNullOrEmpty().Throw();

            return this.screeningService.GetMovieTitleByScreeningId(id);
        }

        public int GetUserBookedSeatsCountByScreeningId(string userName, string filmScreeningId)
        {
            return this.seatService.GetUserBookedSeatsCountByScreeningId(userName, filmScreeningId);
        }

        public string GetBookedSeatsAsString(string userName, string filmScreeningId)
        {
            return this.seatService.GetBookedSeatsAsString(userName, filmScreeningId);
        }

        public string GetPrice(string userName, string filmScreeningId)
        {
            return this.seatService.GetPrice(userName, filmScreeningId);
        }
    }
}
