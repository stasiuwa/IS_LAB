
using WebApplication1;


static IHostBuilder CreateHostBuilder(string[] args)
    =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {

                webBuilder.UseStartup<Startup>().UseUrls("http://localhost:8080");
            });

CreateHostBuilder(args).Build().Run();