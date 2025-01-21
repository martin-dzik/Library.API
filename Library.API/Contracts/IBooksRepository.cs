using Library.API.Models;
using Library.API.Repository;

namespace Library.API.Contracts
{
    public interface IBooksRepository : IRepository<Book>
    {
    }
}
