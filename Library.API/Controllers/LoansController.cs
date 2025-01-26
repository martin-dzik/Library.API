using AutoMapper;
using Library.API.Contracts;
using Library.API.DTOs.LoanDtos;
using Library.API.Helpers;
using Library.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoansRepository _loansRepository;
        private readonly IBooksRepository _booksRepository;

        public LoansController(IMapper mapper, ILoansRepository loansRepository, IBooksRepository booksRepository)
        {
            _mapper = mapper;
            _loansRepository = loansRepository;
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loans = await _loansRepository.GetAllWithReadersAsync();
            var loanDtos = _mapper.Map<IList<ReturnLoanDto>>(loans);

            return Ok(loanDtos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var loan = await _loansRepository.GetAsync(id);

            if (loan is null)
            {
                return BadRequest();
            }

            var loanDto = _mapper.Map<ReturnLoanDto>(loan);

            return Ok(loanDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLoanDto createLoanDto)
        {
            var loan = _mapper.Map<Loan>(createLoanDto);

            // get books
            var ids = createLoanDto.Books.Select(b => b.Id).ToList();
            var books = await _booksRepository.GetBooksWithAuthorsByIds(ids);

            foreach (var book in books)
            {
                if (book.AvailableCount == 0)
                {
                    return BadRequest($"Book with Id: {book.Id} is not available right now!");
                }

                book.AvailableCount--;
                
                _booksRepository.Update(book);
            }

            await _booksRepository.SaveChangesAsync();

            loan.Books = books;

            _loansRepository.Add(loan);

            
            await _loansRepository.SaveChangesAsync();            

            var loanDto = _mapper.Map<ReturnLoanDto>(loan);

            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loanDto);
        }
    }
}
