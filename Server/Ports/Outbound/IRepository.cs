namespace Server.Ports.Outbound
{
    public interface IRepository<T, ID> where T : class
    {
        Task<T?> GetByIdAsync(ID id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(ID id);
    }
}
