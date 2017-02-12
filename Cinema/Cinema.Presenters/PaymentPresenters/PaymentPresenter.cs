using Cinema.Data.Models;
using Cinema.Data.Services.Contracts;
using Cinema.Presenters.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Presenters.PaymentPresenters
{
    public class PaymentPresenter : IPaymentPresenter
    {
        private readonly IFilmScreeningService screeningService;

        public PaymentPresenter(IFilmScreeningService screeningService)
        {
            this.screeningService = screeningService;
        }

        public IQueryable<FilmScreening> GetAllFutureScreenings()
        {
            return this.screeningService.GetAllFutureScreenings();
        }
    }
}
