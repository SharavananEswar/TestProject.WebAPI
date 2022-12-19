using ZipPay.Model;
using ZipPay.Repository.Contracts;
using ZipPay.Service.Contracts;
using ZipPay.WebApi.DTOs;

namespace ZipPay.Service
{
    public class UserAccountsService: IUserAccountsService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAccountsRepository _userAccounntRepository;

        public UserAccountsService(
            IUserAccountsRepository userAccounntRepository,
            IUserRepository userRepository)
        {
            _userAccounntRepository = userAccounntRepository;
            _userRepository = userRepository;
        }

        public async Task<UserAccountResponse> CreateAsync(CreateUserAccountRequest request)
        {
            var user = await _userRepository.SelectAsync(request.UserId);
            if (user == null)
                throw new ArgumentNullException($"User {request.UserId} is not found");

            var product = 
                await _userAccounntRepository.CreateAsync(new UserAccount()
                {
                    UserId = user.Id,
                    CreatedAt = DateTime.UtcNow,
                    Active = true
                });

            return ToResponse(product);
        }

        public async Task<UsersAccountsListResponse> ListAsync(int page, int pageSize)
        {
            var accounts = (await _userAccounntRepository.ListAsync()).ToList();

            return new UsersAccountsListResponse()
            {
                Items = accounts.Skip((page - 1) * pageSize).Take(pageSize).Select(x => ToResponse(x)).ToArray(),
                TotalCount = accounts.Count
            };                
        }

        private UserAccountResponse ToResponse(UserAccount entity)
        {
            return new UserAccountResponse()
            {
                UserId = entity.UserId,
                IsActive = entity.Active
            };
        }
    }
}