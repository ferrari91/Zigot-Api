namespace Zigot.Core.Domain.Abstractions.Exceptions
{
    public abstract class ExceptionAbstraction : Exception
    {
        public new string Message { get; private set; }
        public string Model { get; private set; }

        public ExceptionAbstraction(string message, string modelName)
        {
            Message = message;
            Model = modelName;
        }
    }
}
