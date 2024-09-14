namespace Zigot.Infrastructure.Persistence
{
    public class PersistenceConfiguration
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool SSL { get; set; }
    }
}

