using AutoMapper;
using MediatR;
using Zigot.Core.Domain.Contract.Persons.DomainModel;
using Zigot.Core.Domain.Contract.Persons.Repository;

namespace Zigot.Core.Application.CommandStack.PersonCommand.CreateCommand
{
    public class PersonCreateCommandHandler : IRequestHandler<PersonCreateRequest, PersonCreateResponse>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonCreateCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<PersonCreateResponse> Handle(PersonCreateRequest request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);

            await _personRepository.AddAsync(person, cancellationToken);

            return _mapper.Map<PersonCreateResponse>(person);
        }
    }
}
