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

            if (!this.Page.IsPostBack)
            {
                this.FilmScreeningsDropDownList.DataSource = this.screenings;
                this.FilmScreeningsDropDownList.DataBind();

                this.UsersDropDownList.DataSource = screenings[0].Seats.Select(s => s.User).Where(u => u != null).Distinct().ToArray();
                this.UsersDropDownList.DataBind();
            }
        }

        protected void FilmScreeningsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList screeningDropDownList = (DropDownList)sender;
            int index = screeningDropDownList.SelectedIndex;

            this.SummaryLiteral.Text = screeningDropDownList.SelectedIndex.ToString();
            var selectedScreening =
            this.Presenter.GetAllFutureScreenings().ToList()[index].Seats.Select(s => s.User).Where(u => u != null).Distinct().ToArray();
            this.UsersDropDownList.DataSource = selectedScreening;
            this.UsersDropDownList.DataBind();
        }

        protected void PrintButtonClick(object sender, EventArgs e)
        {

        }

        protected void UsersDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seatsCount =
                this.screenings
                .Where(s => s.Start.ToString() == this.FilmScreeningsDropDownList.Text)
                .FirstOrDefault()
                .Seats
                .Where(x => x.User != null && x.User.UserName == this.UsersDropDownList.SelectedItem.Text)
                .ToList()
                .Count();

            this.SummaryLiteral.Text = "Booked Seats Count: " + seatsCount.ToString();
        }
    }
}