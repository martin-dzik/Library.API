namespace Library.API.Models
{
    public class Reader
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }


        public virtual ICollection<Loan>? Loans { get; set; }
    }
}
