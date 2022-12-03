using Microsoft.EntityFrameworkCore;
using ZipPay.EF.MySQLProvider;
using ZipPay.Model;
using ZipPay.Repository.Contracts;

namespace ZipPay.Repository
{
    public class UserAccountsRepository : RepositoryBase<UserAccount>, IUserAccountsRepository
    {
        protected override DbSet<UserAccount> Table
        {
            get
            {
                return base.Context.UserAccounts;
            }
        }
        public UserAccountsRepository(ZipPayEFContext context) : base(context)
        {

        }
    }
}