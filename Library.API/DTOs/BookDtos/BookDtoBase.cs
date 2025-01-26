﻿using Library.API.DTOs.AuthorDtos;
using System.ComponentModel.DataAnnotations;

namespace Library.API.DTOs.BookDtos
{
    public class BookDtoBase
    {
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ISBN is 13 characters long")]
        public required string ISBN { get; set; }

        public required int AvailableCount { get; set; }

        public required string Name { get; set; }

        public required ICollection<AuthorDto> Authors { get; set; }
    }
}
