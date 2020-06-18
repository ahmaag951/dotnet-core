﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Lookups.WebAPI
{
    /// <inheritdoc />
    public static class Program
    {
        /// <inheritdoc />
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        /// <inheritdoc />
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
