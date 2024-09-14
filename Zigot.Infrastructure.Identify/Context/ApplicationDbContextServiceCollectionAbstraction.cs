using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zigot.Core.Domain.Abstractions;

namespace Zigot.Infrastructure.Identity.Context
{
    public class ApplicationDbContextServiceCollectionAbstraction : ServiceCollectionAbstraction
    {
        public override void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseNpgsql(configuration.GetConnectionString("PostgresqlConnection")));
        }
    }
}
