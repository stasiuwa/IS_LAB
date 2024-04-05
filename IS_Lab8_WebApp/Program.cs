using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApplication1;
using WebApplication1.Services;

static IHostBuilder CreateHostBuilder(string[] args)
    =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {

                webBuilder.UseStartup<Startup>().UseUrls("http://localhost:8080");
            });


var builder = CreateHostBuilder(args);

var app = builder.Build();

app.Run();