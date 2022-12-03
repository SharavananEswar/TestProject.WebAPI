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

        public UserResponse Create(CreateUserRequest request)
        {
            if(request.MonthlyExpenses <= 0)
            {
                throw new ArgumentException($"Specified monthly expense is not valid");
            }

            if (request.MonthlySalary <= 0)
            {
                throw new ArgumentException($"Specified monthly salary is not valid");
            }

            var product = _userRepository.Create(new User()
            {
                UserName = request.UserName,
                EmailAddress = request.EmailAddress,
                MonthlyExpenses = request.MonthlyExpenses,
                MonthlySalary = request.MonthlySalary,
                CreatedAt = DateTime.UtcNow
            });

            return ToResponse(product);
        }

        public UserResponse Get(long id)
        {
            var entity = _userRepository.Select(id);
            if (entity == null)
                throw new ArgumentNullException("User doesn't exists");

            return ToResponse(entity);
        }

        public UsersListResponse List(int page, int pageSize)
        {
            var list = _userRepository.List().ToList();

            return new UsersListResponse()
            {
                Items = list.Skip((page - 1) * pageSize).Take(pageSize).Select(x => ToResponse(x)).ToArray(),
                TotalCount = list.Count
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