using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SqlTest.Site {

    public class Program {

        private static int PORT = 80;

        public static void Main(string[] args) {

            PORT = Convert.ToInt32(Environment.GetEnvironmentVariable("PORT") ?? "80");

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls($"http://*:{PORT}")
                .UseStartup<Startup>();
    }
}
