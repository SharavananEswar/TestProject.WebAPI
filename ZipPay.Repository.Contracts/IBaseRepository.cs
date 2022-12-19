using ZipPay.Model;

namespace ZipPay.Repository.Contracts
{
    public interface IBaseRepository
    {
    }

    public interface IBaseRepository<IdType, T> where T : class, IEntity<long>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> SelectAsync(IdType id);
        Task<IEnumerable<T>> ListAsync();
        Task DeleteAsync(IdType id);
    }
}