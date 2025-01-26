﻿using Library.API.DTOs.BookDtos;

namespace Library.API.DTOs.LoanDtos
{
    public class ReturnLoanDto
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }



        public virtual required ICollection<ReturnBookDto> Books { get; set; }
    }
}
