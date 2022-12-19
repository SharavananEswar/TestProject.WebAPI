using FluentValidation;
using ZipPay.WebApi.DTOs;

namespace TestProject.WebAPI.Validations
{
    public class CreateUserAccountRequestValidator : AbstractValidator<CreateUserAccountRequest>
    {
        public CreateUserAccountRequestValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId is invalid");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId is invalid");
        }
    }
}
