namespace Cinema.Data.Models.Contracts
{
    public interface ISeat
    {
        bool IsFree { get; set; }

        string UserId { get; set; }
    }
}
