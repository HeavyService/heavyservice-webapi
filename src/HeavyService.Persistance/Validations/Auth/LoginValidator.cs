using FluentValidation;
using HeavyService.Persistance.Dtos.Auth;

namespace HeavyService.Persistance.Validations.Auth;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(dto => dto.Email).Must(email => EmailValidator.IsValid(email))
        .WithMessage("The email was entered incorrectly! Ex: xxxx....@gmail.com");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
        .WithMessage("Password is not strong password!");
    }
}