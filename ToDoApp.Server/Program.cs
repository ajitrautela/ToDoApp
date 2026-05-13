using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Server.Data;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddLogging();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ToDoDbContext>(options => options.UseInMemoryDatabase("ToDoAppDb"));

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

var logger = app.Services.GetService<ILogger<Program>>();
// Global exception handling middleware
app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            logger?.LogError(contextFeature.Error.ToString());
            await context.Response.WriteAsJsonAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error."
            });
        }
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
