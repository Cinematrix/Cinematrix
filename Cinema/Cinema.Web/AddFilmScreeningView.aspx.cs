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
        public IGetMoviesPresenter MoviesPresenter { get; set; }

        [Inject]
        public IAddFilmScreeningPresenter FilmScreeningPresenter { get; set; }

        [Inject]
        public Movie[] AllMovies { get; set; }

        [Inject]
        public FilmScreening FilmScreening { get; set; }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.AllMovies = this.MoviesPresenter.GetAllMovies().ToArray();
                this.SelectMovieDropDownList.DataSource = this.AllMovies;
                this.SelectMovieDropDownList.DataBind();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            this.FilmScreening.Start = DateTime.Parse(this.DateInput.Text);
            string selectedMovieId = this.SelectMovieDropDownList.SelectedItem.Value;
            this.FilmScreening.TargetMovieId = int.Parse(selectedMovieId);

            this.FilmScreeningPresenter.CreateFilmScreening(this.FilmScreening);

            Response.Redirect("/FilmScreeningsView.aspx");
        }

        protected void SelectMovieDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}