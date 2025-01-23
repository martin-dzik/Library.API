using AutoMapper;
using Library.API.DTOs.AuthorDtos;
using Library.API.DTOs.BookDtos;
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
        }
    }
}
