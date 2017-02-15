using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Services.Contracts
{
    public interface ISeatService
    {
        int GetUserBookedSeatsCountByScreeningId(string userName, string filmScreeningId);

        string GetBookedSeatsAsString(string userName, string filmScreeningId);

        string GetPrice(string userName, string filmScreeningId);
    }
}
