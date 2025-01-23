namespace Library.API.Models
{
    public class Author
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }


        public virtual ICollection<Book>? Books { get; set; }
    }
}
