using FluentValidation;
using HeavyService.Persistance.Dtos.InstrumentComments;

namespace HeavyService.Persistance.Validations.InstrumentComments;

public class InstrumentCommentValidator : AbstractValidator<InstrumentCommentCreateDto>
{
    public InstrumentCommentValidator()
    {
        RuleFor(dto => dto.ReplyId).NotEmpty().NotNull().WithMessage("Reply id field is required!");

        RuleFor(dto => dto.Comment).NotEmpty().NotNull().WithMessage("Comment field is required!");

        RuleFor(dto => dto.IsEdited).NotEmpty().NotNull().WithMessage("Edited field is required!");
    }
}