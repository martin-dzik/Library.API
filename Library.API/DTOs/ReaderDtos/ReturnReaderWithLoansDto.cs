using Library.API.DTOs.LoanDtos;

namespace Library.API.DTOs.ReaderDtos
{
    public class ReturnReaderWithLoansDto : ReaderDtoBase
    {
        public virtual ICollection<ReturnLoanDto>? Loans { get; set; }
    }
}
