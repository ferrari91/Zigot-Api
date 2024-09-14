using GraphQL.Types;
using MediatR;
using Zigot.Core.Application.QueryStack.PersonQuery.ConsultQuery;

namespace Zigot_Api.Graph.Person
{
    public class PersonQuery(IMediator mediator) : QueryBase<PersonGraphType, PersonsConsultResponse, PersonsConsultRequest>(mediator, true)
    {
        public override string QueryName => "persons";
        public override IList<QueryArgument> Arguments => new List<QueryArgument>();
    }
}

