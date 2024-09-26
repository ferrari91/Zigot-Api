using FluentValidation;
using Zigot.Core.Domain.Abstractions.Works;

namespace Zigot.Core.Domain.Abstractions.Validation
{
    public class FluentValidationAbstraction<TModel> : AbstractValidator<TModel> where TModel : class
    {
        protected readonly IUnityOfWork _unityOfWork;

        public FluentValidationAbstraction(IUnityOfWork unityOfWork) => _unityOfWork = unityOfWork;
    }
}
