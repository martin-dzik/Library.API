using Library.API.Data.Models;

namespace Library.API.Contracts
{
    public interface ILoansRepository : IRepository<Loan>
    {
        Task<IList<Loan>?> GetAllWithReadersAsync(bool onlyActive = false);

        Task<Loan?> GetAllInfoById(int id);
    }
}
