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
    public partial class FilmScreeningDetailsView : System.Web.UI.Page
    {
        [Inject]
        public IUpdateFilmScreeningPresenter Presenter { get; set; }

        [Inject]
        public IFilmScreening FilmScreening { get; set; }

        private IList<ImageButton> buttons = new List<ImageButton>();

        private string queryId;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.queryId = Request.QueryString["Id"];
            this.FilmScreening = this.Presenter.GetScreeningById(this.queryId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.buttons.Add(ImageButton00);
            this.buttons.Add(ImageButton01);
            this.buttons.Add(ImageButton02);
            this.buttons.Add(ImageButton03);
            this.buttons.Add(ImageButton04);
            this.buttons.Add(ImageButton05);
            this.buttons.Add(ImageButton06);
            this.buttons.Add(ImageButton07);
            this.buttons.Add(ImageButton08);
            this.buttons.Add(ImageButton09);
            this.buttons.Add(ImageButton10);
            this.buttons.Add(ImageButton11);
            this.buttons.Add(ImageButton12);
            this.buttons.Add(ImageButton13);
            this.buttons.Add(ImageButton14);
            this.buttons.Add(ImageButton15);
            this.buttons.Add(ImageButton16);
            this.buttons.Add(ImageButton17);
            this.buttons.Add(ImageButton18);
            this.buttons.Add(ImageButton19);
        }

        protected void Button0_Click(object sender, EventArgs e)
        {
            var button = sender as ImageButton;

            var senderIndex = int.Parse(button.ID.Substring(button.ID.Length - 2));

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