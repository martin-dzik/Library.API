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
    public class AuthorsRepositoryTests
    {
        public List<Author> Authors { get; set; } = new List<Author>
        {
            new Author { Id = 1, Name = "John", Surname = "Doe" },
            new Author { Id = 2, Name = "Charles", Surname = "Bukowski" },
            new Author { Id = 3, Name = "Jullia", Surname = "Mendel" },
        };

        private async Task<LibraryDbContext> GetDbContextWithDataAsync()
        {
            var _dbContext = await new DatabaseContext().GetDbContext();

            if (await _dbContext.Authors.CountAsync() <= 0)
            {
                await _dbContext.Authors.AddRangeAsync(Authors);
            }

            await _dbContext.SaveChangesAsync();

            return _dbContext;
        }

        [Fact]
        public async Task AuthorsRepository_GetAuthorsByIds_ReturnsAuthors()
        {
            // Arrange
            var _dbContext = await GetDbContextWithDataAsync();
            var ids = new List<int> { 1, 3 };
            var _authorsRepository = new AuthorsRepository(_dbContext);

            // Act
            var result = await _authorsRepository.GetAuthorsByIds(ids);

            // Assert
            result.Count.Should().Be(2);
            result[0].Should().Be(Authors[0]);
            result[1].Should().Be(Authors[2]);
        }
        
    }
}
