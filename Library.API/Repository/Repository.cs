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

        public void Add(T item)
        {
            _dbContext.Add(item);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dbContext
                .Set<T>()
                .FindAsync(id);

            if (entity != null)
            {
                _dbContext.Remove(entity);

                return true;
            }

            return false;
        }
        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbContext
                .Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbContext
                .Set<T>()
                .FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T item)
        {
            _dbContext.Update(item);
        }
    }
}
