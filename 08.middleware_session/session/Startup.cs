using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace session
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

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello World!1\n");
            //    await next.Invoke();
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello World!696666666\n");
            //    await next.Invoke();
            //});
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello World!1\n");
                await next();
            });

           
            //app.Map("/test", (appBuilder) =>
            //{
            //    appBuilder.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("Hello World!111\n");
            //        await next.Invoke();
            //    });
            //    appBuilder.Run(async (context) =>
            //    {

            //        await context.Response.WriteAsync("from map");
            //    });
            //});
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!2");
            });

        }
    }
}
