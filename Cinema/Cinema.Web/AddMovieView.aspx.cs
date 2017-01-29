using Cinema.Web.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Web
{
    public partial class AddMovieView : System.Web.UI.Page, IAddMovieView
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Info { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public int LengthInMinutes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            this.Name = this.NameInput.Text;
            this.ImageUrl = this.ImageUrlInput.Text;
            this.Info = this.InfoInput.Text;
            this.Genre = this.GenreInput.Text;
            this.Director = this.DirectorInput.Text;
            this.LengthInMinutes = int.Parse(this.LengthInput.Text);
        }
    }
}