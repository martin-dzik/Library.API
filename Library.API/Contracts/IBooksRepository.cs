using Library.API.Helpers;
using Library.API.Models;
using Library.API.Repository;

namespace Library.API.Contracts
{
    public interface IBooksRepository : IRepository<Book>
    {
        Task<Book?> GetBookWithAuthorsByIdAsync(int id);

        Task<Book?> GetBookWithAuthorsByIdAsNoTrackingAsync(int id);

        Task<IList<Book>> GetAllWithAuthorsAsync();

        Task<bool> RemoveBook(int id);

        Task<IList<Book>?> GetBooksWithAuthorsByIds(List<int> ids);
    }
}
