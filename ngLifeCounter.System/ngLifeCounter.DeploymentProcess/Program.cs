// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using ngLifeCounter.Data.DataAccess;

var argsList = Environment.GetCommandLineArgs();
var phaseArg = argsList.FirstOrDefault(arg => arg.StartsWith("--phase="));
var phase = phaseArg?.Split('=')[1];



try
{
    var builder = WebApplication.CreateBuilder(args);
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.deployment.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables()
        .AddCommandLine(args)
        .Build();

    builder.Configuration.AddConfiguration(configuration);

    // Register everything (services, DbContext, etc.)
    builder.Services.AddDbContext<NgLifeCounterDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

    var serviceProvider = builder.Services.BuildServiceProvider();

    if (phase == "pre")
    {
        Console.WriteLine("Trying to disconnect users...");
        Console.WriteLine("Establishing database connection...");
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<NgLifeCounterDbContext>();
            var setting = dbContext.SystemMaintenances.Count();
            Console.WriteLine("SUCCESSFULLY CONNECTED TO DB SERVER...");


            // Perform your deployment logic here using dbContext
        }

        Console.WriteLine("Setting up maintenance page...");

        SetTimerSeconds(10);
    }


    if (phase == "pre")
    {

        Console.WriteLine("Removing maintenance page...");
        SetTimerSeconds(10);
    }

}
catch (Exception ex)
{
    Console.WriteLine("Cannot set maintenance page now...");
    return;
}



static void SetTimerSeconds(int seconds)
{
    for (int i = seconds; i > 0; i--)
    {
        Console.WriteLine(i);
        Thread.Sleep(1000);
    }
}