using AutoMapper;
using Library.API.Contracts;
using Library.API.DTOs.AuthorDtos;
using Library.API.DTOs.BookDtos;
using Library.API.Helpers;
using Library.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBooksRepository _bookRepository;
        private readonly IAuthorsRepository _authorsRepository;

        public BooksController(IMapper mapper, IBooksRepository bookRepository, IAuthorsRepository authorsRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _authorsRepository = authorsRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllWithAuthors()
        {
            var books = await _bookRepository.GetAllWithAuthorsAsync();
            var bookDtos = _mapper.Map<IList<ReturnBookDto>>(books);
            
            return Ok(bookDtos);
        }

        [HttpGet]
        [Route("{id:int}/with-authors")]
        public async Task<IActionResult> GetBookWithAuthorsById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookWithAuthorsByIdAsNoTrackingAsync(id);

            if (book is null)
            {
                return BadRequest();
            }

            var bookDto = _mapper.Map<ReturnBookDto>(book);

            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);

            var dbAuthorIds = createBookDto.Authors.Where(a => a.Id != null).Select(a => a.Id!.Value).ToList();

            var authors = await _authorsRepository.GetAuthorsByIds(dbAuthorIds);
            book = book.GetBookWithMergedAuthors(authors);

            _bookRepository.Add(book);
            await _bookRepository.SaveChangesAsync();

            var bookDto = _mapper.Map<ReturnBookDto>(book);

            return CreatedAtAction(nameof(GetBookWithAuthorsById), new { Id = book.Id }, bookDto);
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto updateBookDto)
        {
            if (id != updateBookDto.Id)
            {
                return BadRequest("Invalid book Id");
            }

            var book = await _bookRepository.GetBookWithAuthorsByIdAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            var dbAuthorIds = updateBookDto.Authors.Where(a => a.Id != null).Select(a => a.Id!.Value).ToList();

            var dbAuthors = await _authorsRepository.GetAuthorsByIds(dbAuthorIds);

            _mapper.Map(updateBookDto, book);

            book = book.GetBookWithMergedAuthors(dbAuthors);
            
            _bookRepository.Update(book);


            try
            {
                await _bookRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (await _bookRepository.RemoveBook(id))
            {
                await _bookRepository.SaveChangesAsync();
                return NoContent();
            }

            return NotFound();
        }

    }
}
