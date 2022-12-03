using Microsoft.EntityFrameworkCore;
using ZipPay.EF.MySQLProvider;
using ZipPay.Model;
using ZipPay.Repository.Contracts;

namespace ZipPay.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        protected override DbSet<User> Table
        {
            get
            {
                return base.Context.Users;
            }
        }
        public UserRepository(ZipPayEFContext context) : base(context)
        {

        }
    }
}