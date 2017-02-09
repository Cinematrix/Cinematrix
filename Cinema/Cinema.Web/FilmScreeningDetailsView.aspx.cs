using Cinema.Data.Models;
using Cinema.Data.Models.Contracts;
using Cinema.Presenters.Contracts;
using Microsoft.AspNet.Identity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Web
{
    public partial class FilmScreeningDetailsView : Page
    {
        [Inject]
        public IUpdateFilmScreeningPresenter Presenter { get; set; }

        [Inject]
        public IFilmScreening FilmScreening { get; set; }

        private IList<ImageButton> buttons = new List<ImageButton>();

        private string queryId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.queryId = Request.QueryString["Id"];
            this.FilmScreening = this.Presenter.GetScreeningById(this.queryId);

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
            
            if (!Page.IsPostBack)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (this.FilmScreening.Seats[i].IsFree == true)
                    {
                        this.buttons[i].BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        this.buttons[i].BackColor = System.Drawing.Color.Red;
                        this.buttons[i].Enabled = false;
                    }
                }
            }
        }

        protected void Button0_Click(object sender, EventArgs e)
        {
            var button = sender as ImageButton;

            int senderIndex = int.Parse(button.ID.Substring(button.ID.Length - 2));

            var clickedButton = this.buttons[senderIndex];
            var clickedSeat = this.FilmScreening.Seats[senderIndex];

            if (clickedSeat.IsFree == false)
            {
                clickedButton.BackColor = System.Drawing.Color.White;
                clickedSeat.IsFree = true;
                clickedSeat.UserId = User.Identity.GetUserId();

                this.Presenter.UpdateScreening(queryId, (FilmScreening)this.FilmScreening);
            }
            else
            {
                clickedButton.BackColor = System.Drawing.Color.LemonChiffon;
                clickedSeat.IsFree = false;
                clickedSeat.UserId = User.Identity.GetUserId();

                this.Presenter.UpdateScreening(queryId, (FilmScreening)this.FilmScreening);
            }
        }

        protected void SubmitButton_Click1(object sender, EventArgs e)
        {
            for (int i = 0; i < this.FilmScreening.Seats.Count; i++)
            {
                if (this.FilmScreening.Seats[i].IsFree == false)
                {
                    this.buttons[i].BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}