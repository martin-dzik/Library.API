using Library.API.Data.DTOs.AuthorDtos;

namespace Library.API.Data.DTOs.BookDtos
{
    public class ReturnBookDto : BookDtoBase
    {
        public required int Id { get; set; }
    }
}
