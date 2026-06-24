using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace test_core_docker_webapi
{
    public class Startup
    {
        // Steps to run this app using Docker:
        // 1. Make sure Docker Desktop is running
        // 2. Open terminal in the solution root folder that contains the dockerfile
        // 3. Build the image:
        //    docker build -t test_core_docker_webapi -f test_core_docker_webapi/Dockerfile .
        // 4. Run the container:
        //    docker run -d -p 8080:5000 --name myapp test_core_docker_webapi
        // 5. Access the API at: http://localhost:8080/api/values
        // 6. Stop the container:  docker stop myapp
        // 7. Remove the container: docker rm myapp
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = Configuration.GetConnectionString("TAMS");
            services.AddDbContext<MyDatabaseContext>
                (options => options.UseSqlServer(connectionString));
            services.AddScoped<DbContext, MyDatabaseContext>();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
