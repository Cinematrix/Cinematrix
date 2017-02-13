﻿using Cinema.Data.Models;
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
    public partial class PaymentView : Page
    {
        [Inject]
        public IPaymentPresenter Presenter { get; set; }

        public IList<FilmScreening> screenings = new List<FilmScreening>(20);

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.screenings = this.Presenter.GetAllFutureScreenings().ToList();
            this.SummaryLiteral.Text = string.Empty;
            this.SeatsSummaryLiteral.Text = string.Empty;


            if (!this.Page.IsPostBack)
            {
                this.FilmScreeningsDropDownList.DataSource = this.screenings;
                this.FilmScreeningsDropDownList.DataBind();

                this.UsersDropDownList.DataSource = this.screenings[0].Seats.Select(s => s.User).Where(u => u != null).Distinct().ToArray();
                this.UsersDropDownList.DataBind();
                this.MovieInfoLiteral.Text = this.screenings[0].TargetMovie.Name;
                this.UsersDropDownList_SelectedIndexChanged(sender, e);
            }

            this.UsersDropDownList_SelectedIndexChanged(sender, e);
        }

        protected void FilmScreeningsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedScreening =
                 this.screenings
                 .Where(x => x.Start.ToString() == this.FilmScreeningsDropDownList.Text)
                 .FirstOrDefault()
                 .Seats
                 .Select(s => s.User)
                 .Where(u => u != null)
                 .Distinct()
                 .ToArray();

            this.MovieInfoLiteral.Text = this.screenings.Where(x => x.Start.ToString() == this.FilmScreeningsDropDownList.Text).FirstOrDefault().TargetMovie.Name;
            this.UsersDropDownList.DataSource = selectedScreening;
            this.UsersDropDownList.DataBind();
            this.UsersDropDownList_SelectedIndexChanged(sender, e);
        }

        protected void UsersDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seatsCount =
                this.screenings
                .Where(s => s.Start.ToString() == this.FilmScreeningsDropDownList.Text)
                .FirstOrDefault()
                .Seats
                .Where(x => x.User != null && x.User.UserName == this.UsersDropDownList.Text)
                .Count();

            var bookedSeats =
                 this.screenings
                .Where(s => s.Start.ToString() == this.FilmScreeningsDropDownList.Text)
                .FirstOrDefault()
                .Seats
                .ToArray();

            this.SummaryLiteral.Text = "Booked Seats Count: " + seatsCount.ToString() + " ";
            this.SeatsSummaryLiteral.Text = "Seats :";

            for (int i = 0; i < bookedSeats.Length; i++)
            {
                if (bookedSeats[i].User != null && bookedSeats[i].User.UserName == this.UsersDropDownList.Text)
                {
                    this.SeatsSummaryLiteral.Text += " Seat" + (i + 1).ToString();
                }
            }
        }
        protected void PrintButtonClick(object sender, EventArgs e)
        {

        }
    }
}