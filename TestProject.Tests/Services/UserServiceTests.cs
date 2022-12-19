using Moq;
using System;
using Xunit;
using ZipPay.Model;
using ZipPay.Repository.Contracts;
using ZipPay.Service;
using ZipPay.WebApi.DTOs;

namespace TestProject.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepository;

        public UserServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public void CreateUser_Success()
        {
            var request = new CreateUserRequest()
            {
                EmailAddress = "oops@test.com",
                UserName = "oops",
                MonthlyExpenses = 100,
                MonthlySalary = 1000
            };

            _userRepository.Setup(s => s.CreateAsync(
                It.IsAny<User>()))
                .ReturnsAsync(new User() { EmailAddress = request.EmailAddress, UserName = request.UserName, MonthlyExpenses = request.MonthlyExpenses, MonthlySalary = request.MonthlySalary });

            var userAccService = new UsersService(_userRepository.Object);
            var response = userAccService.CreateAsync(request).Result;

            Assert.True(response.EmailAddress == request.EmailAddress);
            Assert.Equal(response.UserName, request.EmailAddress);
        }

        [Fact]
        public void CreateUser_MonthlySalaryNotValid()
        {
            var request = new CreateUserRequest()
            {
                EmailAddress = "oops@test.com",
                UserName = "oops",
                MonthlyExpenses = 100,
                MonthlySalary = -1
            };

            var userAccService = new UsersService(_userRepository.Object);
            Assert.Throws<ArgumentException>(() => userAccService.CreateAsync(request).Result);
        }

        [Fact]
        public void CreateUser_MonthlyExpensesNotValid()
        {
            var request = new CreateUserRequest()
            {
                EmailAddress = "oops@test.com",
                UserName = "oops",
                MonthlyExpenses = -1,
                MonthlySalary = 100
            };

            var userAccService = new UsersService(_userRepository.Object);
            Assert.Throws<ArgumentException>(() => userAccService.CreateAsync(request).Result);
        }

        [Fact]
        public void CreateUser_List()
        {
            var list = new User[]
            {
                new User()
                {
                    EmailAddress = "oops1@test.com",
                    UserName = "oops1",
                    MonthlyExpenses = -1,
                    MonthlySalary = 100
                },
                new User()
                {
                    EmailAddress = "oops2@test.com",
                    UserName = "oops2",
                    MonthlyExpenses = -1,
                    MonthlySalary = 100
                },
                new User()
                {
                    EmailAddress = "oops3@test.com",
                    UserName = "oops3",
                    MonthlyExpenses = -1,
                    MonthlySalary = 100
                }
            };

            _userRepository.Setup(s => s.ListAsync()).ReturnsAsync(list);

            var userService = new UsersService(_userRepository.Object);
            var response = userService.ListAsync(0, 100).Result;

            Assert.True(response.TotalCount == 3);
            Assert.True(response.Items.Length == 3);
        }

        [Fact]
        public void CreateUser_ListWithPageSize()
        {
            var list = new User[]
            {
                new User()
                {
                    EmailAddress = "oops1@test.com",
                    UserName = "oops1",
                    MonthlyExpenses = -1,
                    MonthlySalary = 100
                },
                new User()
                {
                    EmailAddress = "oops2@test.com",
                    UserName = "oops2",
                    MonthlyExpenses = -1,
                    MonthlySalary = 100
                },
                new User()
                {
                    EmailAddress = "oops3@test.com",
                    UserName = "oops3",
                    MonthlyExpenses = -1,
                    MonthlySalary = 100
                }
            };

            _userRepository.Setup(s => s.ListAsync()).ReturnsAsync(list);

            var userService = new UsersService(_userRepository.Object);
            var response = userService.ListAsync(0, 1).Result;

            Assert.True(response.TotalCount == 3);
            Assert.True(response.Items.Length == 1);
        }

        [Fact]
        public void CreateUser_NotExistsPageDataSize()
        {
            var list = new User[]
            {
                new User()
                {
                    EmailAddress = "oops1@test.com",
                    UserName = "oops1",
                    MonthlyExpenses = -1,
                    MonthlySalary = 100
                },
                new User()
                {
                    EmailAddress = "oops2@test.com",
                    UserName = "oops2",
                    MonthlyExpenses = -1,
                    MonthlySalary = 100
                },
                new User()
                {
                    EmailAddress = "oops3@test.com",
                    UserName = "oops3",
                    MonthlyExpenses = -1,
                    MonthlySalary = 100
                }
            };

            _userRepository.Setup(s => s.ListAsync()).ReturnsAsync(list);

            var userService = new UsersService(_userRepository.Object);
            var response = userService.ListAsync(10, 10).Result;

            Assert.True(response.TotalCount == 3);
            Assert.True(response.Items.Length == 0);
        }
    }
}
