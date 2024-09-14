using FluentValidation.Results;

namespace Zigot_Api.Wrapper.Exceptions
{
    public class ValidationCustomException : Exception
    {
        public ValidationCustomException(IEnumerable<ValidationFailure> failures) : base("One or more validation failures have occurred.")
        {
            Errors = failures.ToList();
        }
        public List<ValidationFailure> Errors { get; }
    }
}
