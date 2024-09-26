using Zigot.Core.Domain._Shared;

namespace Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel.FederalModel
{
    public class FederalDocument : BaseEntity<long>
    {
        public long FederalRegistrationId { get; set; }
        public string DocumentDescription { get; set; }
        public string BucketReferenceCode { get; set; }
        public FederalRegistration FederalRegistration { get; set; }
    }
}
