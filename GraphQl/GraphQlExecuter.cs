using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace FirstGraphQL.GraphQl
{
    public interface IGraphQlExecuter
    {
        Task<ExecutionResult> Exectue(GraphQlParameter query);
    }

    public class GraphQlExecuter : IGraphQlExecuter
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQlExecuter(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        public async Task<ExecutionResult> Exectue(GraphQlParameter query)
        {
            var executionOptions = new ExecutionOptions { Schema = _schema, Query = query.Query };
            return await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);
        }
    }
}