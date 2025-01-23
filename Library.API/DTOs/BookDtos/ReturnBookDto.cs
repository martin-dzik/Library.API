using Library.API.DTOs.AuthorDtos;

namespace Library.API.DTOs.BookDtos
{
    public class ReturnBookDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string ISBN { get; set; }

        public required ICollection<AuthorDto> Authors { get; set; }
    }
}
