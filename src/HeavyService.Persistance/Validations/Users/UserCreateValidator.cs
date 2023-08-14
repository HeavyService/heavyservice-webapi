using FluentValidation;
using HeavyService.Persistance.Dtos.Users;

namespace HeavyService.Persistance.Validations.Users
{
    public class UserCreateValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator()
        {
            RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname filed is required!")
            .MinimumLength(3).WithMessage("Firstname must be more than 3 characters")
            .MaximumLength(50).WithMessage("Firstname must be less than 50 characters");

            RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname filed is required!")
            .MinimumLength(3).WithMessage("Lastname must be more than 3 characters")
            .MaximumLength(50).WithMessage("Lastname must be less than 50 characters");

            RuleFor(dto => dto.Email).NotNull().NotEmpty().WithMessage("Email filed is required!")
            .MinimumLength(10).WithMessage("Email must be more than 3 characters");

            RuleFor(dto => dto.EmailConfirmed).NotNull().NotEmpty().WithMessage("Email Confirmed filed is required!");

            RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
                .WithMessage("Password isn't strong password");
        }
    }
}