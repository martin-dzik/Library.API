using System.ComponentModel.DataAnnotations;

namespace Library.API.Data.DTOs.AuthorDtos
{
    public class AuthorDtoBase
    {
        [StringLength(100, MinimumLength = 2)]
        public required string Name { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public required string Surname { get; set; }
    }
}
