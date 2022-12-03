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

        public UserAccountResponse Create(CreateUserAccountRequest request)
        {
            if (request.UserId <= 0)
            {
                throw new ArgumentException($"Specified user id is not valid");
            }

            var user = _userRepository.Select(request.UserId);
            if (user == null)
            {
                throw new ArgumentNullException($"User {request.UserId} is not found");
            }

            var product = 
                _userAccounntRepository.Create(new UserAccount()
                {
                    UserId = user.Id,
                    CreatedAt = DateTime.UtcNow,
                    Active = true
                });

            return ToResponse(product);
        }

        public UsersAccountsListResponse List(int page, int pageSize)
        {
            var list = _userAccounntRepository.List().ToList();

            return new UsersAccountsListResponse()
            {
                Items = list.Skip((page - 1) * pageSize).Take(pageSize).Select(x => ToResponse(x)).ToArray(),
                TotalCount = list.Count
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