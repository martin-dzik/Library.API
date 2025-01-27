using FluentAssertions;
using Library.API.Data.Data;
using Library.API.Data.Models;
using Library.API.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.API.Tests.RepositoryTests
{
    public class BooksRepositoryTests
    {
        public List<Book> Books { get; set; } = new List<Book>
        {
            new Book 
            { 
                Id = 1, Name = "The Fight of Our Lives", ISBN = "12345-6789-11", AvailableCount = 2,
                Authors = new List<Author> { new Author { Id = 8, Name = "Jullia", Surname = "Mendel" } }
            },
            new Book 
            { 
                Id = 2, Name = "Brak", ISBN = "88888-7777-65", AvailableCount = 1,
                Authors = new List<Author> { new Author { Id = 9, Name = "Charles", Surname = "Bukowski" } }
            },
            new Book 
            { 
                Id = 3, Name = "Dexter", ISBN = "11223-4444-89", AvailableCount = 1,
                Authors = new List<Author> { new Author { Id = 10, Name = "Jeff", Surname = "Lindsay" } }
            }
        };

        private async Task<LibraryDbContext> GetDbContextWithDataAsync()
        {
            var _dbContext = await new DatabaseContext().GetDbContext();

            if (await _dbContext.Books.CountAsync() <= 0)
            {
                await _dbContext.Books.AddRangeAsync(Books);
            }

            await _dbContext.SaveChangesAsync();

            return _dbContext;
        }

        [Fact]
        public async Task BooksRepositor_GetAllWithAuthorsAsync_ReturnsBooksWithAuthors()
        {
            // Arrange
            var _dbContext = await GetDbContextWithDataAsync();
            var _booksRepository = new BooksRepository(_dbContext);

            // Act
            var result = await _booksRepository.GetAllWithAuthorsAsync();

            // Assert
            result.Count().Should().Be(3);
            result.Should().Contain(Books);
        }
    }
}
