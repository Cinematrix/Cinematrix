namespace Cinema.Data.Models.Contracts
{
    public interface IMovie
    {
        string Name { get; set; }

        string ImageUrl { get; set; }

        string Info { get; set; }

        string Genre { get; set; }

        string Director { get; set; }

        int LengthInMinutes { get; set; }
    }
}
