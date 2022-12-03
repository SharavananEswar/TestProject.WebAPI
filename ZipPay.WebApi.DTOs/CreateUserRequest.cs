using System.ComponentModel.DataAnnotations;

namespace ZipPay.WebApi.DTOs
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "EmailAddress is required")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "MonthlySalary is required")]
        public long MonthlySalary { get; set; }

        [Required(ErrorMessage = "MonthlyExpenses is required")]
        public long MonthlyExpenses { get; set; }
    }
}