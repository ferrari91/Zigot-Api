using CommonValidation.Documents.CadastroPessoaFisica;
using Zigot.Core.Domain._Shared;
using Zigot.Core.Domain.Abstractions.Exceptions;
using Zigot.Core.Domain.Contract.Addresses;
using Zigot.Core.Domain.Contract.Contacts;
using Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel;
using Zigot.Core.Domain.Contract.Persons.Exceptions;
using Zigot.Core.Domain.Contract.Persons.Records;

namespace Zigot.Core.Domain.Contract.Persons
{
    public class Person : BaseEntity<long>
    {
        public string FullName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string MotherFullName { get; private set; }
        public string FatherFullName { get; private set; }
        public Document Documents { get; private set; }
        public Address Address { get; private set; }
        public Contact Contact { get; private set; }
        public string Profession { get; private set; }
        public bool HasChildren { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public string MaritalStatus { get; private set; }

        public List<Process> Processes { get; private set; } = new List<Process>();

        public Person() { }

        public Person(PersonRecord personRecord)
        {
            FullName = personRecord.FullName;
            Birthday = personRecord.Birthday;
            MotherFullName = personRecord.MotherFullName;
            FatherFullName = personRecord.FatherFullName;
            Address = personRecord.Address;
            Contact = personRecord.Contact;
            Profession = personRecord.Profession;
            HasChildren = personRecord.HasChildren;
            MaritalStatus = personRecord.MaritalStatus.ToString();
            RegisterDate = DateTime.Now;

            Documents = new Document(
                personRecord.PersonId,
                personRecord.Cpf,
                personRecord.Rg,
                personRecord.IssuingBody,
                personRecord.State,
                personRecord.IssueDate,
                personRecord.ElectoralTitle
            );

            Validation();
        }

        private void Validation()
        {
            if (IsYoungerThan25())
                throw new PersonException("A idade minima para realização do cadastro é de 25 anos.", nameof(Person));

            Documents.Validation();
        }

        public void UpdateAddress(Address newAddress)
        {
            if (newAddress == null)
                throw new PersonException("Endereço não pode ser nulo.", nameof(Address));
            
            Address = newAddress;
        }

        public void UpdateContact(Contact newContact)
        {
            if (newContact == null)
                throw new PersonException("Contato não pode ser nulo.", nameof(Contact));
            
            Contact = newContact;
        }

        public void UpdateProcess(Process process)
        {
            if (process == null)
                throw new PersonException("Processo não pode ser nulo.", nameof(Process));

            var existingProcessIndex = Processes.FindIndex(x => x.Id == process.Id);

            if (existingProcessIndex >= 0)
                Processes[existingProcessIndex] = process;
            else
                Processes.Add(process);
        }

        private int CalculateAge()
        {
            var age = DateTime.Now.Year - Birthday.Year;
            if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
            {
                age--;
            }
            return age;
        }

        private bool IsYoungerThan25() => CalculateAge() < 25;
    }
}

