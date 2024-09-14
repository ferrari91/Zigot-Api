using Zigot.Core.Domain._Shared;

namespace Zigot.Core.Domain.Contract.Persons.DomainModel
{
    public class PersonDocument : BaseEntity<long>
    {
        public long PersonId { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string IssuingBody { get; set; }
        public string State { get; set; }
        public DateTime IssueDate { get; set; }
        public string ElectoralTitle { get; set; }
        public Person Person { get; set; }
    }
}
