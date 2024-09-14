using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMq;
using Zigot.Core.Domain.Abstractions;
using Zigot.Core.Domain.Persistence.Model;
using Zigot.Core.Domain.Persistence.Service;
using Zigot.Infrastructure.Persistence.Consumer;
using Zigot.Infrastructure.Persistence.Publisher;

namespace Zigot.Infrastructure.Persistence
{
    public class ConsumerServiceCollectionExtension : ServiceCollectionAbstraction
    {

        public override void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("RabbitMqSettings").Get<PersistenceConfiguration>() 
                ?? throw new ArgumentNullException(nameof(PersistenceConfiguration));

            services.AddRabbitMq(
                hostname: config.HostName,
                virtualHost: config.VirtualHost,
                port: config.Port,
                user: config.User,
                password: config.Password,
                ssl: config.SSL);

            services.AddSingleton<IPersistencePublisher<Payload>, PersistencePublisher>();
            services.AddHostedService<PersistenceConsumer>();
        }
    }
}
