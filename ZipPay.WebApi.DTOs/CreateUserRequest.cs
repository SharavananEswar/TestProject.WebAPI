using System.ComponentModel.DataAnnotations;

namespace ZipPay.WebApi.DTOs
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public long MonthlySalary { get; set; }

        public long MonthlyExpenses { get; set; }
    }
}