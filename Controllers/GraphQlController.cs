using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstGraphQL.GraphQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace FirstGraphQL.Controllers
{
    [Route("api/[controller]")]
    public class GraphQlController : Controller
    {
        private readonly GraphQlQuery _graphQLQuery;
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQlController(GraphQlQuery graphQlQuery, IDocumentExecuter documentExecuter, ISchema schema)
        {
            _graphQLQuery = graphQlQuery;
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlParameter query)
        {
            var executionOptions = new ExecutionOptions { Schema = _schema, Query = query.Query };
            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }
    }
}
