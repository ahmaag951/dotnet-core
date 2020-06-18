using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
            // to change the enviornment from development to => web site properties => debug => enviornment variable
            // if you want to get them here and control them you need to use asp.net core configuration library, it's called configuration api
            var configuration = new ConfigurationBuilder()
                                    .AddEnvironmentVariables()
                                    .Build();
            // they are treated as key and value
            var test = configuration["MyCustomEnviornmentVar"];
            // if you have a boolean value or any other type and you want to convert it on the fly
            bool b = configuration.GetValue<bool>("booleanEnviornmentVar");

            // there is another configuration source (json files)
            var configurationJson = new ConfigurationBuilder()
                                    .AddEnvironmentVariables()
                                    .AddJsonFile(env.ContentRootPath + "/config.json")
                                    // this is an optional configuration file, the true is optional
                                    // if the file doesn't exist no problems will happen
                                    // this is useful for you to set configuration files to different enviornments
                                    .AddJsonFile(env.ContentRootPath + "/config.development.json", true)
                                    .Build();
            var testJson = configurationJson["EnviornemtVarFromJson"];
            var testJsonFromObj = configurationJson["complexObj:normalVar"];
            if (env.IsDevelopment())
            {
                // this is for showing the error page
                app.UseDeveloperExceptionPage();

                // this is if you want a custom error page
                app.UseExceptionHandler("/error.html");
            }

            // this is to view the static files that you want to expose to the world, like html, images, js, css
            app.UseFileServer();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("invalid"))
                {
                    throw new Exception();
                }
                await next();
            });

            app.Run(async (context) =>
            {

                await context.Response.WriteAsync("Hello World!" + test);
            });
        }
    }
}
