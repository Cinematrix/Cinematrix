using Cinema.Presenters.Contracts;
using Ninject;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Web
{
    public partial class PaymentView : Page
    {
        [Inject]
        public IPaymentPresenter Presenter { get; set; }

        private int screenigsCount;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.screenigsCount = this.Presenter.GetAllFutureScreenings().Count();
            this.SummaryLiteral.Text = string.Empty;
            this.SeatsSummaryLiteral.Text = string.Empty;
            this.TicketContainer.Visible = false;
            this.PrintScreeningLiteral.Text = string.Empty;
            this.PrintMovieLiteral.Text = string.Empty;

            if (!this.Page.IsPostBack)
            {
                this.FilmScreeningsDropDownList.DataSource = this.Presenter.GetAllFutureScreenings().ToList();
                this.FilmScreeningsDropDownList.DataBind();

                if (this.screenigsCount > 0)
                {
                    this.UsersDropDownList.DataSource =
                        this.Presenter.GetUniqueBookersByScreeningId(this.FilmScreeningsDropDownList.Text);
                    this.UsersDropDownList.DataBind();

                    this.MovieInfoLiteral.Text =
                        this.Presenter.GetMovieTitleByScreeningId(this.FilmScreeningsDropDownList.Text);
                    this.UsersDropDownList_SelectedIndexChanged(sender, e);
                }
            }

            this.UsersDropDownList_SelectedIndexChanged(sender, e);
        }

        protected void FilmScreeningsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bookers = this.Presenter.GetUniqueBookersByScreeningId(this.FilmScreeningsDropDownList.Text);

            this.MovieInfoLiteral.Text =
                this.Presenter.GetMovieTitleByScreeningId(this.FilmScreeningsDropDownList.Text);
            this.UsersDropDownList.DataSource = bookers;
            this.UsersDropDownList.DataBind();
            this.UsersDropDownList_SelectedIndexChanged(sender, e);
        }

        protected void UsersDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.screenigsCount > 0)
            {
                int seatsCount =
                    this.Presenter.GetUserBookedSeatsCountByScreeningId(this.UsersDropDownList.Text, this.FilmScreeningsDropDownList.Text);

                this.SeatsSummaryLiteral.Text =
                    this.Presenter.GetBookedSeatsAsString(this.UsersDropDownList.Text, this.FilmScreeningsDropDownList.Text);

                this.SummaryLiteral.Text = "Booked Seats Count: " + seatsCount.ToString();

                this.TotalPriceLiteral.Text =
                    this.Presenter.GetPrice(this.UsersDropDownList.Text, this.FilmScreeningsDropDownList.Text);
            }
        }

        protected void PrintButtonClick(object sender, EventArgs e)
        {
            this.PrintScreeningLiteral.Text = "Date: " + this.FilmScreeningsDropDownList.SelectedItem.Text;
            this.PrintMovieLiteral.Text = "Movie: " + this.MovieInfoLiteral.Text;
            this.PrintCountLiteral.Text = this.SummaryLiteral.Text;
            this.PrintSeatsSummaryLiteral.Text = this.SeatsSummaryLiteral.Text;
            this.PrintTotalPriceLiteral.Text = this.TotalPriceLiteral.Text;
            this.TicketContainer.Visible = true;
        }
    }
}