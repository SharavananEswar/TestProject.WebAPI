using Microsoft.EntityFrameworkCore;
using ZipPay.EF.MySQLProvider;
using ZipPay.Model;
using ZipPay.Repository.Contracts;

namespace ZipPay.Repository
{
    public abstract class RepositoryBase<T> : IBaseRepository<long, T> where T : class, IEntity<long>
    {
        protected ZipPayEFContext Context { get; set; }
        protected abstract DbSet<T> Table { get; }

        protected RepositoryBase(ZipPayEFContext context)
        {
            Context = context;
        }

        public async virtual Task<T> CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            Context.SaveChanges();

            return entity;
        }

        public async virtual Task<T> UpdateAsync(T entity)
        {
            var updatee = await Table.SingleOrDefaultAsync(e => e.Id == entity.Id);
            if (updatee == null)
                return null;

            updatee = entity;
            await Context.SaveChangesAsync();

            return entity;
        }

        public async virtual Task<T> SelectAsync(long id)
        {
            return await Table.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async virtual Task DeleteAsync(long id)
        {
            var updatee = await this.Table.SingleOrDefaultAsync(e => e.Id == id);
            if (updatee == null)
                return;

            Table.Remove(updatee);
            await Context.SaveChangesAsync();
        }

        public async virtual Task<IEnumerable<T>> ListAsync()
        {
            return await Task.Run(() =>
            {
                return Table.OrderBy(e => e.Id);
            });
        }
    }
}
