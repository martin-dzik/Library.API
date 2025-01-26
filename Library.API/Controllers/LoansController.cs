using AutoMapper;
using Azure;
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
        [Route("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var activeLoans = await _loansRepository.GetAllWithReadersAsync(true);
            var loanDtos = _mapper.Map<IList<ReturnLoanDto>>(activeLoans);

            return Ok(loanDtos);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var loan = await _loansRepository.GetAllInfoById(id);

            if (loan is null)
            {
                return BadRequest();
            }

            var loanDto = _mapper.Map<ReturnLoanDto>(loan);

            return Ok(loanDto);
        }

        [HttpPost]
        [Route("loan")]
        public async Task<IActionResult> Create([FromBody] CreateLoanDto createLoanDto)
        {
            var loan = _mapper.Map<Loan>(createLoanDto);
            var id = createLoanDto.Book.Id;
            var book = await _booksRepository.GetBookWithAuthorsByIdAsync(id);

            if (book is null)
            {
                return BadRequest();
            }

            if (book.AvailableCount == 0)
            {
                return BadRequest($"Book with Id: {book.Id} is not available right now!");
            }

            book.AvailableCount--;
            _booksRepository.Update(book);

            await _booksRepository.SaveChangesAsync();

            loan.Book = book;
            _loansRepository.Add(loan);

            await _loansRepository.SaveChangesAsync();

            var loanDto = _mapper.Map<ReturnLoanDto>(loan);

            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loanDto);
        }

        [HttpPost]
        [Route("return")]
        public async Task<IActionResult> ReturnLoan([FromBody] UpdateLoanDto updateLoanDto)
        {
            var loan = await _loansRepository.GetAsync(updateLoanDto.LoanId);

            if (loan is null)
            {
                return BadRequest();
            }

            var book = await _booksRepository.GetAsync(loan.BookId);

            if (book is null)
            {
                return BadRequest();
            }

            book.AvailableCount++;
            loan.IsActive = false;

            _loansRepository.Update(loan);
            _booksRepository.Update(book);

            await _loansRepository.SaveChangesAsync();
            await _booksRepository.SaveChangesAsync();

            var loanObj = new
            {
                loanId = loan.Id,
                book = book.Name,
                status = "Returned"
                
            };

            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loanObj);
        }
    }
}
