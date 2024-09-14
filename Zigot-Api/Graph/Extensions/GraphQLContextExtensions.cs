using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;

namespace Zigot_Api.Graph.Extensions
{
    public static class GraphQLContextExtensions
    {
        public static IEnumerable<string> GetRequestedFields(this IResolveFieldContext context)
        {
            var fieldType = context.FieldDefinition.ResolvedType as ObjectGraphType;

            var field = context.FieldDefinition;
            
            if (context.Document == null || context.Document.Operations == null)
            {
                return Enumerable.Empty<string>();
            }

            var fieldSelections = context.Document.Operations
                .SelectMany(op => op.SelectionSet.Selections)
                .OfType<Field>()
                .Where(f => f.Name == field.Name) 
                .SelectMany(f => f.SelectionSet.Selections.OfType<Field>())
                .Select(f => f.Name);

            return fieldSelections;
        }
    }
}
