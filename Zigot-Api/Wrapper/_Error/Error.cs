namespace Zigot_Api.Wrapper._Error
{
    public class Error
    {
        public Error(ErrorCode errorCode, string description, string fieldName)
        {
            ErrorCode = errorCode;
            Description = description;
            FieldName = fieldName;
        }

        public Error(ErrorCode errorCode, string message, string[] parameters)
        {
        }

        public ErrorCode ErrorCode { get; set; }
        public string FieldName { get; set; }
        public string Description { get; set; }
    }
}
