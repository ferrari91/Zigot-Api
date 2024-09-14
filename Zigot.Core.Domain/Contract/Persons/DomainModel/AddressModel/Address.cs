using Zigot.Core.Domain._Shared;

namespace Zigot.Core.Domain.Contract.Persons.DomainModel.AddressModel
{
    public class Address : BaseEntity<long>
    {
        public long PersonId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Person Person { get; set; }
    }
}
