using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Empty_Template
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                // if the path starts with /ahmed
                if (context.Request.Path.Value.StartsWith("/ahmed"))
                {
                    await context.Response.WriteAsync("Hello Ahmed! ");
                }
                // to call the next middlewere
                await next();
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello World! One ");
                // to call the next middlewere
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World! Two ");
            });
        }
    }
}
