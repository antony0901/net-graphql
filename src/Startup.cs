using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate.AspNetCore;
using HotChocolate;
using src.Schema.Types;
using src.Services;
using HotChocolate.AspNetCore.Playground;
using src.Db;
using Microsoft.EntityFrameworkCore;

namespace src
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddPooledDbContextFactory<AppDbContext>(option => 
                option.UseMySql(connectionString: connectionString, serverVersion: ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<RestaurantServices>();

            services.AddGraphQL(sp => SchemaBuilder.New()
                .AddQueryType<RestaurantQueries>()
                .AddServices(sp)
                .Create());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseGraphQL("/graphql");

            app.UsePlayground(new PlaygroundOptions
            {
                Path = "/graphql",
                QueryPath = "/graphql"
            });
        }
    }
}
