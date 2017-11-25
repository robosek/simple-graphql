using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstGraphQL.GraphQl;
using FirstGraphQL.GraphQl.Types;
using FirstGraphQL.Services;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FirstGraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<IPersonService, PersonService>();  
            services.AddTransient<GraphQlParameter>();
            services.AddTransient<GraphQlQuery>();
            services.AddTransient<PersonType>();      
            services.AddMvc();

            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new GraphQlSchema(type => (GraphType) sp.GetService(type)) {Query = sp.GetService<GraphQlQuery>()});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
