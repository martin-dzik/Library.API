using AutoMapper;
using Library.API.DTOs.AuthorDtos;
using Library.API.DTOs.BookDtos;
using Library.API.DTOs.LoanDtos;
using Library.API.DTOs.ReaderDtos;
using Library.API.Models;

namespace Library.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateBookDto, Book>();

            CreateMap<Book, ReturnBookDto>();

            CreateMap<AuthorDto, Author>().ReverseMap();

            CreateMap<UpdateBookDto, Book>();

            CreateMap<CreateReaderDto, Reader>();

            CreateMap<Reader, ReturnReaderDto>();

            CreateMap<Loan, ReturnLoanDto>();
        }
    }
}
