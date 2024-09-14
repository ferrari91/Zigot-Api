using GraphQL;
using GraphQL.Types;
using MediatR;
using Zigot_Api.Graph.Extensions;

namespace Zigot_Api.Graph
{
    public abstract class QueryBase<TField, TResponse, TRequest> : ObjectGraphType
        where TField : ObjectGraphType<TResponse>
        where TRequest : new()
    {
        private readonly IMediator _mediator;

        public virtual string QueryName { get; }
        public virtual IList<QueryArgument> Arguments { get; }

        public QueryBase(IMediator mediator, bool isList = false)
        {
            _mediator = mediator;

            Name = QueryName;

            var fieldType = isList ? typeof(ListGraphType<TField>) : typeof(TResponse);
            FieldAsync(fieldType, QueryName, arguments: new QueryArguments(Arguments), resolve: ResolveAsync);
        }

        private async Task<object> ResolveAsync(IResolveFieldContext<object> context)
        {
            var request = new TRequest();
            var requestType = request.GetType();
            var instance = Activator.CreateInstance(requestType) ?? throw new ArgumentException($"Fail to create instance of {nameof(requestType)}.");

            foreach (var argument in Arguments)
            {
                var property = requestType.GetProperty(argument.Name);
                var value = context.GetArgument<object>(argument.Name) ?? null;

                property?.SetValue(instance, value);
            }

            RegisterDefaultFields(requestType, instance, context.GetRequestedFields());

            return await _mediator.Send(instance) ?? throw new Exception("Fail to request the handler.");
        }

        private void RegisterDefaultFields(Type request, object instance, object value)
        {
            var fields = request.GetProperty("Fields");
            fields?.SetValue(instance, value);
        }
    }
}
