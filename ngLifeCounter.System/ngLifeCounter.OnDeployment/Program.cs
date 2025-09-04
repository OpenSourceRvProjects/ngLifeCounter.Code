using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ngLifeCounter.Data.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var argsList = Environment.GetCommandLineArgs();

var phaseArg = argsList.FirstOrDefault(arg => arg.StartsWith("--phase="));
var phase = phaseArg?.Split('=')[1];

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.deployment.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .Build();

// ⚙️ Set up the web host manually with this config

// Replace the auto config with our manual one
builder.Configuration.AddConfiguration(configuration);

// Register everything (services, DbContext, etc.)
builder.Services.AddDbContext<NgLifeCounterDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

// Build the app and create a DI scope
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<NgLifeCounterDbContext>();

    if (phase == "pre")
    {
        Console.WriteLine("------> Setting up MAINTENANCE PAGE");
        Console.WriteLine("Count users: " + dbContext.Users.Count());
        // Use dbContext here for setup logic
        return;
    }
    else if (phase == "post")
    {
        Console.WriteLine("------> Removing maintenance page in ...");
        // Use dbContext here for cleanup logic
        for (int i = 10; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
        return;
    }

    // Normal app startup logic
    Console.WriteLine("------> Running application normally...");

    // You can start the web app normally here
    app.Run();
}
