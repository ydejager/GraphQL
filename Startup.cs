using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.EntityFramework;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EfGraphQl
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Data.TaskContext>(opt => opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Tasks;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var serviceProvider = services.BuildServiceProvider();

            EfGraphQLConventions.RegisterConnectionTypesInContainer(services);
            using (var scope = serviceProvider.CreateScope())
                EfGraphQLConventions.RegisterInContainer(services, serviceProvider.GetService<Data.TaskContext>());

            foreach (var type in GetGraphQlTypes())
                services.AddSingleton(type);
    
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDependencyResolver>(
                provider => new FuncDependencyResolver(provider.GetRequiredService)
            );
            services.AddSingleton<ISchema, Schema>();                
        }

        private static IEnumerable<Type> GetGraphQlTypes() =>        
            typeof(Startup).Assembly
                .GetTypes()
                .Where(x => !x.IsAbstract &&
                            (typeof(IObjectGraphType).IsAssignableFrom(x) ||
                            typeof(IInputObjectGraphType).IsAssignableFrom(x)));

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseGraphiQl("/graphiql", "/graphql");
            app.UseMvc();
        }
    }
}
