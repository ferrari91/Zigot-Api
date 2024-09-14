using Zigot.Core.Domain.Persistence.Model;

namespace Zigot.Core.Domain.Persistence.Service
{
    public interface IPersistencePublisher<TModel> where TModel : Payload
    {
        Task Publish(TModel model, Dictionary<string, object> headers, CancellationToken ctx);
    }
}
