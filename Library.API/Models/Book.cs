namespace Library.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ISBN { get; set; }


        public virtual ICollection<Author>? Authors { get; set; }

    }
}
