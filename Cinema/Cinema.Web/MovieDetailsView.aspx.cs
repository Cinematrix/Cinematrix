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

        private IList<ImageButton> buttons = new List<ImageButton>();

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
            this.buttons.Add(ImageButton0);
            this.buttons.Add(ImageButton1);
            this.buttons.Add(ImageButton2);
            this.buttons.Add(ImageButton3);
            this.buttons.Add(ImageButton4);
            this.buttons.Add(ImageButton5);
            this.buttons.Add(ImageButton6);
            this.buttons.Add(ImageButton7);
            this.buttons.Add(ImageButton8);
        }

        protected void Button0_Click(object sender, EventArgs e)
        {
            var button = sender as ImageButton;

            var senderIndex = int.Parse(button.ID.Substring(button.ID.Length - 1));

            var clickedbutton = this.buttons[senderIndex];

            if (clickedbutton.BackColor == System.Drawing.Color.LemonChiffon)
            {
                clickedbutton.BackColor = System.Drawing.Color.White;
            }
            else
            {
                clickedbutton.BackColor = System.Drawing.Color.LemonChiffon;
            }
        }
    }
}