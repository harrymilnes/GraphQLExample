using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using GraphQLExample.Data.Context;
using GraphQLExample.GraphQL.Mutations;
using GraphQLExample.GraphQL.Query;
using GraphQLExample.GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLExample.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddPooledDbContextFactory<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Context")));
            services
                .AddGraphQLServer()
                .AddQueryType<CaseQuery>()
                .AddType<CaseType>()
                .AddFiltering()
                .AddMutationType<CaseMutation>()
                .AddProjections();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/playground"
            });
            
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions
            {
                GraphQLEndPoint = "/graphql",
                Path = "/voyager",
            });
        }
    }
}