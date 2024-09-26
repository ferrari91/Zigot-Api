using AutoMapper;
using MediatR;
using Zigot.Core.Domain.Abstractions.Works;
using Zigot.Core.Domain.Persistence.Model;
using Zigot.Core.Domain.Persistence.Service;

namespace Zigot.Core.Domain.Abstractions.Handler
{
    public abstract class HandlerAbstraction<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly IMapper _mapper;
        protected readonly IUnityOfWork _unityOfWork;
        protected readonly IPersistencePublisher<Payload> _persistencePublisher;

        protected HandlerAbstraction(IMapper mapper, IUnityOfWork unityOfWork, IPersistencePublisher<Payload> persistencePublisher)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unityOfWork = unityOfWork ?? throw new ArgumentNullException(nameof(unityOfWork));
            _persistencePublisher = persistencePublisher ?? throw new ArgumentNullException(nameof(persistencePublisher));
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
