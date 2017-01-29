using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Data.Services;
using Cinema.Data.Services.Contracts;
using Cinema.Presenters.Contracts;
using Cinema.Presenters.MoviePresenters;
using Cinema.Web.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
    }
}