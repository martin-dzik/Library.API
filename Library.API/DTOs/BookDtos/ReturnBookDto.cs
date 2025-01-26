using Library.API.DTOs.AuthorDtos;

namespace Library.API.DTOs.BookDtos
{
    public class ReturnBookDto : BookDtoBase
    {
        public required int Id { get; set; }
    }
}
