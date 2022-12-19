using ZipPay.WebApi.DTOs;

namespace ZipPay.Service.Contracts
{
    public interface IUsersService
    {
        Task<UserResponse> CreateAsync(CreateUserRequest request);
        Task<UserResponse> GetAsync(long id);
        Task<UsersListResponse> ListAsync(int startIndex, int pageSize);
    }
}