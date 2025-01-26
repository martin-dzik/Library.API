namespace Library.API.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        
        Task<T?> GetAsync(int id);

        void Add(T item);

        void Update(T item);

        Task<bool> Delete(int it);

        Task SaveChangesAsync();

    }
}
