using Zigot.Core.Domain._Shared;
using Zigot.Core.Domain.Contract.Persons;

namespace Zigot.Core.Domain.Contract.Contacts
{
    public class Contact : BaseEntity<long>
    {
        public long PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OriginCity { get; set; }
        public string OriginState { get; set; }
        public Person Person { get; set; }
    }
}
