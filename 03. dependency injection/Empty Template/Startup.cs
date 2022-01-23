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
        // here where you configure the dependency injection services
        public void ConfigureServices(IServiceCollection services)
        {
            // there are three kinds of instances can be created using the depenency injection

            /*
             Transient objects are always different; a new instance is provided to every controller and every service.

            Scoped objects are the same within a request, but different across different requests.

            Singleton objects are the same for every object and every request.
             */
            services.AddTransient<MyClass>();

            // if you want to send parameters to its constructor
            services.AddTransient(x => new MyClass()
            {
                MyProperty = "aaaaaaaaaa"
            });

        }

        // here we depend on MyClass, so we need to inject it using the dependency injection
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MyClass myClass)
        {
            var test = myClass.MyProperty;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!" + test);
            });
        }
    }
}
