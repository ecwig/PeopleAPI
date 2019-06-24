using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PeopleApi.Models;

namespace PeopleApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            // Create a new scope to retrieve scoped services
            /*using (var scope = host.Services.CreateScope())
            {
                // Get the dbInitializer
                var dbInitializer = scope.ServiceProvider.GetRequiredService<DataInitializer>();

                //Seed data 
                dbInitializer.InitializeDatabase();
            }*/

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
