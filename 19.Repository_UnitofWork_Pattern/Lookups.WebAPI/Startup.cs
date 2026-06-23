using Lookups.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Lookups.WebAPI
{
    /// <inheritdoc />
    public class Startup
    {
        /// <inheritdoc />
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <inheritdoc />
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Configure services
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ServicesRegisterConfiguration(Configuration);
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }
        /// <summary>
        /// Configure the HTTP request pipeline
        /// </summary>
        /// <param name="app">Define a class that provides the mechanisms to configure an application's request pipline</param>
        /// <param name="env">Provides information about the web hosting environment an application is running in</param>
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
