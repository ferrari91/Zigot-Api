using Zigot.Core.Domain.Contract.Addresses;
using Zigot.Core.Domain.Contract.Contacts;

namespace Zigot.Core.Domain.Contract.Persons.Records
{
    public record PersonRecord(
        string FullName,
        DateTime Birthday,
        string MotherFullName,
        string FatherFullName,
        long PersonId,
        string Cpf,
        string Rg,
        string IssuingBody,
        string State,
        DateTime IssueDate,
        string ElectoralTitle,
        Address Address,
        Contact Contact,
        string Profession,
        bool HasChildren,
        MaritalStatus MaritalStatus
    );
}
