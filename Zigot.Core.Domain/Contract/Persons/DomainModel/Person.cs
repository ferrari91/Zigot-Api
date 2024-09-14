using Zigot.Core.Domain._Shared;
using Zigot.Core.Domain.Contract.Persons.DomainModel.AddressModel;
using Zigot.Core.Domain.Contract.Persons.DomainModel.ContactModel;
using Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel;

namespace Zigot.Core.Domain.Contract.Persons.DomainModel
{
    public class Person : BaseEntity<long>
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string MotherFullName { get; set; }
        public string FatherFullName { get; set; }
        public PersonDocument Documents { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public string Profession { get; set; }
        public bool HasChildren { get; set; }
        public DateTime RegisterDate { get; set; }
        public string MaritalStatus { get; set; }

        public List<Process> Processes { get; set; } = new List<Process>();
    }
}

