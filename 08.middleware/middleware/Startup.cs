﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace middleware
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
            
            app.Map("/test", (appBuilder) =>
            {
                appBuilder.Run(async (context) => {

                    await context.Response.WriteAsync("from map");
                });
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello World!\n");
                await next.Invoke();
            });


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!222234");
            });
        }
    }
}
