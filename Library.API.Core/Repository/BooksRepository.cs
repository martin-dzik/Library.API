using Library.API.Contracts;
using Library.API.Data.Data;
using Library.API.Helpers;
using Library.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Repository
{
    public class BooksRepository : Repository<Book>, IBooksRepository
    {
        public BooksRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Book>> GetAllWithAuthorsAsync(bool asNoTracking = false)
        {
            var query = _dbContext.Books
                .Include(b => b.Authors)
                .AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        //public async Task<Book?> GetBookWithAuthorsByIdAsNoTrackingAsync(int id)
        //{
        //    return await _dbContext.Books
        //       .Where(b => b.Id == id)
        //       .Include(b => b.Authors)
        //       .AsNoTracking()
        //       .FirstOrDefaultAsync();
        //}

        public async Task<Book?> GetBookWithAuthorsByIdAsync(int id, bool asNoTracking = false)
        {
            var query = _dbContext.Books
               .Where(b => b.Id == id)
               .Include(b => b.Authors)
               .AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveBook(int id)
        {
            var bookToRemove = await _dbContext.Books
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(b => b.Id == id);

            var activeLoanOfBookExists = await _dbContext.Loans
                .Where(l => l.BookId == id && l.IsActive)
                .FirstOrDefaultAsync();

            if (activeLoanOfBookExists != null)
            {
                return false;
            }

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
