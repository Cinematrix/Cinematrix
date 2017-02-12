using Cinema.Presenters.Contracts;
using Ninject;
using System;
using System.Globalization;
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

        protected void DatePickerInput_TextChanged(object sender, EventArgs e)
        {
            this.ScreeningsRepeater.DataSource =
                this.Presenter.GetScreeningsByDate(this.DatePickerInput.Text).ToArray();
            this.ScreeningsRepeater.DataBind();
        }
    }
}