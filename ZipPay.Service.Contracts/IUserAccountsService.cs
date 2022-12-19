using ZipPay.WebApi.DTOs;

namespace ZipPay.Service.Contracts
{
    public interface IUserAccountsService
    {
        Task<UserAccountResponse> CreateAsync(CreateUserAccountRequest request);
        Task<UsersAccountsListResponse> ListAsync(int startIndex, int pageSize);
    }
}