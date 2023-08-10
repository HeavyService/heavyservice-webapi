using FluentValidation;
using HeavyService.Persistance.Dtos.UserRoles;

namespace HeavyService.Persistance.Validations.UserRoles
{
    public class UserRoleUpdateValidator : AbstractValidator<UserRoleUpdateDto>
    {
        public UserRoleUpdateValidator()
        {
            RuleFor(dto => dto.UserId).NotNull().NotEmpty().WithMessage("User id field is required!");

            RuleFor(dto => dto.RoleId).NotNull().NotEmpty().WithMessage("Role id field is required!");
        }
    }
}