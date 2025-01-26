using System.ComponentModel.DataAnnotations;

namespace Library.API.DTOs.ReaderDtos
{
    public class ReaderDtoBase
    {
        [StringLength(100, MinimumLength = 2)]
        public required string Name { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public required string Surname { get; set; }
    }
}
