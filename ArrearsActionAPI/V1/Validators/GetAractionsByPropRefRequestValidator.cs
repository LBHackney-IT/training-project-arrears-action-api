using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArrearsActionAPI.V1.Boundary;
using FluentValidation;

namespace ArrearsActionAPI.V1.Validators
{
    public class GetAractionsByPropRefRequestValidator : AbstractValidator<GetAractionsByPropRefRequest>, IGetAractionsByPropRefRequestValidator
    {
        public GetAractionsByPropRefRequestValidator()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(request => request.PropertyRef)
                .NotNull().WithMessage("PropertyRef must be provided.")
                .NotEmpty().WithMessage("PropertyRef must not be empty.");
        }
    }
}
