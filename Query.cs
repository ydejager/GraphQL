using GraphQL.EntityFramework;

namespace EfGraphQl
{
    public class Query : EfObjectGraphType<Data.Task>
    {
        public Query(IEfGraphQLService graphQlService) : base(graphQlService) =>
            AddQueryField<Graphs.TaskGraph, Data.Task>(
                name: "tasks",
                resolve: context =>
                {
                    var dataContext = (Data.TaskContext) context.UserContext;
                    return dataContext.Tasks;
                });
    }    
}