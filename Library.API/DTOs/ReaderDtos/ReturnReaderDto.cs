using Library.API.DTOs.LoanDtos;

namespace Library.API.DTOs.ReaderDtos
{
    public class ReturnReaderDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }


        public virtual ICollection<ReturnLoanDto>? Loans {  get; set; }
    }
}
