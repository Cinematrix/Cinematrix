using Cinema.Data.Models;
using Cinema.Presenters.Contracts;
using Ninject;
using System;
using System.Linq;

namespace Cinema.Web
{
    public partial class FilmScreeningsView : System.Web.UI.Page
    {
        [Inject]
        public IGetFilmScreeningsPresenter Presenter { get; set; }

        [Inject]
        public FilmScreening[] Screenings { get; set; }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.Screenings = this.Presenter.GetAllScreenings().ToArray();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ScreeningsRepeater.DataSource = this.Screenings;
            this.ScreeningsRepeater.DataBind();
        }
    }
}