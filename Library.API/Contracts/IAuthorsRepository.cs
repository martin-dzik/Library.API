using Library.API.Models;

namespace Library.API.Contracts
{
    public interface IAuthorsRepository : IRepository<Author>
    {
        Task<IList<Author>> GetAuthorsByIds(List<int> ids);
    }
}
