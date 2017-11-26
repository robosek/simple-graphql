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

namespace FirstGraphQL {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.AddCors (options => {
                options.AddPolicy ("CorsPolicy",
                    builder => builder.AllowAnyOrigin ()
                    .AllowAnyMethod ()
                    .AllowAnyHeader ()
                    .AllowCredentials ());
            });

            services.AddTransient<IDocumentExecuter, DocumentExecuter> ();
            services.AddSingleton<IPersonService, PersonService> ();
            services.AddTransient<IGraphQlExecuter, GraphQlExecuter> ();
            services.AddTransient<GraphQlParameter> ();
            services.AddTransient<GraphQlQuery> ();
            services.AddTransient<PersonType> ();
            services.AddMvc ();

            var sp = services.BuildServiceProvider ();
            services.AddScoped<ISchema> (_ => new GraphQlSchema (type => (GraphType) sp.GetService (type)) { Query = sp.GetService<GraphQlQuery> () });
        }
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            
            app.UseCors("CorsPolicy");
            app.UseMvc ();
        }
    }
}