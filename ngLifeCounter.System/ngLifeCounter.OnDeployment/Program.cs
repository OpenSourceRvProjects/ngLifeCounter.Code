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

try
{
	var configuration = new ConfigurationBuilder()
		.SetBasePath(Directory.GetCurrentDirectory())
		.AddJsonFile("appsettings.deployment.json", optional: false, reloadOnChange: true)
		.AddEnvironmentVariables()
		.AddCommandLine(args)
		.Build();

	// ⚙️ Set up the web host manually with this config

	// Replace the auto config with our manual one
	builder.Configuration.AddConfiguration(configuration);
}
catch(Exception ex)
{
	Console.WriteLine("------> ****CANNOT SET MAINTENANCE PAGE, CHECK IF YOUR appsettings.deployment.json exists in the OnDeployment project");
	return;
}


// Register everything (services, DbContext, etc.)
builder.Services.AddDbContext<NgLifeCounterDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));


// Build the app and create a DI scope
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<NgLifeCounterDbContext>();

	try
	{
		dbContext.SystemMaintenances.FirstOrDefault();
	}
	catch (Exception ex) {

		Console.WriteLine("------> **CANNOT SET MAINTENANCE PAGE, CHECK IF YOUR appsettings.deployment.json database is propertly created in the OnDeployment project");
		return;
	}


	if (phase == "pre")
    {
        Console.WriteLine("------> Setting up MAINTENANCE PAGE");
        Console.WriteLine("Count users: " + dbContext.Users.Count());
        // Use dbContext here for setup logic
        dbContext.SystemMaintenances.FirstOrDefault().IsOnMaintenance = true;
        dbContext.SaveChanges();
		AwaitTimeToSetup(10);
		return;
    }
    else if (phase == "post")
	{
		Console.WriteLine("------> Removing maintenance page in ...");
		// Use dbContext here for cleanup logic
		AwaitTimeToSetup(15);

		dbContext.SystemMaintenances.FirstOrDefault().IsOnMaintenance = false;
		dbContext.SaveChanges();
		return;
	}

	// Normal app startup logic
	Console.WriteLine("------> Running application normally...");

    // You can start the web app normally here
    app.Run();
}

static void AwaitTimeToSetup(int secondss)
{
	for (int i = secondss; i > 0; i--)
	{
		Console.WriteLine(i);
		Thread.Sleep(1000);
	}
}