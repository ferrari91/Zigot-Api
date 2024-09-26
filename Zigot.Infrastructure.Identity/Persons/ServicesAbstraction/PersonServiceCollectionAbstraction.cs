using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zigot.Core.Domain.Abstractions.Collection;
using Zigot.Core.Domain.Contract.Persons.Repository;
using Zigot.Infrastructure.Identity.Persons.Repository;

namespace Zigot.Infrastructure.Identity.Persons.ServicesAbstraction
{
    public class PersonServiceCollectionAbstraction : ServiceCollectionAbstraction
    {
        public override void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonDocumentRepository, PersonDocumentRepository>();
        }
    }
}
