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
            return await _dbContext.Readers.FirstOrDefaultAsync(r => r.Id == guid);
        }

        public async Task<Reader?> GetWithLoansByGuid(Guid guid)
        {
            return await _dbContext.Readers
                .Where(r => r.Id == guid)
                .Include(r => r.Loans)
                .FirstOrDefaultAsync();
        }
    }
}
