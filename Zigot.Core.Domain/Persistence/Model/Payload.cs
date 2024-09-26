using Newtonsoft.Json;

namespace Zigot.Core.Domain.Persistence.Model
{
    public class Payload
    {
        public string Id { get; private set; }
        public string Model { get; private set; }
        public string Body { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Processed { get; private set; } = false;

        private Payload() { }

        public static Payload CreatePayload<T>(T model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new Payload
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                Model = typeof(T).Name,
                Body = JsonConvert.SerializeObject(model),
                Processed = false
            };
        }

        public void ChangeToProcessed()
        {
            if (Processed)
                throw new InvalidOperationException("O payload já foi processado.");

            Processed = true;
        }

        public void DoProcess()
        {
            if (!Processed)
                throw new InvalidOperationException("O payload ainda não foi processado.");

            Processed = false;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(Model) && !string.IsNullOrEmpty(Body);
        }

        public T GetModel<T>()
        {
            if (string.IsNullOrEmpty(Body))
                throw new InvalidOperationException("O corpo do payload está vazio.");

            return JsonConvert.DeserializeObject<T>(Body) ?? throw new InvalidOperationException("Falha ao Deserializar o Payload");
        }
    }
}
