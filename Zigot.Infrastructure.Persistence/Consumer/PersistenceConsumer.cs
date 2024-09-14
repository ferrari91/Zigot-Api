using RabbitMq;
using Zigot.Core.Domain.Persistence.Model;

namespace Zigot.Infrastructure.Persistence.Consumer
{
    public class PersistenceConsumer : RabbitMq.QueueSubscriber<Payload>
    {
        public PersistenceConsumer(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override string Queue => PersistenceConstants.PersistenceQueue;
        protected override string DelayedQueue => PersistenceConstants.PersistenceQueueDelayed;
        protected override string DeadQueue => PersistenceConstants.PersistenceQueueDead;
        protected override int RetryDelay => PersistenceConstants.PersistenceAwaitSecondTime;
        protected override int RetryAttempts => PersistenceConstants.PersistenceRetry;

        protected override void ExceptionExecute(IServiceProvider provider, Exception exception, Context<Payload> context, int attempt, CancellationToken ctx)
        {
            throw new NotImplementedException();
        }

        protected override Task ProcessMessage(IServiceProvider serviceProvider, Context<Payload> context, CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
