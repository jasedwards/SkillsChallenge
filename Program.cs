using InterviewTest.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<PersonContext>(opt => opt.UseInMemoryDatabase("People"));
builder.Services.AddDbContext<PlaceContext>(opt => opt.UseInMemoryDatabase("Places"));
builder.Services.AddDbContext<ThingContext>(opt => opt.UseInMemoryDatabase("Things"));

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

app.Use((context, next) =>
{
    if (context.Response.Headers.ContainsKey("X-Powered-By"))
    {
        context.Response.Headers.Remove("X-Powered-By");
    }
    return next(context);
});

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
