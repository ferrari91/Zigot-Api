namespace Zigot.Infrastructure.Persistence
{
    public class PersistenceConstants
    {
        public const string PersistenceQueue = "persistence-outbox";
        public const string PersistenceQueueDelayed = "persistence-retry-outbox";
        public const string PersistenceQueueDead = "persistence-exception-outbox";
        public const int PersistenceRetry = 3;
        public const int PersistenceAwaitSecondTime = 30;
    }
}
