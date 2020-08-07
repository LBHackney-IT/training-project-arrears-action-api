using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Helpers;
using FluentValidation;

namespace ArrearsActionAPI.V1.Validators
{
    public class GetAractionsByPropRefRequestValidator : AbstractValidator<GetAractionsByPropRefRequest>, IGetAractionsByPropRefRequestValidator
    {
        public GetAractionsByPropRefRequestValidator()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(request => request.PropertyRef)
                .NotNull().WithMessage(ErrorMessagesFormatter.FieldIsNullMessage("PropertyRef"))
                .NotEmpty().WithMessage(ErrorMessagesFormatter.FieldIsWhiteSpaceOrEmpty("PropertyRef"));
        }
    }
}
