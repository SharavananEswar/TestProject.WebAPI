using Moq;
using System;
using Xunit;
using ZipPay.Model;
using ZipPay.Repository.Contracts;
using ZipPay.Service;
using ZipPay.WebApi.DTOs;

namespace TestProject.Tests.Services
{
    public class UserAccountsServiceTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IUserAccountsRepository> _userAccounntRepository;

        public UserAccountsServiceTests()
        {
            _userAccounntRepository = new Mock<IUserAccountsRepository>();
            _userRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public void CreateUserAccount_Success()
        {
            var request = new CreateUserAccountRequest()
            {
                UserId = 1
            };

            _userAccounntRepository.Setup(s => s.CreateAsync(
                It.IsAny<UserAccount>()))
                .ReturnsAsync(new UserAccount() { Id = request.UserId, UserId = request.UserId});

            _userRepository.Setup(s => s.SelectAsync(
                It.IsAny<long>()))
                .ReturnsAsync(new User() { Id = request.UserId, EmailAddress = "" });

            var userAccService = new UserAccountsService(_userAccounntRepository.Object, _userRepository.Object);
            var response = userAccService.CreateAsync(request).Result;

            Assert.True(response.UserId == request.UserId);
        }

        [Fact]
        public void CreateUserAccount_UserNotFound()
        {
            var request = new CreateUserAccountRequest()
            {
                UserId = 1
            };

            _userRepository.Setup(s => s.SelectAsync(
                It.IsAny<long>()))
                .ReturnsAsync((User)null);

            var userAccService = new UserAccountsService(_userAccounntRepository.Object, _userRepository.Object);
            Assert.Throws<ArgumentNullException>(() => userAccService.CreateAsync(request).Result);
        }

        [Fact]
        public void CreateUserAccount_UserIdNotValid()
        {
            var request = new CreateUserAccountRequest()
            {
                UserId = -1
            };

            var userAccService = new UserAccountsService(_userAccounntRepository.Object, _userRepository.Object);
            Assert.Throws<ArgumentException>(() => userAccService.CreateAsync(request).Result);
        }

        [Fact]
        public void CreateUserAccount_List()
        {
            var list = new UserAccount[]
            {
                new UserAccount()
                {
                    Id =1,
                    UserId = 1,
                    Active = true
                },
                new UserAccount()
                {
                    Id =2,
                    UserId = 2,
                    Active = true
                },
                new UserAccount()
                {
                    Id =3,
                    UserId = 3,
                    Active = true
                }
            };

            _userAccounntRepository.Setup(s => s.ListAsync()).ReturnsAsync(list);

            var userAccService = new UserAccountsService(_userAccounntRepository.Object, _userRepository.Object);
            var response = userAccService.ListAsync(0, 100).Result;

            Assert.True(response.TotalCount == 3);
            Assert.True(response.Items.Length == 3);
        }

        [Fact]
        public void CreateUserAccount_ListWithPageSize()
        {
            var list = new UserAccount[]
            {
                new UserAccount()
                {
                    Id =1,
                    UserId = 1,
                    Active = true
                },
                new UserAccount()
                {
                    Id =2,
                    UserId = 2,
                    Active = true
                },
                new UserAccount()
                {
                    Id =3,
                    UserId = 3,
                    Active = true
                }
            };

            _userAccounntRepository.Setup(s => s.ListAsync()).ReturnsAsync(list);

            var userAccService = new UserAccountsService(_userAccounntRepository.Object, _userRepository.Object);
            var response = userAccService.ListAsync(0, 1).Result;

            Assert.True(response.TotalCount == 3);
            Assert.True(response.Items.Length == 1);
        }
    }
}
