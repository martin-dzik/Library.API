using Library.API.Contracts;
using Library.API.Data;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Repository
{
    public class ReadersRepository : Repository<Reader>, IReadersRepository
    {
        public ReadersRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Reader?> GetByGuid(Guid guid)
        {
            return await _dbContext.Readers
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == guid);
        }

        public async Task<Reader?> GetWithLoansByGuid(Guid guid, bool onlyActive = false)
        {
            var query = _dbContext.Readers
                .Where(r => r.Id == guid);

            if (onlyActive)
            {
                query = query.Include(r => r.Loans.Where(l => l.IsActive));
            }
            else
            {
                query = query.Include(r => r.Loans);
            }

            return await query
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
