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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ScreeningsRepeater.DataSource = this.Presenter.GetAllFutureScreenings().ToArray();
            this.ScreeningsRepeater.DataBind();
        }
    }
}