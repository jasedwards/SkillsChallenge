using InterviewTest.Extensions;
using InterviewTest.Midllewares;
using InterviewTest.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<PersonContext>(opt => opt.UseInMemoryDatabase("People"), ServiceLifetime.Transient);
builder.Services.AddDbContext<PlaceContext>(opt => opt.UseInMemoryDatabase("Places"), ServiceLifetime.Transient);
builder.Services.AddDbContext<ThingContext>(opt => opt.UseInMemoryDatabase("Things"), ServiceLifetime.Transient);

builder.Services.RegisterRepositories();
builder.Services.ConfigureValidationAttributes();
builder.Services.RegisteredServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.UseExceptionMiddleware();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
