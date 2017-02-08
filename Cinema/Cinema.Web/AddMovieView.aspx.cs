using Cinema.Data.Models;
using Cinema.Presenters.Contracts;
using Ninject;
using System;
using System.Web.UI;

namespace Cinema.Web
{
    public partial class AddMovieView : Page, Presenters.Contracts.IAddMovieView
    {
        [Inject]
        public IAddMoviePresenter Presenter { get; set; }

        [Inject]
        public Movie Movie { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Info { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public int LengthInMinutes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            this.Movie.Name = this.TitleInput.Text;
            this.Movie.ImageUrl = this.ImageUrlInput.Text;
            this.Movie.Info = this.InfoInput.Text;
            this.Movie.Genre = this.GenreInput.Text;
            this.Movie.Director = this.DirectorInput.Text;
            this.Movie.LengthInMinutes = int.Parse(this.LengthInput.Text);

            this.Presenter.CreateMovie(this.Movie);
            Response.Redirect("/MoviesListView.aspx");
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            this.TitleInput.Text=string.Empty;
            this.ImageUrlInput.Text = string.Empty;
            this.InfoInput.Text = string.Empty;
            this.GenreInput.Text = string.Empty;
            this.DirectorInput.Text = string.Empty;
            this.LengthInput.Text = string.Empty;
        }
    }
}