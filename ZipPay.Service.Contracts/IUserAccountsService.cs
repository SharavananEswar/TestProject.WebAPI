using ZipPay.WebApi.DTOs;

namespace ZipPay.Service.Contracts
{
    public interface IUserAccountsService
    {
        UserAccountResponse Create(CreateUserAccountRequest request);
        UsersAccountsListResponse List(int startIndex, int pageSize);
    }
}