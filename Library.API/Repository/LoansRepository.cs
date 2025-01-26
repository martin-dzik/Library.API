using Library.API.Contracts;
using Library.API.Data;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Repository
{
    public class LoansRepository : Repository<Loan>, ILoansRepository
    {
        public LoansRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Loan?> GetAllInfoById(int id)
        {
            return await _dbContext.Loans
                .Where(l => l.Id == id)
                .Include(l => l.Book)
                .ThenInclude(b => b.Authors)
                .Include(l => l.Reader)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Loan>?> GetAllWithReadersAsync(bool onlyActive = false)
        {
            var query = _dbContext.Loans.AsQueryable();

            if (onlyActive)
                query = query.Where(l => l.IsActive);

            query = query
                .Include(l => l.Reader)
                .Include(l => l.Book)
                .ThenInclude(b => b.Authors)
                .AsNoTracking();

            return await query.ToListAsync();
        }
    }
}
