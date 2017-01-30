using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
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
            this.MovieImg.Width = 300;
        }
    }
}