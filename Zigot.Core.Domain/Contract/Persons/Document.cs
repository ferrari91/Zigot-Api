using CommonValidation.Documents.CadastroPessoaFisica;
using Zigot.Core.Domain._Shared;
using Zigot.Core.Domain.Contract.Persons.Exceptions;

namespace Zigot.Core.Domain.Contract.Persons
{
    public class Document : BaseEntity<long>
    {
        public long PersonId { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public string IssuingBody { get; private set; }
        public string State { get; private set; }
        public DateTime IssueDate { get; private set; }
        public string ElectoralTitle { get; private set; }
        public Person Person { get; private set; }

        private Document() { }

        public Document(long personId, string cpf, string rg, string issuingBody, string state, DateTime issueDate, string electoralTitle)
        {
            PersonId = personId;
            CPF = new CPF(cpf).Number;
            RG = rg;
            IssuingBody = issuingBody;
            State = state;
            IssueDate = issueDate;
            ElectoralTitle = electoralTitle;
        }

        public void Validation()
        {
            var cpf = new CPF(CPF);

            if (!cpf.IsValid())
                throw new PersonException($"O CPF {cpf.Format()} não é um CPF válido.", nameof(CPF));

            if (IssueDate > DateTime.Now)
                throw new PersonException("A aata de registro do documento não pode ser superior a data atual.", nameof(Document.IssueDate));
        }
    }
}
