using GraphQL.Types;
using Zigot.Core.Application.QueryStack.PersonQuery.ConsultQuery;

namespace Zigot_Api.Graph.Person
{
    public class PersonGraphType : ObjectGraphType<PersonsConsultResponse>
    {
        public PersonGraphType()
        {
            Field(x => x.Id, nullable: true);
            Field(x => x.FullName, nullable: false);
            Field(x => x.FatherFullName, nullable: true);
            Field(x => x.MotherFullName, nullable: true);
            Field(x => x.Birthday, nullable: true);
            Field(x => x.MaritalStatus, nullable: true);
            Field(x => x.Profession, nullable: true);
            Field(x => x.HasChildren, nullable: true);
        }
    }
}
