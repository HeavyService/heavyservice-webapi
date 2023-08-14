﻿using FluentValidation;
using HeavyService.Persistance.Dtos.Instruments;
using HeavyService.Persistance.Helpers;

namespace HeavyService.Persistance.Validations.Instruments;

public class InstrumentCreateValidator : AbstractValidator<InstrumentCreateDto>
{
    public InstrumentCreateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name filed is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description filed is required!")
            .MinimumLength(20).WithMessage("Description filed is required!");

        int MaxImageSizeMB = 5;
        RuleFor(dto => dto.ImagePath).NotEmpty().NotNull().WithMessage("Image field is required");
        RuleFor(dto => dto.ImagePath.Length).LessThan(MaxImageSizeMB * 1024 * 1024)
            .WithMessage($"Image size must be less than {MaxImageSizeMB} MB");
        RuleFor(dto => dto.ImagePath.FileName).Must(predicate =>
        {
            var fileinfo = new FileInfo(predicate);

            return MediaHelpers.GetImageExtension().Contains(fileinfo.Extension);
        }).WithMessage("This file type isn't image file");

        int num = 0;
        RuleFor(dto => dto.PricePerDay).NotEmpty().NotNull().WithMessage("Price per day is required!")
            .LessThan(num).WithMessage($"Price isn't less than {num}");

        RuleFor(dto => dto.Region).NotNull().NotEmpty().WithMessage("Region filed is required!")
            .MinimumLength(5).WithMessage("Region filed is required!");

        RuleFor(dto => dto.Address).NotNull().NotEmpty().WithMessage("Address filed is required!")
            .MinimumLength(5).WithMessage("Address filed is required!");

        RuleFor(dto => dto.District).NotNull().NotEmpty().WithMessage("District filed is required!")
            .MinimumLength(5).WithMessage("District filed is required!");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidotor.IsValid(phone))
            .WithMessage("Phone Number field is required!");

        RuleFor(dto => dto.UserId).NotNull().NotEmpty().WithMessage("User id filed is required!");
    }
}