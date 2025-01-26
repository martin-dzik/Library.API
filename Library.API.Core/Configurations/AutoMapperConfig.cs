using AutoMapper;
using Library.API.Data.DTOs.AuthorDtos;
using Library.API.Data.DTOs.BookDtos;
using Library.API.Data.DTOs.LoanDtos;
using Library.API.Data.DTOs.ReaderDtos;
using Library.API.Helpers;
using Library.API.Data.Models;

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
