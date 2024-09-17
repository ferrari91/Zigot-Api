using CommonValidation.Documents.CadastroPessoaFisica;
using FluentValidation;
using Zigot.Core.Domain.Contract.Persons.Repository;

namespace Zigot.Core.Application.CommandStack.PersonCommand.Document.CreateCommand
{
    public class DocumentCreateValidation : AbstractValidator<DocumentCreateRequest>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonDocumentRepository _personDocumentRepository;

        public DocumentCreateValidation(IPersonRepository personRepository, IPersonDocumentRepository personDocumentRepository)
        {
            _personRepository = personRepository;
            _personDocumentRepository = personDocumentRepository;

            RuleFor(x => x.PersonId)
                       .NotEmpty().WithMessage("O campo PersonId é obrigatório.")
                       .MustAsync(PersonExists).WithMessage("O PersonId informado não existe.");

            RuleFor(x => x.CPF).NotEmpty().WithMessage("O campo CPF é obrigatório.")
                .Must(IsValidCPF).WithMessage("O CPF informado não é vallido.");

            RuleFor(x => x.RG).NotEmpty().WithMessage("O campo RG é obrigatório.");
            RuleFor(x => x.IssuingBody).NotEmpty().WithMessage("O campo Órgão Emissor é obrigatório.");
            RuleFor(x => x.State).NotEmpty().WithMessage("O campo Estado é obrigatório.");
            RuleFor(x => x.IssueDate).NotEmpty().WithMessage("O campo Data de Emissão é obrigatório.");
            RuleFor(x => x.ElectoralTitle).NotEmpty().WithMessage("O campo Título Eleitoral é obrigatório.");

            RuleFor(x => x.PersonId)
                .MustAsync(DocumentNotExistsForPerson).WithMessage(request => $"Já existem documentos cadastrados para o cliente com PersonId: {request.PersonId}.");
        }

        private bool IsValidCPF(string cpf) => new CPF(cpf).IsValid();

        private async Task<bool> PersonExists(long personId, CancellationToken cancellationToken)
        {
            var person = await _personRepository.FindAsync(x => x.Id == personId, cancellationToken: cancellationToken);
            return person != null;
        }

        private async Task<bool> DocumentNotExistsForPerson(long personId, CancellationToken cancellationToken)
        {
            var existingDocument = await _personDocumentRepository.FindAsync(x => x.PersonId == personId, cancellationToken: cancellationToken);
            return existingDocument == null;
        }
    }
}
