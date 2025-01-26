using Library.API.Data.DTOs.BookDtos;
using Library.API.Data.DTOs.ReaderDtos;
using Library.API.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.API.Data.DTOs.LoanDtos
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
