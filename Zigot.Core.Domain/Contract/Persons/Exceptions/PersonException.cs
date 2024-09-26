using Zigot.Core.Domain.Abstractions.Exceptions;

namespace Zigot.Core.Domain.Contract.Persons.Exceptions
{
    public class PersonException : ExceptionAbstraction
    {
        public PersonException(string message, string modelName) : base(message, modelName)
        {
        }
    }
}
