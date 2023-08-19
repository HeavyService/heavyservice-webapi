using FluentValidation;
using HeavyService.Persistance.Dtos.Users;

namespace HeavyService.Persistance.Validations.Users
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname filed is required!")
            .MinimumLength(3).WithMessage("Firstname must be more than 3 characters")
            .MaximumLength(50).WithMessage("Firstname must be less than 50 characters");

            RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname filed is required!")
            .MinimumLength(3).WithMessage("Lastname must be more than 3 characters")
            .MaximumLength(50).WithMessage("Lastname must be less than 50 characters");

            RuleFor(dto => dto.Email).NotNull().NotEmpty().WithMessage("Email filed is required!")
            .Must(email => EmailValidator.IsValid(email)).WithMessage("Email adress is invalid! ex: ____@gmail.com");

            RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
                .WithMessage("Password isn't strong password");
        }
    }
}