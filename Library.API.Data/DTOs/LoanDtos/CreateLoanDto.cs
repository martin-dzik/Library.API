using Library.API.Data.DTOs.BookDtos;
using Library.API.Data.Models;

namespace Library.API.Data.DTOs.LoanDtos
{
    public class CreateLoanDto
    {
        public required Guid ReaderId { get; set; }

        public required BookForLoanDto Book { get; set; }
    }
}
