using MediatR;
using Zigot.Core.Domain.Contract.Persons;

namespace Zigot.Core.Application.CommandStack.PersonCommand.CreateCommand
{
    public class PersonCreateRequest : IRequest<PersonCreateResponse>
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string MotherFullName { get; set; }
        public string FatherFullName { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string IssuingBody { get; set; }
        public string DocumentState { get; set; }
        public DateTime IssueDate { get; set; }
        public string ElectoralTitle { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OriginCity { get; set; }
        public string OriginState { get; set; }
        public string Profession { get; set; }
        public bool HasChildren { get; set; }
        public DateTime RegisterDate { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
    }
}
