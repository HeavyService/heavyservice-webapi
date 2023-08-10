using FluentValidation;
using HeavyService.Persistance.Dtos.Roles;

namespace HeavyService.Persistance.Validations.Roles;

public class RoleCreateValidator : AbstractValidator<RoleCreateDto>
{
    public RoleCreateValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().NotNull().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(20).WithMessage("Name must be less than 20 characters");
    }
}