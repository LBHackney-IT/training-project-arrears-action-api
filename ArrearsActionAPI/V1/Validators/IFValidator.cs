using FluentValidation.Results;

namespace ArrearsActionAPI.V1.Validators
{
    public interface IFValidator<T> where T : class
    {
        ValidationResult Validate(T request);
    }
}
