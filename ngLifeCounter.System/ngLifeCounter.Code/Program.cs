using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Backend.Services;
using ngLifeCounter.Data.DataAccess;
using ngLifeCounter.MVC;
using ngLifeCounter.Security.Core;
using ngLifeCounter.Security.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

builder.Services.InjectServices();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "ngLifeCounter API", Version = "v1" });
});

builder.Services.AddDbContext<NgLifeCounterDbContext>(options => options.
	   UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
