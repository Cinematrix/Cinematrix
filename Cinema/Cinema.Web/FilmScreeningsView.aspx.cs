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
            this.ScreeningsRepeater.DataSource =
                this.Presenter.GetAllFutureScreenings().ToArray();
            this.ScreeningsRepeater.DataBind();

            this.ResultLiteral.Text = this.Presenter.GetAllFutureScreenings().Count().ToString();
            this.ResultLiteral.DataBind();
        }

        protected void DatePickerInput_TextChanged(object sender, EventArgs e)
        {
            this.ScreeningsRepeater.DataSource =
                this.Presenter.GetScreeningsByDate(this.DatePickerInput.Text).ToArray();
            this.ScreeningsRepeater.DataBind();

            this.ResultLiteral.Text = this.Presenter.GetScreeningsByDate(this.DatePickerInput.Text).Count().ToString();
            this.ResultLiteral.DataBind();
        }

        protected void SearchInput_TextChanged(object sender, EventArgs e)
        {
            this.ScreeningsRepeater.DataSource =
               this.Presenter.GetScreeningsByMovieTitle(this.SearchInput.Text).ToArray();
            this.ScreeningsRepeater.DataBind();

            this.ResultLiteral.Text = this.Presenter.GetScreeningsByMovieTitle(this.SearchInput.Text).Count().ToString();
            this.ResultLiteral.DataBind();
        }
    }
}