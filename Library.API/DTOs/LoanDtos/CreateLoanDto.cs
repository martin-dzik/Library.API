﻿using Library.API.DTOs.BookDtos;
using Library.API.Models;

namespace Library.API.DTOs.LoanDtos
{
    public class CreateLoanDto
    {
        public Guid ReaderId { get; set; }

        public required BookForLoanDto Book { get; set; }
    }
}
