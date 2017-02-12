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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.screenings = this.Presenter.GetAllFutureScreenings().ToList();
                this.FilmScreeningsDropDownList.DataSource = this.screenings;
                this.FilmScreeningsDropDownList.DataBind();

                this.UsersDropDownList.DataSource = screenings[0].Seats.Select(s => s.User).Where(u => u != null).Distinct().ToArray();
                this.UsersDropDownList.DataBind();
            }
        }

        protected void FilmScreeningsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SummaryLiteral.Text = this.UsersDropDownList.SelectedIndex.ToString();//var selectedScreening =
                                                                                       // this.Presenter.GetAllFutureScreenings().ToList()[this.UsersDropDownList.SelectedIndex].ToString();
                                                                                       //this.UsersDropDownList.DataSource = selectedScreening.Seats.Select(s => s.User).ToArray();
                                                                                       //this.UsersDropDownList.DataBind();
        }

        protected void PrintButtonClick(object sender, EventArgs e)
        {

        }
    }
}