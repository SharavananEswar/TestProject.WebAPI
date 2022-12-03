using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipPay.Model;

namespace ZipPay.Repository.Contracts
{
    public interface IUserRepository : IBaseRepository<long, User>
    {
    }
}
