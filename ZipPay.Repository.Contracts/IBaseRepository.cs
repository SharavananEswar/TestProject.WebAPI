using ZipPay.Model;

namespace ZipPay.Repository.Contracts
{
    public interface IBaseRepository
    {
    }

    public interface IBaseRepository<IdType, T> where T : class, IEntity<long>
    {
        T Create(T entity);
        T Update(T entity);
        T Select(IdType id);
        IEnumerable<T> List();
        void Delete(IdType id);
    }
}