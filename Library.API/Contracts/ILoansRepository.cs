using Library.API.Models;

namespace Library.API.Contracts
{
    public interface ILoansRepository : IRepository<Loan>
    {
        Task<IList<Loan>?> GetAllWithReadersAsync();
    }
}
