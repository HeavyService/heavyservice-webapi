using FluentValidation;
using HeavyService.Persistance.Dtos.Transports;
using HeavyService.Service.Helpers;

namespace HeavyService.Persistance.Validations.Transports;

public class TransportUpdateValidator : AbstractValidator<TransportUpdateDto>
{
    public TransportUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().NotNull().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(20).WithMessage("Name must be less than 20 characters");

        When(dto => dto.ImagePath is not null, () =>
        {
            int maxImageSizeMB = 5;
            RuleFor(dto => dto.ImagePath!.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.ImagePath!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);

                return MediaHelpers.GetImageExtension().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });

        int num = 0;
        RuleFor(dto => dto.PricePerHours).NotEmpty().NotNull().WithMessage("Price per day is required!")
            .Must(price => PriceValidator.IsValid(price)).WithMessage($"Price isn't less than {num}");

        RuleFor(dto => dto.Region).NotNull().NotEmpty().WithMessage("Region filed is required!")
            .MinimumLength(5).WithMessage("Region filed is required!");

        RuleFor(dto => dto.Address).NotNull().NotEmpty().WithMessage("Address filed is required!")
            .MinimumLength(5).WithMessage("Address filed is required!");

        RuleFor(dto => dto.District).NotNull().NotEmpty().WithMessage("District filed is required!")
            .MinimumLength(5).WithMessage("District filed is required!");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidotor.IsValid(phone))
            .WithMessage("Phone Number field is required!");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description filed is required!")
            .MinimumLength(20).WithMessage("Description filed is required!");
    }
}