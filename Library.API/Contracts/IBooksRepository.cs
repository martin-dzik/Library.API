using Library.API.Models;
using Library.API.Repository;

namespace Library.API.Contracts
{
    public interface IBooksRepository : IRepository<Book>
    {
        Task<Book?> GetBookWithAuthorsByIdAsync(int id);

        Task<Book?> GetBookWithAuthorsByIdAsNoTrackingAsync(int id);
    }
}
