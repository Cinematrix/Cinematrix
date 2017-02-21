using Cinema.Presenters.Contracts;
using Cinema.Web.Controls;
using Ninject;
using System;
using System.Linq;
using System.Web.UI;

namespace Cinema.Web
{
    public partial class AddFilmScreeningView : System.Web.UI.Page
    {
        [Inject]
        public IAddFilmScreeningPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SelectMovieDropDownList.DataSource = this.Presenter.GetAllMovies().ToArray();
                this.SelectMovieDropDownList.DataBind();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Notifier.AddSuccessMessage("New film screening has been released!");
                Notifier.ShowAfterRedirect = true;

                this.Presenter.CreateFilmScreening(this.DateInput.Text, this.SelectMovieDropDownList.SelectedItem.Value, this.PriceInput.Text, this);               
            }
        }
    }
}