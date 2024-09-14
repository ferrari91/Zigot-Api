using MediatR;
using Zigot.Core.Application.QueryStack.PersonQuery.ConsultQuery;
using Zigot.Core.Domain.Abstractions;

namespace Zigot_Api.Graph.Person
{
    public class PersonQueryServiceCollectionAbstraction : ServiceCollectionAbstraction
    {
        public override void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<PersonGraphType>();
            services.AddScoped<PersonQuery>();

            services.AddTransient(typeof(IRequestHandler<PersonsConsultRequest, IList<PersonsConsultResponse>>), typeof(PersonsConsultHandler));
        }
    }
}
