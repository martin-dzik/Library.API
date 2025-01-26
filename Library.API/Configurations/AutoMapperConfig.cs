using AutoMapper;
using Library.API.DTOs.AuthorDtos;
using Library.API.DTOs.BookDtos;
using Library.API.DTOs.LoanDtos;
using Library.API.DTOs.ReaderDtos;
using Library.API.Helpers;
using Library.API.Models;

namespace Library.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, ReturnBookDto>();
            CreateMap<UpdateBookDto, Book>();
            CreateMap<BookForLoanDto, Book>();

            CreateMap<AuthorDto, Author>().ReverseMap();

            CreateMap<CreateReaderDto, Reader>();
            CreateMap<Reader, ReturnReaderDto>();
            CreateMap<Reader, ReturnReaderWithLoansDto>();

            CreateMap<Loan, ReturnLoanDto>();
            CreateMap<CreateLoanDto, Loan>()
                .ForMember(dest => dest.StartDate, opt => opt
                    .MapFrom(_ => DateOnly.FromDateTime(DateTime.Now)))
                .ForMember(dest => dest.EndDate, opt => opt
                    .MapFrom(_ => DateOnly.FromDateTime(DateTime.Now.AddDays(Constants.LOAN_DAYS)))
                    );
        }
    }
}
