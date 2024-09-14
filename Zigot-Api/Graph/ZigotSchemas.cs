using GraphQL.Types;
using MediatR;
using System.Reflection;

namespace Zigot_Api.Graph
{
    public class ZigotSchema : Schema
    {
        protected readonly IServiceProvider _serviceProvider;

        public ZigotSchema(IMediator mediator, IServiceProvider services) : base(services)
        {
            _serviceProvider = services;

            RegisterQueries();
        }

        private void RegisterQueries()
        {
            Query = new ObjectGraphType { Name = "query" };

            var queryTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Name.Contains("Query"))
                .ToList();

            foreach (var queryType in queryTypes)
            {
                var objectQuery = _serviceProvider.GetService(queryType) as ObjectGraphType;
                if (objectQuery is null)
                    continue;

                foreach (var field in objectQuery.Fields)
                {
                    Query.AddField(field);
                }
            }
        }
    }
}
