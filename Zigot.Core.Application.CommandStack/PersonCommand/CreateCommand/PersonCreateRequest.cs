using MediatR;

namespace Zigot.Core.Application.CommandStack.PersonCommand.CreateCommand
{
    public class PersonCreateRequest : IRequest<PersonCreateResponse>
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string MotherFullName { get; set; }
        public string FatherFullName { get; set; }
        public string Profession { get; set; }
        public bool HasChildren { get; set; }
        public string MaritalStatus { get; set; }
    }
}
