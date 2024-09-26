using AutoMapper;
using Zigot.Core.Domain.Abstractions.Handler;
using Zigot.Core.Domain.Abstractions.Works;
using Zigot.Core.Domain.Contract.Persons;
using Zigot.Core.Domain.Contract.Persons.Records;
using Zigot.Core.Domain.Persistence.Model;
using Zigot.Core.Domain.Persistence.Service;

namespace Zigot.Core.Application.CommandStack.PersonCommand.CreateCommand
{
    public class PersonCreateCommandHandler :
        HandlerAbstraction<PersonCreateRequest, PersonCreateResponse>
    {
        public PersonCreateCommandHandler(IMapper mapper,
            IUnityOfWork unityOfWork,
            IPersistencePublisher<Payload> persistencePublisher) : base(mapper, unityOfWork, persistencePublisher)
        {
        }

        public override async Task<PersonCreateResponse> Handle(PersonCreateRequest request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<PersonRecord>(request);

            var person = CreatePerson(record);

            using (var personRepository = _unityOfWork.GetRepository<Person>())
            {
                await personRepository.AddAsync(person, cancellationToken);
            }

            return _mapper.Map<PersonCreateResponse>(person);
        }

        private Person CreatePerson(PersonRecord record) => new Person(record);
    }
}
