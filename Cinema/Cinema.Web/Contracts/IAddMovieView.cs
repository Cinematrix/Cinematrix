namespace Cinema.Web.Contracts
{
    public interface IAddMovieView
    {
        string Name { get; set; }

        string ImageUrl { get; set; }

        string Info { get; set; }

        string Genre { get; set; }

        string Director { get; set; }

        int LengthInMinutes { get; set; }

    }
}
