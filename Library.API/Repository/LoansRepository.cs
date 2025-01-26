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

        public async Task<IList<Loan>?> GetAllWithReadersAsync()
        {
            return await _dbContext.Loans
                .Include(l => l.Reader)
                .ToListAsync();
        }
    }
}
