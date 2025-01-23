using Library.API.DTOs.AuthorDtos;

namespace Library.API.DTOs.BookDtos
{
    public class UpdateBookDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string ISBN { get; set; }

        public required ICollection<AuthorDto> Authors { get; set; }

    }
}
