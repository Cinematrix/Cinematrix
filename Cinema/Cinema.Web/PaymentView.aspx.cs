using Cinema.Data.Models;
using Cinema.Presenters.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Web
{
    public partial class PaymentView : Page
    {
        [Inject]
        public IPaymentPresenter Presenter { get; set; }

        public IList<FilmScreening> screenings = new List<FilmScreening>(20);

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.screenings = this.Presenter.GetAllFutureScreenings().ToList();
            this.SummaryLiteral.Text = string.Empty;
            this.SeatsSummaryLiteral.Text = string.Empty;
            this.TicketContainer.Visible = false;
            this.PrintScreeningLiteral.Text = string.Empty;
            this.PrintMovieLiteral.Text = string.Empty;

            if (!this.Page.IsPostBack)
            {
                this.FilmScreeningsDropDownList.DataSource = this.screenings;
                this.FilmScreeningsDropDownList.DataBind();
                if (this.screenings.Count > 0)
                {
                    this.UsersDropDownList.DataSource = this.screenings[0].Seats.Select(s => s.User).Where(u => u != null).Distinct().ToArray();
                    this.UsersDropDownList.DataBind();
                    this.MovieInfoLiteral.Text = this.screenings[0].TargetMovie.Name;
                    this.UsersDropDownList_SelectedIndexChanged(sender, e);
                }
            }

            this.UsersDropDownList_SelectedIndexChanged(sender, e);
        }

        protected void FilmScreeningsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedScreening =
                 this.screenings
                 .Where(x => x.Start.ToString() == this.FilmScreeningsDropDownList.Text)
                 .FirstOrDefault()
                 .Seats
                 .Select(s => s.User)
                 .Where(u => u != null)
                 .Distinct()
                 .ToArray();

            this.MovieInfoLiteral.Text = this.screenings.Where(x => x.Start.ToString() == this.FilmScreeningsDropDownList.Text).FirstOrDefault().TargetMovie.Name;
            this.UsersDropDownList.DataSource = selectedScreening;
            this.UsersDropDownList.DataBind();
            this.UsersDropDownList_SelectedIndexChanged(sender, e);
        }

        protected void UsersDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.screenings.Count > 0)
            {

                int seatsCount =
                    this.screenings
                    .Where(s => s.Start.ToString() == this.FilmScreeningsDropDownList.Text)
                    .FirstOrDefault()
                    .Seats
                    .Where(x => x.User != null && x.User.UserName == this.UsersDropDownList.Text)
                    .Count();

                var bookedSeats =
                     this.screenings
                    .Where(s => s.Start.ToString() == this.FilmScreeningsDropDownList.Text)
                    .FirstOrDefault()
                    .Seats
                    .ToArray();

                decimal price =
                    this.screenings
                    .Where(s => s.Start.ToString() == this.FilmScreeningsDropDownList.Text)
                    .FirstOrDefault()
                    .Price;

                this.SummaryLiteral.Text = "Booked Seats Count: " + seatsCount.ToString() + " ";
                this.SeatsSummaryLiteral.Text = "Seats :";
                this.TotalPriceLiteral.Text = "Total Price: " + string.Format("{0:C}", (seatsCount * price));

                for (int i = 0; i < bookedSeats.Length; i++)
                {
                    if (bookedSeats[i].User != null && bookedSeats[i].User.UserName == this.UsersDropDownList.Text)
                    {
                        this.SeatsSummaryLiteral.Text += " Seat" + (i + 1).ToString();
                    }
                }
            }
        }
        protected void PrintButtonClick(object sender, EventArgs e)
        {
            this.PrintScreeningLiteral.Text = "Date: " + this.FilmScreeningsDropDownList.Text;
            this.PrintMovieLiteral.Text = "Movie: " + this.MovieInfoLiteral.Text;
            this.PrintCountLiteral.Text = this.SummaryLiteral.Text;
            this.PrintSeatsSummaryLiteral.Text = this.SeatsSummaryLiteral.Text;
            this.PrintTotalPriceLiteral.Text = this.TotalPriceLiteral.Text;
            this.TicketContainer.Visible = true;
        }
    }
}