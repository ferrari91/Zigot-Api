using Newtonsoft.Json;

namespace Zigot.Core.Domain.Persistence.Model
{
    public class Payload
    {
        public required string Id { get; set; }
        public required string Model { get; set; }
        public required string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Processed { get; set; } = false;

        public void CreatePayload<T>(T model)
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            Model = nameof(T);
            Body = JsonConvert.SerializeObject(model);
        }

        public void DefineProcessed() => Processed = true;
    }
}
