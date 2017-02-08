using Cinema.Presenters.Contracts;
using Ninject;
using System;
using System.Linq;
using System.Web.UI;

namespace Cinema.Web
{
    public partial class MoviesListView : Page
    {
        [Inject]
        public IGetMoviesPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewMovies.DataSource = this.Presenter.GetAllMovies().ToArray();
            this.ListViewMovies.DataBind();
        }
    }
}