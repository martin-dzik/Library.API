using Library.API.Contracts;
using Library.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly LibraryDbContext _dbContext;

        public Repository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T item)
        {
            await _dbContext.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext
                .Set<T>()
                .FindAsync(id);

            if (entity != null)
            {
                _dbContext.Remove(entity);
                
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbContext
                .Set<T>()
                .ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbContext
                .Set<T>()
                .FindAsync(id);
        }

        public async Task Update(T item)
        {
            _dbContext.Update(item);

            await _dbContext.SaveChangesAsync();
        }
    }
}
