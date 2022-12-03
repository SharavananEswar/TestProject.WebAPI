using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.Context = context;
        }

        public virtual T Create(T entity)
        {
            this.Table.Add(entity);
            this.Context.SaveChanges();

            return entity;
        }

        public virtual T Update(T entity)
        {
            var updatee = this.Table.SingleOrDefault(e => e.Id == entity.Id);
            if (updatee == null)
                return null;

            updatee = entity;
            this.Context.SaveChanges();

            return entity;
        }

        public virtual T Select(long id)
        {
            return this.Table.SingleOrDefault(e => e.Id == id);
        }

        public virtual void Delete(long id)
        {
            var updatee = this.Table.SingleOrDefault(e => e.Id == id);
            if (updatee == null)
                return;

            this.Table.Remove(updatee);
            this.Context.SaveChanges();
        }

        public virtual IEnumerable<T> List()
        {
            return this.Table.OrderBy(e => e.Id);
        }
    }
}
