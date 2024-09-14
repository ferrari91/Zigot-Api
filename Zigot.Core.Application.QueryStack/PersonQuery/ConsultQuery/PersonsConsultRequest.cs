using MediatR;
using Zigot.Core.Domain._Shared;

namespace Zigot.Core.Application.QueryStack.PersonQuery.ConsultQuery
{
    public class PersonsConsultRequest : BaseRequest, IRequest<IList<PersonsConsultResponse>>
    {
    }
}
