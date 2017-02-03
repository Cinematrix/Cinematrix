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
    public partial class MoviesListView : System.Web.UI.Page, IMovieListView
    {
        [Inject]
        public IEnumerable<Movie> AllMovies { get; set; }

        [Inject]
        public IGetMoviesPresenter Presenter { get; set; }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.AllMovies = this.Presenter.GetAllMovies().ToArray();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewMovies.DataSource = this.AllMovies;
            this.ListViewMovies.DataBind();
        }
    }
}