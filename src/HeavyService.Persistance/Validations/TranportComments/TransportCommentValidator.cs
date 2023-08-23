using FluentValidation;
using HeavyService.Persistance.Dtos.TransportComments;

namespace HeavyService.Persistance.Validations.TranportComments
{
    public class TransportCommentValidator : AbstractValidator<TransportCommentDto>
    {
        public TransportCommentValidator()
        {
            RuleFor(dto => dto.ReplyId).NotEmpty().NotNull().WithMessage("Reply id field is required!");

            RuleFor(dto => dto.Comment).NotEmpty().NotNull().WithMessage("Comment field is required!");

            RuleFor(dto => dto.IsEdited).NotEmpty().NotNull().WithMessage("Edited field is required!");
        }
    }
}