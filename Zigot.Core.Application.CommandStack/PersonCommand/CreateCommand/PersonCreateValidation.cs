using FluentValidation;
using Zigot.Core.Domain.Abstractions.Validation;
using Zigot.Core.Domain.Abstractions.Works;
using Zigot.Core.Domain.Contract.Persons;

namespace Zigot.Core.Application.CommandStack.PersonCommand.CreateCommand
{
    public class PersonCreateValidation : FluentValidationAbstraction<PersonCreateRequest>
    {
        public PersonCreateValidation(IUnityOfWork unityOfWork) : base(unityOfWork)
        {
            RuleFor(person => person.FullName)
              .NotEmpty().WithMessage("Nome completo é obrigatório.")
              .NotNull().WithMessage("Nome completo não pode ser nulo.")
              .MustAsync(ExistPersonWithSameNameAsync).WithMessage("Já existe uma pessoa com o mesmo nome.");

            RuleFor(person => person.MotherFullName)
              .NotEmpty().WithMessage("Nome completo da mãe é obrigatório.")
              .NotNull().WithMessage("Nome completo da mãe não pode ser nulo.");

            RuleFor(person => person.FatherFullName)
                .NotEmpty().WithMessage("Nome completo do pai é obrigatório.")
                .NotNull().WithMessage("Nome completo do pai não pode ser nulo.");

            RuleFor(person => person.Profession)
               .NotEmpty().WithMessage("Profissão é obrigatória.")
               .NotNull().WithMessage("Profissão não pode ser nula.");

            RuleFor(person => person.MaritalStatus)
                .NotEmpty().WithMessage("Estado civil é obrigatório.")
                .NotNull().WithMessage("Estado civil não pode ser nulo.");

            RuleFor(person => person.Birthday)
              .NotNull().WithMessage("Data de nascimento é obrigatória.")
              .Must(date => date != default).WithMessage("Data de nascimento inválida.");

            RuleFor(person => person.HasChildren)
               .NotNull().WithMessage("Deve ser especificado se a pessoa tem filhos.");

            RuleFor(x => x.RG).NotEmpty().WithMessage("O campo RG é obrigatório.");

            RuleFor(x => x.IssuingBody).NotEmpty().WithMessage("O campo Órgão Emissor é obrigatório.");

            RuleFor(x => x.State).NotEmpty().WithMessage("O campo Estado é obrigatório.");

            RuleFor(x => x.IssueDate).NotEmpty().WithMessage("O campo Data de Emissão é obrigatório.");

            RuleFor(x => x.ElectoralTitle).NotEmpty().WithMessage("O campo Título Eleitoral é obrigatório.");
        }

        private async Task<bool> ExistPersonWithSameNameAsync(string fullName, CancellationToken cancellationToken)
        {
            var person = await _unityOfWork.GetRepository<Person>().FindAsync(x => x.FullName.ToLower() == fullName.ToLower(), cancellationToken: cancellationToken);
            return person == null;
        }
    }
}
