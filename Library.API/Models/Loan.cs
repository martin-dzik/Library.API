namespace Library.API.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }


        public Reader? Reader { get; set; }
        public Guid? ReaderId { get; set; }

        public virtual required ICollection<Book> Books { get; set; }
    }
}
