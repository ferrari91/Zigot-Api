using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zigot.Core.Domain.Abstractions;

namespace Zigot.Infrastructure.Identity._Shared._ServiceCollections
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
