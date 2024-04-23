

using ChatServer;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello, iniciando el server chat");
        CreateWebHostBuilder(args).Build().Run();
    }

    private static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();


}




