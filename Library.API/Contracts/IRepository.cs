namespace Library.API.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        
        Task<T?> GetAsync(int id);

        Task<T> AddAsync(T item);

        Task Update(T item);

        Task DeleteAsync(int it);
    }
}
