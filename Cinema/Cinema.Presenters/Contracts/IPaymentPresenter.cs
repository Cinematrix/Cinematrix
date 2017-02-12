using Cinema.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Presenters.Contracts
{
    public interface IPaymentPresenter
    {
        IQueryable<FilmScreening> GetAllFutureScreenings();
    }
}
