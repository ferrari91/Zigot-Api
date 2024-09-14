using Zigot.Core.Domain.Persistence.Model;
using Zigot.Core.Domain.Persistence.Service;

namespace Zigot.Infrastructure.Persistence.Publisher
{
    public class PersistencePublisher : RabbitMq.QueuePublisher<Payload>, IPersistencePublisher<Payload>
    {
        public PersistencePublisher(IServiceProvider services) : base(services)
        {
        }

        protected override string QueueName => throw new NotImplementedException();
    }
}
