﻿using System;
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
