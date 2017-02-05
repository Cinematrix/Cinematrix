namespace Cinema.Data.Models.Contracts
{
    public interface ISeat
    {
        bool IsFree { get; set; }

        int UserId { get; set; }
    }
}
