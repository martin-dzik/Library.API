using Library.API.Models;

namespace Library.API.Contracts
{
    public interface IReadersRepository : IRepository<Reader>
    {
        Task<Reader> GetByGuid(Guid guid);
    }
}
