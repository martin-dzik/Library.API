using Library.API.DTOs.LoanDtos;

namespace Library.API.DTOs.ReaderDtos
{
    public class ReturnReaderWithLoansDto : ReturnReaderDto
    {
        public virtual ICollection<ReturnLoanDto>? Loans { get; set; }
    }
}
