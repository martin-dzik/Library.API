using AutoMapper;
using Library.API.Contracts;
using Library.API.DTOs.ReaderDtos;
using Library.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReadersRepository _readersRepository;

        public ReadersController(IMapper mapper, IReadersRepository readersRepository)
        {
            _mapper = mapper;
            _readersRepository = readersRepository;
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var reader = await _readersRepository.GetByGuid(id);

            if (reader == null)
            {
                return NotFound();
            }

            var readerDto = _mapper.Map<ReturnReaderDto>(reader);

            return Ok(readerDto);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateReaderDto createReaderDto)
        {
            var reader = _mapper.Map<Reader>(createReaderDto);

            _readersRepository.Add(reader);
            await _readersRepository.SaveChangesAsync();

            var readerDto = _mapper.Map<ReturnReaderDto>(reader);

            return CreatedAtAction(nameof(GetById), new { Id = reader.Id }, readerDto);
        }
    }
}
