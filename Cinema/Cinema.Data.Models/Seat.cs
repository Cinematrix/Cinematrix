using Cinema.Data.Models.Contracts;

namespace Cinema.Data.Models
{
    public class Seat : ISeat
    {
        public int Id { get; set; }

        public bool IsFree { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
