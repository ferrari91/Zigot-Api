using Zigot.Core.Domain._Shared;

namespace Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel.FederalModel
{
    public class FederalRegistration : BaseEntity<long>
    {
        public long ProcessId { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsFinalized { get; set; }
        public List<FederalDocument> Documents { get; set; } = new List<FederalDocument>();
        public Process Process { get; set; }
    }
}
