using Library.API.Models;

namespace Library.API.Contracts
{
    public interface IReadersRepository : IRepository<Reader>
    {
        Task<Reader?> GetByGuid(Guid guid);

        Task<Reader?> GetWithLoansByGuid(Guid guid, bool onlyActive = false);
    }
}
