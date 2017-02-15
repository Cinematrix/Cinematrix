using Cinema.Data.Models;
using Cinema.Data.Repositories;
using Cinema.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Services
{
    public class SeatService : ISeatService
    {
        private const string SeatName = "Seat";

        private IRepository<FilmScreening> screenings;

        public SeatService(IRepository<FilmScreening> screenings)
        {
            this.screenings = screenings;
        }

        public int GetUserBookedSeatsCountByScreeningId(string userName, string filmScreeningId)
        {
            int parsedId;
            int.TryParse(filmScreeningId, out parsedId);
            var targetScreening = this.screenings.GetById(parsedId);

            return targetScreening.Seats.Where(s => s.User != null && s.User.UserName == userName).Count();
        }

        public string GetBookedSeatsAsString(string userName, string filmScreeningId)
        {
            int parsedId;
            int.TryParse(filmScreeningId, out parsedId);
            var targetScreening = this.screenings.GetById(parsedId);

            var bookedSeats = targetScreening.Seats.ToArray();
            var expression = new List<string>();

            for (int i = 0; i < bookedSeats.Length; i++)
            {
                if (bookedSeats[i].User != null && bookedSeats[i].User.UserName == userName)
                {
                    expression.Add(SeatName + (i + 1).ToString());
                }
            }

            string output = string.Join(" ,", expression);
            return output;
        }

        public string GetPrice(string userName, string filmScreeningId)
        {
            int parsedId;
            int.TryParse(filmScreeningId, out parsedId);
            var targetScreening = this.screenings.GetById(parsedId);
            int bookedTicketsCount = targetScreening.Seats.Where(s => s.User != null && s.User.UserName == userName).Count();

            decimal totalPrice = targetScreening.Price * bookedTicketsCount;
            string result = "Total Price: " + string.Format("{0:C}", totalPrice);

            return result;
        }
    }
}
