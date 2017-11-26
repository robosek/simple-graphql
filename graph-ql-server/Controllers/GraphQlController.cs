using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstGraphQL.GraphQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FirstGraphQL.Controllers {
    
    [Route ("[controller]")]
    [Produces ("application/json")]
    public class GraphQlController : Controller {
        private readonly GraphQlQuery _graphQLQuery;
        private readonly IGraphQlExecuter _executer;

        public GraphQlController (GraphQlQuery graphQlQuery, IGraphQlExecuter executer) 
        {
            _graphQLQuery = graphQlQuery;
            _executer = executer;
        }

        [HttpGet]
        public async Task<IActionResult> Get ([FromQuery] string query) 
        {
            if (!string.IsNullOrEmpty(query)) {
                ExecutionResult result = await _executer.Exectue (new GraphQlParameter { Query = query });

                if (result.Errors?.Count > 0) {
                    return BadRequest (result.Errors);
                }

                return Ok (result);
            }

            return BadRequest ("No query pameter specified");
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] GraphQlParameter query) 
        {
            ExecutionResult result = await _executer.Exectue(query);

            if (result.Errors?.Count > 0) {
                return BadRequest (result.Errors);
            }

            return Ok (result);
        }
    }
}