using AutoMapper;
using MediatR;
using Zigot.Core.Domain.Contract.Persons.Repository;

namespace Zigot.Core.Application.QueryStack.PersonQuery.ConsultQuery
{
    public class PersonsConsultHandler : IRequestHandler<PersonsConsultRequest, IList<PersonsConsultResponse>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonsConsultHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonsConsultResponse>> Handle(PersonsConsultRequest request, CancellationToken cancellationToken)
        {
            var persons = await _personRepository.GetAllAsync(request.Fields, cancellationToken);

            var response = persons.Select(x => _mapper.Map<PersonsConsultResponse>(x)).ToList();

            return response;
        }
    }
}
