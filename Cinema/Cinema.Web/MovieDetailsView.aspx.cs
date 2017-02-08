using Cinema.Data.Models.Contracts;
using Cinema.Presenters.Contracts;
using Ninject;
using System;

namespace Cinema.Web
{
    public partial class MovieDetailsView : System.Web.UI.Page
    {
        [Inject]
        public IGetMoviesPresenter Presenter { get; set; }

        [Inject]
        public IMovie Movie { get; set; }

        private string queryId;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.queryId = Request.QueryString["Id"];
            this.Movie = this.Presenter.GetMovieById(this.queryId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MovieImg.ImageUrl = this.Movie.ImageUrl;
            this.TitleLabel.Text = this.Movie.Name;
            this.GenreLabel.Text = this.Movie.Genre;
            this.DescriptionLabel.Text = this.Movie.Info;
            this.DirectorLabel.Text = this.Movie.Director;
            this.DurationLabel.Text = this.Movie.LengthInMinutes.ToString();
        }
    }
}