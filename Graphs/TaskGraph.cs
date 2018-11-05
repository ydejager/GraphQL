using System;
using GraphQL;
using GraphQL.EntityFramework;

namespace EfGraphQl.Graphs
{
    public class TaskGraph : EfObjectGraphType<Data.Task>
    {
        public TaskGraph(IEfGraphQLService graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);
            /* AddNavigationField<EmployeeGraph, Employee>(
                name: "employees",
                resolve: context => context.Source.Employees);*/
        }
    }
}