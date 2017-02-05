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
    public partial class AddFilmScreeningView : System.Web.UI.Page
    {
        [Inject]
        public IAddFilmScreeningPresenter Presenter { get; set; }

        [Inject]
        public Movie[] AllMovies { get; set; }
        

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.AllMovies = this.Presenter.GetAllMovies().ToArray();
                this.SelectMovieDropDownList.DataSource = this.AllMovies;
                this.SelectMovieDropDownList.DataBind();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            this.Presenter.CreateFilmScreening(this.DateInput.Text, this.SelectMovieDropDownList.SelectedItem.Value);

            Response.Redirect("/FilmScreeningsView.aspx");
        }
    }
}