using Library.API.Contracts;
using Library.API.Data;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Repository
{
    public class BooksRepository : Repository<Book>, IBooksRepository
    {
        public BooksRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Book?> GetBookWithAuthorsByIdAsNoTrackingAsync(int id)
        {
            return await _dbContext.Books
               .Where(b => b.Id == id)
               .Include(b => b.Authors)
               .AsNoTracking()
               .FirstOrDefaultAsync();
        }

        public async Task<Book?> GetBookWithAuthorsByIdAsync(int id)
        {
            return await _dbContext.Books
               .Where(b => b.Id == id)
               .Include(b => b.Authors)
               .FirstOrDefaultAsync();
        }
    }
}
