using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zigot.Core.Domain.Abstractions.Collection;
using Zigot.Core.Domain.Abstractions.Repository;
using Zigot.Core.Domain.Abstractions.Works;

namespace Zigot.Infrastructure.Identity._Shared.ServicesAbstraction
{
    public class SharedServiceCollectionAbstraction : ServiceCollectionAbstraction
    {
        public override void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }
    }
}
