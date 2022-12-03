using ZipPay.WebApi.DTOs;

namespace ZipPay.Service.Contracts
{
    public interface IUsersService
    {
        UserResponse Create(CreateUserRequest request);
        UserResponse Get(long id);
        UsersListResponse List(int startIndex, int pageSize);
    }
}