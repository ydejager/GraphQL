using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace EfGraphQl
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQlController : Controller
    {
        IDocumentExecuter executer;
        ISchema schema;

        public GraphQlController(ISchema schema, IDocumentExecuter executer)
        {
            this.schema = schema;
            this.executer = executer;
        }

        [HttpPost]
        public Task<ExecutionResult> Post(
            [BindRequired, FromBody] PostBody body,
            [FromServices] Data.TaskContext dataContext,
            CancellationToken cancellation)
        {
            return Execute(dataContext, body.Query, body.OperationName, body.Variables, cancellation);
        }

        public class PostBody
        {
            public string OperationName;
            public string Query;
            public JObject Variables;
        }

        async Task<ExecutionResult> Execute(Data.TaskContext dataContext, string query, string operationName, JObject variables, CancellationToken cancellation)
        {
            var executionOptions = new ExecutionOptions
            {
                Schema = schema,
                Query = query,
                OperationName = operationName,
                Inputs = variables?.ToInputs(),
                UserContext = dataContext,
                CancellationToken = cancellation,
    #if (DEBUG)
                ExposeExceptions = true,
                EnableMetrics = true,
    #endif
            };

            var result = await executer.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
            }

            return result;
        }

        static JObject ParseVariables(string variables)
        {
            if (variables == null)
            {
                return null;
            }

            try
            {
                return JObject.Parse(variables);
            }
            catch (Exception exception)
            {
                throw new Exception("Could not parse variables.", exception);
            }
        }
    }
}