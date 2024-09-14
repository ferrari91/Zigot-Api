using Zigot.Core.Domain._Shared;
using Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel.FederalModel;
using Zigot.Core.Domain.Contract.Persons.Enum;

namespace Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel
{
    public class Process : BaseEntity<long>
    {
        public long PersonId { get; set; }
        public string WeaponType { get; set; }
        public string WeaponRegistrationType { get; set; }
        public DateTime WeaponRegisterDate { get; set; }
        public string Caliber { get; set; }
        public StatusProcess Status { get; set; } = StatusProcess.None;
        public Person Person { get; set; }
        public FederalRegistration FederalRegistration { get; set; }
    }
}
