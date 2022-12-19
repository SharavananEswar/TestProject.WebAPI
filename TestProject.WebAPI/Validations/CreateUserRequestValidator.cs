using FluentValidation;
using ZipPay.WebApi.DTOs;

namespace TestProject.WebAPI.Validations
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Username is required");
            RuleFor(x => x.EmailAddress)
                .NotNull().WithMessage("EmailAddress is required")
                .EmailAddress().WithMessage("EmailAddress is not valid");
            RuleFor(x => x.MonthlySalary)
                .NotNull().WithMessage("MonthlySalary is required")
                .GreaterThan(0).WithMessage("MonthlySalary must be greater than zero");
            RuleFor(x => x.MonthlyExpenses)
                .NotNull().WithMessage("MonthlyExpenses is required")
                .GreaterThan(0).WithMessage("MonthlyExpenses must be greater than zero");
        }
    }
}
