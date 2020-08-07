using ArrearsActionAPI.V1.Boundary;
using FluentValidation.Results;

namespace ArrearsActionAPI.V1.Validators
{
    public interface IGetAractionsByPropRefRequestValidator
    {
        ValidationResult Validate(GetAractionsByPropRefRequest request);
    }
}