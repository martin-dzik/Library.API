using Library.API.Data.DTOs.LoanDtos;

namespace Library.API.Data.DTOs.ReaderDtos
{
    public class ReturnReaderWithLoansDto : ReaderDtoBase
    {
        public virtual ICollection<ReturnLoanDto>? Loans { get; set; }
    }
}
