using Library.API.DTOs.BookDtos;
using Library.API.DTOs.ReaderDtos;
using Library.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.API.DTOs.LoanDtos
{
    public class ReturnLoanDto
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsActive { get; set; }


        public required ReturnReaderDto Reader { get; set; }
        public required ReturnBookDto Book { get; set; }
    }
}
