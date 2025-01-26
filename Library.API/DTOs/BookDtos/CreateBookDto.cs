using Library.API.DTOs.AuthorDtos;
using Library.API.Models;

namespace Library.API.DTOs.BookDtos
{
    public class CreateBookDto
    {
        public required string Name { get; set; }
        public required string ISBN { get; set; }
        public required int AvailableCount { get; set; }

        public required ICollection<AuthorDto> Authors { get; set; }
    }
}
