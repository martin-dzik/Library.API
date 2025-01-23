using Library.API.Contracts;
using Library.API.Data;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Repository
{
    public class AuthorsRepository : Repository<Author>, IAuthorsRepository
    {
        public AuthorsRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Author>> GetAuthorsByIds(List<int> ids)
        {
            return await _dbContext.Authors
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();
        }
    }
}
