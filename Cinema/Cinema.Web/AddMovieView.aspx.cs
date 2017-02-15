using Cinema.Data.Models;
using Cinema.Presenters.Contracts;
using Ninject;
using System;
using System.Web.UI;

namespace Cinema.Web
{
    public partial class AddMovieView : Page
    {
        [Inject]
        public IAddMoviePresenter Presenter { get; set; }

        [Inject]
        public Movie Movie { get; set; }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            this.Movie.Name = Server.HtmlEncode(this.TitleInput.Text);
            this.Movie.ImageUrl = this.ImageUrlInput.Text;
            this.Movie.Info = Server.HtmlEncode(this.InfoInput.Text);
            this.Movie.Genre = Server.HtmlEncode(this.GenreInput.Text);
            this.Movie.Director = Server.HtmlEncode(this.DirectorInput.Text);
            this.Movie.LengthInMinutes = int.Parse(this.LengthInput.Text);

            this.Presenter.CreateMovie(this.Movie, this);
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            this.TitleInput.Text = string.Empty;
            this.ImageUrlInput.Text = string.Empty;
            this.InfoInput.Text = string.Empty;
            this.GenreInput.Text = string.Empty;
            this.DirectorInput.Text = string.Empty;
            this.LengthInput.Text = string.Empty;
        }
    }
}