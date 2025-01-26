using Library.API.Contracts;
using Library.API.Data;
using Library.API.Helpers;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Repository
{
    public class BooksRepository : Repository<Book>, IBooksRepository
    {
        public BooksRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Book>> GetAllWithAuthorsAsync()
        {
            return await _dbContext.Books
                .Include(b => b.Authors)
                .ToListAsync();
        }

        public async Task<IList<Book>?> GetBooksWithAuthorsByIds(List<int> ids)
        {
            return await _dbContext.Books
                .Where(b => ids.Contains(b.Id))
                .Include(b => b.Authors)
                .ToListAsync();
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

        public async Task<bool> RemoveBook(int id)
        {
            var bookToRemove = await _dbContext.Books
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (bookToRemove != null)
            {
                bookToRemove.Authors!.Clear();

                _dbContext.Books.Remove(bookToRemove);

                return true;
            }

            return false;
        }
    }
}
