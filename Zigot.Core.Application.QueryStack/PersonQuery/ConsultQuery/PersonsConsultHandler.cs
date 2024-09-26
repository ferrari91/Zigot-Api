using AutoMapper;
using Zigot.Core.Domain.Abstractions.Handler;
using Zigot.Core.Domain.Abstractions.Works;
using Zigot.Core.Domain.Contract.Persons;
using Zigot.Core.Domain.Persistence.Model;
using Zigot.Core.Domain.Persistence.Service;

namespace Zigot.Core.Application.QueryStack.PersonQuery.ConsultQuery
{
    public class PersonsConsultHandler :
        HandlerAbstraction<PersonsConsultRequest, IList<PersonsConsultResponse>>
    {
        public PersonsConsultHandler(IMapper mapper, IUnityOfWork unityOfWork, IPersistencePublisher<Payload> persistencePublisher) : base(mapper, unityOfWork, persistencePublisher)
        {
        }

        public override async Task<IList<PersonsConsultResponse>> Handle(PersonsConsultRequest request, CancellationToken cancellationToken)
        {
            var documentRepository = _unityOfWork.GetRepository<Person>();

            var persons = await documentRepository.GetAllAsync(request.Fields, cancellationToken);

            return persons.Select(x => _mapper.Map<PersonsConsultResponse>(x)).ToList();
        }
    }
}
