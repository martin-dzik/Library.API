using Library.API.Contracts;
using Library.API.Data;
using Library.API.Models;

namespace Library.API.Repository
{
    public class BooksRepository : Repository<Book>, IBooksRepository
    {
        public BooksRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
