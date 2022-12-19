using ZipPay.Model;
using ZipPay.Repository.Contracts;
using ZipPay.Service.Contracts;
using ZipPay.WebApi.DTOs;

namespace ZipPay.Service
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> CreateAsync(CreateUserRequest request)
        {
            var product = await _userRepository.CreateAsync(new User()
            {
                UserName = request.UserName,
                EmailAddress = request.EmailAddress,
                MonthlyExpenses = request.MonthlyExpenses,
                MonthlySalary = request.MonthlySalary,
                CreatedAt = DateTime.UtcNow
            });

            return ToResponse(product);
        }

        public async Task<UserResponse> GetAsync(long id)
        {
            var entity = await _userRepository.SelectAsync(id);
            if (entity == null)
                throw new ArgumentNullException("User doesn't exists");

            return ToResponse(entity);
        }

        public async Task<UsersListResponse> ListAsync(int page, int pageSize)
        {
            var users = (await _userRepository.ListAsync()).ToList();

            return new UsersListResponse()
            {
                Items = users.Skip((page - 1) * pageSize).Take(pageSize).Select(x => ToResponse(x)).ToArray(),
                TotalCount = users.Count
            };                
        }

        private UserResponse ToResponse(User entity)
        {
            return new UserResponse()
            {
                UserName = entity.UserName,
                EmailAddress = entity.EmailAddress,
                MonthlyExpenses = entity.MonthlyExpenses,
                MonthlySalary = entity.MonthlySalary
            };
        }
    }
}