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
        public List<Movie> AllMoviesTitles { get; set; }

        [Inject]
        public FilmScreening FilmScreening { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AllMoviesTitles = this.MoviesPresenter.GetAllMovies().ToList();
            this.SelectMovieDropDownList.DataSource = this.AllMoviesTitles;
            this.SelectMovieDropDownList.DataBind();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            this.FilmScreening.Start = DateTime.Parse(this.DateInput.Text);
            this.FilmScreening.TargetMovieId = int.Parse(this.SelectMovieDropDownList.SelectedValue);

            this.FilmScreeningPresenter.CreateFilmScreening(this.FilmScreening);
            Response.Redirect("/MoviesListView.aspx");
        }
    }
}