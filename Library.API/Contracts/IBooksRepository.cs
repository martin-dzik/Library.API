using Library.API.Helpers;
using Library.API.Models;
using Library.API.Repository;

namespace Library.API.Contracts
{
    public interface IBooksRepository : IRepository<Book>
    {
        Task<Book?> GetBookWithAuthorsByIdAsync(int id, bool asNoTracking = false);

        //Task<Book?> GetBookWithAuthorsByIdAsNoTrackingAsync(int id);

        Task<IList<Book>> GetAllWithAuthorsAsync(bool asNoTracking = false);

        Task<bool> RemoveBook(int id);
    }
}
