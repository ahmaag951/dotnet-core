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
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Map("/abc", HandleMapTest);

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

        private static void HandleMapTest(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test Successful");
            });
        }
    }
}
