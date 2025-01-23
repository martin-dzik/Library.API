namespace Library.API.DTOs.AuthorDtos
{
    public class AuthorDto
    {
        // null ID means author doesn't exist yet
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
    }
}
